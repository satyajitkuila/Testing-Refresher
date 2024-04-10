using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSeleniumFramework.PageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElements(By.XPath("//div/h4"))
        [FindsBy(How = How.XPath, Using = "//div/h4")]
        private IList<IWebElement> checkOutItems;
        //driver.FindElement(By.XPath("//button[normalize-space(text())='Checkout']")).Click();
        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Checkout']")]
        private IWebElement clickCheckOut;
        

        public IList<IWebElement> getCheckOutItems()
        {
            return checkOutItems;
        }
        public ConfirmationPage GetclickCheckOut()
        {
            clickCheckOut.Click();
            return new ConfirmationPage(driver);

        }
        
    }
}
