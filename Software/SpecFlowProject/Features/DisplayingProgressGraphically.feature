Feature: DisplayingProgressGraphically

As a fitness enthusiast, I want to be able to track my progress visually 
by displaying my workout progress in the form of a graph, 
so that I can easily see how far I've come

Background: 
    Given I am logged in as registered user
    And I am on the main page
	And I go to the chart generator page

Scenario: Displaying weight progress chart with a correctly selected time range
	Given I choosed start and end date for the weight progress chart
	When I click on the Display Chart button for the weight progress chart
	Then I should see generated weight progress chart

Scenario: Displaying a message when start date is not choosed for the weight progress chart
	Given I choosed end date for the weight progress chart
	When I click on the Display Chart button for the weight progress chart
	Then I should see message that prompts me to select a start date for the weight progress chart

Scenario: Displaying a message when end date is not choosed for the weight progress chart
	Given I choosed start date for the weight progress chart
	When I click on the Display Chart button for the weight progress chart
	Then I should see message that prompts me to select a end date for the weight progress chart

Scenario: Displaying a message when time range is not selected at all for the weight progress chart
	When I click on the Display Chart button for the weight progress chart
	Then I should see message that prompts me to select whole time range for the weight progress chart

Scenario: Displaying calories intake chart with a correctly selected time range
	Given I choosed start and end date for the calories intake chart
	When I click on the Display Chart button for the calories intake chart
	Then I should see generated calories intake chart

Scenario: Displaying a message when start date is not choosed for the calories intake chart
	Given I choosed end date for the calories intake chart
	When I click on the Display Chart button for the calories intake chart
	Then I should see message that prompts me to select a start date for the calories intake chart

Scenario: Displaying a message when end date is not choosed for the calories intake chart
	Given I choosed start date for the calories intake chart
	When I click on the Display Chart button for the calories intake chart
	Then I should see message that prompts me to select a end date for the calories intake chart

Scenario: Displaying a message when time range is not selected at all for the calories intake chart
	When I click on the Display Chart button for the calories intake chart
	Then I should see message that prompts me to select whole time range for the calories intake chart