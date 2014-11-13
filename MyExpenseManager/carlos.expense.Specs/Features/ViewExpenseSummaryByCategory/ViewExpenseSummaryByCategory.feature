Feature: ViewExpenseSummaryByCategory
	In order to know in what things I spent my money
	As a User
	I want to see a summary specifying how much I spent in each expense category in a period of time

@mytag
Scenario: View expense summary by category
	Given I have an expenses stored
	When I press search "Summary"
	Then the result should be the next set of data:
	| Amount  | RegisterDate | CategoryId |
	| 430.00 | 2014/01/10   | 01         |
	| 45600.00 | 2014/04/10   | 01         |
	| 400.00 | 2014/02/10   | 02         |
	| 200.00 | 2014/03/10   | 02         |
	| 8000.00 | 2014/04/10   | 03         |
