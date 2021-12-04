using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using MusalaFramework.Base;

namespace MusalaFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T , bool> condition , int timeOut )
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }

            
        }

        public static IWebElement FindById(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementById(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementById(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not found : {element}");
            }
            return null;
        }


    }

}



