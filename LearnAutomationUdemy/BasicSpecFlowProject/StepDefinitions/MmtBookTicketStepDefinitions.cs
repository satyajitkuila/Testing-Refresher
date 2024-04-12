using BasicSpecFlowProject.Drivers;
using BasicSpecFlowProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BasicSpecFlowProject.StepDefinitions
{
    [Binding]
    public class MmtBookTicketStepDefinitions:Base
    {
        
        [Given(@"I am on the MakeMyTrip website '([^']*)'\.")]
        public void GivenIAmOnTheMakeMyTripWebsite_(string url)
        {
            driver.Url = url;
        }



        [When(@"I search for a flight from ""([^""]*)"" to ""([^""]*)"" on ""([^""]*)""")]
        public void WhenISearchForAFlightFromToOn(string src, string dst, string date)
        {
            mmtHomePage mhp = new mmtHomePage(getDriver());
            Thread.Sleep(10000);
            mhp.getClickFrom().Click();
            mhp.getenterFrom().SendKeys(src);
            Thread.Sleep(10000);

            //entering From field
            foreach (IWebElement option in mhp.GetFromDropdownSuggestions())
            {
                if (option.Text.Contains( src))
                {
                    option.Click();
                    Console.WriteLine("i am in loop");
                    break;
                }
            }
            Thread.Sleep(10000);

            //entering To field
            mhp.getclickTo().Click();
            mhp.getenterTo().SendKeys(dst);
            Thread.Sleep(10000);
            foreach (IWebElement option in mhp.GetToDropdownSuggestions())
            {
                if (option.Text.Contains(dst))
                {
                    option.Click();
                    Console.WriteLine("i am in loop");
                    break;
                }
            }

            //Selecting the date from date picker
            string[] parts = date.Split('-');
            string year = parts[0];
            string month = parts[1];
            string monthName = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1).ToString("MMMM");
            string day = parts[2]; 
            Console.WriteLine(monthName + " " + day);

            foreach (IWebElement option in mhp.GetfetchMonthsDisplayed())
            {
                if (option.Text.Contains(monthName))
                {
                    Console.WriteLine("i am in month loop");


                    break;
                }
                else
                {
                    mhp.getclickNextSetMonth().Click();
                }
            }
        }

        [When(@"I select ""([^""]*)"" passengers and ""([^""]*)"" class")]
        public void WhenISelectPassengersAndClass(string p0, string economy)
        {
            
        }

        [When(@"I click on the search button")]
        public void WhenIClickOnTheSearchButton()
        {
        }

        [Then(@"I should see a list of available flights")]
        public void ThenIShouldSeeAListOfAvailableFlights()
        {
        }

        [When(@"I select a flight")]
        public void WhenISelectAFlight()
        {
        }

        [When(@"I proceed to book the flight")]
        public void WhenIProceedToBookTheFlight()
        {
        }

        [Then(@"I should be redirected to the booking page")]
        public void ThenIShouldBeRedirectedToTheBookingPage()
        {
        }

        [Then(@"I should be able to complete the booking process")]
        public void ThenIShouldBeAbleToCompleteTheBookingProcess()
        {
        }
    }
}
