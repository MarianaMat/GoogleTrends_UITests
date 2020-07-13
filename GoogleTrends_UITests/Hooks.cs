using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GoogleTrends_UITests
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;


        private readonly IObjectContainer _iObjectContainer;

        public Hooks(ScenarioContext scenarioContext, IObjectContainer iObjectContainer)
        {
            System.Threading.Thread.Sleep(3000);
            _scenarioContext = scenarioContext;
            _iObjectContainer = iObjectContainer;
        }

        [BeforeScenario()]
        public void BeforeScenarioChrome()
        {
            _scenarioContext.TryGetValue("Browser", out var browser);

            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            //_scenarioContext.ScenarioContainer.RegisterInstanceAs(_driver);
            _iObjectContainer.RegisterInstanceAs(_driver);
            _driver.Url= "https://trends.google.com/";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {

                _driver.Quit();
           
        }
       

    }
}
