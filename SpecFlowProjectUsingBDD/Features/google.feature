@E2E 
Feature:search in google home page
#We can provide comment in feature file by using # 

Background: 
   Given Google page open
   When Search text box should be present and enabled in the google home page

@Intigration @Regression
Scenario: search java Tutorial
	When User search a tutorial with a keyword Java Tutorial
	And Click on enter button
	Then All courses related to java tutorial should be dispaly

	#By using @ignore tag we can ignore specific scenario
	@ignore
	Scenario: search Spec flow Tutorial
	When User search a tutorial with a keyword SpecFlow Tutorial
	And Click on enter button
	Then All courses related to SpecFlow tutorial should be dispaly

	@UAT
	Scenario Outline: search google home page with different keywords Tutorial for git test
	When User search a tutorial with a keyword <Text> Tutorial
	And Click on enter button
	Then All courses related to <Text> tutorial should be dispaly

	@Smoke @Regression
	Examples: 
	| Text      |
	| Java      |
	| SpecFlow  |

