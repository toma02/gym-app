Feature: ConsumedCaloriesInDayModification

As a User
I want to be able to insert calories for a certaint day
So that I can track my calorie intake

Background: 
    Given I am logged in as registered user ivor
    And I am on the main page with said user ivor
	And I have entered calories form

Scenario: calorie insertion
	Given I clicked calories button
	When I enter calories into textbox
	And I click add button
	Then I get message with succesfull insertion of calories

Scenario: empty calorie insertion
	Given I clicked calories button
	When I click add button
	Then I get message with unsuccessful insertion of calories

Scenario: calorie insertion via groceries
	Given I clicked Foodstuff button
	When I choose groceries in combobox
	And I click insert grams button to insert grams
	And I enter grams into textbox
	And I click insert grams button to add groceries to day
	Then I get message with succesful insertion of groceries to day

Scenario: calorie insertion via groceries without picking groceries
	Given I clicked Foodstuff button
	When I click insert grams button to insert grams
	Then I get message with warning that I need to choose groceries

Scenario: calorie insertion via groceries without inputing number of grams
	Given I clicked Foodstuff button
	When I choose groceries in combobox
	And I click insert grams button to insert grams
	And I click insert grams button to add groceries to day
	Then I get message with warning that I need to insert grams

Scenario: Inserting groceries to database
	Given I clicked insert food button
	When I enter name of grocery into textbox
	And I click insert grams button to insert calories per 100 grams for grocery 
	And I enter calories per 100 grams into textbox
	And I click add button to add the grocery to database
	Then I get message with succesful insertion of grocery into database

Scenario: Inserting grocery to database that is already in database
	Given I clicked insert food button
	When I enter name of grocery into textbox
	And I click insert grams button to insert calories per 100 grams for grocery 
	And I enter calories per 100 grams into textbox
	And I click add button to add the grocery to database
	Then I get message with unsuccesful insertion of grocery into database

Scenario: Inserting grocery to database without name
	Given I clicked insert food button
	When I click insert grams button to insert calories per 100 grams for grocery
	Then I get message with warning that I need to insert name of grocery first

Scenario: Inserting grocery to database without calories per 100 grams
	Given I clicked insert food button
	When I enter name of grocery into textbox
	And I click insert grams button to insert calories per 100 grams for grocery
	And I click add button to add the grocery to database
	Then I get message with unsuccesful insertion of grocery into database

Scenario: Exiting form for calorie intake
	When I click cancel button
	Then The form closes

Scenario: inserting random characters into calories
	Given I clicked calories button
	When I enter random characters for calories into textbox
	And I click add button
	Then I get warning with unsuccesful insertion of calories

Scenario: inserting negativ numbers into calories
	Given I clicked calories button
	When I enter negativ numbers for calories into textbox
	And I click add button
	Then I get warning with unsuccesful insertion of calories

Scenario: Inserting groceries to database with random characters as grams
	Given I clicked insert food button
	When I enter name of grocery into textbox
	And I click insert grams button to insert calories per 100 grams for grocery 
	And I enter  random characters for calories per 100 grams into textbox
	And I click add button to add the grocery to database
	Then I get message with unsuccesful insertion of grocery into database

Scenario: Inserting groceries to database with negativ numbers for grams
	Given I clicked insert food button
	When I enter name of grocery into textbox
	And I click insert grams button to insert calories per 100 grams for grocery 
	And I enter negativ numbers for calories per 100 grams into textbox
	And I click add button to add the grocery to database
	Then I get message with unsuccesful insertion of grocery into database