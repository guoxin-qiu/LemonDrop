@Account
@automated
Feature: US01 - User Registration
	In order to use the website
	As a potential user
	I want to register as a formal user

Scenario: Register successfully
	When I submit the following information on Register page
	| Email          | FirstName | LastName | Gender | Password  | ConfirmPassword |
	| denis@sydq.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       |
	Then I should see the following information on the Welcome page
	| Value                                |
	| Hello Qiu Denis, welcome to join us! |
	| Your account is denis@sydq.net       |

Scenario Outline: Register failed
	When I submit the following information on Register page
	| Email   | FirstName   | LastName   | Gender   | Password   | ConfirmPassword   |
	| <Email> | <FirstName> | <LastName> | <Gender> | <Password> | <ConfirmPassword> |
	Then I should see error messages '<ErrorMessage>' on the Register page
	Examples: 
	| Email         | FirstName | LastName | Gender | Password  | ConfirmPassword | ErrorMessage                                                       |
	|               | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is required'                                                |
	| invalid@      | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is not valid'                                               |
	| denis@qyq.net |           |          | Male   | p@55w0rd! | p@55w0rd!       | 'FirstName is required','LastName is required' |
	| denis@qyq.net | Denis     |          | Male   | p@55w0rd! | p@55w0rd!       | 'LastName is required'                                   |
	| denis@qyq.net | Denis     | Qiu      | Male   | p@55w     | p@55w           | 'Password must be longer than 5 characters'                        |
	| denis@qyq.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd        | 'Password not match'                                               |
	

