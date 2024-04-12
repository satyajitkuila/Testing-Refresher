using BasicSpecFlowProject.Drivers;
using BasicSpecFlowProject.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AngleSharp.Dom;

namespace BasicSpecFlowProject.StepDefinitions
{
    [Binding]
    public class MmtLoginStepDefinitions : Base
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        [Given(@"User is Navigated to MMT home page with url '([^']*)'\.")]
        public void GivenUserIsNavigatedToMMTHomePageWithUrl_(string p0)
        {
            driver.Url = p0;

        }

        [When(@"User enter '([^']*)' and '([^']*)'")]
        public void WhenUserEnterAnd(string p0, string p1)
        {
            LoginPage lp = new LoginPage(getDriver());
            Console.WriteLine("in the frame");
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(lp.getclickFrame()));
                IWebElement frameElement = lp.getclickFrame();
                if (frameElement!=null)
                {
                    driver.SwitchTo().Frame(frameElement);
                    lp.getClosebanner().Click();
                    driver.SwitchTo().DefaultContent();
                }
            }
            catch (NoSuchElementException ex)
            {
                // Handle the stale element reference exception gracefully
                Console.WriteLine("Element reference is stale: " + ex.Message);
            }
            catch (WebDriverTimeoutException ex)
            {
                // Handle the timeout exception gracefully
                Console.WriteLine("Timeout waiting for element to be selected: " + ex.Message);
            }

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lp.getClickLoginLink()));
            lp.getClickLoginLink().Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lp.getClickEmailLink()));
            lp.getClickEmailLink().Click();
            lp.getusername().SendKeys(p0);
            Console.WriteLine($"Entered {p0}");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lp.getContinuebtn()));
            /*      IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                  executor.ExecuteScript("arguments[0].click();", lp.getContinuebtn());*/

            lp.getContinuebtn().Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(lp.getpassword()));
            lp.getpassword().SendKeys(p1);
            lp.getClicklogin().Click();

        }


        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {

        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {

        }
    }
}
