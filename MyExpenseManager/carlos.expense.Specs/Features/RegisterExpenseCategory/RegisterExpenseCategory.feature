Feature: RegisterExpenseCategory
	In order to be able to categoryze my expenses
	As a User
	I want to be able to register an expense category

@mytag
Scenario: Add category
	Given I have entered the category information
		| Field | Value  |
		| Name  | "Food" |
	When I press add
	Then it should notify 'Category registered successfully'
	And the last category registered should match:
		| Field | Value  |
		| Name  | "Food" |