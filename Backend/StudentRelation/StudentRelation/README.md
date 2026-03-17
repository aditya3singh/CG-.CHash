# Student-Hostel Management API

A comprehensive Web API built with ASP.NET Core implementing a 1:1 relationship between Students and Hostels with role-based authorization.

## Features

- **1:1 Relationship**: Each student can have only one hostel room
- **Role-Based Authorization**: Admin, Warden, and Student roles with different permissions
- **JWT Authentication**: Secure token-based authentication
- **Code-First Approach**: Entity Framework Core with migrations
- **Complete CRUD Operations**: Full management of students and hostels
- **Room Validation**: Prevents double-booking of hostel rooms

## Architecture

### Roles & Permissions

| Role | Permissions |
|------|-------------|
| **Admin** | Full access - Create/Update/Delete students and hostels |
| **Warden** | View all students/hostels, Update hostel room details |
| **Student** | View their own data |

## Getting Started

### 1. Install Dependencies

```bash
dotnet restore
```

### 2. Update Database Connection

Edit `appsettings.json` and update the connection string if needed.

### 3. Create Database Migration

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

## API Endpoints

### Authentication

#### Register User
```http
POST /api/auth/register
Content-Type: application/json

{
  "username": "admin1",
  "email": "admin@example.com",
  "password": "Admin@123",
  "fullName": "Admin User",
  "role": "Admin"
}
```

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin1",
  "password": "Admin@123"
}
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "username": "admin1",
  "email": "admin@example.com",
  "roles": ["Admin"]
}
```

### Students

#### Get All Students (Admin/Warden)
```http
GET /api/students
Authorization: Bearer {token}
```

#### Get Student by ID
```http
GET /api/students/{id}
Authorization: Bearer {token}
```

#### Create Student with Hostel (Admin)
```http
POST /api/students
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john@example.com",
  "collegeName": "Engineering College",
  "hostel": {
    "roomNumber": "101",
    "blockName": "A"
  }
}
```

#### Create Student without Hostel (Admin)
```http
POST /api/students
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "Jane Smith",
  "email": "jane@example.com",
  "collegeName": "Medical College"
}
```

#### Update Student (Admin)
```http
PUT /api/students/{id}
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "John Doe Updated",
  "email": "john.updated@example.com",
  "collegeName": "Engineering College"
}
```

#### Delete Student (Admin)
```http
DELETE /api/students/{id}
Authorization: Bearer {token}
```

### Hostels

#### Get All Hostels (Admin/Warden)
```http
GET /api/hostels
Authorization: Bearer {token}
```

#### Get Hostel by Student ID (Admin/Warden)
```http
GET /api/hostels/student/{studentId}
Authorization: Bearer {token}
```

#### Update Hostel Room (Admin/Warden)
```http
PUT /api/hostels/student/{studentId}
Authorization: Bearer {token}
Content-Type: application/json

{
  "roomNumber": "205",
  "blockName": "B"
}
```

#### Delete Hostel (Admin)
```http
DELETE /api/hostels/student/{studentId}
Authorization: Bearer {token}
```

## Database Schema

### Student Table
- Id (PK)
- Name
- Email (Unique)
- CollegeName

### Hostel Table
- Id (PK)
- RoomNumber
- BlockName
- StudentId (FK, Unique) - 1:1 relationship
- Unique constraint on (RoomNumber, BlockName)

### Relationship
- One Student can have zero or one Hostel
- One Hostel belongs to exactly one Student
- Cascade delete: Deleting a student removes their hostel record

## Testing the API

### Step 1: Register Users

```bash
# Register Admin
curl -X POST https://localhost:7xxx/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "admin",
    "email": "admin@test.com",
    "password": "Admin@123",
    "fullName": "Admin User",
    "role": "Admin"
  }'

# Register Warden
curl -X POST https://localhost:7xxx/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "warden",
    "email": "warden@test.com",
    "password": "Warden@123",
    "fullName": "Warden User",
    "role": "Warden"
  }'
```

### Step 2: Login and Get Token

```bash
curl -X POST https://localhost:7xxx/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "admin",
    "password": "Admin@123"
  }'
```

### Step 3: Use Token in Requests

```bash
# Create Student with Hostel
curl -X POST https://localhost:7xxx/api/students \
  -H "Authorization: Bearer YOUR_TOKEN_HERE" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "email": "john@test.com",
    "collegeName": "Engineering College",
    "hostel": {
      "roomNumber": "101",
      "blockName": "A"
    }
  }'
```

## Key Implementation Details

### 1:1 Relationship Configuration
```csharp
modelBuilder.Entity<Student>()
    .HasOne(s => s.Hostel)
    .WithOne(h => h.Student)
    .HasForeignKey<Hostel>(h => h.StudentId)
    .OnDelete(DeleteBehavior.Cascade);
```

### Room Uniqueness
```csharp
modelBuilder.Entity<Hostel>()
    .HasIndex(h => new { h.RoomNumber, h.BlockName })
    .IsUnique();
```

## Business Logic

- **Email Validation**: Prevents duplicate student emails
- **Room Validation**: Prevents double-booking of rooms
- **Atomic Transactions**: Student and hostel created together
- **Cascade Delete**: Removing a student removes their hostel assignment
- **Role-Based Access**: Different permissions for different roles

## Error Handling

The API returns appropriate HTTP status codes:
- 200 OK: Successful GET/PUT requests
- 201 Created: Successful POST requests
- 204 No Content: Successful DELETE requests
- 400 Bad Request: Validation errors
- 401 Unauthorized: Missing or invalid token
- 403 Forbidden: Insufficient permissions
- 404 Not Found: Resource not found

## Technologies Used

- ASP.NET Core 10.0
- Entity Framework Core 9.0
- SQL Server
- ASP.NET Core Identity
- JWT Bearer Authentication
