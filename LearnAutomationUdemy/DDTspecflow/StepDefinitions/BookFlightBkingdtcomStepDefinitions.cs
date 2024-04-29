using DDTspecflow.Drivers;
using DDTspecflow.PageObjects;
using FluentAssertions.Equivalency.Steps;
using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;

namespace DDTspecflow.StepDefinitions
{
    [Binding]
    public class BookFlightBkingdtcomStepDefinitions:Base
    {
        booking_HomePage bmp = new booking_HomePage(getDriver());
        booking_FlightPage bfp =new booking_FlightPage(getDriver());
        booking_FlightSelectionPage bfsp =new booking_FlightSelectionPage(getDriver());

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        [Given(@"user is on the home page with (.*) given\.")]
        public void GivenUserIsOnTheHomePageWithUrlGiven_(String Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

      
        [Given(@"user is not seeing any alerts and popUp\.")]
        public void GivenUserIsNotSeeingAnyAlertsAndPopUp_()
        {                     
            try
            {
                IWebElement alerts = bmp.getalert();
                wait.Until(ExpectedConditions.ElementToBeClickable(alerts));
                alerts.Click();
                Console.WriteLine("alertss found");
            }
            catch(TimeoutException e)
            {
                Console.WriteLine(e.ToString()+"No alerts found");
            }
        }

        [Then(@"Click on the flight bokking link\.")]
        public void ThenClickOnTheFlightBokkingLink_()
        {
            
            Console.WriteLine("link");
            IWebElement link = bmp.getflightLink();
            wait.Until(ExpectedConditions.ElementToBeClickable(link));
            link.Click();
        }

        [When(@"user is on flight booking page provide the (.*) to book\.")]
        public void WhenUserIsOnFlightBookingPageProvideTheToBook_(string p0)
        {
            IList<IWebElement> listElements = bfp.getjrnyTypelist();
            foreach (IWebElement type in listElements)
            {
                if(type.Text.Contains(p0))
                {
                   type.Click();
                    break;
                }
                else
                {
                    Console.WriteLine("Journey Type not available in the List");
                }
            }
        }

        [Then(@"user provides from (.*) field \.")]
        public void ThenUserProvidesFromFromDestField_(string fromDest)
        {
            Console.WriteLine("user wants to go : "+fromDest);
            bfp.getflighFromClick().Click();
            IWebElement preSlctd= bfp.getflighFromPreselected();
            if (preSlctd.Text.Contains(fromDest))
            {
                Console.WriteLine("Already slected");
            }
            else
            {
                bfp.getflighFromCrossbtn().Click();
                bfp.getflighFromInput().SendKeys(fromDest);
                Thread.Sleep(1000);
                IList<IWebElement> listSuggst = bfp.getflighFromSugsttList();
                

                foreach (IWebElement suggst in listSuggst)
                {
                    if (suggst.Text.Contains(fromDest))
                    {
                        suggst.Click();
                        Console.WriteLine($"from field slected {fromDest}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Destination not available in the List");
                    }
                }
            }
        }

        [Then(@"user provides (.*) field")]
        public void ThenUserProvidesField(string toDest)
        {
            bfp.getflighToClick().Click();            
            bfp.getflighFromInput().SendKeys(toDest);
            Thread.Sleep(1000);
            IList<IWebElement> tolistSuggst = bfp.getflighToSugsttList();
            foreach (IWebElement suggst in tolistSuggst)
            {
                if (suggst.Text.Contains(toDest))
                {
                    suggst.Click();
                    Console.WriteLine($"from field slected {toDest}");
                    break;
                }
                else
                {
                    Console.WriteLine("Destination not available in the List");
                }
            }
            
        }

        [Then(@"user provides (.*) on the picker\.")]
        public void ThenUserProvidesOnThePicker_(string date)
        {
            // Parse the input date string into a DateTime object
            DateTime date1 = DateTime.Parse(date);

            string monthString = date1.ToString("MMMM");

            // Format the date into the desired format: "10 July 2024"
            string formattedDate = date1.ToString("yyyy-MM-dd");
            Console.WriteLine(formattedDate);

            bfp.getflighDateClick().Click();
            Thread.Sleep(1000);
            IList<IWebElement> MnthMenu= bfp.getflighDateMenu();
            Thread.Sleep(1000);
            foreach (IWebElement month in MnthMenu)
            {
                if (month.Text.Contains(monthString))
                {
                    IList<IWebElement> datePick= bfp.getflighDatePick();
                    Thread.Sleep(1000);
                    foreach (IWebElement item in datePick)
                    {
                       
                        if (item.GetAttribute("data-date").Contains(formattedDate))
                        {
                            item.Click();
                            break;
                        }
                        
                    }
                    break;
                }
                else
                {
                    bfp.getflighDateNxtMenu().Click();
                    Thread.Sleep(1000);
                }
            }
           
        }

        [Then(@"User click on Search buttton\.")]
        public void ThenUserClickOnSearchButtton_()
        {
            Thread.Sleep(1000);
            bfp.getflightSearchbutton().Click();
        }

        [Then(@"User is shown Flight resultz to choose from\.")]
        public void ThenUserIsShownFlightResultzToChooseFrom_()
        {

            // Find the element you want to check visibility for
            IWebElement element = bfsp.getsearch_tabs_BEST();
            wait.Until(ExpectedConditions.ElementToBeClickable(element));//chnge it to a method

            // Assert if the element is visible
            Assert.IsTrue(element.Displayed, "Element is not visible on the page.");
            Thread.Sleep(1000);

            IList <IWebElement> flights=bfsp.getflightCards();

            foreach (IWebElement flight in flights)
            {
                Console.WriteLine(flight.Text);
                
                
                if (flight.Text.Contains("IndiGo"))
                {
                    
                    bfsp.getclickViewDetails().Click();
                }
            }
        }

    }
}
