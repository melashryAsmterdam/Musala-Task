Feature: Contact Us
	Check if the contact us functionality is working
	as expected with invalid emails

Background: 
	#Given 

@smoke @positive
Scenario: Check contact us with invalid emails
	Given I Have navigated to the application
	And I see application opened
	And I Click contact button
	When I submit invalid <email> with correct <name>,<subject>,<message>
	Then Invalid <errorMessage> appears

Examples:
		| name  |  email   | subject  | message |               errorMessage            |
		| test1 |test@test | subject1 | message | The e-mail address entered is invalid.|
		| test2 |test2@test| subject2 | message | The e-mail address entered is invalid.|
		| test3 |test3     | subject3 | message | The e-mail address entered is invalid.|
		| test4 |test4.com | subject4 | message | The e-mail address entered is invalid.|
		| test5 |test5@    | subject5 | message | The e-mail address entered is invalid.|