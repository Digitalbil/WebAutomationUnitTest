using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using OpenQA.Selenium;

namespace WebAutomationUnitTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var driver = new ChromeDriver())
			{
				try
				{
					string curDir = Directory.GetCurrentDirectory();
					driver.Url = new Uri(String.Format("file:///{0}/Index.html", curDir)).ToString();
					driver.Navigate();

                    var element = driver.FindElement(By.ClassName("btnHello"));
                    element.Click();

                    Thread.Sleep(5000);
				}
				catch (Exception)
				{

					throw;
				}

				
			}
		}

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void TestUndefinedElement()
        {
            using (var driver = new ChromeDriver())
            {
                try
                {
                    string curDir = Directory.GetCurrentDirectory();
                    driver.Url = new Uri(String.Format("file:///{0}/Index.html", curDir)).ToString();
                    driver.Navigate();

                    var element = driver.FindElement(By.ClassName("btnHello_not"));
                    element.Click();

                }
                catch (Exception)
                {

                    throw;
                }


            }
        }
	}
}
