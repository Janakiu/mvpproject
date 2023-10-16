using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAboard.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver { get; set; }
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
            TurnOnWait();
        }
        public void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void NavigateUrl()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }
        public void Close()
        {
            // Close the current browser window or tab
            driver.Close();
        }

        public void Quit()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }


    }
}
    
    
    
    
    
    
    
    
    

