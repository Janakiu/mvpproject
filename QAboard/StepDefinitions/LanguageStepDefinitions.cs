using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.DevTools.V113.Browser;
using QAboard.Pages;
using QAboard.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QAboard.StepDefinitions
{

    [Binding]
    public class LanguageFeatureStepDefinition : CommonDriver
    {
        [Given(@"I successfully logged into website")]
        public void GivenISuccessfullyLoggedIntoWebsite()
        {
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();

           // driver.Navigate().Refresh();
        }

        [When(@"I create a language into profile '([^']*)' and '([^']*)'")]
        public void WhenICreateALanguageIntoProfileAnd(string language, string level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.AddLanguage(language, level);
        }

        [Then(@"The created record '([^']*)' and '([^']*)' been created successfully")]
        public void ThenTheCreatedRecordAndBeenCreatedSuccessfully(string language, string level)
        {
            LanguagePage languagePageObj = new LanguagePage();

            string newLanguage = languagePageObj.GetVerifyLanguageAdd();
            string newLevel = languagePageObj.GetVerifyLevelAdd();

            Console.WriteLine("Actual Language: " + language);
            Console.WriteLine("Actual Language Level: " + level);

            Console.WriteLine("New  Language: " + newLanguage);
            Console.WriteLine("New Language Level: " + newLevel);

            Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");
        }

        [When(@"I update '([^']*)' and '([^']*)' on an existing language and levels record")]
        public void WhenIUpdateAndOnAnExistingLanguageAndLevelsRecord(string language, string level)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.UpdateLanguage(language, level);

        }

        [Then(@"The record should been updated '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeenUpdatedAnd(string language, string level)
        {
            LanguagePage languagePageObj = new LanguagePage();

            string updatedLanguage = languagePageObj.GetVerifyUpdateLanguage();
            string updatedLevel = languagePageObj.GetVerifyUpdateLevel();

            Assert.AreEqual(language, updatedLanguage,"Actual language and expected language do not match");
            Assert.AreEqual(level, updatedLevel, "Actual level and expected level do not match");
        }
        [When(@"I delete '([^']*)' on an existing language record")]
        public void WhenIDeleteOnAnExistingLanguageRecord(string language)
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.DeleteLanguage(language);
        }
        [Then(@"The language record should be deleted and the message display as '([^']*)' has been deleted from your languages")]
        public void ThenTheLanguageRecordShouldBeDeletedAndTheMessageDisplayAsHasBeenDeletedFromYourLanguages(string language)
        {
            LanguagePage languagePageObj = new LanguagePage();
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string actualPopUpMessage = languagePageObj.DeleteLanguageAssertion();
            string expectedMessage = $"{language} has been deleted from your languages";

            Assert.AreEqual(expectedMessage, actualPopUpMessage);


        }

        
    }
}




    







    
































