Feature: Show the compare to feature
	In order to show the compare to features of SpecFlow Assist
	As a SpecFlow evanglist
	I want to show how the different versions of compareTo works


#Yes - this is a bug with the date format...
Scenario: CompareToInstance
	Given I have the following person
		| Field		 | Value		|
		| Name		 | Marcus		|
		| Style      | Butch		|
		| Birth date | 1972-10-09	|
	Then CompareToInstance should match this guy
		| Field		 | Value					|
		| Name		 | Marcus					|
		| Style      | Butch					|
		| BirthDate  | 10/9/1972 12:00:00 AM	| 
	And CompareToInstance should match this guy
		| Field		 | Value					|
		| Name		 | Marcus					|
		| BirthDate	 | 10/9/1972 12:00:00 AM	|
	But CompareToInstance should not match this guy
		| Field		 | Value					|
		| Name		 | Anders					|
		| Style      | very cool				|
		| BirthDate	 | 10/9/1974 12:00:00 AM	|