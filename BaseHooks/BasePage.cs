using AutoDemoRefactor.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutoDemoRefactor.BaseHooks
{

    public enum BType
    {
        Chrome,
        Edge,
        Firefox
    }

    public class BasePage
    {

        public WebDriver browser;

        [SetUp]
        public void Start()
        {
            ChooseBrowser(BType.Edge);
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("Start-maximized", "Incognito");
            //browser = new ChromeDriver(options);
            //browser.Navigate().GoToUrl(Credentials.AutomationUrl);

        }
        public void ChooseBrowser(BType browserType)
        {
            if (browserType == BType.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized", "incognito");
                browser = new ChromeDriver(options);
                browser.Navigate().GoToUrl(Credentials.AutomationUrl);
                browser.Manage().Cookies.DeleteAllCookies();
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            else if (browserType == BType.Edge)
            {
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("start-maximized", "inPrivate");
                browser = new EdgeDriver(options);
                browser.Navigate().GoToUrl(Credentials.AutomationUrl);
                browser.Manage().Cookies.DeleteAllCookies();
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            else if (browserType == BType.Firefox)
            {
                browser = new FirefoxDriver();
                browser.Manage().Window.Maximize();
                browser.Navigate().GoToUrl(Credentials.AutomationUrl);
                browser.Manage().Cookies.DeleteAllCookies();
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            else
            {
                //Console.WriteLine("Browser Not Listed");
                throw new NoSuchDriverException("Browser Not Listed");

            }
        }
        [TearDown]
        public void End()
        {
                if (browser != null)
                {
                    browser?.Quit();
                    browser = null;
                }
        }
}   }

        