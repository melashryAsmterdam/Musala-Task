using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace MusalaFramework.Base
{

    public class DriverContext
    {

        public readonly ParallelConfig _parallelConfig;

        public DriverContext(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void GoToUrl(string url)
        {
            _parallelConfig.Driver.Url = url;
        }


        public static Browser Browser { get; set; }

    }
}

