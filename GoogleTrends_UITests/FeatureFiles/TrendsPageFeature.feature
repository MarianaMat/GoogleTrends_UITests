Feature: TrendsPageFeature


@Browser:Chrome
@Browser:Firefox
Scenario: User can filter by any value that doesn't relate to any category
	Given I have navigated to the Google Trends page
	When I have entered unique text value into the main search bar 
	Then I see 'Search term' category at the suggestion drop-list
