using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTrends_UITests.PageObjects
{
    public class ExplorePage : AbstractPage
    {
        private NgWebDriver _ngDriver;

        public ExplorePage(IWebDriver driver) : base(driver)
        {
            _ngDriver = new NgWebDriver(driver);
            log.Info("User navigates into Explore page");
            _ngDriver.WaitForAngular();
        }
        private readonly By GeoPickerXpath = By.XPath("//hierarchy-picker[@track-name='geoPicker']");
        private readonly By GeoInputXpath = By.XPath("//hierarchy-picker[@track-name='geoPicker']//input[@type = 'search']");
        private readonly By RelatedQueriesXpath = By.XPath("//trends-widget[@widget-name='RELATED_QUERIES']//div[@class = 'item']");
        private readonly By HeaderSubTitleLocator = By.XPath("//h2[@class='header-sub-title']");

        private readonly string suggestedListXpathString = "//ul[@class='md-autocomplete-suggestions']/li";

        public string GetPageTitle()
        {
            var element = _ngDriver.FindElement(HeaderSubTitleLocator);
            return element.Text;
        }
        

        public ExplorePage InputGeoFilter(string geoInputValue)
        {
            _ngDriver.FindElement(GeoPickerXpath).Click();
            _ngDriver.FindElement(GeoInputXpath).SendKeys(geoInputValue);
            log.Info($"User input '{geoInputValue}' to the Geo Picker");
            return this;
        }

        public ExplorePage HoverAndExpandSuggestionOption(string value)
        {
            var suggestedOption = GetElementOnSuggestionList(value);
            new Actions(_ngDriver)
                .MoveToElement(suggestedOption)
                .Perform();
            suggestedOption.FindElement(By.XPath(suggestedListXpathString+"//md-icon[@role = 'button']")).Click();
            return this;
        }
        public ExplorePage ClickOnSuggestionOption(string value)
        {
            GetElementOnSuggestionList(value).Click();
            log.Info($"User clicks on '{value}' drop-list value ");
            return this;
        }

        public IList<NgWebElement> GetRelatedQueries() 
        {
            return _ngDriver.FindElements(RelatedQueriesXpath);
        }

        private NgWebElement GetElementOnSuggestionList(string value) 
        {
            return _ngDriver.FindElement(By.XPath(suggestedListXpathString + $"//span[contains(text(),'{value}')]"));
        }
    }
}