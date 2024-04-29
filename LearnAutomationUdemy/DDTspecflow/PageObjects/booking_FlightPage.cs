using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTspecflow.PageObjects
{
    public class booking_FlightPage
    {
        private IWebDriver driver;
        public booking_FlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        /*Elements for the journeyType selection*/
        [FindsBy(How = How.XPath, Using = "data-ui-name=\"search_type_oneway\"")]
        private IWebElement jrnyType;        
        [FindsBy(How = How.XPath, Using = "//div[@data-ui-name]")]
        private IList<IWebElement> jrnyTypelist;

        /*Elements for the From selection*/
        [FindsBy(How = How.XPath, Using = "//button[@data-ui-name=\"input_location_from_segment_0\"]")]
        private IWebElement flighFromClick;
        [FindsBy(How = How.XPath, Using = "//span[@class=\"Tags-module__text___9xa9e\"]")]
        private IWebElement flighFromPreselected;
        [FindsBy(How = How.XPath, Using = "//span[@class=\"Icon-module__root___JaqfB Tags-module__icon___c2KIW Icon-module__root--size-small___XVXFj\"]")]
        private IWebElement flighFromCrossbtn;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Airport or city']")]
        private IWebElement flighFromInput;        
        [FindsBy(How = How.XPath, Using = "//span[@class=\"List-module__content___a0FlE\"]")]
        private IList<IWebElement> flighFromSugsttList;

        /*Elements for the To selection*/
        [FindsBy(How = How.XPath, Using = "//button[@data-ui-name=\"input_location_to_segment_0\"]")]
        private IWebElement flighToClick;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Airport or city']")]
        private IWebElement flighToInput;
        [FindsBy(How = How.XPath, Using = "//span[@class=\"List-module__content___a0FlE\"]")]
        private IList<IWebElement> flighToSugsttList;

        /*Elements for the Date selection*/
        [FindsBy(How = How.XPath, Using = "//button[@placeholder=\"Choose departure date\"]")]
        private IWebElement flighDateClick;        
        [FindsBy(How = How.XPath, Using = "//div[@class=\"Calendar-module__monthWrapper___n+yfx\"]")]
        private IList<IWebElement> flighDateMenu;
        [FindsBy(How = How.XPath, Using = "//span[@data-date]")]
        private IList<IWebElement> flighDatePick;
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[7]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[2]/span[1]/span[1]/*[name()='svg'][1]")]
        private IWebElement flighDateNxtMenu;

        /*Elements for the search selection*/
        [FindsBy(How = How.XPath, Using = "//button[@data-ui-name=\"button_search_submit\"]")]
        private IWebElement flightSearchbutton;




        /*Method for Elements for the From selection*/
        public IWebElement getjrnyType()
        {
            return jrnyType;
        }
        public IList<IWebElement> getjrnyTypelist()
        {
            return jrnyTypelist;
        }
        public IWebElement getflighFromClick()
        {
            return flighFromClick;
        }
        public IWebElement getflighFromPreselected()
        {
            return flighFromPreselected;
        }
        public IWebElement getflighFromCrossbtn()
        {
            return flighFromCrossbtn;
        }
        public IWebElement getflighFromInput()
        {
            return flighFromInput;
        }
        public IList<IWebElement> getflighFromSugsttList()
        {
            return flighFromSugsttList;
        }

        /*Method for Elements for the TO selection*/
        public IWebElement getflighToClick()
        {
            return flighToClick;
        }
        public IWebElement getflighToInput()
        {
            return flighToInput;
        }
        public IList<IWebElement> getflighToSugsttList()
        {
            return flighToSugsttList;
        }

        /*Method Elements for the Date selection*/
        public IWebElement getflighDateClick()
        {
            return flighDateClick;
        }
        public IWebElement getflighDateNxtMenu()
        {
            return flighDateNxtMenu;
        }
        public IList<IWebElement> getflighDateMenu()
        {
            return flighDateMenu;
        }
        public IList<IWebElement> getflighDatePick()
        {
            return flighDatePick;
        }
        /*Method Elements for the search selection*/
        public IWebElement getflightSearchbutton()
        {
            return flightSearchbutton;
        }

    }
}
