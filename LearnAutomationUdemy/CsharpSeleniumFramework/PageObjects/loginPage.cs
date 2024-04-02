using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CsharpSeleniumFramework.PageObjects
{
    public class loginPage
    {
        private IWebDriver driver;
        public loginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        //driver.FindElement(By.Id("username"))
        //pageobject factory
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How =How.XPath,Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement acceptTerm;

        [FindsBy(How = How.XPath, Using = "//input[@value='Sign In']")]
        private IWebElement Signin;

        public productsPage validLogin(String user,String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            acceptTerm.Click();
            Signin.Click();

            return new productsPage(driver);
        }
    }
}
