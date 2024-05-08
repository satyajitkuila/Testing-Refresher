using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    public class ActionClass
    {
        public static void main(String[] args)
        {
            ActionClass actionClass = new ActionClass();
        }

        public void dragDrop()
        {
            WebDriver driver = new ChromeDriver();
            Actions a = new Actions(driver);
            IWebElement src =driver.FindElement(By.XPath("hhh"));
            IWebElement trgt= driver.FindElement(By.XPath("hhh")); 

            a.DragAndDrop(src, trgt).Perform();
            a.DoubleClick().Perform();
            a.ContextClick().Perform();
            a.MoveToElement(src).Perform();
            
        }
    }
}
