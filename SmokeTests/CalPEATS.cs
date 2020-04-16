using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class CalPEATSTests
    {
        private IWebDriver browser;
        private string appURL;
        private string apiURL;

        static string suiteId = "1";
        static string suiteTitle = "CalPEATS Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("CalPEATS")]
        [TestMethod]
        public void TestLoginPage()
        {
            testId = "1.1.1";
            testTitle = "CalPEATS Login Page";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;
            bool testAbort = false;

            IWebElement webElement;

            try
            {

                // STEP: open browser and navigate to login page
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Naviage to " + appURL;
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(appURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = browser.Title == "CalPeats";
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: check if the user textbox is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Username textbox is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("UserName"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }
                // STEP: check if the password textbox is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Password textbox is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("Password"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }
                // STEP: check if the Login button is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Login button is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("//input[@value='Log in']"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }
            }
            catch (Exception ex)
            {
                stepResult = false;
                testResult = false;
                Helper.TakeScreenshot(browser, testId, stepNumber);
                Helper.TestStepComment(ex.Message);
                Helper.TestStepResult(stepNumber, stepName, stepResult);
            }

            // finish up this test case
            // ------------------------
            Helper.TestCaseResult(testId, testTitle, testResult);
            // fail this test case if testResult has been set to FALSE
            Assert.IsTrue(testResult);
        }

        [TestCategory("CalPEATS")]
        [TestMethod]
        public void TestDashboard()
        {
            testId = "1.1.2";
            testTitle = "CalPEATS Dashboard";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;
            bool testAbort = false;

            IWebElement webElement;

            try
            {

                // STEP: open browser and navigate to login page
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Naviage to " + appURL;
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(appURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   verify
                    stepResult = browser.Title == "CalPeats";
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: enter user credentials
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Enter user credentials";
                    stepResult = true;
                    //   action
                    browser.FindElement(By.Id("UserName")).SendKeys("calicoadmin12");
                    browser.FindElement(By.Id("Password")).SendKeys("CalPEATSRocks!");
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: click the Login button
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click login button - Dashboard appears";
                    stepResult = true;
                    //   verify
                    browser.FindElement(By.XPath("//input[@value='Log in']")).Click();
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check if the CalPEATS logo is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify CalPEATS logo is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
                    //   report
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "CalPEATS", webElement.Text);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: check if the name of the logged in person shows correctly
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify correct User Name displays";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("userDropdownMenu"));
                    //   report
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "Humboldt, CaliCoAdmin (Humboldt)", webElement.Text);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check if the logoff button is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Logout button is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
                    //   report
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "Log off", webElement.Text);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }


                // STEP: click the logoff button and verify login screen displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click Logout button, verify we're back at Login screen";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")); 
                    webElement.Click();
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

            }
            catch (Exception ex)
            {
                stepResult = false;
                testResult = false;
                Helper.TakeScreenshot(browser, testId, stepNumber);
                Helper.TestStepComment(ex.Message);
                Helper.TestStepResult(stepNumber, stepName, stepResult);
            }

            // finish up this test case
            // ------------------------
            Helper.TestCaseResult(testId, testTitle, testResult);
            // fail this test case if testResult has been set to FALSE
            Assert.IsTrue(testResult);
        }


        [TestCategory("CalPEATS")]
        [TestMethod]
        public void TestAccela1()
        {
            testId = "1.2.1";
            testTitle = "CalPEATS Accela API 1";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;
            bool testAbort = false;

            IWebElement webElement;

            try
            {

                // STEP: open browser and navigate to api page
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Naviage to " + apiURL;
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(apiURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = browser.Title == "Test Accela Data Exchange";
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: click the 'Test Me!' button w/o any parameters
                // -----------------------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click the Test Me button";
                    stepResult = true;
                    // action
                    // Click Me/html/body/form[1]/input[1]
                    webElement = browser.FindElement(By.XPath("//input[@value='Test Me!']"));
                    webElement.Click();
                    //   verify

                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }
                // STEP: take data content and check for substring: AccelaInspectionsResponse
                // ---------------------------------------
                string daContent = browser.PageSource;
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify returned data contains: 'AccelaInspectionsResponse'";
                    stepResult = true;
                    //   verify
                    stepResult = daContent.Contains("AccelaInspectionsResponse");
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }
            }
            catch (Exception ex)
            {
                stepResult = false;
                testResult = false;
                Helper.TakeScreenshot(browser, testId, stepNumber);
                Helper.TestStepComment(ex.Message);
                Helper.TestStepResult(stepNumber, stepName, stepResult);
            }

            // finish up this test case
            // ------------------------
            Helper.TestCaseResult(testId, testTitle, testResult);
            // fail this test case if testResult has been set to FALSE
            Assert.IsTrue(testResult);
        }
        [TestCategory("CalPEATS")]
        [TestMethod]
        public void TestAccela2()
        {
            testId = "1.2.2";
            testTitle = "CalPEATS Accela API 2";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;
            bool testAbort = false;

            IWebElement webElement;

            try
            {

                // STEP: open browser and navigate to api page
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Naviage to " + apiURL;
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(apiURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = browser.Title == "Test Accela Data Exchange";
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: click the 'Test Me!' button w/o any parameters
                // -----------------------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click the Test Me button";
                    stepResult = true;
                    // action
                    webElement = browser.FindElement(By.XPath("//input[@value='Me Too!']"));
                    webElement.Click();
                    //   verify

                    //   report
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }
                // STEP: take data content and check for substring: <Inspection
                // ---------------------------------------
                string daContent = browser.PageSource;
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify returned data contains: '<Data>Test OK</Data>'";
                    stepResult = true;
                    //   verify
                    stepResult = daContent.Contains("<Data>Test OK</Data>");
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }
            }
            catch (Exception ex)
            {
                stepResult = false;
                testResult = false;
                Helper.TakeScreenshot(browser, testId, stepNumber);
                Helper.TestStepComment(ex.Message);
                Helper.TestStepResult(stepNumber, stepName, stepResult);
            }

            // finish up this test case
            // ------------------------
            Helper.TestCaseResult(testId, testTitle, testResult);
            // fail this test case if testResult has been set to FALSE
            Assert.IsTrue(testResult);
        }
        [TestCategory("CalPEATS")]
        [TestMethod]
        public void TestAccela3()
        {
            testId = "1.2.3";
            testTitle = "CalPEATS Accela API Date Range";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;
            bool testAbort = false;

            IWebElement webElement;

            try
            {

                // STEP: open browser and navigate to api page
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Naviage to " + apiURL;
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(apiURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = browser.Title == "Test Accela Data Exchange";
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: click the 'Test Me!' button w/o any parameters
                // -----------------------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "click 'Test Me With Parameters!'";
                    stepResult = true;
                    // action
                    webElement = browser.FindElement(By.Name("startDate"));
                    webElement.SendKeys("20171001000000");
                    webElement = browser.FindElement(By.Name("endDate"));
                    webElement.SendKeys("20171031000000");
                    Helper.TakeScreenshot(browser, testId, stepNumber);

                    webElement = browser.FindElement(By.XPath("//input[@value='Test Me With Parameters!']"));
                    webElement.Click();
                    //   verify

                    //   report
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }
                // STEP: take data content and check for substring: <AccelaInspectionResponse
                // ---------------------------------------
                string daContent = browser.PageSource;
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify returned data contains: 'AccelaInspectionsResponse'";
                    stepResult = true;
                    //   verify
                    stepResult = daContent.Contains("AccelaInspectionsResponse");
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: take data content and check for substring: <inspections
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify returned data contains: 'inspections'";
                    stepResult = true;
                    //   verify
                    stepResult = daContent.Contains("inspections");
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }
                // STEP: take data content and check for substring: <pk_inspection_id
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify returned data contains: 'pk_inspection_id'";
                    stepResult = true;
                    //   verify
                    stepResult = daContent.Contains("pk_inspection_id");
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

            }
            catch (Exception ex)
            {
                stepResult = false;
                testResult = false;
                Helper.TakeScreenshot(browser, testId, stepNumber);
                Helper.TestStepComment(ex.Message);
                Helper.TestStepResult(stepNumber, stepName, stepResult);
            }

            // finish up this test case
            // ------------------------
            Helper.TestCaseResult(testId, testTitle, testResult);
            // fail this test case if testResult has been set to FALSE
            Assert.IsTrue(testResult);
        }


        [ClassInitialize()]
        public static void SetupClass(TestContext testContext)
        {
            Helper.InitReport(suiteId,suiteTitle);
         }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            Helper.CloseReport();
        }
        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.calpeats.org";
            apiURL = "https://data.calpeats.org/accelaTest.html";

            browser = new ChromeDriver();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            browser.Quit();
            // browser.Close();
        }

    }
}
