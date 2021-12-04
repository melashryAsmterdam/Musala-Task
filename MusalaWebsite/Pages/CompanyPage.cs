using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using MusalaFramework.Base;
using MusalaFramework.Extensions;

namespace MusalaWebsite.Pages
{
   internal class CompanyPage : BasePage
    {
        public CompanyPage(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }

        IWebElement linkFacebook => _parallelConfig.Driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/MusalaSoft?fref=ts']"));

        internal void CheckIfCompanyPageUrlIsCorrect()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.musala.com/company/"));
            Assert.True(_parallelConfig.Driver.Url.Equals("https://www.musala.com/company/"));
        }

        internal CompanyPage ScrollToLeadershipSection()
        {
            
            return new CompanyPage(_parallelConfig);
        }

        internal void CheckIfLeadershipSectionExists()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement SectionLeadership = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("company-members")));
            Actions actions = new Actions(_parallelConfig.Driver);
            ((IJavaScriptExecutor)_parallelConfig.Driver).ExecuteScript("arguments[0].scrollIntoView();", SectionLeadership);
            actions.MoveToElement(SectionLeadership);
            actions.Perform();
            SectionLeadership.AssertElementPresent();
        }

        public CompanyPage ClickFacebookLink()
        {
            Actions actions = new Actions(_parallelConfig.Driver);
            ((IJavaScriptExecutor)_parallelConfig.Driver).ExecuteScript("arguments[0].scrollIntoView();", linkFacebook);
            actions.MoveToElement(linkFacebook);
            actions.Perform();
            linkFacebook.Click();
            string currentTab = _parallelConfig.Driver.CurrentWindowHandle;
            foreach (string tab in _parallelConfig.Driver.WindowHandles)
            {
                if (!tab.Equals(currentTab))
                {
                    _parallelConfig.Driver.SwitchTo().Window(tab);
                }
            }
            return new CompanyPage(_parallelConfig);
        }

        internal void CheckIfFacebookPageUrlIsCorrect()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("facebook.com/MusalaSoft?fref=ts"));
            Assert.True(_parallelConfig.Driver.Url.Contains("facebook.com/MusalaSoft?fref=ts"));
        }

        internal void CheckIfFacebookProfilePictureExists()
        {
            
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement ImageProfile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div[3]/div[1]/div/div/div[1]/div/div/div[1]/div/div/div/a/div/img")));
            ImageProfile.AssertElementPresent();
            _parallelConfig.Driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
            Assert.True(ImageProfile.Displayed);
        }



    }
}
