### [Curotec Task Management Frontend](https://github.com/jeanlopes/curotec_task_front_app)
FYI: In case we need I also put the frontend folder on the backend repository.

# Curotec Task Management API

## Project Overview
The Curotec Task Management API is a backend application designed to manage tasks efficiently. It provides RESTful endpoints for creating, updating, deleting, and retrieving tasks. Additionally, it integrates with SignalR to enable real-time notifications for task-related events, such as task creation, updates, and deletions. This project is built using .NET Core and follows a clean architecture approach.

### Features
- **Task Management**: CRUD operations for tasks.
- **Real-Time Notifications**: SignalR integration to broadcast task-related events to connected clients.
- **Error Handling**: Global error handling middleware for consistent error responses.
- **Database Management**: Entity Framework Core for database interactions.
- **Dependency Injection**: IoC container for managing dependencies.

## Prerequisites
- .NET SDK 6.0 or later
- SQL Server
- Visual Studio or any IDE supporting .NET development
- Node.js (for frontend integration, if applicable)

## Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd curotec_task_back_api
```

### 2. Configure the Database
Update the `appsettings.json` or `appsettings.Development.json` file with your SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;"
}
```

### 3. Build the Project
Run the following command to restore dependencies and build the project:
```bash
dotnet build
```

### 4. Create and Apply Migrations
To create a new migration:
```bash
dotnet ef migrations add <MigrationName> --project 4 - Infra --startup-project 0 - Api
```
To apply migrations and update the database:
```bash
dotnet ef database update --project 4 - Infra --startup-project 0 - Api
```

### 5. Run the Application
Start the application using the following command:
```bash
dotnet run --project 0 - Api
```
The API will be available at `https://localhost:5001` or `http://localhost:5000`.

## SignalR Integration
The SignalR hub is exposed at `/hub`. It supports real-time notifications for the following events:
- `TaskAdded`: Broadcasts when a new task is added.
- `TaskUpdated`: Broadcasts when a task is updated.
- `TaskDeleted`: Broadcasts when a task is deleted.

## Project Structure
- **0 - Api**: Contains the API layer, including controllers and SignalR hubs.
- **1 - Application**: Contains application logic, such as services, commands, and queries.
- **2 - Domain**: Contains domain entities and enums.
- **4 - Infra**: Contains database context, migrations, and repositories.
- **5 - CrossCutting**: Contains cross-cutting concerns, such as IoC and middleware.
- **6 - UnitTests**: Contains unit tests for the application.

## Contributing
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes and push the branch.
4. Create a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any inquiries or support, please contact [jeanoliveiralopes@gmail.com].