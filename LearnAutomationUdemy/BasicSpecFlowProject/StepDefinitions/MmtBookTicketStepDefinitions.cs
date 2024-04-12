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
            IList<IWebElement> optionListfrom=mhp.GetFromDropdownSuggestions();
            Console.WriteLine(optionListfrom[0].Text);
            foreach (IWebElement option in optionListfrom)
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
            IList<IWebElement> optionListTo = mhp.GetToDropdownSuggestions();
            Console.WriteLine(optionListTo[0].Text);
            foreach (IWebElement option in optionListTo)
            {
                if (option.Text.Contains(dst))
                {
                    option.Click();
                    Console.WriteLine("i am in loop");
                    break;
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
