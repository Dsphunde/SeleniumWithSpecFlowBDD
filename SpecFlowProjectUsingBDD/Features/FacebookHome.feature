Feature:FacebookHome Page Login

A short summary of the feature

@Smoke @Regression @Application
Scenario Outline: To chcek the login functionality for the facebook with invalid credentials
	Given user navigate to the facebook home page
	When user enters the username as <username> and password as <Password>
	And user click on the login button
	Then login should be unsuccessful

	Examples: 
	| username | Password  |
	| Deepak   | Funde@314 |
	|   Neha   |   Funde   |