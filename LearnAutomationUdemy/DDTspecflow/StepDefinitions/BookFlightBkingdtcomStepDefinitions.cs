using DDTspecflow.Drivers;
using DDTspecflow.PageObjects;
using Microsoft.VisualBasic;
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

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

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
                Console.WriteLine("loading 3");

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
            Console.WriteLine(date);
        }

        [Then(@"User click on Search buttton\.")]
        public void ThenUserClickOnSearchButtton_()
        {
            Console.WriteLine("click");
        }

        [Then(@"User is shown Flight resultz to choose from\.")]
        public void ThenUserIsShownFlightResultzToChooseFrom_()
        {
            Console.WriteLine("rslt");
        }

    }
}
