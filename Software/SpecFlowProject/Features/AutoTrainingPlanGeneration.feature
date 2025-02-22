Feature: AutoTrainingPlanGeneration

As a user
I want an option that will automatically generate a training plan for me
So I dont have to

Scenario: All fields properly fillled
	Given I am on the AutoPlanGenerationForm
	When I enter a "MyGeneratedPlan" plan name
	And I select my goal
	And I select plan length
	And I select training frequency
	And I select training volume
	And I select wanted training days
	And I click generate button
	Then A training plan should appear in my downloads folder


Scenario: Plan name not provided
	Given I am on the AutoPlanGenerationForm
	When I click generate button
	Then error "Please give your plan a valid name (3+ chars)" will be under plan input field



