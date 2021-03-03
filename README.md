# FeedKitchen
A feedburner alternative based on C# and Azure

This will not burn the feeds, but cook them and serve them like a delicious menu ;-)

Components:

## Cook Portal
Enables the cooks (users) to cook (configure) their menus (feeds)

* Menu configuration
* Menu statistics


## Chef portal
Enables the chefs (admins) to manage the kitchen

* Admin / configuration area
* Cook stats
* Ban Ingredients 
* MAnage cooks
* Ban guests


## Menu Waiter
Is serving the cooked menus (target feeds)


## Ingredients Buyer
Is buying (fetches) the ingredients (source feed) on a regular basis


## Glossary

* Chef
  * Administrator
* Cook
  * User
* Guests
  * Consumers / Clients
* Kitchen
  * Application
* Menu
  * Target feed
* Ingredients
  * Source feed
* To cook
  * Building the target feed
* Waiter
  * Server
* Spices
  * Monetarization 


## Docker Compose
(not yet completely configured)

To run docker compose you need to add a `.env` file to the docker folder.

Currently this files contains the following variables:

``` env
# mongo
MONGO_INITDB_ROOT_USERNAME=youruser
MONGO_INITDB_ROOT_PASSWORD=yourtopsecretpassword

# mongo-express
ME_CONFIG_MONGODB_ADMINUSERNAME=youruser
ME_CONFIG_MONGODB_ADMINPASSWORD=yourtopsecretpassword
```

after that you can run `docker-compose up` to run the application