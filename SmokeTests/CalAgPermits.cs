using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class CalAgPermitsTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "1.2";
        static string suiteTitle = "CalAgPermits Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("CalAgPermits")]
        [TestMethod]
        public void TestLoginPage()
        {
            testId = "1.2.1";
            testTitle = "CalAgPermits Login Page";

            int stepNumber = 0;
            string stepName = "";
            bool stepResult = true;

            bool testResult = true;


            // STEP: open browser and navigate to login page
            //   prep
            stepNumber++; 
            stepName = "Naviage to " + appURL;
            stepResult = true;
            //   action
            browser.Navigate().GoToUrl(appURL);
            Helper.TakeScreenshot(browser, testId, stepNumber);
            stepResult = browser.Title == "CalAgPermits";
            //   report
            Helper.TestStepResult(stepNumber, stepName, stepResult);
            if (!stepResult) testResult = false;


            // STEP: check if the user textbox is present
            // ---------------------------------------
            //   prep
            stepNumber++;
            stepName = "Verify Username textbox is present";
            stepResult = true;
            //   verify
            IWebElement element = browser.FindElement(By.Id("UserName"));
            stepResult = element.Displayed;
            //   report
            Helper.TestStepResult(stepNumber, stepName, stepResult);
            if (!stepResult) testResult = false;

            // STEP: check if the password textbox is present
            // ---------------------------------------
            //   prep
            stepNumber++;
            stepName = "Verify Password textbox is present";
            stepResult = true;
            //   verify
            element = browser.FindElement(By.Id("Password"));
            stepResult = element.Displayed;
            //   report
            Helper.TestStepResult(stepNumber, stepName, stepResult);
            if (!stepResult) testResult = false;

            // STEP: check if the Login button is present
            // ---------------------------------------
            //   prep
            stepNumber++;
            stepName = "Verify Login button is present";
            stepResult = true;
            //   verify
            element = browser.FindElement(By.XPath("//input[@value='Log in']"));
            stepResult = element.Displayed;
            //   report
            Helper.TestStepResult(stepNumber, stepName, stepResult);
            if (!stepResult) testResult = false;


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
            appURL = "http://www.calagpermits.org";

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
