# Employee Management System

## Overview

- A web application to manage employee records with CRUD operations using ASP.NET 9.0.
- Built with Clean Architecture and CQRS (using MediatR) for scalability and maintainability.
- Uses Azure SQL for the backend database and Basic Authentication for secure access.

## Key Features

- **CRUD Operations**: Create, Read, Update, and Delete employee records.
- **Clean Architecture**: Clear separation between business logic and infrastructure.
- **CQRS**: Command and query operations are handled separately for better performance.
- **Basic Authentication**: Simple user authentication for secure access to data.
- **Hybrid Caching**: In-memory (L1) and distributed (L2) cache for improved performance.
- **Central NuGet Package Management**: Manage all NuGet packages and versions centrally across the solution.

## Caching Strategy

- **L1 Cache (In-memory)**: Fast access to frequently used data.
- **L2 Cache (Distributed)**: Redis or SQL Server for scalable caching across multiple instances.

## Caching Features

- **Cache Stampede Protection**: Prevents simultaneous cache misses.
- **Tag-based Invalidation**: Efficiently invalidates related cache entries.
- **Configurable Serialization**: Flexibility in how data is serialized for cache storage.
- **Metrics & Monitoring**: Track cache hit/miss rates and performance.

## Central NuGet Package Management

- **Centralized Management**: Define package versions in one file (`Directory.Packages.props`).
- **Automatic Updates**: Add or update packages across projects in one place.
- **Easy Reference**: Reference packages without specifying versions in project files.

## Technology Stack

- **Backend**: ASP.NET 9.0, Azure SQL, MediatR (for CQRS), Clean Architecture.
- **Authentication**: Basic Authentication.
- **Caching**: Hybrid Cache (L1 and L2 with Redis/SQL Server).
- **Package Management**: Central NuGet Package Management.
