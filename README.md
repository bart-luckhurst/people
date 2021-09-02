# people
A simple .NET Core API and Angular app to manage a list of people.

#### Features ####
- View all people
- Add a person
- Update a person
- Delete a person

#### View online ####
Angular App: https://people-angular.azurewebsites.net/
API: https://people-api.azurewebsites.net/swagger

#### API Overview ####
- Visual Studio
- .Net Core 3.1
- C# (No VB.Net...sorry James!)
- Entity Framework Core
- Controller => Service => Repository
- Global exception handling
- Automapper to map to DTOs
- Unit testing using xUnit and Moq
- Swashbuckle/Swagger
- Basic debug logging for simplicity - I would usually use NLog in the real world.

#### Steps to run the API ####
- Open in VS
- Change the connection string in appsettings.json
- EF Core will create the database for you on first run
- You should be good to go!

#### Front End Overview ####
- Angular 11
- scss for stylesheets
- Services with Observables and Subjects
- (Reckonise the colours??)

#### Steps to run the Angular App ####
- Open the folder "/Angular/people" in VS Code
- Configure the base url to point to the service in environment.ts
- Run from console: "ng serve --open"


#### Things I would do with more time ####
- Secure the service with JWT
- Obfuscate secrets
- Responsive front end
- A better (i.e more testable) approach for global exception handler
- A more sophisticated logging approach
- Improved styling & animations on the front end
- A favicon for the front end
