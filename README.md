# Movie Review
### Purpose

A place where you can find movies that match your taste, talk to strangers about them and watch the movies together.

## Documentation

### Admin


| Movies                                          | Genres                                | People                                                        | Movie Crew                                                                  |
|-------------------------------------------------|---------------------------------------|---------------------------------------------------------------|-----------------------------------------------------------------------------|
| Getting the list of movies by year, actor or... | Getting Genre by id and their names   | Getting All the Actors and Directors by id and their names    | Getting All the Actors and Directors by id and their names                  |
| Adding movie with it's genres, cast and crew    | CRUD Operation                        | CRUD Operation                                                | Adding actor or director, one Person Entity can be both actor and director  |
| Uploading Movie Trailer to it's intended folder |                                       | Upload image of actor or director into their intended folder  | Upload image of actor or director into their intended folder                |

Admins will have their own dashboard to view everything and perform all kinds of operations on the Entities.

### User

There is no Authentication or Authorization with cookie or jwt with Identity even though i know how they work and how to implement and configure them, but i want to make my own simple authentication.

User will be able to Register and Login, have dashboard to change their properties, view and review movies, view cast and crew of the movie, view Movies that one actor or director have been part of and so on...


## Startup

in order to configure and run the project you need to do the following steps:

1. Clone the repository to your local machine:
   ```
   git clone https://github.com/IliyaRezaei/MovieReviewApi.git
   ```

2. Navigate to the project directory and open the MovieReviewApi.sln

3. Let the project download it's dependencies(nuget packages)

4. Open SSMS and create a database
   
5. copy the database connectionString -> open visual studio from the top select Tools/Connect to Database -> it opens a new window
   
6. In the new window Enter your server name, if its local enter . -> check the trust server certificate checkbox and click on "select or enter database name" and select your database and click on OK

7. Right click on the database select properties and copy the Connection String
   
8. Paste the connection string to appsettings.json like below (don't delete trust server certificate it might throw an error)
    
   ```
   "ConnectionString": {
       "MovieReview": "Your Connection String Here;Trust Server Certificate=True;"
   },
   ```

   ---This project surely needs more work, but currently i'm learning other things---
