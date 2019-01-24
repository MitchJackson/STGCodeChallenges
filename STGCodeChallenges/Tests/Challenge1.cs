using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using STGCodeChallenges.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STGCodeChallenges.Tests
{
    [TestFixture]
    class Challenge1 : TestBase
    {
        SkiUtah ski;

        [SetUp]
        public void setUp()
        {
            ski = new SkiUtah(Driver);
        }

        [Test]
        public void GoToSite()
        {
            Driver.Navigate().GoToUrl(ski.URL);

            IWebElement[] titles = Driver.FindElements(ski.Title).ToArray();
            string name = titles[0].GetAttribute("text");
            Console.WriteLine(name);
        }
    }
}
