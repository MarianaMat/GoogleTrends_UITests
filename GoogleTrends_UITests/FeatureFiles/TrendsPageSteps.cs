using FluentAssertions;
using GoogleTrends_UITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GoogleTrends_UITests.FeatureFiles.StepClasses
{
    [Binding]
    public class TrendsPageSteps
    {
        private IWebDriver _driver;
        private TrendsPage trendsPage;
        private ExplorePage explorePage;

        public TrendsPageSteps(IWebDriver driver )
        {
            _driver = driver;
        }

        [Given(@"I have navigated to the Google Trends page")]
        public void GivenIHaveEnteredIntoTheSearchBarAndSelectedAnOptionFromTheSuggestionList()
        {
            trendsPage = new TrendsPage(_driver, "https://trends.google.com/");
            trendsPage.GetPageTitle().Should().Be("Trends");
        }

        [Given(@"I have entered '(.*)' into the search bar and selected an option from '(.*)' category")]
        public void GivenIHaveEnteredIntoTheSearchBarAndSelectedAnOptionFromTheSuggestionList(string searchQuery, string category)
        {
            explorePage = trendsPage.SelectSuggestedOptionFromDropList(searchQuery, category);
            explorePage.GetPageTitle().Should().Be("Explore");
        }

        [When(@"I have entered unique text value into the main search bar")]
        public void WhenIHaveEnteredUniqueTextValueIntoTheMainSearchBar()
        {
            var uniqueTextInput = Guid.NewGuid().ToString("n").Substring(0, 8);

            trendsPage.FillInMainSearchInput(uniqueTextInput);
        }

        [Then(@"I see '(.*)' category at the suggestion drop-list")]
        public void ThenISeeCategoryAtTheSuggestionDrop_List(string category)
        {
            var elementExist = trendsPage.CheckThatAutoSuggestedListHasValueFromDefinedCategory(category);
            elementExist.Should().BeTrue();
        }

    }
}
