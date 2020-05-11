using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;

namespace SmokeTests
{
    [TestClass]
    public class CalCATSTests
    {
        private IWebDriver browser;
        private string appURL;

        static string suiteId = "6";
        static string suiteTitle = "CalCATS Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("CalCATS")]
        [TestMethod]
        public void TestLoginPage()
        {
            testId = "6.1.1";
            testTitle = "CalCATS Login Page";

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
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS Home Page", browser.Title);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
                    }
                }

                // STEP: check if the Welcome Message is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Welcome Message is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.XPath("//h2"));
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "Welcome to CalCATS", webElement.Text);

                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check if login button is present
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Login button is present";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("loginButton"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: Click Login button 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click Login button";
                    stepResult = true;
                    // action
                    webElement = browser.FindElement(By.Id("loginButton"));
                    webElement.Click();
                    browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check Login dialog displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Login dialog displays";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.ClassName("modal-title"));
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "Please Log In", webElement.Text);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check UserID textfield displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify UserID textfield displays";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("calico-ajax-userid"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check Password textfield displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Password textfield displays";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("calico-ajax-password"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: check Login button displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Login button displays";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("calico-ajax-login-button"));
                    stepResult = webElement.Displayed;
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }


                // //*[@id="calico-ajax-login-modal"]/div/div/div[1]/button
                // STEP: check Login button displays
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Close Login dialog";
                    stepResult = true;
                    //   verify
                    //IReadOnlyCollection<IWebElement> listOfElements1 = browser.FindElements(By.XPath("//h4"));
                    //IReadOnlyCollection<IWebElement> listOfElements2 = browser.FindElements(By.XPath("//*[@id='calico-ajax-login-modal']/div/div/div[1]/button"));
                    //IReadOnlyCollection<IWebElement> listOfElements3 = browser.FindElements(By.ClassName("close"));
                    //IReadOnlyCollection<IWebElement> listOfElements4 = browser.FindElements(By.LinkText("x"));
                    // //*[@id="calico-ajax-login-modal"]/div/div/div[1]/button
                    webElement = browser.FindElement(By.XPath("//*[@id='calico-ajax-login-modal']/div/div/div[1]/button"));
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
            appURL = "http://calcatsdev.calicosol.com";
            
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
