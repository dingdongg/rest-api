# MVC REST API

## Description of the project
---
`rest-api`, like the name suggests, is a RESTful API that holds information about the various different commands that can be used on different platforms/frameworks (many of which are quite difficult to retain by memory).

The API supports basic CRUD (create/read/update/delete) operations, with update having 2 distinct methods: PATCH and UPDATE.

## Frameworks used
---
This project was primarily built upon the .NET 5.0 Core framework. Please see `APIProject.csproj` for an exhaustive list of frameworks employed as part of this project.

## Implementation details
---
Here, I go over the key things that drove my implementation from start to end.

### ***Model-View-Controller pattern***
I used the Model-View-Controller (MVC) design pattern for the main architecture of this API. 

- The *model* class is a representation of the data at the level of the API, which also includes some data annotations to impose restrictions on the types of accepted values. (See `/Models`) 

- The *controller* class essentially houses all of the API endpoints and handles the various HTTP requests as necessary. In all cases, each method handles a unique HTTP request and returns the appropriate status code back to the client, along with additional information whenever necessary. (See `/Controllers`)

- The *view* portion of the MVC pattern was not implemented, as I didn't implement this API with the intention of clients interacting with it through a UI.

### ***Dependency Injection***
Dependency injection allows for different parts of an application to be connected without being directly connected to one another. This leads to a decoupling between the involved components. 

In my project, the repository and the controller were the components at play. By separating the interface (`ICommanderRepo`) and its implementation details, I allowed the implementation of the repository (`SqlCommanderRepo`) to change at any time down the road (as long as I upheld the signatures defined as part of the interface).

In order to link the controller and the repository, I injected a dependency on `ICommanderRepo` into `CommandsController`. This way, my controller doesn't need to know any of the implementation details of the repository. 

This increases the scalability of this API, as well as its flexibility in choosing which implementation (eg. SQL Server, Oracle, etc.) to stick with.

### ***Data Transfer Objects***
Sending HTTP responses back with raw, domain-level resources imposes a number of issues, such as transmission of irrelevant data and/or potential security issues.

But more importantly, this introduces coupling. By sending domain-level data back to the client, I would be exposing my API's internal implementation details to the client, which violates the REST principle of client-server decoupling. My API should remain as a black box to my clients, and data transfer objects (DTOs) assisted with this decoupling.

DTOs are also objects that are mapped from the domain-level data. They are created for the sole purposes of transmission to the client. They can be considered the "polished" versions of domain-level data, as they can omit/tweak certain resource attributes before being mapped, which allows sensitive/unnecessary information to be held securely within our API/database. The mapping from domain-level data to DTOs were done through the use of automappers.

## Testing
---
Each API endpoint was thoroughly tested via Postman HTTP requests. SQL Server Express was also used to ensure that data was being stored correctly within our database.
