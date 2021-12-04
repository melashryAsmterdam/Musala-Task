using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using MusalaFramework.Configuration;
using MusalaFramework.Helpers;
using TechTalk.SpecFlow;


namespace MusalaFramework.Base
{

    public class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelper.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelper.Write("Initialized framework");

        }

        
        private void OpenBrowser(DriverOptions driverOptions)
        {
            

            switch (driverOptions)
            {
                case EdgeOptions edgeOptions:

                    driverOptions = new EdgeOptions();
                    _parallelConfig.Driver = new EdgeDriver();

                    break;

                case FirefoxOptions fireFoxOptions:

                    driverOptions = new FirefoxOptions();
                    _parallelConfig.Driver = new FirefoxDriver();

                    break;

                case ChromeOptions chromeOptions:
                   // chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);

                    chromeOptions.AddAdditionalOption(CapabilityType.EnableProfiling, true);
                    _parallelConfig.Driver = new ChromeDriver();

                    break;
            }

        }


        public virtual void NavigateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelper.Write("Opened the browser !!!");
        }

        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.MSEdge:
                    return new EdgeOptions();

                case BrowserType.Firefox:
                    return new FirefoxOptions();

                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }

    }
}
