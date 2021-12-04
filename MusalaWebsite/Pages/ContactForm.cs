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
    class ContactForm : BasePage
    {

        public ContactForm(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }


        IWebElement TxtName => _parallelConfig.Driver.FindElement(By.Name("your-name"));
        IWebElement TxtEmail => _parallelConfig.Driver.FindElement(By.Name("your-email"));

        IWebElement TxtSubject => _parallelConfig.Driver.FindElement(By.Name("your-subject"));

        IWebElement TxtMessage => _parallelConfig.Driver.FindElement(By.Name("your-message"));







        public ContactForm Send(string email, string name, string subject, string message)
        {

            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement BtnSend = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("btn-cf-submit")));
            TxtName.SendKeys(name);
            TxtEmail.SendKeys(email);
            TxtSubject.SendKeys(subject);
            TxtMessage.SendKeys(message);
            BtnSend.Click();        

            return new ContactForm(_parallelConfig);
        }

        internal void CheckIfInvalidEmailMessageExists(string errorMessage)
        {
            WebDriverWait wait = new WebDriverWait(_parallelConfig.Driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement TipInvalidEmail = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("wpcf7-not-valid-tip")));
            TipInvalidEmail.AssertElementPresent();
            Assert.True(TipInvalidEmail.Text.Equals(errorMessage));
        }


    }


    
}
