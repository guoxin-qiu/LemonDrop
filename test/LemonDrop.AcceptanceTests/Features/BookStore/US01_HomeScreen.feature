@automated
@BookStore
@web
Feature: US01 - Home Screen
	As a potential customer
	I want to see the books with the best price
	So that I can save money on buying discounted books.

Background:
	Given the following books
		|Author			|Title								|Price	|
		|Martin Fowler	|Analysis Patterns					|50.20	|
		|Eric Evans		|Domain Driven Design				|46.34	|
		|Ted Pattison	|Inside Windows SharePoint Services	|31.49	|
		|Gojko Adzic	|Bridging the Communication Gap		|24.75	|

Scenario: Cheapest 3 books should be listed on the home screen
	When I enter the bookstore
	Then the home screen should show the following books
		|Title								|
		|Bridging the Communication Gap		|
		|Inside Windows SharePoint Services	|
		|Domain Driven Design				|


