﻿Feature: Basket
	In order to know how much I'm spending
	As a shopper
	I want to be told the price of my basket
	
Scenario: Empty basket
	Given I have an empty basket
	When I check my basket
	Then the price should be 0

Scenario: Single item in basket
	Given I have item A in my basket
	When I check my basket
	Then the price should be 50

Scenario: Lots of undiscounted items in basket
	Given I have items ABCD in my basket
	When I check my basket
	Then the price should be 115

Scenario: Several discounts in basket
	Given I have items AACBAADBAA in my basket
	When I check my basket
	Then the price should be 340