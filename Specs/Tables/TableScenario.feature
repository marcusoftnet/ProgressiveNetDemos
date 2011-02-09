Feature: Showing table usage
	In order to show how to use tables
	As a SpecFlow evanglist
	I want to write some simple scenarios that uses tables tables

Scenario: Select from list - old school
	Given I have the following persons
		| Name		| Style		| Birth date | Cred |
		| Marcus    | Cool		| 1972-10-09 | 50   |
		| Anders    | Butch		| 1977-01-01 | 500  |
		| Jocke     | Soft		| 1974-04-04 | 1000 |
	When I search for Jocke
	Then the following person should be returned
		| Name		| Style		| Birth date | Cred |
		| Jocke     | Soft		| 1974-04-04 | 1000 |