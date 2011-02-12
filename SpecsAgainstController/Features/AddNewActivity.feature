Feature: Add new activity
	In order to keep track of the activities I do at work
	As a consultant
	I want to be able to add a activity I have done

Background:
	Given the following activities in the database
		| Activity id | When       | Number of hours | Who    | At Customer      | Heading   | Description                     |
		| 1           | 2010-02-17 | 2               | Marcus | Alt.Net          | Fluent NH | Blixttal om Fluent NHibernate   |
		| 2           | 2011-01-17 | 4               | Marcus | LF               | Kanban    | En dragning om Kanban           |
		| 3           | 2011-02-17 | 2               | Anders | Avega            | BDD       | Beskrev vad BDD är för säljarna |
		And I am logged in as Marcus

@wip
Scenario: Add new item without any validation errors
	When I navigate to to the Add Activity page
		And I submit an activitiy with this information
				| Field			  | Value                      |
				| When			  | 2011-02-17                 |
				| Number of hours | 3                          |
				| Who             | Marcus                     |
				| At Customer     | Progressive .NET           |
				| Heading         | SpecFlow                   |
				| Description     | En dragning kring SpecFlow |
	Then I should be redirected the Activity list
	When I am redirected to the Activity list
	Then I should see the following activites
			| When       | NumberOfHours | Heading   | Description                   |			
			| 2010-02-17 | 2             | Fluent NH | Blixttal om Fluent NHibernate |
			| 2011-01-17 | 4             | Kanban    | En dragning om Kanban         |
			| 2011-02-17 | 3             | SpecFlow  | En dragning kring SpecFlow    |
