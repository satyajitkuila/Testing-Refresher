Feature: bookFlightBkingdtcom

A short summary of the feature

@DataSource:FlightTestData.xlsx @DataSet:Sheet1
Scenario: User is able to book tickets from the website
	Given user is on the home page with <Url> given.
	And user is not seeing any alerts and popUp.
	Then Click on the flight bokking link.
	When user is on flight booking page provide the <journey_type> to book.
	Then user provides from <FromDest> field .
	Then user provides <ToDest> field	
	Then user provides <Date> on the picker.
	And User click on Search buttton.
	Then User is shown Flight resultz to choose from.
