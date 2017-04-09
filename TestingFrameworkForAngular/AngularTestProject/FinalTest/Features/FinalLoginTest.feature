Feature: Shop login test
	Check if learning Angular page opened correctly through site menu

@Positive
Scenario: Open learning Angular page through site menu
	Given I have navigated to the website
	And I see main page page opened
	When I click Get started button
	Then The quickstartpage opened
	When I click learning angular link
	Then The learning angular page opened
