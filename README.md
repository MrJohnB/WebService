![.NET Core](https://github.com/MrJohnB/WebService/workflows/.NET%20Core/badge.svg)

# Introduction
WebService is a simple REST API implementation written in ASP.NET Core that allows for the basic CRUD operation via a REST web service.  The main purpose is the investigate and demonstrate the best practices for implementing a caching middleware.  The use of PATCH to do a partial update will also be demonstrated.

The solution is comprised of 3 components:
1.	WebService.Api is a REST API that allows for client applications to interact with the Web API.  Provides simple data access.
2.	WebService Tests is a set of unit tests and integration tests to automate testing of the system components.

Additional components:
- Simple in memory database using .NET DataSet and DataTable classes to store all the data used for the system.

#Tech Stack
1.	.NET Core 3.1 (for Web API)
2.	.NET Standard 2.1 (for libraries)
3.	.NET DataTable (for database)
4.	Swagger (API documentation)
5.	Serilog (logging)
6.	Docker (containers)

# Problem Statement

Demonstrate how to implement caching middleware for an ASP.NET Core REST API application.  Demonstrate how to use PATCH to do partial updates via RESTful service.

A solution called WebService will be developed to perform the required operations.

# Requirements

1.	Create a simple REST API.
2.	Implement caching middleware.
3.	Implement partial update (PATCH).
4.	Use Docker.

Note: See below for links to code repositories.

# Documentation
- [README.md] (https://github.com/MrJohnB/WebService/blob/master/README.md)

# GitHub
- [RunLog Project] (https://github.com/users/MrJohnB/projects/2)
- [RunLog Repository] (https://github.com/MrJohnB/WebService)

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
- Build the solution in Visual Studio 2019 and run.
TODO: Describe and show how to build your code and run the tests.

# Contribute
- [RunLog Repository] (https://github.com)
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)