using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class CASPIRTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "7";
        static string suiteTitle = "CASPIR Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("CASPIR")]
        [TestMethod]
        public void TestMainPage61()
        {
            testId = "7.1.1";
            testTitle = "CASPIR Main Page";

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
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CASPIR", browser.Title);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: check H1 text
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify H1 tag shows correct title";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("//h1"));
                    //   report
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "About CASPIR", webElement.Text);
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
                    webElement = browser.FindElement(By.XPath("//button[text()='Login']"));
                    stepResult = webElement.Displayed;
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
                    stepName = "Click the Login button";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("//button[text()='Login']"));
                    webElement.Click();
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CASPIR Portal", browser.Title);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
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
                    webElement = browser.FindElement(By.Id("Username"));
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
                    webElement = browser.FindElement(By.XPath("//button[@value='Log in']"));
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
            appURL = "http://caspirapp.org";
            // calico39
            // Denver5280!
            // 
            // 
            
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
