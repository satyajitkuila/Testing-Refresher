using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using CsharpSeleniumFramework.Utilities;
using NUnit.Framework;
using CsharpSeleniumFramework.PageObjects;

namespace CsharpSeleniumFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETests : Base
    {
        [Test]
        [TestCaseSource("AddTestDataConfig"), Category("Regression")]
        //[TestCase("rahulshettyacademy","learning","ind")]//valid
        //[TestCase("rahulshetty", "learning","ind")]     //invalid
        [Parallelizable(ParallelScope.All)]

        public void EndToEndFlow(String username,String password, String country, string[] expectedproducts)
        {
            //string[] expectedproducts = { "iphone X", "Blackberry" }; //passing it on method level
            string[] actualproducts = new string[2];

            loginPage lp = new loginPage(getDriver());
            productsPage productPage= lp.validLogin(username, password);
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
            confirmationPage.GetinpCountry(country);
            confirmationPage.waitForPageDisplay();
            confirmationPage.GetchooseCountry();
            confirmationPage.GetchooseCheckbox();
            confirmationPage.GetclickPurchase();

            string actMessage = confirmationPage.GetconfirmMessage();

            StringAssert.Contains("Success", actMessage);

        }

        [Test,Category("smoke")]
        public void LocatorsIdentification()
        {
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.Value.FindElement(By.Id("username")).Clear();
            driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyy");
            driver.Value.FindElement(By.Name("password")).SendKeys("123456");
            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            // --//tagname[@attribute='value']--
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            //Thread.Sleep(3000);

            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            //using explicit wait here
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")), "Sign In"));

            String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.Value.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";

            //Validate URL of the Linktext
            Assert.AreEqual(expectedUrl, hrefAttr);

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), 
                                          getDataParser().extractData("password"), 
                                          getDataParser().extractData("country"), 
                                          getDataParser().extractDataArray("products"));

            yield return new TestCaseData(getDataParser().extractData("username_wrong"), 
                                          getDataParser().extractData("password_wrong"), 
                                          getDataParser().extractData("country_wrong"), 
                                          getDataParser().extractDataArray("products"));
            
        }
    }
}