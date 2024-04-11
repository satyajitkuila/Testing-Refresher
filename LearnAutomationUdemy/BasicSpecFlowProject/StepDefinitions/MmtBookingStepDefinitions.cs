using BasicSpecFlowProject.Drivers;
using BasicSpecFlowProject.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BasicSpecFlowProject.StepDefinitions
{
    [Binding]
    public class MmtBookingStepDefinitions:Base
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
            
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(lp.getclickFrame().GetType());
            Thread.Sleep(15000);
            Console.WriteLine("in the frame");
            driver.SwitchTo().Frame(lp.getclickFrame());
            Console.WriteLine("switchd the frame");
            lp.getClosebanner().Click();
            
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(10000);
            lp.getClickLoginLink().Click();
            Thread.Sleep(10000);
            lp.getClickEmailLink().Click();
            lp.getusername().SendKeys(p0);            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lp.getContinuebtn()));            
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
