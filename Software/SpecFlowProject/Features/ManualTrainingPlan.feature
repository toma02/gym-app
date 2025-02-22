Feature: ManualTrainingPlan


Scenario: Valid input for training plan
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click create training plan button
	And I enter training plan name "Naziv5.1.1"
	And I enter description "Opis5.1.1"
	And I enter training plan duration "5"
	And I select volume from Plan volume dropdown
	And I select type from Plan type dropdown
	And I click "Save" button
	Then The training plan should be created and no error messages should pop up

Scenario: No input for training plan description
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click create training plan button
	And I enter training plan name "Naziv5.1.3"
	And I enter training plan duration "5"
	And I select volume from Plan volume dropdown
	And I select type from Plan type dropdown
	And I click "Save" button
	Then The training plan should be created and no error messages should pop up

Scenario: Invalid input for training plan duration
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click create training plan button
	And I enter training plan name "Naziv5.1.4"
	And I enter description "Opis5.1.4"
	And I enter training plan duration "abc"
	And I select volume from Plan volume dropdown
	And I select type from Plan type dropdown
	And I click "Save" button
	Then A pop up window should appear saying I need to enter a numeric value for duration


Scenario: Valid input for training
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click create training button
	And I select a training plan from choose a training plan dropdown
	And I select a date from Date dropdown
	Then The training should be created and no error messages should pop up

Scenario: Valid input for training exercise
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click add exercise info button
	And I select Bench press from Select exercise dropdown
	And I enter training exercise "3" sets
	And I enter training exercise "8" repetitions
	And I enter training exercise "10" duration
	And I select a training from Training dropdown
	And I click "Save" button
	Then Exercise info should be added and no error messages should pop up

Scenario: Invalid input for exercise duration
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click add exercise info button
	And I select Bench press from Select exercise dropdown
	And I enter training exercise "3" sets
	And I enter training exercise "8" repetitions
	And I enter training exercise "abc" duration
	And I select a training from Training dropdown
	And I click "Save" button
	Then A pop up window should appear saying I need to enter a numeric value for duration, reps or sets

Scenario: User has selected a training plan to send to their mail
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I select a training plan to send to mail from Choose a plan dropdown
	And I click send to mail button
	Then I should get an email with selected training plan

Scenario: User hasn't selected a training plan to send to their mail
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window for creating a new training plan by clicking a button "Create training plan"
	When I click send to mail button
	Then A pop up window should appear saying I need to select a value from Choose a plan dropdown