Feature: ViewingExistingFitnessExercises

As a User,
I want to be able to view a list of existing fitness exercises,
So that I can choose the ones that suit my fitness goals and preferences.

Background: 
    Given I am logged in as registered user
    And I am on the main page

Scenario: Displaying a list of excercises
	Given I have selected the body part "Chest" and exercise equipment "Machine"
	When I click on the "Search" button
	Then I should see a list of exercises that fit my fitness goals and preferences

Scenario: Displaying a message when no body part is selected
    Given I have not selected a body part combobox
    And I have selected exercise equipment "Machine"
    When I click on the "Search" button
    Then I should see a message that prompts me to select a body part combobox

Scenario: Displaying a message when no an exercise equipment is selected
    Given I have not selected an exercise equipment combobox
    And I have selected a body part "Chest"
    When I click on the "Search" button
    Then I should see a message that prompts me to select an exercise equipment combobox 

Scenario: Displaying a message when nothing is selected
    Given I have not selected an exercise equipment and a body part combobox
    When I click on the "Search" button
    Then I should see a message that prompts me to select an exercise equipment and a body part comboboxes

Scenario: Clearing selected filters
    Given I have selected the body part "Chest" and exercise equipment "Machine"
    When I clear filters
    Then I should see filters that now have default value

Scenario: Displaying a new list of exercises after changing filters
    Given I have selected the body part "Chest" and exercise equipment "Machine"
	When I click on the "Search" button
    And I clear filters
    And I have selected the body part "Glutes" and exercise equipment "Barbell"
    Then I should see new list of excercises

Scenario: Displaying enlarged photo of selected exercise
    Given I have selected the body part "Chest" and exercise equipment "Machine"
    When I click on the "Search" button
    And I click on excercise image
    Then I should see enlarged photo of selected exercise

Scenario: Displaying more information of selected exercise
    Given I have selected the body part "Chest" and exercise equipment "Machine"
    When I click on the "Search" button
    And I click on Select button to show more info
    Then I should see more information of selected exercise