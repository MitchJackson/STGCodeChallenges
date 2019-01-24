using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGCodeChallenges.PageObjects
{
    class SkiUtah
    {
        IWebDriver Driver;

        public SkiUtah(IWebDriver d)
        {
            Driver = d;
        }

        public string URL = "https://www.skiutah.com/";

        //elements
        public By Title { get { return By.XPath("/html/head/title"); } }
        public By MainLogo { get { return By.CssSelector(".HeaderMain-logoImg"); } }
    }
}
