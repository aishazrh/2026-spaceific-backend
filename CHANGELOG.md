# Changelog

All notable changes to this project will be documented in this file.

This project follows a simple versioning approach.

---

## [1.0.0] - 2026-02-15

### Added
- Initial project setup with ASP.NET Core Web API
- Entity Framework Core integration
- SQL Server database configuration
- User entity
- Room entity
- Booking entity
- DTO implementation (AuthDTO, RoomDTO, BookingDTO, UpdateBookingDTO)
- Authentication system with JWT
- AuthController (Register & Login endpoints)
- RoomsController (Get all rooms, Get room by ID)
- BookingsController (CRUD booking endpoints)
- Role-based authorization (Admin & User)
- Database migration setup
- Seed data for rooms

### Features
- User registration & login
- Room listing
- Room creation, update & delete (Admin)
- Booking creation, update & delete (User)
- Booking status update (Admin)

### Security
- Password hashing
- JWT token generation
- Role-based access control
