# 📝 Commands Reference Guide

## 🚀 Essential Commands

### Start the Application
```bash
cd LPUID
dotnet run
```
**Opens at:** http://localhost:5284

### Stop the Application
Press **Ctrl+C** in the terminal

---

## 🗄️ Database Commands

### Create/Update Database
```bash
dotnet ef database update
```

### Create New Migration (after model changes)
```bash
dotnet ef migrations add MigrationName
```

### Remove Last Migration
```bash
dotnet ef migrations remove
```

### List All Migrations
```bash
dotnet ef migrations list
```

### Drop Database (careful!)
```bash
dotnet ef database drop
```

---

## 🔨 Build Commands

### Build Project
```bash
dotnet build
```

### Clean Build
```bash
dotnet clean
```

### Restore NuGet Packages
```bash
dotnet restore
```

### Build and Run
```bash
dotnet build
dotnet run
```

---

## 📦 Package Management

### Add NuGet Package
```bash
dotnet add package PackageName
```

### Remove NuGet Package
```bash
dotnet remove package PackageName
```

### List Installed Packages
```bash
dotnet list package
```

---

## 🧪 Testing Commands

### Run Tests (if you add test project)
```bash
dotnet test
```

---

## 🔍 Useful Visual Studio Commands

### Package Manager Console Commands

```powershell
# Update database
Update-Database

# Add migration
Add-Migration MigrationName

# Remove migration
Remove-Migration

# List migrations
Get-Migration

# Update to specific migration
Update-Database -Migration MigrationName

# Generate SQL script
Script-Migration
```

---

## 🌐 URLs Reference

| Purpose | URL |
|---------|-----|
| Home Page | http://localhost:5284 |
| Register | http://localhost:5284/Account/Register |
| Login | http://localhost:5284/Account/Login |
| Logout | http://localhost:5284/Account/Logout (POST) |
| Student Admission | http://localhost:5284/Portal/Student/Admission |
| All Students | http://localhost:5284/Portal/Student |
| Student Dashboard | http://localhost:5284/Portal/Student/{id}/Dashboard |
| ID Card | http://localhost:5284/Portal/Student/{id}/IdCard |

---

## 🔧 Troubleshooting Commands

### Check .NET Version
```bash
dotnet --version
```

### Check EF Core Tools Version
```bash
dotnet ef --version
```

### Install EF Core Tools (if missing)
```bash
dotnet tool install --global dotnet-ef
```

### Update EF Core Tools
```bash
dotnet tool update --global dotnet-ef
```

### Clear NuGet Cache
```bash
dotnet nuget locals all --clear
```

---

## 📊 Database Connection String

**Location:** `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### For Full SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### For SQL Server with credentials:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LPUID_Database;User Id=sa;Password=YourPassword;MultipleActiveResultSets=true"
}
```

---

## 🎯 Quick Setup (Fresh Start)

```bash
# 1. Navigate to project
cd LPUID

# 2. Restore packages
dotnet restore

# 3. Create database
dotnet ef database update

# 4. Run application
dotnet run
```

---

## 🔄 Reset Database (Start Fresh)

```bash
# 1. Drop database
dotnet ef database drop

# 2. Remove all migrations
# Manually delete files in Migrations folder (except ApplicationDbContextModelSnapshot.cs)

# 3. Create new migration
dotnet ef migrations add InitialCreate

# 4. Create database
dotnet ef database update
```

---

## 📝 Git Commands (Version Control)

### Initialize Git
```bash
git init
```

### Add Files
```bash
git add .
```

### Commit Changes
```bash
git commit -m "Initial commit"
```

### Check Status
```bash
git status
```

---

## 🔐 Common Test Credentials

### Admin User
- Email: `admin@lpu.com`
- Password: `Admin@123`

### Test Students
1. Application: `APP-2026-001`, Email: `student1@lpu.in`
2. Application: `APP-2026-002`, Email: `student2@lpu.in`
3. Application: `APP-2026-003`, Email: `student3@lpu.in`

---

## 🛠️ Development Workflow

### Making Changes to Models

```bash
# 1. Modify model class (e.g., Student.cs)

# 2. Create migration
dotnet ef migrations add UpdateStudentModel

# 3. Review migration file in Migrations folder

# 4. Apply to database
dotnet ef database update

# 5. Run and test
dotnet run
```

---

## 📦 Project Structure Commands

### Create New Controller
```bash
# In Visual Studio: Right-click Controllers folder → Add → Controller
```

### Create New Model
```bash
# In Visual Studio: Right-click Models folder → Add → Class
```

### Create New View
```bash
# In Visual Studio: Right-click Views/ControllerName → Add → View
```

---

## 🎓 For Presentation

### Before Demo:
```bash
# 1. Ensure database is up to date
dotnet ef database update

# 2. Build project
dotnet build

# 3. Run application
dotnet run

# 4. Open browser to http://localhost:5284
```

### During Demo:
- Keep terminal visible to show it's running
- Have SQL Server Object Explorer open
- Have key code files open in tabs

---

## 🚨 Emergency Commands

### If Application Won't Start:
```bash
dotnet clean
dotnet restore
dotnet build
dotnet run
```

### If Database Issues:
```bash
dotnet ef database drop
dotnet ef database update
```

### If Migration Issues:
```bash
dotnet ef migrations remove
dotnet ef migrations add NewMigration
dotnet ef database update
```

---

## 📱 Port Configuration

**Default Port:** 5284 (HTTP)

To change port, edit `Properties/launchSettings.json`:

```json
"applicationUrl": "http://localhost:YOUR_PORT"
```

---

## ✅ Pre-Presentation Checklist Commands

```bash
# 1. Check .NET version
dotnet --version

# 2. Check EF tools
dotnet ef --version

# 3. Restore packages
dotnet restore

# 4. Build project
dotnet build

# 5. Update database
dotnet ef database update

# 6. Run application
dotnet run

# 7. Test in browser
# Open: http://localhost:5284
```

---

**Keep this reference handy during development and presentation! 📚**
