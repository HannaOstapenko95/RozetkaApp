Feature: SendingMessage
	In order to receive an answer to the question
	As a user of website
	I want to be send message to website administrator

@mytag
Scenario: Send valid message
	Given I am on the Contact page
	And I have entered Hanna into the Name field
	And I have entered 345-23-45 into the Phone field
	And I have entered dareta@simcorp.com into the Email field
	And I have entered "What is your the most popular mobile phone among women?" into the Message field
	When I press submit
	Then I should see "Your email has been sent" text on the screen

@mytag
	Scenario: Send message with invalid phone number
	Given I am on the Contact page
	And I have entered Hanna into the Name field
	And I have entered aaaaa into the Phone field
	And I have entered dareta@simcorp.com into the Email field
	And I have entered "What is your the most popular mobile phone among women?" into the Message field
	When I press submit
	Then I should see "The Phone field is not a valid phone number." text on the contact screen

@mytag
	Scenario: Send message with empty name
	Given I am on the Contact page
	And I have entered  into the Name field
	And I have entered 0932170955 into the Phone field
	And I have entered dareta@simcorp.com into the Email field
	And I have entered "What is your the most popular mobile phone among women?" into the Message field
	When I press submit
	Then I should see "The Name field is required." text on the contact screen

@mytag
	Scenario: Send message with empty phone
	Given I am on the Contact page
	And I have entered Olena into the Name field
	And I have entered  into the Phone field
	And I have entered dareta@simcorp.com into the Email field
	And I have entered "What is your the most popular mobile phone among women?" into the Message field
	When I press submit
	Then I should see "The Phone field is required." text on the contact screen

@mytag
	Scenario: Send message with empty email
	Given I am on the Contact page
	And I have entered Olena into the Name field
	And I have entered 0932170955 into the Phone field
	And I have entered  into the Email field
	And I have entered "What is your the most popular mobile phone among women?" into the Message field
	When I press submit
	Then I should see "The Email field is required." text on the contact screen


@mytag
	Scenario: Send message with empty message
	Given I am on the Contact page
	And I have entered Olena into the Name field
	And I have entered 0932170955 into the Phone field
	And I have entered dareta@simcorp.com into the Email field
	And I have entered "" into the Message field
	When I press submit
	Then I should see "The Message field is required." text on the contact screen
