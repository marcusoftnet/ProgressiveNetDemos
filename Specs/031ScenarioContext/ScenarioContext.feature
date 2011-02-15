Feature: Scenario Context
	In order to show how to use ScenarioContext.Current
	As a SpecFlow evangelist
	I want to write some simple scenarios with data in ScenarioContext

@mytag
Scenario: Store and retrive Person Marcus
	When I store a person called Marcus in the ScenarioContext.Current
	Then a person called Marcus can easily be retrieved