using MusalaWebsite.Pages;
using MusalaFramework.Base;
using TechTalk.SpecFlow;

namespace SpecFlowMusalaWebsite.Steps
{
    [Binding]
    public class CompanyProfileSteps : BaseStep
    {

        private readonly ParallelConfig _parallelConfig;

        public CompanyProfileSteps(ParallelConfig parallelConfig) : base(parallelConfig)
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


        [When(@"I Click company tab on top")]
        public void WhenIClickCompanyTab()
        {
           _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickCompanyTab();
        }

        [When(@"I Click facebook icon")]
        public void WhenIClickFacebookLink()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CompanyPage>().ClickFacebookLink();
        }


        [When(@"I check for leadership section")]
        public void WhenICheckForLeadershipSection()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CompanyPage>().ScrollToLeadershipSection();
        }

        [Then(@"I see company page url is loaded correctly")]
        public void CheckIfCompnayPageUrlIsCorrect()
        {
             _parallelConfig.CurrentPage.As<CompanyPage>().CheckIfCompanyPageUrlIsCorrect();
        }


        [Then(@"I see leadership section on page")]
        public void CheckIfLeadershipSectionExists()
        {
            _parallelConfig.CurrentPage.As<CompanyPage>().CheckIfLeadershipSectionExists();
        }

        [Then(@"I see facebook page url is loaded correctly")]
        public void CheckIfFacebookPageUrlIsCorrect()
        {
            _parallelConfig.CurrentPage.As<CompanyPage>().CheckIfFacebookPageUrlIsCorrect();
        }


        [Then(@"I see company profile picture is loaded correctly")]
        public void CheckIfFacebookProfilePictureExists()
        {
            _parallelConfig.CurrentPage.As<CompanyPage>().CheckIfFacebookProfilePictureExists();
        }






    }
}
