using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class GopherTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "4";
        static string suiteTitle = "Gopher Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("Gopher")]
        [TestMethod]
        public void TestLoginPage41()
        {
            testId = "4.1.1";
            testTitle = "Gopher Login Page";

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
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CSI-FESTF", browser.Title);
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
                    webElement = browser.FindElement(By.Id("Password"));
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
                    webElement = browser.FindElement(By.XPath("//button[text() = 'Sign in']"));
                    stepResult = webElement.Displayed;
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
            appURL = "http://gopher.festf.org";
            // CalicoAdmin
            // calico_FESTF_09
            // CalicoAdmin
            
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
