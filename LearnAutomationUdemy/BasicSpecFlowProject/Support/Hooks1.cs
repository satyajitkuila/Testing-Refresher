﻿using BasicSpecFlowProject.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace BasicSpecFlowProject.Support
{
    [Binding]
    public sealed class Hooks1:Base
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario("Edge")]
        public void BeforeScenarioWithTag2()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario("Chrome")]
        public void BeforeScenarioWithTag1()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            /*// Set the path to the ChromeDriver executable
            ChromeOptions options = new ChromeOptions();

            // Add headless argument
            options.AddArgument("--headless");

            // Initialize ChromeDriver with options
            driver = new ChromeDriver(options);*/
        }
        

        
        [AfterScenario]
        public void AfterScenario()
        {
         //   driver.Quit();      
        }
    }
}