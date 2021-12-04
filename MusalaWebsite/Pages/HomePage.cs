using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using MusalaFramework.Base;
using MusalaFramework.Extensions;
using System.Threading;

namespace MusalaWebsite.Pages
{
   internal class HomePage : BasePage
    {
        public HomePage(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }


        IWebElement linkFacebook => _parallelConfig.Driver.FindElement(By.XPath("//a[@href='https://www.facebook.com/MusalaSoft?fref=ts']"));


        public ContactForm ClickContactButton()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            IWebElement BtnContact = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='contacts-title']/div/a[1]/button")));
            Actions actions = new Actions(_parallelConfig.Driver);
            ((IJavaScriptExecutor)_parallelConfig.Driver).ExecuteScript("arguments[0].scrollIntoView();", BtnContact);
            actions.MoveToElement(BtnContact);
            actions.Perform();
            BtnContact.Click();
            return new ContactForm(_parallelConfig);
        }

        public CompanyPage ClickCompanyTab()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            IWebElement TabCompany = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='menu']/ul/li[1]/a")));
            ((IJavaScriptExecutor)_parallelConfig.Driver).ExecuteScript("arguments[0].click();", _parallelConfig.Driver.FindElement(By.XPath("//div[@id='menu']/ul/li[1]/a")));
            return new CompanyPage(_parallelConfig);
        }


        internal void CheckIfContactButtonExists()
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            IWebElement BtnContact = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='contacts-title']/div/a[1]/button")));
            BtnContact.AssertElementPresent();
        }

    }
}