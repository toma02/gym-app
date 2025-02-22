Feature: Login

As a User
I want to be able to login to the application
So that I can access to its features


Scenario: username and password not provided
    Given I am on the login form
	When I click Login button
	Then I should see "Credentials can't be empty" error message

Scenario: Invalid credentials
    Given I am on the login form
	When I enter a username "someUsername"
	And I enter a password "wrong password"
	And I click Login button
	Then I should see "Invalid credentials!" message


Scenario: Successfull login
    Given I am on the login form
	When I enter my username "testerr"
	And I enter corresponding password "testtest"
	And I click Login button
	Then I should be transferred to the main application window
