using GoogleTrends_UITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Protractor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTrends_UITests
{
    public class TrendsPage : AbstractPage
    {
        private NgWebDriver _ngDriver;

        public TrendsPage(IWebDriver driver, string URL) : base(driver)
        {
            _ngDriver = new NgWebDriver(driver)
            {
                Url = URL
            };
            _ngDriver.WaitForAngular();
        }

        private readonly By MainSearchLocator = By.Id("input-254");
        private readonly By SearchAutoSuggestionDropListLocator = By.Id("ul-254");
        private readonly By HeaderTitleLocator = By.XPath("//a[contains(@class,'header-title')]/h1");
        public string GetPageTitle()
        {
            var element = _ngDriver.FindElement(HeaderTitleLocator);
            return element.GetAttribute("textContent");
        }

        public void FillInMainSearchInput(string searchQuery) 
        {
            _ngDriver.FindElement(MainSearchLocator).SendKeys(searchQuery);
            _ngDriver.WaitForAngular();
        }

        public ExplorePage SelectSuggestedOptionFromDropList(string searchQuery, string searchCategory)
        {
            FillInMainSearchInput(searchQuery);
            var sugestedElement = FindSuggestionValueFromDefinedCategory(searchCategory);
            sugestedElement.Click();
            return new ExplorePage(driver);
        }

        public bool CheckThatAutoSuggestedListHasValueFromDefinedCategory(string searchCategory)
        {
            try
            {
                var element = FindSuggestionValueFromDefinedCategory(searchCategory);
                return element.Displayed;
            }
            catch (NoSuchElementException) { return false; } 
        }

        private NgWebElement FindSuggestionValueFromDefinedCategory(string searchCategory) 
        {
            return _ngDriver.FindElement(By.XPath($"//ul/li//div[text()= '{searchCategory}']"));
        }

    }
}
