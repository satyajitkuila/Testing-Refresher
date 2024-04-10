using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace CsharpSeleniumFramework.Utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        //Reportfile
        [OneTimeSetUp]
        public void Setup()
        {
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

        //public IWebDriver driver;

        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        /*cdmLine query to override Browser : 
         * dotnet test CsharpSeleniumFramework.csproj --filter TestCategory=smoke --% -- TestRunParameters.Parameter(name=\"browserName\",value=\"Edge\") 
         * --% issue addition src :https://github.com/microsoft/vstest/issues/4637
         */
        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];

            if(browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            
            String Url = ConfigurationManager.AppSettings["url"];

            InitBrowser(browserName);
            //using implicitwait here
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);    
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = Url;
            TestContext.Progress.WriteLine("Url :" + driver.Value.Url);
            TestContext.Progress.WriteLine("Title :" + driver.Value.Title);

        }

        public void InitBrowser(String browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }

        }

        public static jsonReader getDataParser()
        {
            return new jsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace =TestContext.CurrentContext.Result.StackTrace;


            DateTime time =DateTime.Now;
            String fileName = "screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenShot(driver.Value,fileName));
                test.Log(Status.Fail,"Test failed with logtrace"+stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                
            }
            extent.Flush();
            driver.Value.Quit();
        }

        public AventStack.ExtentReports.Model.Media captureScreenShot(IWebDriver driver, String screenShotName)
        {
            //switching from driver mode to screenshot mode by casting the interface (Itakescreenshot)
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,screenShotName).Build();
        }
    }
}
