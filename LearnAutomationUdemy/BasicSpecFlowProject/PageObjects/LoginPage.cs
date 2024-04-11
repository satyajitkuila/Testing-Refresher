using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSpecFlowProject.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //driver.FindElement(By.Id("username"))
        //pageobject factory
        [FindsBy(How = How.Id, Using = "webklipper-publisher-widget-container-notification-frame")]
        private IWebElement clickFrame;


        [FindsBy(How = How.Id, Using = "webklipper-publisher-widget-container-notification-close-div")]
        private IWebElement Closebanner;

        
        [FindsBy(How = How.XPath, Using = "//p[@data-cy='LoginHeaderText']")]
        private IWebElement ClickLoginLink;
        
        [FindsBy(How = How.XPath, Using = "//img[@data-cy='signInByMailButton']")]
        private IWebElement ClickEmailLink;
        
        [FindsBy(How = How.XPath, Using = "//input[@class=\"font14 fullWidth\"]")]
        private IWebElement username;
        
        [FindsBy(How = How.XPath, Using = "//button[@data-cy='continueBtn']")]
        private IWebElement Continuebtn;

        [FindsBy(How = How.XPath, Using = "//input[@data-cy=\"password\"]")]
        private IWebElement password;
        
        [FindsBy(How = How.XPath, Using = "//button[@data-cy=\"login\"]")]
        private IWebElement Clicklogin;




        public IWebElement getClosebanner()
        {
            return Closebanner;
        }
        public IWebElement getclickFrame()
        {
            return clickFrame;
        } 
        
        public IWebElement getClickLoginLink()
        {
            return ClickLoginLink;
        } 
        public IWebElement getClickEmailLink()
        {
            return ClickEmailLink;
        }
        public IWebElement getusername()
        {
            return username;
        }
        public IWebElement getContinuebtn()
        {
            return Continuebtn;
        }
        public IWebElement getpassword()
        {
            return password;
        }
        public IWebElement getClicklogin()
        {
            return Clicklogin;
        }
    }
}
