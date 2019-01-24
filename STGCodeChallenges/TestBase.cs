using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGCodeChallenges
{
    public class TestBase
    {
        #region GlobalVARS
        // !! Global Browsers !!
        public const string BROWSER_Firefox = "firefox";
        public const string BROWSER_Chrome = "chrome";
        public const string BROWSER_IE = "ie";
        #endregion
        public static IWebDriver Driver { get; set; }
        public static WebDriverWait Wait { get; set; }

        public static int TIMEOUT_IMPLICITWAIT_SECS;
        public static int TIMEOUT_PAGELOAD_SECS;
        public static string browser;

        protected virtual void SetImplicitWaitTimeOut()
        {
            TIMEOUT_IMPLICITWAIT_SECS = 10;
        }

        protected virtual void SetPageLoadTimout()
        {
            TIMEOUT_PAGELOAD_SECS = 30;
        }

        protected virtual void SetBrowser()
        {
            //browser = "Chrome";
            browser = BROWSER_Chrome;
        }

        [OneTimeSetUp]
        public void InitialSetUp()
        {
            SetImplicitWaitTimeOut();
            SetPageLoadTimout();
            SetBrowser();

            switch (browser)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    options.AddArguments("use-fake-ui-for-media-stream");
                    Driver = new ChromeDriver(options);
                    break;
                case BROWSER_Firefox:
                    Driver = new FirefoxDriver();
                    break;
                case BROWSER_IE:
                    Driver = new InternetExplorerDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT_IMPLICITWAIT_SECS);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TIMEOUT_PAGELOAD_SECS);
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(TIMEOUT_IMPLICITWAIT_SECS);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TIMEOUT_IMPLICITWAIT_SECS));

            Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            if (Driver != null)
                Driver.Quit();
        }
    }
}
