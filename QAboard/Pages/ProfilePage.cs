using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAboard.Pages
{
    public class ProfilePage
    {
        public void GoToLanguagePage(IWebDriver driver)
        {
            //navigate to languages tab
            IWebElement profileTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]"));
            profileTab.Click();

            IWebElement lang = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            lang.Click();

        }
        public void GoToSkillsPage(IWebDriver driver)
        {
            //navigate to skills tab
            //IWebElement skills = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            IWebElement skills = driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
            skills.Click();
        }




    }


}
