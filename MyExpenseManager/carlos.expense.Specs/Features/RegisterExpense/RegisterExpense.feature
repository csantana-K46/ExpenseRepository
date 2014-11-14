Feature: RegisterExpense
	In orde to keep track of my money
	As a User
	I want to register all my expenses associating
	Then with an expense category

Background: 
	Given I have entered the category information

@mytag
Scenario: Add expense
	Given I want to keep the next expense information:
		| Field			| Value        |
		| ID			| 1            |
		| Amount		| 200.00       |
		| DateAdd		| 2014/11/01   |
		| Category	| Food         |
		
	When I press the add button
	Then I should see the message "Expense added successfully"
	And aggregated expense information


