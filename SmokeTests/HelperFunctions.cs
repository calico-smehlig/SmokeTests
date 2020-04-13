using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

namespace SmokeTests
{
    class Helper
    {
        static DirectoryInfo testDir;

        static string txtFileName;
        static string htmlFileName;

        static string testSuiteId;
        static string testSuiteName;
        static DateTime testSuiteStart;

        // store additional information to the test step
        static string testSuiteSummaryTXT;
        static string testSuiteSummaryHTML;
        static string testSuiteDetailsTXT;
        static string testSuiteDetailsHTML;
        static string testCaseDetailsTXT;
        static string testCaseDetailsHTML;
        static string testStepDetailsTXT;
        static string testStepDetailsHTML;
        static int testCasePass;
        static int testCaseFail;

        static public void InitReport()
        {
            // where do we store the test report ?
            // evaluate WORKSPACE (Jenkins' base directory) 
            string testDirString = Environment.GetEnvironmentVariable("WORKSPACE");
            if (testDirString != null)
            {
                testDir = new DirectoryInfo(testDirString);
            }
            else
            {
                 testDir = Directory.CreateDirectory(Path.Combine(@"c:\temp", DateTime.Now.ToString("yyyyMMddHHmmss")));
            }
            txtFileName  = Path.Combine(testDir.FullName, "00_testlog.txt");
            htmlFileName = Path.Combine(testDir.FullName, "00_testlog.html");

            testSuiteId = "";
            testSuiteName = "";
            testSuiteStart = DateTime.Now;

            testSuiteSummaryTXT = "";
            testSuiteSummaryHTML = "";
            testSuiteDetailsTXT = "";
            testSuiteDetailsHTML = "";
            testCaseDetailsTXT = "";
            testCaseDetailsHTML = "";
            testStepDetailsTXT  = "";
            testStepDetailsHTML = "";
            
            testCasePass = 0;
            testCaseFail = 0;

        }
        static public void InitReport(string testID, string testName)
        {
            InitReport();

            testSuiteId = testID;
            testSuiteName = testName;

          }
        static public void CloseReport()
        {
            int testCaseTotal = testCasePass + testCaseFail;
            double percentPass = (double)testCasePass / testCaseTotal;
            double percentFail = (double)testCaseFail / testCaseTotal;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.PercentDecimalDigits = 0;

            using (StreamWriter file = new StreamWriter(txtFileName, true))
            {
                file.WriteLine("" + testSuiteId + ": " + testSuiteName);
                file.WriteLine("");
                file.WriteLine("Test Started: " + testSuiteStart.ToString("yyyy-MM-dd HH:mm:ss") + " ");
                file.WriteLine("Test Ended  : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ");
                file.WriteLine("Tests Ran   : " + testCaseTotal + " ");
                file.WriteLine("Tests Passed: " + testCasePass + " (" + percentPass.ToString("P",nfi) + ")");
                file.WriteLine("Tests Failed: " + testCaseFail + " (" + percentFail.ToString("P",nfi) + ")");
                file.WriteLine("=================================================");

                file.WriteLine("Test Cases:");
                file.Write(testSuiteSummaryTXT);
                file.WriteLine("-------------------------------------------------");
                file.WriteLine("Details:");
                file.WriteLine(testSuiteDetailsTXT);

            }
            using (StreamWriter file = new StreamWriter(htmlFileName, true))
            {
                file.WriteLine("<HTML>");
                file.WriteLine(" <BODY>");
                file.WriteLine("  <H1>" + testSuiteId + ": " + testSuiteName + "</H1>");
                file.WriteLine("   <B>Test Started:</B> " + testSuiteStart.ToString("yyyy-MM-dd HH:mm:ss") + "<BR>");
                file.WriteLine("   <B>Test Ended:</B> " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "<BR>");
                file.WriteLine("   <B>Tests Ran:</B> " + testCaseTotal + "<BR>");
                file.WriteLine("   <B>Tests Passed:</B> " + testCasePass + "  (" + percentPass.ToString("P", nfi) + ")<BR>");
                file.WriteLine("   <B>Tests Failed:</B> " + testCaseFail + "  (" + percentFail.ToString("P", nfi) + ")<BR>");
                file.WriteLine("   <HR>");

                file.WriteLine("<B>Test Cases:</B><BR>");
                file.WriteLine(testSuiteSummaryHTML);
                file.WriteLine(testSuiteDetailsHTML);

                file.WriteLine(" </BODY>");
                file.WriteLine("</HTML>");
            }
        }

