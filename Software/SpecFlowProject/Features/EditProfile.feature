Feature: EditProfile

Scenario: Valid credentials
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window to edit profile clicking the profile button.
	When I enter "Pero" for name
	And I enter "Peric" for last name
	And I enter "85" for weight
	And I enter "TestiranjeTestiranje" for password
	And I enter "TestiranjeTestiranje" to confirm password
	And I click the button "Save"
	Then The profile is edited and no error messages should pop up

Scenario: Name input contains special characters
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window to edit profile clicking the profile button.
	When I enter "Pero/(" for name
	And I click the button "Save"
	Then An error message should appear saying that name can't contain any special characters

Scenario: Last name input contains special characters
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window to edit profile clicking the profile button.
	When I enter "Peric/(" for last name
	And I click the button "Save"
	Then An error message should appear saying that last name can't contain any special characters

Scenario: Weight input contains letters
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window to edit profile clicking the profile button.
	When I enter "85kg" for weight
	And I click the button "Save"
	Then An error message should appear saying that I must enter numeric values for weight

Scenario: Passwords do not match
	Given User is logged in to the application using username "TestiranjeTestiranje" and password "TestiranjeTestiranje" and has opened a window to edit profile clicking the profile button.
	When I enter "Password123" for password
	And I enter a different passoword to confirm password
	And I click the button "Save"
	Then An error message should appear saying that passwords do not match

