Feature: Product
	Create, Read and Update a product

@mytag
Scenario: Read a Product with below details
	Given I have supplied 1 as product Id
	Then product details should be
	|Id | Name	| Quantity	|
	|1	|Milk	| 2			|

Scenario: Read All Product with below details
	When No product supplied All product list should return
	|Id | Name	| Quantity	|
	|1	|Milk	| 2			|
	|2	|Banana	| 6			|
	|3	|Apple	| 4			|

Scenario: Add new Product with below details
	When product required attributes provided
	|Id | Name	| Quantity	|
	|1	|Mango	|4			|

