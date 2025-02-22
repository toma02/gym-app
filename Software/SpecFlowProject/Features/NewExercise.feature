Feature: NewExercise


Scenario: Valid credentials
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened user control for adding new exercise by clicking "Add Exercise" button.
	When I enter exercise name "Naziv4.1.1"
	And I enter exercise description "Opis4.1.1"
	And I enter exercise video "https://www.youtube.com/watch?v=4Y2ZdHCOXok"
	And I enter exercise difficulty "5"
	And I select "Chest" from bodypart dropdown menu
	And I select "Barbell" From equipment dropdown menu
	And I press the button "Save"
	Then The exercise should be added and no error messages should pop up


Scenario: No input for exercise description
Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened user control for adding new exercise by clicking "Add Exercise" button.
	When I enter exercise name "Naziv4.1.3"
	And I leave exercise description empty
	And I enter exercise video "https://www.youtube.com/watch?v=4Y2ZdHCOXok"
	And I enter exercise difficulty "5"
	And I select "Chest" from bodypart dropdown menu
	And I select "Barbell" From equipment dropdown menu
	And I press the button "Save"
	Then The exercise should be added and no error messages should pop up

Scenario: No input for exercise video
Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened user control for adding new exercise by clicking "Add Exercise" button.
	When I enter exercise name "Naziv4.1.4"
	And I enter exercise description "Opis4.1.5"
	And I leave exercise video empty
	And I enter exercise difficulty "5"
	And I select "Chest" from bodypart dropdown menu
	And I select "Barbell" From equipment dropdown menu
	And I press the button "Save"
	Then The exercise should be added and no error messages should pop up

Scenario: No exercise difficulty
Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened user control for adding new exercise by clicking "Add Exercise" button.
	When I enter exercise name "Naziv4.1.6"
	And I enter exercise description "Opis4.1.6"
	And I enter exercise video "https://www.youtube.com/watch?v=4Y2ZdHCOXok"
	And I leave exercise difficulty empty
	And I select "Chest" from bodypart dropdown menu
	And I select "Barbell" From equipment dropdown menu
	And I press the button "Save"
	Then A pop up window should appear saying I need to enter a number for the exercise difficulty



