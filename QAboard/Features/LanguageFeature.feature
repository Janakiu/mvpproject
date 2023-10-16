Feature: LanguageFeature

As a mars Page portal admin
I would like to create, edit and delete for language records
So that I can manage language records successfully


Scenario:Adding a language to the user profile
Given I successfully logged into website
When  I create a language into profile '<Language>' and '<LanguageLevel>'
Then The created record '<Language>' and '<LanguageLevel>' been created successfully

Examples: 
| Language	| LanguageLevel		|
| Telugu	| Native/Bilingual	|  


Scenario Outline:Edit existing language and level with valid details
Given I successfully logged into website
When  I update '<Language>' and '<Level>' on an existing language and levels record
Then  The record should been updated '<Language>' and '<Level>'

Examples: 
| Language | Level     |
| Telugu   | Fluent    |


Scenario Outline:Delete existing language and level with valid details
Given I successfully logged into website
When  I delete '<Language>' on an existing language record
Then  The language record should be deleted and the message display as '<Language>' has been deleted from your languages

Examples:
| Language | Level  |
| Telugu   | Fluent |
