# What is this?
This repository presents the main concepts of Clean Architecture and best practices. In this project we will be moving from a monolithic solution containing a single project to a solution containing 5 projects where each project will be assigned specific responsibilities and where we will define the relationships between projects respecting the principles of clean architecture and the dependency rule.The final solution will have the following projects: Domain, Application, Infrastructure, IoC and the presentation project, which is an ASP.NET Core MVC / ASP.NET Web API application, where we will apply separation of responsibilities, dependency injection , use some Domain Drive Design concepts and implement the Repository and CQRS standards.

# How to run

##### 1 - Clean the solution.
```
dotnet clean
```
##### 2 - Restore the packages.
```
dotnet restore
```
##### 3 - Build the solution!
```
dotnet build
```
##### 4 - And them run it!
```
dotnet run
```
