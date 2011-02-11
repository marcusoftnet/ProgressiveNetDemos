Feature: Navigating the activity list
	In order to keep track on what's happening in the company
	As a user
	I want to see the current activities

Background:
	Given the following activities in the database
		| Activity id | When       | Number of hours | Who    | At Customer      | Heading  | Description                     |
		| 1           | 2011-02-17 | 2               | Marcus | Progressive .NET | SpecFlow | En dragning kring SpecFlow      |
		| 2           | 2011-01-17 | 4               | Marcus | LF               | Kanban   | En dragning om Kanban           |
		| 3           | 2011-02-17 | 2               | Anders | Avega            | BDD      | Beskrev vad BDD är för säljarna |

@spec @marcusoftnet
Scenario: Navigating the Activity list
	When I go to the Activity list
	Then I should see the following activites
		| When       | NumberOfHours | Heading  | Description                     |
		| 2011-02-17 | 2             | SpecFlow | En dragning kring SpecFlow      |
		| 2011-01-17 | 4             | Kanban   | En dragning om Kanban           |
		| 2011-02-17 | 2             | BDD      | Beskrev vad BDD är för säljarna |
	
@spec @marcusoftnet
Scenario: When Marcus view the activity list he only sees his activites
	Given I am logged in as Marcus
	When I go to the Activity list
	Then I should see the following activites
		| When       | NumberOfHours | Heading  | Description                     |
		| 2011-02-17 | 2             | SpecFlow | En dragning kring SpecFlow      |
		| 2011-01-17 | 4             | Kanban   | En dragning om Kanban           |
