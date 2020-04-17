using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class SMCDailyTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "3";
        static string suiteTitle = "SMC Daily Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("SMCDaily")]
        [TestMethod]
        public void TestLoginPage31()
        {
            testId = "3.1.1";
            testTitle = "SMCDaily Login Page";

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
                    stepName = "Naviage to " + appURL + " and verify title";
                    stepResult = true;
                    //   action
                    browser.Navigate().GoToUrl(appURL);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "SMC Daily", browser.Title);
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
                    webElement = browser.FindElement(By.Id("Login1_UserName"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
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
                    webElement = browser.FindElement(By.Id("Login1_Password"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
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
                    // recorded XPath: //*[@id="Login1_LoginButton"]
                    webElement = browser.FindElement(By.Id("Login1_LoginButton"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check that version number displays and has expected value
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Login version string";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("VersionLabel"));
                    //   report
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "7.0-smc", webElement.Text);
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
            appURL = "http://smcdaily.org";
            
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
