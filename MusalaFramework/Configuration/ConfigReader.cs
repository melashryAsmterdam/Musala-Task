using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MusalaFramework.Base;

using static MusalaFramework.Base.Browser;

namespace MusalaFramework.Configuration
{
    public class ConfigReader
    {

        public static void SetFrameworkSettings()
        {

            var _builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = _builder.Build();


            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            // Settings.IsReporting = SPTestConfiguration.SPSettings.TestSettings["staging"].IsReadOnly;
            Settings.LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            // Settings.AppConnectionString = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUTConnectionString;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;

        }


    }
}