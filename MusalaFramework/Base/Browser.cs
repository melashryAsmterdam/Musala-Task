using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace MusalaFramework.Base
{
    public class Browser
    {
        private readonly DriverContext driverContext;

        public Browser(DriverContext driver)
        {
            driverContext = driver;
        }

        public BrowserType Type { get; set; }

        

    }

   

        public enum BrowserType
        {
            
            MSEdge,
            Chrome,
            Firefox
        }

    }

