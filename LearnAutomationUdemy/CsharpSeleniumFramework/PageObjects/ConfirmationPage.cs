using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSeleniumFramework.PageObjects
{
    public class ConfirmationPage
    {
        private IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.XPath("//input[@id='country']")).SendKeys("ind");
        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]
        private IWebElement inpCountry;
        //driver.FindElement(By.XPath("//a[text()='India']")).Click();
        [FindsBy(How = How.XPath, Using = "//a[text()='India']")]
        private IWebElement chooseCountry;
        //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
        [FindsBy(How = How.XPath, Using = "//label[@for='checkbox2']")]
        private IWebElement chooseCheckbox;
        //driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        private IWebElement clickPurchase;
        //driver.FindElement(By.XPath("//div[@class='alert alert-success alert-dismissible']"))
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success alert-dismissible']")]
        private IWebElement confirmMessage;

        public void GetinpCountry(String country)
        {
            inpCountry.SendKeys(country);
        } 
        public void GetchooseCountry()
        {
            chooseCountry.Click();
        }
        public void GetchooseCheckbox()
        {
            chooseCheckbox.Click();
        }
        public void GetclickPurchase()
        {
            clickPurchase.Click();
        }
        public string GetconfirmMessage()
        {
            return confirmMessage.Text;
        }

        public void waitForPageDisplay()
        {
            //using explicit wait here
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='India']")));

        }


    }
}
