Feature: ContextInjection
	I want to share common data between step bindings

#Step defs for these steps can be found in Steps/BackgroundSteps.cs
Background:
	Given an inline horizontal table with one row of data like this
		| Username  | Password     |
		| edgewords | edgewords123 |
	* or an inline vertical table like this
		| Field     | Value |
		| FirstName | John  |
		| LastName  | Doe   |
		| Age       | 42    |
	And even a table with multpile rows
		| Sku    | Name                      |
		| Cap    | The Best cap in the world |
		| Jumper | An OK Jumper              |

#Step defs for these steps can be found in Steps/ScenarioSteps.cs
#In order to get data between BackgroundSteps.cs and ScenarioSteps.cs context injection must be used
Scenario: Getting the above data using ScenarioObject context injection
	Then we write out the horizontal table
	And we write out the verticle table
	And we loop through multirow table
	But we can also get at an individual rows data directly

Scenario: Getting the data by injecting custom POCOs
	Then we access the horizontal POCO
	Then we access the vertical POCO


