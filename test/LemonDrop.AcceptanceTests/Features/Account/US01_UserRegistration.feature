@Account
@automated
Feature: US01 - User Registration
	In order to use the website
	As a potential user
	I want to register as a formal user

Scenario: Register successfully
	When I register with the following information
	| Email          | FirstName | LastName | Gender | Password  | ConfirmPassword |
	| denis@sydq.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       |
	Then I should see the following information on the welcome screen
	| Value                                      |
	| Denis Qiu                                  |
	| denis@sydq.net                             |
	| Register successfully! Welcome to join us! |

Scenario Outline: Register failed
	When I register with the following information
	| Email          | FirstName | LastName | Gender | Password  | ConfirmPassword |
	| denis@sydq.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       |
	Then I should see '<Error Messages>' on the screen
	Examples: 
	| Email         | FirstName | LastName | Gender | Password  | ConfirmPassword | ErrorMessage                                                       |
	|               | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is required'                                                |
	| invalid@      | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is not valid'                                               |
	| denis@qyq.net |           |          | Male   | p@55w0rd! | p@55w0rd!       | 'The FirstName field is required','The LastName field is required' |
	| denis@qyq.net | Denis     |          | Male   | p@55w0rd! | p@55w0rd!       | 'The LastName field is required'                                   |
	| denis@qyq.net | Denis     | Qiu      | Male   | p@55w     | p@55w           | 'Password must be longer than 5 characters'                        |
	| denis@qyq.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd        | 'Password not match'                                               |
	

