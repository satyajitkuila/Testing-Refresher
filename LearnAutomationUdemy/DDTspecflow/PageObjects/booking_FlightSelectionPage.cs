using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTspecflow.PageObjects
{
    public class booking_FlightSelectionPage
    {
        private IWebDriver driver;
        public booking_FlightSelectionPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);

        }


        [FindsBy(How = How.XPath, Using = "//button[@data-testid=\"search_tabs_BEST\"]")]
        private IWebElement search_tabs_BEST;
        [FindsBy(How = How.XPath, Using = ".//button[@data-testid=\"flight_card_bound_select_flight\"]")]
        private IWebElement clickViewDetails;
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'flight-card')]")]
        private IList <IWebElement> flightCards;

        public IWebElement getsearch_tabs_BEST()
        {
            return search_tabs_BEST;
        }
        public IWebElement getclickViewDetails()
        {
            return clickViewDetails;
        }
        public IList<IWebElement> getflightCards()
        {
            return flightCards;
        }


    }
}
