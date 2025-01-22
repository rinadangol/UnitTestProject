using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            
            
        }

        [TestMethod]
        public void TestMethod1()
        {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/#/");
                driver.Manage().Window.Maximize();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("search-query")).SendKeys("hammer");
                Thread.Sleep(4000);
                driver.FindElement(By.XPath("//button[contains(@class,'btn btn-secondary')]")).Click();
                Thread.Sleep(2000);
                new SelectElement(driver.FindElement(By.XPath("//select[contains(@class,'form-select')]"))).SelectByText("Name (A - Z)");
                Thread.Sleep(2000);
                //scroll down
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0,900)");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[text()=' ForgeFlex Tools']")).Click();
                //scroll up
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(-900,0)");

                IList<IWebElement> x = driver.FindElements(By.XPath("//div[contains(@class,'container')]"));
                // int i = 0;
                foreach (IWebElement element in x)
                {
                    Console.WriteLine(element.Text);
                }
                string actualPageTitle = "Practice Software Testing - Toolshop - v5.0";
                NUnit.Framework.Assert.That(actualPageTitle.Contains("Practice Software Testing"));
                
            }

        [TearDown]
        public void TearDown() 
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
        }
    }

