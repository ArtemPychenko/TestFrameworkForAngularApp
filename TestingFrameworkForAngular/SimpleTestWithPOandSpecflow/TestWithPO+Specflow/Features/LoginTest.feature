Feature: Login test
	Login with correct user name and password

@Positive
Scenario: Login with correct user name and password
	Given I have navigated to the application
	And I see login page opened
	When I fill all fields with correct data
	| UserName | Password |
	| test     | test     |
	And I submit login form
	Then The Main page is opened
