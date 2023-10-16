using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using QAboard.Pages;
using QAboard.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAboard.Tests
{
    
    public class Start : CommonDriver
    {
        LoginPage   loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();
        LanguagePage languagePageObj = new LanguagePage();
        SkillsPage   skillPageObj = new SkillsPage();

        //    [SetUp]
        //    public void LanguagePageSetUp()
        //    {
        //        //open chrome browser
        //        driver = new ChromeDriver();
        //        

        //        //Login page object initialization and definition
        //       // loginPageObj.LoginSteps(driver);
        //        
        //          //Profile page initialization
                    //ProfilePage profilepageObj = new ProfilePage();
        //        //profilePageObj.GoToLanguagePage(driver);
        //    }
        //    [Test, Order(1)]
        //    public void AddLanguage()
        //    {
        //        LanguagePage languagePageObj = new LanguagePage();
        //        languagePageObj.LanguageText(driver);

        //    }

        //    [Test, Order(2)]
        //    public void EditLanguage()
        //    {

        //        //Edit language
        //        languagePageObj.GetEditedLanguage(driver);

        //    }
        //    [Test, Order(3)]
        //    public void DeleteLanguage()
        //    {
        //        //profilePageObj.GoToLanguagePage(driver);
        //        //Delete language
        //        languagePageObj.GetDeletedElement(driver);

        //    }
        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }

    }
}









