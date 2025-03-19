# Doenet API

## Features
- RESTful API for managing personal data.
- CRUD operations for various entities.
- Authentication and authorization support.
- Error handling and validation mechanisms.
- Logging and monitoring capabilities.

## Technologies Used
- **.NET Core**: Backend framework for building the API.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database for storing application data.
- **Swagger**: API documentation and testing.
- **JWT**: Authentication and authorization.
- **Serilog**: Logging framework.

## How to Use the Project

### Prerequisites
- Install [.NET SDK](https://dotnet.microsoft.com/download).
- Install [SQL Server](https://www.microsoft.com/en-us/sql-server).
- Install a tool like [Postman](https://www.postman.com/) for API testing.

### Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/InnwaCommunity/Doenet-API.git
   cd Doenet-API
   ```

2. Configure the database connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=<your-server>;Database=<your-database>;Trusted_Connection=True;"
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation at `http://localhost:<port>/swagger`.

### Testing the API
- Use Postman or any HTTP client to test the endpoints.
- Refer to the Swagger documentation for available endpoints and request/response formats.

### Contribution
Feel free to fork the repository and submit pull requests for new features or bug fixes.
