using FluentAssertions;
using GoogleTrends_UITests.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GoogleTrends_UITests.FeatureFiles.StepClasses
{
    [Binding]
    public class ExplorePageSteps
    {
        private IWebDriver _driver;
        private ExplorePage _explorePage;

        public ExplorePageSteps(IWebDriver driver, ExplorePage explorePage) {
            _driver = driver;
            _explorePage = explorePage;
        }

        [When(@"I set '(.*)' value into Geo input and select '(.*)' sub-location")]
        public void WhenISetValueIntoGeoInputAndSelectSub_Location(string parentLocation, string childLocation)
        {
            _explorePage
                .InputGeoFilter(parentLocation)
                .HoverAndExpandSuggestionOption(parentLocation)
                .ClickOnSuggestionOption(childLocation);
        }
        
        [Then(@"Explore page have related queries")]
        public void ThenExplorePageHaveRelatedQueriesForMyRequest()
        {
            _explorePage.GetRelatedQueries().Should().HaveCountGreaterOrEqualTo(1, "At lease 1 relater query expected.");
        }
    }
}
