using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSpecFlowProject.PageObjects
{
    public class mmtHomePage
    {
        private IWebDriver driver;
        public mmtHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@data-cy=\"fromCity\"]")]
        private IWebElement clickFrom;        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"From\"]")]
        private IWebElement enterFrom;        
        [FindsBy(How = How.XPath, Using = "//li[@role=\"option\"]")]
        private IList<IWebElement> fetchFromDropdownList;

        [FindsBy(How = How.XPath, Using = "//input[@data-cy=\"toCity\"]")]
        private IWebElement clickTo;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"To\"]")]
        private IWebElement enterTo;
        [FindsBy(How = How.XPath, Using = "//li[@role=\"option\"]")]
        private IList<IWebElement> fetchToDropdownList;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"DayPicker-Month\"]")]
        private IList<IWebElement> fetchMonthsDisplayed;
        
        [FindsBy(How = How.XPath, Using = "//span[@class=\"DayPicker-NavButton DayPicker-NavButton--next\"]")]
        private IWebElement clickNextSetMonth;

        public IWebElement getClickFrom()
        {
            return clickFrom;
        }
        public IWebElement getenterFrom()
        {
            return enterFrom;
        }
        public IList<IWebElement> GetFromDropdownSuggestions()
        {
            return fetchFromDropdownList;
        }
        public IList<IWebElement> GetfetchMonthsDisplayed()
        {
            return fetchMonthsDisplayed;
        }
        
        public IWebElement getclickTo()
        {
            return clickTo;
        }
        public IWebElement getenterTo()
        {
            return enterTo;
        }
        public IList<IWebElement> GetToDropdownSuggestions()
        {
            return fetchToDropdownList;
        }

        public IWebElement getclickNextSetMonth()
        {
            return clickNextSetMonth;
        }
    }
}
