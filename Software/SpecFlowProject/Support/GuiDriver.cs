﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Support
{
    public static class GuiDriver
    {
        private static WindowsDriver<WindowsElement> driver;
        public static WindowsDriver<WindowsElement> GetOrCreateDriver()
        {
            if (driver == null)
            {
                driver = CreateDriverInstance();
            }
            return driver;
        }
        public static WindowsDriver<WindowsElement> GetDriver()
        {
            return driver;
        }
        private static WindowsDriver<WindowsElement> CreateDriverInstance()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Users\Matija\source\repos\tkipp-tjuic-irosic-mtomasic-mkljaic\Software\FoiFitness\bin\Debug\net6.0-windows\FoiFitness.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            var wd = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"),
           options);
            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return wd;
        }

        public static void Dispose()
        {
            foreach (var wh in driver.WindowHandles)
            {
                driver.SwitchTo().Window(wh);
                driver.CloseApp();
            }
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }
}
