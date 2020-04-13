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

        static string suiteId = "1.1";
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
            appURL = "http://www.calpeats999.org";

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
