using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Text.Json;

namespace MoqPowerShell.Tests
{
    [TestClass()]
    public class Program
    {
        [TestMethod()]
        public void GetLogAnalyticsSavedSearchTest()
        {            
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(@"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe","-noprofile & .\\PowerShellToMoqTest.ps1")
                {
                    WorkingDirectory = Environment.CurrentDirectory,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                }
            };
            process.Start();

            var reader = process.StandardOutput;
            var l =  reader.ReadToEnd();
            if (l.Contains("completed", StringComparison.InvariantCultureIgnoreCase))
            {
                //succeeded
                var jsonString = File.ReadAllText(".\\results.json");
                var testResults = JsonSerializer.Deserialize<List<DVTTest>>(jsonString);

                foreach (DVTTest test in testResults)
                {
                    Assert.AreEqual("Pass", test.Status);
                }

            }            
        }        
    }

    internal class DVTTest
    {
        public string TestName { get; set; }
        public string Status { get; set; }
    }
}
