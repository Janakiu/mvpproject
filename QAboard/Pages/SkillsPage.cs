using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAboard.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static QAboard.Pages.LanguagePage;
using static System.Collections.Specialized.BitVector32;

namespace QAboard.Pages
{
    [Binding]
    public class SkillsPage : CommonDriver
    {

        //private IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//a[text()='Skills']"));
        private IWebElement SkillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//a[@data-tab='second' and contains(@class, 'item')]"));
        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement addSkillTextbox => driver.FindElement(By.Name("name"));
        private IWebElement skillLevelOption => driver.FindElement(By.Name("level"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private IWebElement newSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement newSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private IWebElement editIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private IWebElement getSkillTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private IWebElement getSkillLevelTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement updatedSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement updatedSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

        //private IWebElement removeIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
       private IWebElement ActualPopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        

        //Adding New skill to the skill list
        public void AddSkill(string skill, string level)
        {
            // Use explicit waits to wait for the Skills tab to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SkillTabElement = wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));

            SkillTabElement.Click();

            //IWebElement addNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(addNewButtonBy));
            addNewButton.Click();
            addSkillTextbox.SendKeys(skill);
            skillLevelOption.SendKeys(level);

            //IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(addButtonBy));
            addButton.Click();
        }
        public string GetVerifySkillAdd()
        {
            Thread.Sleep(2000);
            return newSkill.Text;
        }
        public string GetVerifyLevel()
        {
            Thread.Sleep(2000);
            return newSkillLevel.Text;
        }

        public void UpdateSkill(string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SkillsTabElement = wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));
            SkillsTabElement.Click();

            IWebElement editIconElement = wait.Until(ExpectedConditions.ElementToBeClickable(editIcon));
            editIcon.Click();

            // Clear the skill text box and update skill
            var skillTextboxElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(getSkillTextbox));

            getSkillTextbox.Clear();
            getSkillTextbox.SendKeys(skill);

            // Update the skill level
            var skillLevelTextBox = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(getSkillLevelTextbox));
            getSkillLevelTextbox.Click();
            getSkillLevelTextbox.SendKeys(level);

            // Click the update button
            updateButton.Click();

        }
        public string GetVerifyUpdateSkill()
        {
            Thread.Sleep(2000);
            return updatedSkill.Text;
        }
        public string GetVerifyUpdateSkillLevel()
        {
            Thread.Sleep(2000);
            return updatedSkillLevel.Text;
        }

        //Deleting a skill from the skills list
        public void DeleteSkill(string skill)
        {
            // Assuming DeleteIcon is the element for the delete action
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement SkillsTabElement = wait.Until(ExpectedConditions.ElementToBeClickable(SkillsTab));
            SkillsTabElement.Click();

            IWebElement removeIconElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"))));
            wait.Until(ExpectedConditions.ElementToBeClickable(removeIconElement));
            removeIconElement.Click();


            
        }
        public string DeleteSkillsAssertion()
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




            
        
        

    




















