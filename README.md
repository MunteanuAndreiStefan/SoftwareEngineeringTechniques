# Real time fake news detection
Project for advanced software engineering techniques subject on Distribuited System master

Functional Requirements:
  - Information will be collected from Twitter (posts, user information (number of posts, folowers, account creation date, etc.))
  - User profiles will be built (characterized by details about the user, user activity, reactions of other users to what he does on the network, etc.)
  - A metric will be proposed to calculate the credibility of a post
  - A metric will be proposed for credibility of a user
  - A metainformation should be taken into consideration
  - Methods will be proposed to detect "fake" users and "fake" news
  - We could have a list of fake users centralized in order to get a better response, after the front-end is putting the user in a category
  - Resources we will be centralized in order to get faster responses for already processed news
  - Resources will be used outside the Twitter network to validate the information (Google, blogs, newspapers, etc.)
  - Fronted will be able to show extra information about metrics
  - Fronted will be able to edit the stric level of the marking
  - Fronted will show analized resources
  - All users will be unique
  - User posibility to mark a post as fake manually

Actors:
  - Any user that will have the plugin installed

Use Cases:
  - User will be able to install the plugin from a store
  - User will be able to disable/enable the application.
  - User will be able to set the maximum/minimum level of marking a news as fake
  - User will be able to see results from a news
  - User will be able to see what resources we found
  - User will be able to open those resources

Non-Functional Requirements:
  - Cache centralized system for all the users
  - Nothing on security side for the final product due it's created only for academic purposes
  - The application will run for chrome and firefox
  - Level of trust per user, calculated with a Bayes/ML/Statistical methods over semantic or non semantic data
  - Take advantage of posts metadata
  - "Layers of trust" in order to say as fast as possible if a post is fake or not
  - Parser with BS4 in order to get information from trusted websites
  - Implement a crawler maybe with google in order to find credible sources

Team members:
  - Munteanu Andrei-Ștefan - Contact member
  - Răzvan Baisan
  - Crîșnuţã Iulian-Gabriel
  - Victor Vlad
  - Pantelemon Victor-Stefan
  - Ursu Vlad-Florin

Link to our development page:
https://munteanuandreistefan.github.io/SoftwareEngineeringTechniques/
