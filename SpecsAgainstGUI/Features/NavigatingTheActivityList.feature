Feature: Navigating the activity list
	In order to keep track on what's happening in the company
	As a user
	I want to see the current activities

@spec_gui @marcusoftnet
Scenario: Navigating the Activity list
	When I go to the Activity list
	Then I should see a list of Activities for Administrator

@wip @spec_gui @marcusoftnet
Scenario: Navigate to Create new Activity
	Given I am on the Activity list
	When I click the Create New link
	Then I should be on the Create Activity page

