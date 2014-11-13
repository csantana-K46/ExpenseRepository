Feature: RegisterExpenseCategory
	In order to be able to categoryze my expenses
	As a User
	I want to be able to register an expense category

@mytag
Scenario: Add category
	Given I have entered the category information
		| Field | Value    |
		| ID    | 1        |
		| Name  | "Comida" |
	When I press add
	Then the result should see a message Category successfully added
