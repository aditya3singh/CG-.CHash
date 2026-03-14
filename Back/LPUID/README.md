# 🎓 LPU Student ID Management System

A complete ASP.NET MVC application for college student management with automatic ID card generation, hostel allocation, and CGPA calculation.

---

## 🌟 Features

✅ Student admission application form
✅ Automatic unique ID card generation
✅ Hostel allocation management
✅ Semester-wise marks tracking
✅ Automatic CGPA calculation
✅ Printable ID cards
✅ User authentication & authorization
✅ Repository pattern for data access
✅ Service layer for business logic
✅ Entity Framework Code First approach
✅ Fluent API for database configuration

---

## 🚀 Quick Start

### 1. Open Package Manager Console
`Tools` → `NuGet Package Manager` → `Package Manager Console`

### 2. Create Database
```powershell
Update-Database
```

### 3. Run Application
Press **F5**

---

## 📋 Technologies Used

- **ASP.NET Core MVC** (.NET 10.0)
- **Entity Framework Core** (Code First)
- **SQL Server LocalDB**
- **ASP.NET Identity** (Authentication)
- **Repository Pattern**
- **Service Layer Pattern**
- **Fluent API**
- **Attribute Routing**

---

## 📁 Project Structure

```
LPUID/
├── Controllers/        # MVC Controllers with attribute routing
├── Models/            # Entity classes (Student, IdCard, etc.)
├── Views/             # Razor views
├── Services/          # Business logic layer
├── Repositories/      # Data access layer
├── Data/              # DbContext and database seeding
├── ViewModels/        # Form models for views
└── Migrations/        # EF Core migrations
```

---

## 📚 Documentation

- **[PROJECT_DOCUMENTATION.md](PROJECT_DOCUMENTATION.md)** - Complete technical documentation
- **[QUICK_START_GUIDE.md](QUICK_START_GUIDE.md)** - Fast setup and testing guide
- **[DEPENDENCIES_AND_SETUP.md](DEPENDENCIES_AND_SETUP.md)** - Package details and configuration

---

## 🎯 Key Features Explained

### 1. Unique ID Card Generation
- Format: `LPU-XXXXXX`
- Auto-generated on student admission
- Enforced unique constraint in database

### 2. CGPA Calculation
- Automatically calculates from semester SGPA
- Formula: Average of all semester SGPAs
- Displayed on student dashboard

### 3. Repository Pattern
- Separates data access from business logic
- Makes code testable and maintainable
- Easy to switch database providers

### 4. Service Layer
- Contains business logic
- Reusable across controllers
- Handles ID generation and CGPA calculation

### 5. Fluent API
- Configures database relationships
- Enforces unique constraints
- Defines one-to-one and one-to-many relationships

---

## 🔐 Security Features

- ASP.NET Identity for authentication
- Password hashing
- `[Authorize]` attribute on protected routes
- Secure login/logout functionality

---

## 📊 Database Schema

### Main Tables:
- **Students** - Student information
- **IdCards** - Unique ID cards
- **HostelAllocations** - Hostel assignments
- **SemesterMarks** - Semester-wise marks and SGPA
- **AspNetUsers** - User authentication

### Relationships:
- Student ↔ IdCard (1:1)
- Student ↔ HostelAllocation (1:1)
- Student ↔ SemesterMarks (1:Many)

---

## 🧪 Testing

1. Register a new user
2. Login with credentials
3. Submit student admission form
4. View student dashboard (see CGPA, hostel, marks)
5. View and print ID card

---

## ✅ Assignment Requirements

All requirements are fully implemented:

- ✅ ASP.NET MVC
- ✅ Entity Framework Code First
- ✅ Services Layer
- ✅ Repository Pattern
- ✅ Database Context
- ✅ SQL Server Database
- ✅ Fluent API Configuration
- ✅ Authentication & Authorization
- ✅ Attribute Routing
- ✅ Unique Constraints
- ✅ ID Card Generation
- ✅ CGPA Calculation

---

## 📦 Dependencies

All required packages are already installed:

- Microsoft.AspNetCore.Identity.EntityFrameworkCore (10.0.3)
- Microsoft.AspNetCore.Identity.UI (10.0.3)
- Microsoft.EntityFrameworkCore.SqlServer (10.0.3)
- Microsoft.EntityFrameworkCore.Tools (10.0.3)

**No additional installation required!**

---

## 🛠️ Common Commands

```powershell
# Apply migrations
Update-Database

# Create new migration
Add-Migration MigrationName

# Remove last migration
Remove-Migration
```

---

## 📞 Support

For detailed information, check:
- [Complete Documentation](PROJECT_DOCUMENTATION.md)
- [Quick Start Guide](QUICK_START_GUIDE.md)
- [Setup Instructions](DEPENDENCIES_AND_SETUP.md)

---

## 👨‍🎓 For Students

This project demonstrates:
- Clean architecture principles
- SOLID design patterns
- Best practices in ASP.NET MVC
- Professional code organization
- Production-ready implementation

---

**Built with ❤️ for LPU Assignment**

**Ready to run and present! 🎉**
