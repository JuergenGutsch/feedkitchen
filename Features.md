
# Manager Portal Features

* Register by
	* LinkedIn
	* FaceBook
	* GitHub
	* Manual
		* Full Name
		* Email
		* Password
* Reset password
* Login by
	* LinkedIn
	* FaceBook
	* GitHub
	* Manual
		* Email
		* Password
* Profile
	* Change password
		* via password reset link in email 
	* Change email
		* needs to be verified
* Overview Page
	* Show number of ingredients
		* quick links to manage
	* Show number of recipes		* quick link to manage
	* Show basic stats
		* views per recipe, etc.
	* Show issues like
		* uncerified ingredients
		* unavailable ingredients
		* unverified email
		* etc.
* Add Ingredient
	* Add Feed URL
	* Output verification Token
		* Instructions to add the token
	* button to verify
* Change Ingrdient
	* change feed url
	* Output verification Token
		* Instructions to add the token
	* button to verify
* Delete ingredient
	* only unused can be deleted
* Add / Manage Recipe
	* Title
	* Description
	* (Author will be set using profile information)
	* select ingredients
		* unverified can be configured but won't work	
	* add tag & category filters
	* preview
		* won't work with unverified ingrdients
* Menu Statistics
	* Views
	* Interactions
		* Open: View on source
		* Link cLick
		* Image click
	* Clients / Consumer
	* Location
		* Country
		* City
		* 

# Manager Portal Features

* Admin / configuration area
* Chef statistics
	* logins
	* location
	* recipes created
	* ingrdients created
* Menu statistics
	* Menues created
	* feeds used
	* items created
	* filter used
	* etc
* Ban Ingredients 
	* by hostname or IP
* Disable recipes
	* depending on tags, bad words etc.
* Manage chefs
	* disable
	* enable
	* change
	* etc
* Ban chefs
	* by email
	* 

# Waiter App features

* Serving the Cookec menu
* HTTP Endpoint using content negotiation to serve 
	* HTML
	* RSS
	* Atom
	* XML 
	* JSON
	* CSV
* 


# Buyer Function Requirements

* Azure function
* Loads fixings (feed items) based on the recipes
* Doesn't fetch unused ingredients
* Doens't fetch unverified ingredients
* saves the fixings (feed items) to th emenu
* stores all to the database
* 


## Cook Ffunction Requirements
* Azure function
* creates menus based on the recipes
* Uses recipe definition to create the menu
	* adds the fetched fixings (feed items) to it
	* filter the items 
* stores all into the database
* 

