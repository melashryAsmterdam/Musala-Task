using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace MusalaFramework.Base
{
    public class ParallelConfig
    {

        public WebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }

    }
}
