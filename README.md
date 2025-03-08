# Preqin - AssetManager

## Overview

Asset Manager

## Project Structure

- **API/**: The main entry point of the application. Contains controllers and `Program.cs`
- **DataAccess/**: Contains DbContext for database interactions.
- **Domain/**: Defines core model classes.
- **Client/**: React frontend for the application.

## Installation

### Prerequisites

### Backend (.NET Core API)

- .NET 8.0 SDK
- EF Core CLI (For migrations). If it is not installed use `dotnet tool install --global dotnet-ef`

### Frontend (React)
- Node.js (LTS)

### Steps

1. Apply database migrations: 
    - Open the project in Visual Studio Code & navigate to project root directory and run:
    `dotnet ef database update -p DataAccess -s API` 

2. Install react dependencies:
   - Navigate to client directory and install -
   `cd client`
   `npm install`

3. Run API project:
   - Navigate to dotnet API project and build
   - `cd ../API`
   - `dotnet build`
   - `dotnet run`

4. Run React app:
   - `npm run dev`

5. Access the app in the browser:
   - `http://localhost:5173/`
