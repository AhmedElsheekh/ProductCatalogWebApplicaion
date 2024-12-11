# Product Catalog Web Application

## Overview
This is a **Product Catalog Web Application** developed using **.NET Core MVC** and **Entity Framework (EF)** with an **MSSQL** backend. The application displays products that are active based on the current date and time, managing product information and user roles securely. Admin users have access to full CRUD operations on products, while regular users can view only the active products.

## Features
- **Product List:** A list of all products regardless of the current time (Admin only).
- **Add Product:** Admin users can add new products to the catalog.
- **Edit Product:** Admin users can update details of existing products.
- **Delete Product:** Admin users can delete products from the catalog.
- **Product Filter by Category:** Filter products based on predefined categories.
- **Product Details View:** View detailed information about each product.
- **Role-based Access:** Admin users can perform CRUD operations, and non-admin users can view the active products based on current date and time.

## Technologies Used
- **Backend:** .NET Core (MVC)
- **Database:** MSSQL (via Entity Framework)
- **User Authentication & Authorization:** ASP.NET Identity
- **ORM:** Entity Framework Core

## Requirements
- **.NET Core SDK 6.0** or higher
- **MSSQL Server** or compatible database (LocalDB, SQL Server, etc.)
- **Visual Studio 2022** or a similar IDE for .NET Core development

## Setup Instructions

### Prerequisites
Ensure you have the following installed:
- .NET SDK
- SQL Server or LocalDB
- Visual Studio or preferred IDE

### Steps to Run Locally:
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/product-catalog.git
   cd product-catalog
   ```

2. Restore the dependencies:
   ```bash
   dotnet restore
   ```

3. Create the database by running the SQL script included in the project:
   - Navigate to the **Database** folder (or the folder where the script is located).
   - Run the script in your SQL Server Management Studio (SSMS) or via the `sqlcmd` tool to create the database and tables.

4. Run the application:
   ```bash
   dotnet run
   ```
   This will start the application at `https://localhost:5001` by default.

5. The admin user can be created through the **Identity Seed** or through the application UI, depending on the implementation of user roles.

### SQL Script for Database Setup
A script to create the required database and tables is provided. The database includes the following tables:
- `Products`
- `Categories`
- `Users` (managed by ASP.NET Identity)

### Database Structure
- **Products Table:**
  - `Id` (Primary Key)
  - `Name`
  - `CreatedByUserId` (Foreign Key linked to the Users table)
  - `StartDate`
  - `Duration`
  - `Price`
  - `CategoryId` (Foreign Key linked to Categories)

- **Categories Table:**
  - `Id` (Primary Key)
  - `Name`

The `Category` data will be seeded into the database.

### Running the Application
Once the database is set up, and the application is running, you can:
- **Login as an Admin:** Use the provided seed data or registration process to create an admin user.
- **View Product List (Admins Only):** The admin can see all products listed.
- **Add, Edit, or Delete Products:** Admins can manage product data.
- **View Active Products:** Regular users will only see products that are active at the current time.

### Role-based Access
- Admins will have access to the **Admin Panel** where they can manage product information.
- Non-admin users can only view the products that are currently active based on the start date and duration.

## Error Handling and Security Considerations
- **Error Handling:** The application includes proper error handling using `try-catch` blocks and custom error pages for common exceptions.
- **Security:** Authentication is handled through ASP.NET Identity. Admin users must log in to perform CRUD operations. Passwords and sensitive data are hashed and securely stored.



