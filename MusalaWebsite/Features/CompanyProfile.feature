Feature: Company Profile
	Check if the company profile is loaded and facebook page

Background: 
	#Given 

@smoke @positive
Scenario: Check company profile is loaded correctly
	Given I Have navigated to the application
	And I see application opened
	When I Click company tab on top
	Then I see company page url is loaded correctly
	And I see leadership section on page
	When I Click facebook icon
	Then I see facebook page url is loaded correctly
	And I see company profile picture is loaded correctly


	
