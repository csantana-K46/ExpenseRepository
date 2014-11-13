Feature: RegisterExpense
	In orde to keep track of my money
	As a User
	I want to register all my expenses associating
	Then with an expense category

@mytag
Scenario: Add expense
	Given I have entered expense money for this Expense:
		| Field			| Value        |
		| ID			| 1            |
		| Amount		| 200.00          |
		| DateAdd		| 2014/11/01   |
		| CategoryId	| 1            |
		
	When I press the add button
	Then the user should see a message Expense successfully added


