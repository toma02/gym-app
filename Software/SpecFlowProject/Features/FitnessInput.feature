Feature: FitnessInput

As a user
I want to be able to provide my fitness goals and current stats
So the application can generate me personalised training plans


@tag1
Scenario: All information provided
	Given I am on the fitness input form
	When I enter my gender
	And I enter my age
	And I enter my weight
	And I enter my height
	And I select my daily activity rate
	And I click save button
	Then I should be transferred to the main application window

Scenario: Gender not selected
	Given I am on the fitness input form
	When I click save button
	Then An error message should appear under the gender combobox

Scenario: Age not provided
	Given I am on the fitness input form
	When I click save button
	Then an error message should appear under the age input field
