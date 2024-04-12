Feature: mmtBookTicket

Will try to booka ticket from BBS to BLR
@Chrome
Scenario Outline: Search and book a flight ticket on MakeMyTrip
    Given I am on the MakeMyTrip website 'https://www.makemytrip.com/'.
    When I search for a flight from "<SourceCity>" to "<DestinationCity>" on "<DepartureDate>"
    And I select "<NumberOfPassengers>" passengers and "<TravelClass>" class
    And I click on the search button
    Then I should see a list of available flights
    When I select a flight
    And I proceed to book the flight
    Then I should be redirected to the booking page
    And I should be able to complete the booking process

Examples:
    | SourceCity    | DestinationCity | DepartureDate | NumberOfPassengers | TravelClass |
    | Delhi         | Mumbai          | 2024-05-01    | 2                  | Economy     |
    | Bengaluru     | Kolkata         | 2024-05-15    | 1                  | Business    |