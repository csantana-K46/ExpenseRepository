Feature: ViewExpenseHistory
	In order to review my expenses
	As a User
	I want to view a list with my expenses in a given periot of time

@mytag
Scenario: View expense history
	Given I have an expenses stored
	Given I have entered "2014/02/01" and "2014/05/20" dates
	When I press search "History"
	Then the result should be a list with my expenses:
	|Id  |Amount  |RegisterDate |CategoryId|
	| 03 | 400.00 | 2014/02/10  | 02 |
	| 04 | 200.00 | 2014/03/10  | 02 |
	| 05 | 45600.00| 2014/04/10 | 01 |
	| 06 | 4000.00 | 2014/04/10 | 03 |
	| 07 | 4000.00 | 2014/04/10 | 03 |