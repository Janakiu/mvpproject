Feature: SkillsFeature

As a mars Page portal admin
I would like to create, edit and delete for skills records
So that I can manage skills records successfully

Scenario: Adding skill to user profile
Given I successfully logged into Project Mars website
When  I create a skill into profile '<Skill>' and '<SkillLevel>'
Then  The created skill '<Skill>' and '<SkillLevel>' been created successfully

Examples: 
| Skill | SkillLevel |
| Html  | Beginner   |

Scenario Outline:Edit existing skill and level with valid details
Given I successfully logged into Project Mars website
When  I update '<Skill>' and '<Level>' on an existing skill and levels record
Then The Skill record should been updated '<Skill>' and '<Level>'

Examples: 
| Skill | Level        |
| Html  | Intermediate |

Scenario Outline:Delete existing skill and verify message
Given I successfully logged into website
When  I delete '<Skill>' on an existing skill record
Then  The skill record should be deleted and the message display as'<Skill>' has been deleted

Examples: 
| Skill  | Level        |
| Html   | Intermediate |