# Setup Guide - Student-Hostel Management API

## Quick Start

### Step 1: Restore Packages
```bash
dotnet restore
```

### Step 2: Create Database
```bash
cd StudentRelation
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 3: Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:7000` (or the port shown in console)

## Testing the Complete Flow

### 1. Register an Admin User

```bash
curl -X POST https://localhost:7000/api/auth/register \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"admin\",\"email\":\"admin@test.com\",\"password\":\"Admin@123\",\"fullName\":\"Admin User\",\"role\":\"Admin\"}"
```

### 2. Login to Get Token

```bash
curl -X POST https://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"admin\",\"password\":\"Admin@123\"}"
```

Copy the token from the response.

### 3. Create a Student with Hostel

```bash
curl -X POST https://localhost:7000/api/students \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"John Doe\",\"email\":\"john@test.com\",\"collegeName\":\"Engineering College\",\"hostel\":{\"roomNumber\":\"101\",\"blockName\":\"A\"}}"
```

### 4. Update Hostel Room (Warden can do this)

```bash
curl -X PUT https://localhost:7000/api/hostels/student/1 \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -H "Content-Type: application/json" \
  -d "{\"roomNumber\":\"205\",\"blockName\":\"B\"}"
```

### 5. Get All Students

```bash
curl -X GET https://localhost:7000/api/students \
  -H "Authorization: Bearer YOUR_TOKEN"
```

## Role Permissions Summary

| Operation | Admin | Warden | Student |
|-----------|-------|--------|---------|
| View all students | ✓ | ✓ | ✗ |
| View student details | ✓ | ✓ | Own only |
| Create student | ✓ | ✗ | ✗ |
| Update student | ✓ | ✗ | ✗ |
| Delete student | ✓ | ✗ | ✗ |
| View all hostels | ✓ | ✓ | ✗ |
| Update hostel room | ✓ | ✓ | ✗ |
| Delete hostel | ✓ | ✗ | ✗ |

## Key Features Implemented

✅ 1:1 relationship between Student and Hostel
✅ Code-First approach with EF Core
✅ JWT authentication
✅ Role-based authorization (Admin, Warden, Student)
✅ Create student with or without hostel
✅ Update student details
✅ Update hostel room number through API
✅ Delete student (cascades to hostel)
✅ Room uniqueness validation
✅ Email uniqueness validation
✅ Atomic transactions

## Database Schema

```
Students
├── Id (PK)
├── Name
├── Email (Unique)
└── CollegeName

Hostels
├── Id (PK)
├── RoomNumber
├── BlockName
├── StudentId (FK, Unique)
└── Unique Index on (RoomNumber, BlockName)
```

## Connection Through College

The connection between College and Hostel is managed through the Student entity:
- Student has CollegeName property
- Student has 1:1 relationship with Hostel
- To change hostel details, you access it through the student

This design allows:
- Finding all students in a college
- Finding all hostel rooms occupied by students from a specific college
- Managing hostel assignments per student

## Troubleshooting

### If migrations fail:
```bash
dotnet ef database drop
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### If port is already in use:
Edit `StudentRelation/Properties/launchSettings.json` and change the port numbers.

### If JWT token is invalid:
Make sure the SecretKey in `appsettings.json` is at least 32 characters long.
