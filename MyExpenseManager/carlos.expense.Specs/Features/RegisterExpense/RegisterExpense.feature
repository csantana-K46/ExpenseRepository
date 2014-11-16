Feature: RegisterExpense
	In orde to keep track of my money
	As a User
	I want to register all my expenses associating
	Then with an expense category

Background: 
	Given the category "Food" exists

@mytag
Scenario: Add expense
	When I register an expense with the following data:
		| Field		| Value        |
		| Amount	| 200.00       |
		| Date		| 2014/11/01   |
		| Category	| Food         |
		
	Then it should notify 'Expense registered successfully'
	And the last expense registed should match:
	    | Field		| Value        |
		| Amount	| 200.00       |
		| Date		| 2014/11/01   |
		| Category	| Food         |


