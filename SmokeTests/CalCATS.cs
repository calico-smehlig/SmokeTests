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
        private string appUser;
        private string appPass;

        static string suiteId = "7";
        static string suiteTitle = "CalCATS Smoke Tests";

        // the following variables are expected to
        // be set by the test case
        private string testId;
        private string testTitle;

        [TestCategory("CalCATS")]
        [TestMethod]
        public void TestLoginPage()
        {
            testId = "7.1.1";
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
                    Helper.Wait(5);
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
                    // copied XPath: //*[@id="calico-ajax-login-modal"]/div/div/div[1]/h4
                    //IReadOnlyCollection<IWebElement> listOfElements1 = browser.FindElements(By.XPath("//h4"));
                    //IReadOnlyCollection<IWebElement> listOfElements2 = browser.FindElements(By.XPath("//*[@id='calico-ajax-login-modal']/div/div/div[1]/button"));
                    IReadOnlyCollection<IWebElement> listOfElements3 = browser.FindElements(By.ClassName("modal-title"));
                    //IReadOnlyCollection<IWebElement> listOfElements4 = browser.FindElements(By.LinkText("x"));

                    webElement = browser.FindElement(By.XPath("//*[@id='calico-ajax-login-modal']/div/div/div[1]/h4"));
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
                    Helper.Wait(5);
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
        [TestCategory("CalCATS")]
        [TestMethod]
        public void TestDashboard()
        {
            testId = "7.1.2";
            testTitle = "CalCATS Dashboard";

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
                    Helper.Wait(5);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: enter User Credentials
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Enter User Credentials (" + appUser + ")";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("calico-ajax-userid"));
                    webElement.SendKeys(appUser);
                    webElement = browser.FindElement(By.Id("calico-ajax-password"));
                    webElement.SendKeys(appPass);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

 
                // STEP: click Login button 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click 'Sign In' Button";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("calico-ajax-login-button"));
                    webElement.Click();
                    Helper.Wait(5);
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    // verify
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS - Dashboard", browser.Title);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: click away 'What's New' if exists
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Check for 'Whats New'";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("calico-message-modal-title"));
                    if (webElement == null)
                    {
                        // What's New does not exist - do nothing
                        stepName = "Check for 'Whats New' - non-existing.";
                    }
                    else
                    {
                        // What's New exists - click it away
                        stepName = "Check for 'Whats New' - existing, clicking away.";
                        webElement = browser.FindElement(By.Id("calico-error-confirmation-button"));
                        webElement.Click();
                    }

                    // verify
                    Helper.TestStepResult(stepNumber, stepName, stepResult);

                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }

                }


                // STEP: verify User Name 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify User Name";
                    stepResult = true;
                    //   verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    webElement = browser.FindElement(By.Id("userDropdown"));
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "CaliCo County Admin", webElement.Text);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }


                //*[@id="navbarsExample04"]/ul[2]/li[2]/a
                // .XPath("//a[@value='Log Out']")
                // STEP: Logout 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Logout";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("userDropdown"));
                    webElement.Click();
                    webElement = browser.FindElement(By.XPath("//a[@href='javascript:LogOut()']"));
                    webElement.Click();
                    Helper.Wait(5);
                    // verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS Home Page", browser.Title);
                    //   report
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

        [TestCategory("CalCATS")]
        [TestMethod]
        public void TestNewActivity()
        {
            testId = "7.1.3";
            testTitle = "CalCATS New Activity";

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
                    //   report
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS Home Page", browser.Title);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = true;
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
                    Helper.Wait(5);

                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: enter User Credentials
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Enter User Credentials (" + appUser + ")";
                    stepResult = true;
                    //   verify
                    webElement = browser.FindElement(By.Id("calico-ajax-userid"));
                    webElement.SendKeys(appUser);
                    webElement = browser.FindElement(By.Id("calico-ajax-password"));
                    webElement.SendKeys(appPass);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }


                // STEP: click Sign In button 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click 'Sign In' Button";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("calico-ajax-login-button"));
                    webElement.Click();
                    Helper.Wait(5);
                    // verify
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS - Dashboard", browser.Title);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: click away 'What's New' if exists
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Check for 'Whats New'";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("calico-message-modal-title"));
                    if (webElement == null)
                    {
                        // What's New does not exist - do nothing
                        stepName = "Check for 'Whats New' - non-existing.";
                    }
                    else
                    {
                        // What's New exists - click it away
                        stepName = "Check for 'Whats New' - existing, clicking away.";
                        webElement = browser.FindElement(By.Id("calico-error-confirmation-button"));
                        webElement.Click();
                    }

                    // verify
                    Helper.TestStepResult(stepNumber, stepName, stepResult);

                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }

                }

                // STEP: verify User Name 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Verify Dashboard";
                    stepResult = true;
                    //   verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    webElement = browser.FindElement(By.Id("userDropdown"));
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "County Admin", webElement.Text);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // STEP: click on 'New Activity' button 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Click New Activity";
                    stepResult = true;
                    // action
                    // /html/body/div[1]/div[8]/div[2]/button
                    webElement = browser.FindElement(By.XPath("/html/body/div[1]/div[8]/div[2]/button"));
                    webElement.Click();
                    Helper.Wait(5);
                    //   verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    // /html/body/div[1]/div[10]/div/div/div[1]/h4
                    webElement = browser.FindElement(By.XPath("/html/body/div[1]/div[10]/div/div/div[1]/h4"));
                    stepResult = Helper.TestStepCompare(stepNumber, stepName, "New Activity", webElement.Text);
                    //   report
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }


                // STEP: dismiss 'New Activity' modal 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Dismiss New Activity Modal";
                    stepResult = true;
                    // action
                    // /html/body/div[1]/div[10]/div/div/div[1]/button
                    webElement = browser.FindElement(By.XPath("/html/body/div[1]/div[10]/div/div/div[1]/button"));
                    webElement.Click();
                    Helper.Wait(5);
                    //   verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    //   report
                    Helper.TestStepResult(stepNumber, stepName, stepResult);
                    if (!stepResult)
                    {
                        testResult = false;
                        testAbort = false;
                    }
                }

                // .XPath("//a[@value='Log Out']")
                // STEP: Logout 
                // ---------------------------------------
                if (!testAbort)
                {
                    //   prep
                    stepNumber++;
                    stepName = "Logout";
                    stepResult = true;
                    //   action
                    webElement = browser.FindElement(By.Id("userDropdown"));
                    webElement.Click();
                    webElement = browser.FindElement(By.XPath("//a[@href='javascript:LogOut()']"));
                    webElement.Click();
                    Helper.Wait(5);
                    // verify
                    Helper.TakeScreenshot(browser, testId, stepNumber);
                    stepResult = Helper.TestStepContains(stepNumber, stepName, "CalCATS Home Page", browser.Title);
                    //   report
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
            appURL = "http://calcats.org";
            appUser = "admin@calicosol.com";
            appPass = "m@cPhase01";



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
