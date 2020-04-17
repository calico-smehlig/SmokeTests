using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SmokeTests
{
    [TestClass]
    public class BeeWhereTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "5";
        static string suiteTitle = "BeeWhere Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("BeeWhere")]
        [TestMethod]
        public void TestMainPage51()
        {
            testId = "5.1.1";
            testTitle = "BeeWhere Main Page";

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
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "BeeWhere California", browser.Title);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: check if Access Beekeeper Mgmt button is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify link 'Beekeeper' is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.PartialLinkText("BEEKEEPER MANAGEMENT"));
                    Helper.TestStepComment("Link '" + webElement.Text + "' goes to '" + webElement.GetAttribute("href") + "'.");
                    //   report
                    stepResult = webElement.Displayed;
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check if Access PCA BeeCheck button is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify link 'PCA BeeCheck' is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.PartialLinkText("PCA BEE CHECK"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepComment("Link '" + webElement.Text + "' goes to '" + webElement.GetAttribute("href") + "'.");
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check if Access Grower BeeCheck button is present
                //       Access Grower BeeCheck -> /GrowerApplicator
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify link 'Grower BeeCheck' is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.PartialLinkText("GROWER BEECHECK")); // (By.XPath("//a[@href='/GrowerApplicator']"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepComment("Link '" + webElement.Text + "' goes to '" + webElement.GetAttribute("href") + "'.");
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
                    webElement = browser.FindElement(By.XPath("//p[contains(text(),'CalAgPermits BeeWhere Version')]"));
                    //   report
                    Helper.TestStepComment("Label: '" + webElement.Text + "'.");
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalAgPermits", webElement.Text);
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
            appURL = "http://beewhere.calagpermits.org";
            // calico39
            // Denver5280!
            // calico39 (County User)
            // San Joaquin
            
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
