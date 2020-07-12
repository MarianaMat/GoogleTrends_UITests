Feature: ExplorePageTests

@Browser:Chrome
@Browser:Firefox
Scenario: User filter explore results by location and verify that related queries applied 
	Given I have navigated to the Google Trends page
	Given I have entered 'Selenium' into the search bar and selected an option from 'Software' category
	When I set 'Israel' value into Geo input and select 'Tel Aviv' sub-location 
	Then Explore page have related queries
