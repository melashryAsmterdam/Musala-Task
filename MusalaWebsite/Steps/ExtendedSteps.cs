using System;
using MusalaWebsite.Pages;
using MusalaFramework.Base;
using MusalaFramework.Configuration;
using MusalaFramework.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowMusalaWebsite.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public virtual void NavigateSite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelper.Write("Navigated to the home page");
        }


        //[Then(@"I Have navigated to the application")]
        [Given(@"I Have navigated to the application")]
        public void IHaveNavigatedToTheApplication()
        {
            NavigateSite();
            _parallelConfig.Driver.Manage().Window.Maximize();
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        }

        [Then(@"I see application opened")]
        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfContactButtonExists();
        }


        [Then(@"I see contact form opened")]
        [Given(@"I see contact form opened")]
        public void GivenISeeContactFormOpened()
        {
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfContactButtonExists();
        }





       


      
    }




  
}
