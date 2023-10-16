using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAboard.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Collections.Specialized.BitVector32;

namespace QAboard.Pages
{
    [Binding]
    public class LanguagePage : CommonDriver
    {
        private static IWebElement LanguagesTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//a[@data-tab='first']"));
        private static IWebElement addnewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement addlanguageTextBox => driver.FindElement(By.XPath("//input[@name='name']"));

        private static IWebElement languageLevelOption => driver.FindElement(By.XPath("//select[@name='level']"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement newLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement newLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement editIcon => driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
        //private static IWebElement editIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement getLanguageTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private static IWebElement getLevelTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement updatedLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement updatedLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement ActualPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        public void AddLanguage(string language, string level)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement addnewButtonElement = wait.Until(ExpectedConditions.ElementToBeClickable(addnewButton));
            addnewButton.Click();

            // Wait for the "Add Language" input box to become clickable
            IWebElement languageTextBoxElement = wait.Until(ExpectedConditions.ElementToBeClickable(addlanguageTextBox));
            languageTextBoxElement.SendKeys(language);

            // Wait for the "Level" input box to become clickable
            IWebElement levelOptionElement = wait.Until(ExpectedConditions.ElementToBeClickable(languageLevelOption));
            levelOptionElement.SendKeys(level);

            addButton.Click();
        }
        public string GetVerifyLanguageAdd()
        {
            Thread.Sleep(2000);
            return newLanguage.Text;
        }
        public string GetVerifyLevelAdd()
        {
            Thread.Sleep(2000);
            return newLevel.Text;
        }
        public void UpdateLanguage(string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement LanguagesTabElement = wait.Until(ExpectedConditions.ElementToBeClickable(LanguagesTab));
            LanguagesTabElement.Click();

            IWebElement editIconElement = wait.Until(ExpectedConditions.ElementToBeClickable(editIcon));
            editIcon.Click();

            var languageTextboxElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(getLanguageTextBox));
            getLanguageTextBox.Clear();
            getLanguageTextBox.SendKeys(language);


            var LevelTextbox = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(getLevelTextBox)); 
            getLevelTextBox.Click();
            getLevelTextBox.SendKeys(level);
            updateButton.Click();
            
        }
        public string GetVerifyUpdateLanguage()
        {
            Thread.Sleep(2000);
            return updatedLanguage.Text;
        }

        public string GetVerifyUpdateLevel()
        {
            Thread.Sleep(2000);
            return updatedLevel.Text;
        }
        public void DeleteLanguage(string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //deleteLanguageTab.Click();

            IWebElement LanguagesTabElement = wait.Until(ExpectedConditions.ElementToBeClickable(LanguagesTab));
            LanguagesTabElement.Click();

            IWebElement removeIconElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")));
            wait.Until(ExpectedConditions.ElementToBeClickable(removeIconElement));
            removeIconElement.Click();


        }
        public string DeleteLanguageAssertion()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Wait for the pop-up message to become visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));

            // Assuming ActualPopUpMsg is the element for the pop-up message
            string actualPopUpDeleteMsg = ActualPopUpMsg.Text;
            return actualPopUpDeleteMsg;
        }






    }

}       


        





        
   


   
    








