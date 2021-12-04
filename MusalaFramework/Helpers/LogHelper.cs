using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MusalaFramework.Configuration;

namespace MusalaFramework.Helpers
{
    public class LogHelper
    {

        // log file (Global Declaration - dynamic)
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;



        //Create a file which can store the log information
        public static void CreateLogFile()
        {
            
        }


        // create a method which can write the test in the log file
        public static void Write(String logMessage)
        {
            
        }


    }
}
