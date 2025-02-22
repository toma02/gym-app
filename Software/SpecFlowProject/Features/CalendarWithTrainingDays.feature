Feature: CalendarWithTrainingDays

As a User
I want to be able to see days 
Where I have something to do
So that I can track my plans easier

Background: 
    Given I am logged in as registered user ivor
    And I am on the main page with said user ivor

Scenario: click on modify calories button
	Given I have selected wanted date
	And I have pressed choose date button
	When I click on modify calories button
	Then form for calory modification opens
