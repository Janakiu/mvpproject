//using OpenQA.Selenium.DevTools.V113.Browser;
using QAboard.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace QAboard.Hooks
{
        [Binding]
        public sealed class Hooks
        {
            private CommonDriver commonDriver;

            [BeforeScenario]
            public void BeforeScenarioWithTag()
            {
                try
                {
                    commonDriver = new CommonDriver();
                    commonDriver.Initialize();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during initialization
                    // You can log the exception or take other appropriate actions
                    Console.WriteLine($"Initialization failed: {ex.Message}");
                    throw; // Rethrow the exception to mark the scenario as failed
                }
            }

            [AfterScenario]
            public void AfterScenario()
            {
                if (commonDriver != null)
                {
                    commonDriver.Quit();
                }
            }
        }
    
}




