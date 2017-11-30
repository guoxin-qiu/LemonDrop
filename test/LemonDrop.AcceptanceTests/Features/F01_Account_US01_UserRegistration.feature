@Account
@automated
@web
Feature: F01 - Account - US01 - User Registration
	In order to use the website
	As a potential user
	I want to register as a formal user

Scenario: Register successfully
	When I submit the following information on Register page
	| Email                | FirstName | LastName | Gender | Password  | ConfirmPassword |
	| denis@lemon-drop.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       |
	Then I should see the following information on the Welcome page
	| Value                                |
	| Hello Qiu Denis, welcome to join us! |
	| Your account is denis@lemon-drop.net |

Scenario: Register successfully again
	When I submit the following information on Register page
	| Email                 | FirstName | LastName  | Gender | Password  | ConfirmPassword |
	| test01@lemon-drop.net | Tester01  | LemonDrop | Female | p@55w0rd! | p@55w0rd!       |
	Then I should see the following information on the Welcome page
	| Value                                         |
	| Hello LemonDrop Tester01, welcome to join us! |
	| Your account is test01@lemon-drop.net         |

Scenario Outline: Register failed
	When I submit the following information on Register page
	| Email   | FirstName   | LastName   | Gender   | Password   | ConfirmPassword   |
	| <Email> | <FirstName> | <LastName> | <Gender> | <Password> | <ConfirmPassword> |
	Then I should see error messages '<ErrorMessage>' on the Register page
	Examples: 
	| Email                | FirstName | LastName | Gender | Password  | ConfirmPassword | ErrorMessage                                   |
	|                      | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is required'                            |
	| invalid@             | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd!       | 'Email is not valid'                           |
	| denis@lemon-drop.net |           |          | Male   | p@55w0rd! | p@55w0rd!       | 'FirstName is required','LastName is required' |
	| denis@lemon-drop.net | Denis     |          | Male   | p@55w0rd! | p@55w0rd!       | 'LastName is required'                         |
	| denis@lemon-drop.net | Denis     | Qiu      | Male   | p@55w     | p@55w           | 'Password must be longer than 5 characters'    |
	| denis@lemon-drop.net | Denis     | Qiu      | Male   | p@55w0rd! | p@55w0rd        | 'Password not match'                           |
	

