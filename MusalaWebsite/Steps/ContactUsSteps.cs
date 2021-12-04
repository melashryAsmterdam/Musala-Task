using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusalaWebsite.Pages;
using MusalaFramework.Base;
using MusalaFramework.Configuration;
using MusalaFramework.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowMusalaWebsite.Steps
{
    [Binding]
    public class ContactUsSteps : BaseStep
    {

        private readonly ParallelConfig _parallelConfig;

        public ContactUsSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        [Then(@"I Close the browser")]
        public void ThenICloseTheBrowser()
        {
            if (_parallelConfig.Driver != null)
            {
                _parallelConfig.Driver.Close();

                _parallelConfig.Driver.Quit();

                _parallelConfig.Driver.Dispose();
            }
        }


        [Given(@"I Click contact button")]
        public void WhenIClickContactButton()
        {
           _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickContactButton();
        }


        [When(@"I submit invalid (.*) with correct (.*),(.*),(.*)")]
        public void WhenISubmitInvalidEmail(string email, string name, string subject, string message)
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<ContactForm>().Send(email,name,subject,message);
        }


        [Then(@"Invalid (.*) appears")]
        public void CheckIfInvalidEmailMessageAppears(string errorMessage)
        {
             _parallelConfig.CurrentPage.As<ContactForm>().CheckIfInvalidEmailMessageExists(errorMessage);
        }

    }
}