        static public void TakeScreenshot(IWebDriver browser, string testcase, int teststep, int index = -1)
        {
            string fileName;
            string imageName;            
 
            // only use the index for the filename, if it's positive
            // this enables multiple screenshots for a single test step.
            if (index > 0)
                imageName = "screenshot_" + testcase + "_" + teststep + "_" + index + ".jpg";
            else
                imageName = "screenshot_" + testcase + "_" + teststep + ".jpg";


            fileName = Path.Combine(testDir.FullName , imageName);
            ((ITakesScreenshot)browser).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);

            // for the HTML repost include an IMG link into the report
            testStepDetailsHTML += "<A HREF=\"" + imageName + "\"><IMG SRC=\"" + imageName + "\" WIDTH=\"50%\"></A>";
            testStepDetailsHTML += "<BR>";
        }

        static public void TestStepResult(int tsID, string tsName, bool result)
        {
            testCaseDetailsTXT += String.Format("    Step {0,2}: {1,-60} - ", tsID, tsName);
            if (result) testCaseDetailsTXT += "Pass";
            else testCaseDetailsTXT += "FAIL";
            testCaseDetailsTXT += "\n";


            testCaseDetailsHTML += "    <b>Step " + tsID + ":</b> " + tsName + " - ";
            if (result) testCaseDetailsHTML += "<font color=\"green\">Pass</font>";
            else testCaseDetailsHTML += "<font color =\"red\">FAIL</font>";
            testCaseDetailsHTML += "<BR>";

            if (testStepDetailsHTML.Length >0)
            {
                testCaseDetailsHTML += testStepDetailsHTML;
                testCaseDetailsHTML += "<BR>";
            }
            testStepDetailsHTML = "";

        }
        static public bool TestStepCompare(int tsID, string tsName, string expected, string actual)
        {
            bool result = expected == actual;

            testCaseDetailsTXT += String.Format("    Step {0,2}: {1,-60} - ", tsID, tsName);
            if (expected == actual)
            {
                testCaseDetailsTXT += "Pass";
                testCaseDetailsTXT += "\n";
                testCaseDetailsTXT += "             (checked for string '" + expected + "')";
            }
            else
            {
                testCaseDetailsTXT += "FAIL";
                testCaseDetailsTXT += "\n";
                testCaseDetailsTXT += "             expected: '" + expected + "' - is: '" + actual + "'";
            }
            testCaseDetailsTXT += "\n";



            testCaseDetailsHTML += "    <b>Step " + tsID + ":</b> " + tsName + " - ";
            if (result)
            {
                testCaseDetailsHTML += "<font color=\"green\">Pass</font>";
                testCaseDetailsHTML += "<BR>";
                testCaseDetailsHTML += "<I>(checked for string '" + expected + "')</I>";
                testCaseDetailsHTML += "<BR>";
            }
            else
            {
                testCaseDetailsHTML += "<font color =\"red\">FAIL</font>";
                testCaseDetailsHTML += "<BR>";
                testCaseDetailsHTML += "<I> expected: '" + expected + "' - is: '" + actual + "'</I>";
                testCaseDetailsHTML += "<BR>";
            }
            if (testStepDetailsHTML.Length > 0)
            {
                testCaseDetailsHTML += testStepDetailsHTML;
                testCaseDetailsHTML += "<BR>";
            }
            testStepDetailsHTML = "";

            return result;
        }
        static public bool TestStepContains(int tsID, string tsName, string expected, string actual)
        {
            bool result = actual.Contains(expected);

            testCaseDetailsTXT += String.Format("    Step {0,2}: {1,-60} - ", tsID, tsName);
            if (expected == actual)
            {
                testCaseDetailsTXT += "Pass";
                testCaseDetailsTXT += "\n"; 
                testCaseDetailsTXT += "             (checked for substring '" + expected + "')";
            }
            else
            {
                testCaseDetailsTXT += "FAIL";
                testCaseDetailsTXT += "\n"; 
                testCaseDetailsTXT += "             expected: '" + expected + "' is not part of '" + actual + "'";
            }
            testCaseDetailsTXT += "\n";
            if (testStepDetailsTXT.Length > 0)
            {
                testCaseDetailsTXT += testStepDetailsTXT;
                testCaseDetailsTXT += "\n";
            }
            testStepDetailsTXT = "";


            testCaseDetailsHTML += "    <b>Step " + tsID + ":</b> " + tsName + " - ";
            if (result)
            {
                testCaseDetailsHTML += "<font color=\"green\">Pass</font>";
                testCaseDetailsHTML += "<BR>";
                testCaseDetailsHTML += "<I>(checked for substring '" + expected + "')</I>";
                testCaseDetailsHTML += "<BR>";
            }
            else
            {
                testCaseDetailsHTML += "<font color =\"red\">FAIL</font>";
                testCaseDetailsHTML += "<BR>";
                testCaseDetailsHTML += "<I> expected: '" + expected + "' - is part of '" + actual + "'</I>";
                testCaseDetailsHTML += "<BR>";
            }
            if (testStepDetailsHTML.Length > 0)
            {
                testCaseDetailsHTML += testStepDetailsHTML;
                testCaseDetailsHTML += "<BR>";
            }
            testStepDetailsHTML = "";

            return result;
        }
        static public void TestStepComment(string tsComment)
        {
            testStepDetailsTXT += tsComment + "\n";
            testCaseDetailsHTML += tsComment;
            testCaseDetailsHTML += "<BR>\n";
        }
        static public void TestCaseResult(string tcID, string tcName, bool result)
        {
            testSuiteSummaryTXT += String.Format("{0}: {1,-35} - ", tcID, tcName);
            if (result) testSuiteSummaryTXT += "Pass";
            else testSuiteSummaryTXT += "FAIL";
            testSuiteSummaryTXT += "\n";

            testSuiteDetailsTXT += "" + tcID + ": " + tcName + " - ";
            if (result) testSuiteDetailsTXT += "Pass";
            else testSuiteDetailsTXT += "FAIL";
            testSuiteDetailsTXT += "\n";
            if (testCaseDetailsTXT.Length > 0) testSuiteDetailsTXT += testCaseDetailsTXT;
            testCaseDetailsTXT = "";


            testSuiteSummaryHTML += "<B>" + tcID + ":</B> " + tcName + " - ";
            if (result) testSuiteSummaryHTML += "<font color=\"green\">Pass</font>";
            else testSuiteSummaryHTML += "<B><font color =\"red\">FAIL</font></B>";
            testSuiteSummaryHTML += "<BR>";

            testSuiteDetailsHTML += "<HR>";
            testSuiteDetailsHTML += " <H2>" + tcID + ": " + tcName + " - ";
            if (result) testSuiteDetailsHTML += "<font color=\"green\">Pass</font>";
            else testSuiteDetailsHTML += "<font color =\"red\">FAIL</font>";
            testSuiteDetailsHTML += "</H2>";
            testSuiteDetailsHTML += "<BR>";
            if (testCaseDetailsHTML.Length > 0) testSuiteDetailsHTML += testCaseDetailsHTML;
            testCaseDetailsHTML = "";

            if (result) testCasePass++;
            else testCaseFail++;

        }

    }
}
