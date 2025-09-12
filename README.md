# 📦 Postal Company Management System

A simple postal company management system built with **Clean Architecture** principles, featuring modern .NET technologies and best practices.



## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
📁 PostalCompany.API/          # Presentation Layer (Minimal APIs)
📁 PostalCompany.Application/  # Application Layer (Business Logic)
📁 PostalCompany.Domain/       # Domain Layer (Entities, Interfaces)
📁 PostalCompany.Infrastructure/ # Infrastructure Layer (Data Access)
```

## 🛠️ Technologies & Patterns

### Core Technologies
- **.NET 9** - Latest .NET framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database engine
- **JWT Bearer Authentication** - Secure authentication

### Design Patterns & Practices
- **Clean Architecture** - Maintainable and testable design
- **Repository Pattern** - Data access abstraction
- **MediatR** - In-process messaging (CQRS)
- **CQRS** - Command Query Responsibility Segregation
- **Minimal APIs** - Lightweight endpoint definitions
- **Dependency Injection** - Loose coupling and testability

## 🎯 Project Structure

### **API Layer** (Presentation)
- **Endpoints/** - Minimal API endpoint definitions
- **Extensions/** - Service registration and configuration
- **Program.cs** - Application entry point and startup

### **Application Layer** (Business Logic)  
- **Features/** - CQRS implementation
  - **Authentication/** - Login/Register commands and queries
  - **Missions/** - Mission management features
- **Interfaces/** - Application service contracts
- **DTOs/** - Data transfer objects for API communication

### **Domain Layer** (Core Business)
- **Entities/** - Core domain entities
  - **Driver.cs** - Driver entity and business rules
  - **Manager.cs** - Manager entity and operations  
  - **Mission.cs** - Mission entity and workflow
- **Common/** - Base entities and shared domain logic

### **Infrastructure Layer** (External Concerns)
- **Data/** - Entity Framework DbContext and configurations
- **Repositories/** - Repository pattern implementation
- **Services/** - External services 

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

