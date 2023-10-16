using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QAboard.Pages;
using QAboard.Utilities;
using SeleniumExtras.WaitHelpers;
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
    public class SkillStepDefinitions : CommonDriver
    {


        [Given(@"I successfully logged into Project Mars website")]
        public void GivenISuccessfullyLoggedIntoProjectMarsWebsite()
        {
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();

            // Refresh the page after logging in
            //driver.Navigate().Refresh();
        }

        [When(@"I create a skill into profile '([^']*)' and '([^']*)'")]
        public void WhenICreateASkillIntoProfileAnd(string skill, string level)
        {
            SkillsPage skillsPageObj = new SkillsPage();
            skillsPageObj.AddSkill(skill, level);
            //driver.Navigate().Refresh();
        }

        [Then(@"The created skill '([^']*)' and '([^']*)' been created successfully")]
        public void ThenTheCreatedSkillAndBeenCreatedSuccessfully(string skill, string level)
        {
            SkillsPage skillsPageObj = new SkillsPage();

            // Add a wait condition to ensure the skill value is visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            string newSkill = skillsPageObj.GetVerifySkillAdd();
            string newLevel = skillsPageObj.GetVerifyLevel();

            //CustomAssertions.AssertStringEquals(skill, newSkill, "String is not equals to the expected value.");
            //CustomAssertions.AssertStringEquals(level, newLevel, "String is not equals to the expected value.");



            Assert.AreEqual(skill, newSkill, "Actual skill and expected skill do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");

        }
        [When(@"I update '([^']*)' and '([^']*)' on an existing skill and levels record")]
        public void WhenIUpdateAndOnAnExistingSkillAndLevelsRecord(string skill, string level)
        {
            SkillsPage skillsPageObj = new SkillsPage();
            skillsPageObj.UpdateSkill(skill, level);

        }
        [Then(@"The Skill record should been updated '([^']*)' and '([^']*)'")]
        public void ThenTheSkillRecordShouldBeenUpdatedAnd(string skill, string level)
        {
            SkillsPage skillsPageObj = new SkillsPage();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string updatedSkill = skillsPageObj.GetVerifyUpdateSkill();
            string updatedLevel = skillsPageObj.GetVerifyUpdateSkillLevel();

            Assert.AreEqual(skill, updatedSkill, "Actual skill and expected skill do not match");
            Assert.AreEqual(level, updatedLevel, "Actual level and expected level do not match");

        }
        [When(@"I delete '([^']*)' on an existing skill record")]
        public void WhenIDeleteOnAnExistingSkillRecord(string skill)
        {
            SkillsPage skillsPageObj = new SkillsPage();
            skillsPageObj.DeleteSkill(skill);
        }

        [Then(@"The skill record should be deleted and the message display as'([^']*)' has been deleted")]
        public void ThenTheSkillRecordShouldBeDeletedAndTheMessageDisplayAsHasBeenDeleted(string skill)
        {

            SkillsPage skillsPageObj = new SkillsPage();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string actualPopUpMessage = skillsPageObj.DeleteSkillsAssertion();
            string expectedMessage = $"{skill} has been deleted";
            
            Assert.AreEqual(expectedMessage, actualPopUpMessage);
        }

    }

}


        





    

           

























  
















    



    















    





   


    

    
