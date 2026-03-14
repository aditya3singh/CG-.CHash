# Quick Start Guide

## ✅ Setup Complete!

Your database `autho` has been created with all tables:
- Students
- Hostels (1:1 relationship with Students)
- AspNetUsers, AspNetRoles (Identity tables)

## 🚀 Run the Application

```bash
cd StudentRelation
dotnet run
```

The API will start at `https://localhost:7000` (or check console for actual port)

## 🧪 Test the API

### Option 1: Use the HTTP File (Recommended)

1. Open `StudentRelation.http` in Visual Studio or VS Code with REST Client extension
2. Update the `@token` variable after login
3. Click "Send Request" above each endpoint

### Option 2: Use PowerShell/Bash

#### 1. Register an Admin User

```powershell
$registerBody = @{
    username = "admin"
    email = "admin@test.com"
    password = "Admin@123"
    fullName = "Admin User"
    role = "Admin"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:7000/api/auth/register" `
    -Method Post `
    -ContentType "application/json" `
    -Body $registerBody `
    -SkipCertificateCheck
```

#### 2. Login and Get Token

```powershell
$loginBody = @{
    username = "admin"
    password = "Admin@123"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "https://localhost:7000/api/auth/login" `
    -Method Post `
    -ContentType "application/json" `
    -Body $loginBody `
    -SkipCertificateCheck

$token = $response.token
Write-Host "Token: $token"
```

#### 3. Create a Student with Hostel

```powershell
$studentBody = @{
    name = "John Doe"
    email = "john@test.com"
    collegeName = "Engineering College"
    hostel = @{
        roomNumber = "101"
        blockName = "A"
    }
} | ConvertTo-Json

$headers = @{
    Authorization = "Bearer $token"
}

Invoke-RestMethod -Uri "https://localhost:7000/api/students" `
    -Method Post `
    -ContentType "application/json" `
    -Headers $headers `
    -Body $studentBody `
    -SkipCertificateCheck
```

#### 4. Get All Students

```powershell
Invoke-RestMethod -Uri "https://localhost:7000/api/students" `
    -Method Get `
    -Headers $headers `
    -SkipCertificateCheck
```

#### 5. Update Hostel Room (Warden can do this too)

```powershell
$hostelBody = @{
    roomNumber = "205"
    blockName = "B"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:7000/api/hostels/student/1" `
    -Method Put `
    -ContentType "application/json" `
    -Headers $headers `
    -Body $hostelBody `
    -SkipCertificateCheck
```

## 📊 Check Your Database

Connect to SQL Server Management Studio:
- Server: `(localdb)\MSSQLLocalDB`
- Database: `autho`

Run queries:
```sql
-- View all students
SELECT * FROM Students;

-- View all hostels with student info
SELECT s.Name, s.Email, h.RoomNumber, h.BlockName
FROM Students s
LEFT JOIN Hostels h ON s.Id = h.StudentId;

-- View all users and their roles
SELECT u.UserName, u.Email, r.Name as Role
FROM AspNetUsers u
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r ON ur.RoleId = r.Id;
```

## 🎭 Test Different Roles

### Create Warden User
```powershell
$wardenBody = @{
    username = "warden"
    email = "warden@test.com"
    password = "Warden@123"
    fullName = "Hostel Warden"
    role = "Warden"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:7000/api/auth/register" `
    -Method Post `
    -ContentType "application/json" `
    -Body $wardenBody `
    -SkipCertificateCheck
```

### Login as Warden
```powershell
$wardenLogin = @{
    username = "warden"
    password = "Warden@123"
} | ConvertTo-Json

$wardenResponse = Invoke-RestMethod -Uri "https://localhost:7000/api/auth/login" `
    -Method Post `
    -ContentType "application/json" `
    -Body $wardenLogin `
    -SkipCertificateCheck

$wardenToken = $wardenResponse.token
```

### Warden Updates Room (Allowed)
```powershell
$wardenHeaders = @{
    Authorization = "Bearer $wardenToken"
}

$roomUpdate = @{
    roomNumber = "301"
    blockName = "C"
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:7000/api/hostels/student/1" `
    -Method Put `
    -ContentType "application/json" `
    -Headers $wardenHeaders `
    -Body $roomUpdate `
    -SkipCertificateCheck
```

### Warden Tries to Delete Student (Forbidden)
```powershell
# This will return 403 Forbidden
Invoke-RestMethod -Uri "https://localhost:7000/api/students/1" `
    -Method Delete `
    -Headers $wardenHeaders `
    -SkipCertificateCheck
```

## 🔍 What You Can Test

✅ Create student with hostel in one request
✅ Create student without hostel (day scholar)
✅ Update student details (name, email, college)
✅ Update hostel room number (Admin or Warden)
✅ Delete student (cascades to hostel)
✅ Delete hostel only (student remains)
✅ View all students with their hostels
✅ View all hostels
✅ Role-based access control
✅ Room uniqueness validation
✅ Email uniqueness validation

## 🎯 Key Features Implemented

1. **1:1 Relationship**: Each student has max one hostel room
2. **Code-First**: Database created from C# models
3. **JWT Auth**: Secure token-based authentication
4. **3 Roles**: Admin (full access), Warden (hostel updates), Student (view only)
5. **Atomic Transactions**: Student + Hostel created together
6. **Validation**: No duplicate emails, no double-booked rooms
7. **Cascade Delete**: Removing student removes their hostel

## 📝 Next Steps

1. Test all endpoints using the HTTP file
2. Try creating multiple students with different hostels
3. Test the validation (duplicate email, duplicate room)
4. Test role permissions (Warden can't delete students)
5. Check the database to see the 1:1 relationship

## 🐛 Troubleshooting

**Port already in use?**
- Check `Properties/launchSettings.json` and change the port

**Database connection error?**
- Verify SQL Server LocalDB is running: `sqllocaldb info`
- Start it if needed: `sqllocaldb start MSSQLLocalDB`

**Token expired?**
- Login again to get a new token (expires after 60 minutes)

**Can't find dotnet ef?**
- Install: `dotnet tool install --global dotnet-ef`

## 📚 Documentation

- `README.md` - Complete API documentation
- `PROJECT_STRUCTURE.md` - Architecture overview
- `USAGE_SCENARIOS.md` - Real-world examples
- `SETUP_GUIDE.md` - Detailed setup instructions
