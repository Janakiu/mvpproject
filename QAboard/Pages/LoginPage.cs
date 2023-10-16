using NUnit.Framework;
using OpenQA.Selenium;
using QAboard.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAboard.Pages
{
    public class LoginPage : CommonDriver
    {
        public void LoginSteps()
        {
            //Launch page
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1500);
            //Click on SignIn
            driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")).Click();

            Wait.WaitToExist(driver, "name", "email", 3);
            try
            {
                IWebElement emailaddressTextbox = driver.FindElement(By.XPath("//input[@name ='email']"));
                emailaddressTextbox.SendKeys("janakiu3@gmail.com");
            }
            catch (Exception ex)
            {
                Assert.Fail("Mars page didn't load.", ex);
            }
            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[contains(@name,'password')]"));
            passwordTextbox.SendKeys("w1nner");

            IWebElement loginButton = driver.FindElement(By.XPath("//button[@class='fluid ui teal button']"));
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }

    
}        
        
        
        
    
    
    
    
    
    
    
    
    

