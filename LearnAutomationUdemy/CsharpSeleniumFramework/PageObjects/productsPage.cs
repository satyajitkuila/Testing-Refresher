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
    public class productsPage
    {
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addCart = By.CssSelector(".card-footer button");

        public productsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        //driver.FindElement(By.PartialLinkText("Checkout"))

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkOut;

        

        public void waitForPageDisplay()
        {
            //using explicit wait here
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        }
        public IList<IWebElement> getCards()
        {
            return cards;
        }
                
        public By getCardTitle()
        {
            return cardTitle;
        }
        public By getAddCart()
        {
            return addCart;
        }
        public CheckoutPage GetCheckout()
        {
            checkOut.Click();
            return new CheckoutPage(driver);
        }
    }

    
}
