using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using CsharpSeleniumFramework.Utilities;
using NUnit.Framework;
using CsharpSeleniumFramework.PageObjects;

namespace CsharpSeleniumFramework.Tests
{
    public class E2ETests : Base
    {

        [Test]
        public void EndToEndFlow()
        {
            string[] expectedproducts = { "iphone X", "Blackberry" };
            string[] actualproducts = new string[2];

            loginPage lp = new loginPage(getDriver());
            productsPage productPage= lp.validLogin("rahulshettyacademy", "learning");
            productPage.waitForPageDisplay();
            

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {
                TestContext.Progress.WriteLine(product.FindElement(productPage.getCardTitle()).Text);

                if (expectedproducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    //click on addcart
                    product.FindElement(productPage.getAddCart()).Click();
                }
            }
            CheckoutPage checkoutPage= productPage.GetCheckout();

            IList<IWebElement> checkoutcards = checkoutPage.getCheckOutItems();
            for (int i = 0; i < checkoutcards.Count; i++)
            {
                actualproducts[i] = checkoutcards[i].Text;
            }
            Assert.AreEqual(expectedproducts, actualproducts);

            ConfirmationPage confirmationPage= checkoutPage.GetclickCheckOut();
            confirmationPage.GetinpCountry("ind");
            confirmationPage.waitForPageDisplay();
            confirmationPage.GetchooseCountry();
            confirmationPage.GetchooseCheckbox();
            confirmationPage.GetclickPurchase();

            string actMessage = confirmationPage.GetconfirmMessage();

            StringAssert.Contains("Success", actMessage);


        }
    }
}