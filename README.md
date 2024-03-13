# FeedKitchen
A feedburner alternative based on C# and Azure that doesn't burn your feeds.

This will not burn your feeds, but cook them and serve them like a delicious menu ;-)

## Scenario
You are the chef, creating recipes for delicious menus. 
You are specifying the ingredience, which can be just one or many different. 
Salt and pepper and other spyces are additions to make it even more delicious for your guests.
Since you are the chef and not just a cook, the engine will cook the menu gor you. 
It will buy the ingredience, cut it and cook it as you defined to create the menu, and will even serve it yo your guest.
Do you like to be the chef?

### Scenario translated to tech speak
You are creating definitions for your new feed. 
You are specifying the source feeds, which can be one or many different.
Monetising, tag filters, and styles make your feed more relevant yo your users.
The engine will do all the rest for you.
It will fetch the latest feed items from the sources, order it and create a complete new feed for you to send it to the users.
Do you like defie feeds in a new way.

## secuity
### data protection
The ingredients need to be verified. 
You can't just fetch any ingredient you like to create a completely new feed.
This is because ingredients shouldn't be stolen. 
If the ingredient is yours, just add a verification tag to it.
If it's not your ingredient, ask the owner to add a verification tag. 
Once the verification tag was found on the ingredient, the engine will buy it.
Once a year the verification tag need to be renewed, jsut to be sure. 
THe ingredient owner will also be able to add a stop tag to the feed to revoke the verification. 
Just in case verification tag was added by accident or without the owners approval.
See it as a eko label on the ingredients and we just veryfy if the ingredient is really eko.
### Statistic security
One of the main features is the statistics about the guest.
The IP address get's trackt to just get the municipal area of the guest. Once we have that location we will delete the IP address. 
The user agent get's trackt and generalized to the general name and version of the client. Any additional data will be deleted.
We will track the reading time, the date and time when the feed item was opened.
We will gice a cookie to the guest, to recognize him once he comes back. We just add a generic token to the cookie. This is to track track if guests come back. 
We will track clicks on links and doensloads of images. To do this we will change links in the content tag and the link tag. We do so to track interactions with the menu. 

We won't add methods to track the age and gender of the guests. 
### general security
Chefs need to authintacate against the FeedKitchen using a valid email. 
The authentication can be done via Google, Facebook or Microsoft. We don't store any credentials. Only the email and a full name is needed and stored to send reports and notification.
The chef is able to add more information to the profile besides the email and the full name. 


<!--
## Lizenses
FeedKitchen will be available for you with two licenses:
* OpenSource for personal and non-profit organizations use
* Commercial in case you are a commercial organization
  * Includes direct support

## SaaS
FeedKitchen SaaS will be available 
* for free for personal and non-profit use
  * up to a specific amount of traffic
  * includes 5 ingredient
  * one output feed
  * basic stats
* basic for comercial use
  * best for small companies
  * up to a specific amount of traffic
  * includes 25 ingredients
  * 5 output feeds
  * basic stats
* extended for commercial use
  * best for midsized companies
  * up to a specific amount of traffic
  * includes 100 ingredients
  * 25 output feeds
  * AI driven stats
* maximum for commercial use
  * best for big companies
  * up to a specific amount of traffic
  * includes 1000 ingredients
  * 250 output feeds
  * AI driven stats
-->

# Components:

## Chef Portal
Enables the chefs (users) to define (configure) their recipes (feeds)

* Ingredient configuration	
  * source feeds
* Recioe definition
  *	Meta information
  * add ingredients
  	* tag filtere
* Menu statistics
  * interaction
  * reading time
  * clients
  * regions

The user (chef) will be able to register a specific amound of source feeds (ingredients) 
depending on the license used.
The user will be able to define a specific amount of source feeds (recipes) by setting meta information 
like menu name, description, author, etc. He also can add one or more source feeds 
(ingredients) and filter the source feeds by tag or category. This way he can create completely new 
feeds out of source feeds.
The user would also be able to just register one source feed and to define a single target feed without 
any filters just to use the statistics.
The needs to be authenticated ant the feeds need to be verified (see above)


## Manager portal
Enables the managers (admins) to manage the kitchen

* Admin / configuration area
* Chef statistics
* Menu statistics
* Ban Ingredients
* Manage chefs
* Ban chefs/emails


## Waiter App
Is serving the cooked menus (target feeds)
Is basically an HTTP Endpoint that serves the feed to the client as defined in the accept header.
Means the browser will see a HTML page. A feed reader get's RSS or Atom. If you prefer basic XML, just accept it. The default will be JSON. 
* HTML
* RSS
* Atom
* XML 
* JSON
* 

## Cook function


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
  * Monetarization, Filtering, Styling and stuff

# further ideas

* AI driven stats
* AI chef
