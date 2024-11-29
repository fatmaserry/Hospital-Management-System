
# Hospital Management System

A feature-rich **Hospital Management System** built using **.NET 8** to optimize hospital operations, improve patient care, and streamline administrative processes. This system provides an intuitive interface and powerful backend to manage patients, doctors, appointments, and medical records effectively.

## Features
- **Patient Management**
  - Create, view, update, and delete patient profiles.
  - Search and filter patients by ID, name.
- **Doctor Management**
  - Manage doctor profiles, specialties, schedules, and availability.
- **Appointment Management**
  - Book, reschedule, or cancel appointments.
  - View appointments by patient or doctor.
- **Medical Records Management**
  - Maintain a secure repository of patient records.
  - Easy retrieval of treatment histories.
- **Role-Based Access Control (RBAC)**
  - Secure access for administrators, doctors, and hospital staff.

## Tech Stack
- **Frontend:** Razor Pages (for interactive UI)
- **Backend:** .NET 8 (C#)
- **Database:** SQL Server
- **Authentication:** ASP.NET Identity

## Installation

1. **Clone the repository**  
   Open your terminal and run the following commands:
   ```bash
   git clone https://github.com/fatmaserry/Hospital-Management-System.git
   cd Hospital-Management-System
2. **Configure the connection string**  
   Update the `appsettings.json` file in the project directory with your database configuration:
   ```bash
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=HospitalDB;Trusted_Connection=True;"
   }
3. **Apply database migrations** Run the following command to set up the database schema:
   ```bash
   dotnet ef database update
4. **Build the application** Use the following command to compile the application: 
	```bash
	dotnet build
5. **Run the application**
	  ```bash
	  dotnet run
