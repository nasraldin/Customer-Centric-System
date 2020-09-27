# Customer Centric System

This project use .Net Core 3.1

- .NET Core 3.1
- Entity Framework Core 3.1
- IdentityServer4
- MediatR
- Autofac
- AutoMapper
- FluentValidation
- Refit

## Project spec

- Clean Architecture
- DDD
- MediatR
- Seeding initial data by using Code First approach
- Logging and Exception Handling
- Inter-commutation between services secured (OAUTH). 
- API Versioning 

## Development

Core
This will contain all entities, exceptions, interfaces, types and logic specific to the domain layer.

Infrastructure
This layer contains all application logic and classes for accessing external resources.

Api
This layer is a RestApi application based and .NET Core API 3.1. This layer depends on the Infrastructure layer.

## Services

## OAuth
IdentityServer

## CustomerService
CustomerService.Core
CustomerService.Infrastructure
CustomerService.API - this service call account service to get list of accounts releat to cutomer

## AccountService
AccountService.Core
AccountService.Infrastructure
AccountService.API

## StatementService
StatementService.Core
StatementService.Infrastructure
StatementService.API

## How to run
Set Startup project from sulotion and make 3 services start (IdentityServer, CustomerService.API, AccountService.API, StatementService.API) 
