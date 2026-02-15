# Spaceific

## Description
Repository ini adalah bagian backend dari project Spaceific, yang merupakan suatu sistem pemesanan ruangan kampus berbasis web. Spaceific API adalah RESTful backend service yang digunakan untuk mengelola sistem pemesanan ruangan.
<br><br>
API ini memungkinkan pengguna untuk:
+ Register & Login (Authentication)
+ Melihat daftar ruangan
+ Membuat booking ruangan
+ Mengupdate dan membatalkan booking

## Features
+ User Authentication (Register & Login)
+ User Management
+ Room Management (Get all rooms & get room by ID)
+ Booking Management
+ Create booking
+ Update booking
+ Delete booking
+ Get booking list
+ Database using Entity Framework Core
+ DTO pattern implementation

## Tech Stack
+ C#
+ ASP.NET Core Web API
+ Entity Framework Core
+ SQL Server
+ JWT Authentication (if used inside AuthController)
+ Postman (for API testing)
  
## Installation
1. Clone this repository
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name
2. Restore dependency
   ```bash
   dotnet restore
3. Setup database
   <br>Pastikan connection string di appsettings.json sudah sesuai dengan database.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=spaceific_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
    }
4. Apply Migration
   ```bash
   dotnet ef database update
5. Run project
   ```bash
   dotnet run
   ```
   API akan berjalan di:
   ```arduino
   https://localhost:7166

## Usage (Using Postman)
Setelah project berjalan,
1. Buka Postman
2. Gunakan base URL:
   ```bash
   https://localhost:7166

## Authentication
### Authentication Endpoints and Guide
Jika ingin membuat akun baru, maka:
+ Register:
  ```arduino
  POST /api/auth/register
  ```
  Body (raw JSON):
  ```json
  {
    "firstName": "(enter your first name)",
    "lastName": "(enter your last name)",
    "username": "(enter your username)",
    "password": "(enter your password)"
  }
Namun jika tidak ingin membuat akun baru, sudah terdapat 2 akun dari seeder database yang bisa digunakan. 
+ Login as User:
  ```arduino
  POST /api/auth/login
  ```
  Body (raw JSON):
  ```json
  {
    "username": "user",
    "password": "user123"
  }
+ Login as Admin:
  ```arduino
  POST /api/auth/login
  ```
  Body (raw JSON):
  ```json
  {
    "username": "admin",
    "password": "admin123"
  }
Jika berhasil login, akan mendapatkan JWT token. Token tersebut akan digunakan untuk mengakses endpoint room dan booking. Masukkan token tersebut dalam header 
```makefile
Authorization: Bearer Token
```

### Room Endpoints
+ Get All Rooms (gunakan token admin/user)
  ```arduino
  GET /api/rooms
+ Get Room by ID (gunakan token admin/user)
  ```arduino
  GET /api/rooms/{id}
+ Create Room (gunakan token admin)
  ```arduino
  POST /api/rooms
+ Update Room (gunakan token admin)
  ```arduino
  PUT /api/rooms/{id}
+ Delete Room (gunakan token admin)
  ```arduino
  DELETE /api/rooms/{id}

### Booking Endpoints
+ Get All Bookings (gunakan token admin/user)
  ```arduino
  GET /api/bookings
+ Create Booking (gunakan token user)
  ```arduino
  POST /api/bookings/my
+ Update Booking (gunakan token user)
  ```arduino
  PUT /api/bookings/my/{id}
+ Delete Booking (gunakan token user)
  ```arduino
  DELETE /api/bookings/my/{id}

## Environment Variables
Project ini menggunakan konfigurasi dari ```appsettings.json```. 
### Database Configuration
```env
ConnectionStrings__DefaultConnection=Server=.;Database=RoomBookingDB;Trusted_Connection=True;
```
atau
```env
ConnectionStrings__DefaultConnection=Server=.;Database=RoomBookingDB;User Id=sa;Password=yourpassword;
```
### JWT Configuration
```env
Jwt__Key=your_super_secret_key_here
Jwt__Issuer=SpaceificAPI
Jwt__Audience=SpaceificAPIUsers
```

## License
This project is licensed under the MIT License.

## Credits
Owner & Developer: Aisha Zarrah Amalia.
