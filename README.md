# 🍽️ Restaurant Management System

![.NET 8](https://img.shields.io/badge/.NET-8.0-blue)  ![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)  ![Swagger](https://img.shields.io/badge/API-Documented-brightgreen)

A comprehensive **RESTful API** for managing a restaurant system, including **menus**, **orders**, **users**, **favorites**, **payments**, and more. Built with **ASP.NET Core**, this system supports **authentication**, **DTOs**, **services**, **repositories**, and uses **Entity Framework Core** with SQL Server.

## 🚀 Features

- ✅ **User Authentication & Authorization**
- 🛒 **Cart Management**
- 📋 **Order Processing**
- 💖 **Favorite Items Management**
- 💳 **Payment Card Management**
- 🔔 **Notifications**
- 🧾 **Offers & Discounts**
- 🧑‍🍳 **Item & Category Management**
- 📍 **Address Management**
- 📄 **Pagination Support**
- 🧪 **Validation Helpers**
- 📨 **Email Notifications**
- 🧱 **Modular Architecture (DTOs, Services, Interfaces)**

## 🧱 Project Structure

```bash
Restaurant_Management_System/
├── Controllers/              # REST API endpoints
├── Models/                   # Database entities (e.g., User, Item, Order)
├── DTOs/                     # Data Transfer Objects for input/output
│   ├── AddressDTO/
│   ├── AuthDTO/
│   ├── CartDTO/
│   ├── FavoriteDTO/
│   ├── ItemsDTO/
│   ├── OffersDTO/
│   ├── Orders/
│   ├── PaymentCardDTO/
│   └── ... 
├── Interfaces/               # Service interfaces (IService)
├── Service/                  # Business logic implementations
├── Helper/                   # Utilities (e.g., MailingHelper, ValidationHelper)
├── Properties/               # Launch settings
├── wwwroot/                  # Static files
├── appsettings.json          # Configuration (JWT, Email, DB connection)
├── Program.cs                # Application startup and dependency injection
└── README.md                 # Project documentation
```

## 🛠️ Setup & Installation

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- SQL Server (or LocalDB)
- A code editor or IDE (e.g., Visual Studio, VS Code)

### Steps

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/Restaurant_Management_System.git
   cd Restaurant_Management_System
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Update database (EF Core):**

   ```bash
   dotnet ef database update
   ```

4. **Run the application:**

   ```bash
   dotnet run
   ```

5. **Access the API via:**

   ```
   http://localhost:5226
   ```

6. **Swagger UI for Testing:**

   ```
   http://localhost:5226/swagger
   ```

## 🌐 API Endpoints

| Method   | Endpoint                        | Description                              |
| -------- | ------------------------------- | ---------------------------------------- |
| `POST`   | `/api/auth/register`            | Register a new user                      |
| `POST`   | `/api/auth/login`               | Authenticate and get JWT token           |
| `GET`    | `/api/item`                     | Get all menu items                       |
| `POST`   | `/api/cart/Add Item To Cart`    | Add item to cart                         |
| `GET`    | `/api/order/history`            | Get order history by user ID             |
| `POST`   | `/api/favorite/add`             | Add item to favorites                    |
| `POST`   | `/api/payment/card`             | Save payment card                        |
| `GET`    | `/api/notification`             | Get user notifications                   |
| `GET`    | `/api/offer`                    | Get active offers/discounts              |

### ✅ Sample Request Example

#### Login (POST)

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password"
}
```

#### Response

```json
{
  "userId": 1,
  "username": "Ahmad",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.xxxxx"
}
```

## 📦 DTOs Overview

| DTO Class                   | Purpose                             |
| --------------------------- | ----------------------------------- |
| `LoginDTO`                  | Input for login                     |
| `RegisterDTO`               | Input for registration              |
| `ItemDTO`                   | Output for listing menu items       |
| `OrderHistoryDTO`           | Output for user order history       |
| `FavoriteDTO`               | Output for favorite items           |
| `OfferDTO`                  | Output for current offers           |
| `AddPaymentCardDTO`         | Input for saving payment cards      |
| `AddAddressDTO`             | Input for adding delivery address   |

## 🧠 Business Logic

- **Services:** Encapsulate business operations like placing orders, adding to cart, etc.
- **Interfaces:** Define contracts for service implementations.
- **Helpers:** Includes email sending, password validation, OTP handling.

## 📂 Data Layer

- **`RMSDbContext`**: Entity Framework Core context for interacting with SQL Server.
- **SQL Backup File:** Included in `Restaurant_Management_System_DB/RMS.bak`

## 🔐 Authentication & Security

- Uses **JWT Bearer tokens** for authentication
- Password hashing with secure methods
- OTP-based email verification during registration

## 📖 API Documentation

- 🐳 **Swagger UI**:
  Access the interactive API docs at:
  [http://localhost:5226/swagger](http://localhost:5226/swagger)

- 📬 **Postman Collection**:
  Import our Postman collection to quickly test the API:
  👉 [Download Postman Collection](docs/RestaurantManagementSystem.postman_collection.json)

![Swagger UI Screenshot](docs/swagger-screenshot.png)

## ⚙️ Technologies Used

- **ASP.NET Core 8**
- **C#**
- **Entity Framework Core**
- **SQL Server**
- **Swagger / Swashbuckle**
- **Postman**
- **JWT Authentication**
- **Email Services (SendGrid)**
