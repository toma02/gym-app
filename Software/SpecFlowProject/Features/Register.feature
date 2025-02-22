Feature: Register

As a User
I want to be able to register to the application
So that it can provide me personalised experience

Scenario: Successful registration
	Given I am on the registration form
	When I enter a random firstname
	And I enter a random second name
	And I enter a random username
	And I enter a random email
	And I enter a random password
	And I click the register button
	Then I should be transferred to the fitness input form

Scenario: Username already exists
	Given I am on the registration form
	When I enter a random firstname
	And I enter a random second name
	When I enter a username "test"
	And I enter a random email
	And I enter a random password
	And I click the register button
	Then I should see Username already in use error message


Scenario: Password too short
	Given I am on the registration form
	When I enter a password "1234"
	And I click the register button
	Then I should see "Password must have alteast 6 chars!" error message under input field

