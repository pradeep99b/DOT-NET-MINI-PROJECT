# MedLab - Medical Laboratory Management System

## Overview
MedLab is a comprehensive Medical Laboratory Management System built with ASP.NET Core MVC. It helps manage lab assistants, track samples, generate reports, and much more. The system supports user roles (Admin and User) with different levels of access and functionalities.

## Features
- **Admin Dashboard**: Manage states, cities, tests, departments, and appointments.
- **User Dashboard**: Manage personal profile and appointments.
- **Role-based Access**: Different functionalities for Admin and User.
- **Appointment Management**: Create and manage appointments with lab assistants based on department.
- **Dynamic Registration**: Users select states and cities dynamically during registration.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or later

### Installation
1. **Clone the repository**:
    ```sh
    git clone https://github.com/yourusername/medlab.git
    cd medlab
    ```

2. **Set up the database**:
    - Update the `appsettings.json` with your SQL Server connection string:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Your SQL Server Connection String"
    }
    ```
    - Run the following commands in the Package Manager Console to apply migrations and seed the database:
    ```sh
    Add-Migration InitialCreate
    Update-Database
    ```

3. **Run the application**:
    ```sh
    dotnet run
    ```

4. **Access the application**:
    Open a browser and navigate to `https://localhost:5001` to see the application in action.

## Usage

### Admin Role
- **Dashboard**: Access a dashboard with links to manage states, cities, tests, departments, and appointments.
- **Create Appointments**: Create appointments for different tests and assign them to specific lab assistants based on the department.

### User Role
- **Profile**: View and update personal profile information.
- **Appointments**: Create and manage personal appointments.

## Code Structure
- **Controllers**: Handle HTTP requests and return responses.
- **Models**: Define the data structure of the application.
- **Views**: Render the UI using Razor templates.
- **Data**: Manage database context and seeding logic.

## Contributing
Contributions are welcome! Please create an issue or submit a pull request with your changes. 

## Contact
For any queries or feedback, please contact bahukhandi99p@gmail.com

