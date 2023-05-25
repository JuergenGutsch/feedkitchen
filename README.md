# FeedKitchen
A feedburner alternative based on C# and Azure

This will not burn the feeds, but cook them and serve them like a delicious menu ;-)

Components:

## Chef Portal
Enables the chefs (users) to define (configure) their recipes (feeds)

* Menu configuration
* Menu statistics


## Manager portal
Enables the managers (admins) to manage the kitchen

* Admin / configuration area
* Chef stats
* Ban Ingredients 
* Manage chefs
* Ban guests


## Waiter App
Is serving the cooked menus (target feeds)


## Buyer Function
Is buying (fetches) the ingredients (source feed) on a regular basis


## Glossary

* Manager
  * Administrator
* Chef
  * User who defines the Menus
* Guests
  * Consumers / Clients who consumes the Menu
* Kitchen
  * The entire application
* Waiter
  * App that serves the target feed
* Buyer
  * Function App that fetches the Ingredients from the source feed
* Doorman
  * Authentication app
* Recipe
  * Definition of the Menu
  * Containes Ingredients defined by the Chef
* Ingredients
  * A set of source feeds
* Fixings
  * A set of boght Ingredients to cook to get the Menu
  * The actual feed items from the source feeds 
* Menu
  * Target feed
  * cooked out of the Recipe and the Fixings
* To buye
  * Fetching the Ingredients from the source feeds
* To cook
  * Building the Menu out of the Recipe and the fetched Ingredients
* Spices
  * Monetarization, Styling and stuff

