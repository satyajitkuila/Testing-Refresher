@Chrome
Feature: mmtBooking

Test E2E flow of MMT ticket booking


Scenario Outline: Navigate to Login Page and LogIn
	Given User is Navigated to MMT home page with url 'https://www.makemytrip.com/'.
	When User enter <UserName> and <Password>
	And Click on the LogIn button
	Then Successful LogIN message should display
Examples:
	| UserName                     | Password    |
	| 'samuelwitwicky56@gmail.com' | 'kanhu@143' |
	| 'samuelwitwicky@gmail.com'  | 'kanhu@143' |
