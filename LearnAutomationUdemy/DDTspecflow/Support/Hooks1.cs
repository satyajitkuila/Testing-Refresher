using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using DDTspecflow.Drivers;
using Gherkin.CucumberMessages.Types;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;
using Scenario = AventStack.ExtentReports.Gherkin.Model.Scenario;

namespace DDTspecflow.Support
{
    [Binding]
    public sealed class Hooks1:Base
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        [BeforeTestRun]
        public static void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser1"];
            InitBrowser(browserName);
            driver.Manage().Window.Maximize();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA1");
            extent.AddSystemInfo("Username", "Satyajit Kuila");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);

                }

                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

                }

                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);

                }

            }
            else if (ScenarioContext.Current.TestError != null)
            {
                String fileName= TakeScreenshot();
                Console.WriteLine(fileName);
                if (stepType == "Given")
                {

                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message).AddScreenCaptureFromPath(fileName); 
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message).AddScreenCaptureFromPath(fileName);
                    
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).
                        Fail(ScenarioContext.Current.TestError.Message).AddScreenCaptureFromPath(fileName);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(ScenarioContext.Current.TestError.Message).AddScreenCaptureFromPath(fileName);
                    
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("AfterScenario");

            //implement logic that has to run after executing each scenario
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Close();
            driver.Dispose();
            //kill the browser
            //Flush report once test completes
            extent.Flush();

        }
    }
}
