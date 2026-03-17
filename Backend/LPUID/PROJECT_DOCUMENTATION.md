# 🎓 LPU Student ID Management System - Complete Documentation

## 📌 Project Overview
This is a complete ASP.NET MVC application for managing student admissions, hostel allocations, semester marks, CGPA calculation, and ID card generation at a college.

## ✅ Technologies & Patterns Implemented

### 1. **ASP.NET MVC Core (.NET 10.0)**
- Model-View-Controller architecture
- Razor Views for UI

### 2. **Entity Framework Core - Code First Approach**
- Database created from C# classes
- Migrations for database versioning

### 3. **Repository Pattern**
- `IStudentRepository` (Interface)
- `StudentRepository` (Implementation)
- Separates data access logic from business logic

### 4. **Service Layer**
- `IStudentService` (Interface)
- `StudentService` (Implementation)
- Contains business logic (CGPA calculation, ID generation)

### 5. **Database Context**
- `ApplicationDbContext` extends `IdentityDbContext`
- Manages all database operations


### 6. **Fluent API Configuration**
Located in `ApplicationDbContext.OnModelCreating()`:
- Unique constraints on `ApplicationNumber` and `UniqueCardNumber`
- One-to-One relationships (Student ↔ IdCard, Student ↔ HostelAllocation)
- One-to-Many relationship (Student ↔ SemesterMarks)

### 7. **Authentication & Authorization**
- ASP.NET Identity for user management
- `[Authorize]` attribute on StudentController
- Login/Register functionality

### 8. **Attribute Routing**
- `[Route("Portal/[controller]")]` on StudentController
- Clean URLs like `/Portal/Student/Admission`

---

## 📦 Dependencies Already Installed

Your `.csproj` file already has all required packages:

```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.3" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="10.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.3" />
```

**✅ No additional packages needed!**


---

## 🗂️ Project Structure

```
LPUID/
├── Controllers/
│   ├── AccountController.cs      # Login/Register/Logout
│   ├── HomeController.cs         # Landing page
│   └── StudentController.cs      # Student operations (Admission, Dashboard, ID Card)
│
├── Data/
│   ├── ApplicationDbContext.cs   # EF Core DbContext with FluentAPI
│   └── DbSeeder.cs              # Seeds sample data
│
├── Models/
│   ├── Student.cs               # Main student entity
│   ├── IdCard.cs                # ID card with unique number
│   ├── HostelAllocation.cs      # Hostel details
│   ├── SemesterMark.cs          # Semester-wise marks & SGPA
│   └── ErrorViewModel.cs        # Error handling
│
├── Repositories/
│   ├── IStudentRepository.cs    # Repository interface
│   └── StudentRepository.cs     # Repository implementation
│
├── Services/
│   ├── IStudentService.cs       # Service interface
│   └── StudentService.cs        # Business logic (CGPA, ID generation)
│
├── ViewModels/
│   ├── LoginViewModel.cs        # Login form model
│   └── RegisterViewModel.cs     # Registration form model
│
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   ├── Student/
│   │   ├── Admission.cshtml     # Student application form
│   │   ├── Dashboard.cshtml     # Student profile with CGPA
│   │   ├── Index.cshtml         # All students list
│   │   └── IdCard.cshtml        # Printable ID card
│   └── Shared/
│       └── _Layout.cshtml       # Master layout
│
├── Migrations/                  # EF Core migrations
├── Program.cs                   # App configuration & DI setup
└── appsettings.json            # Database connection string
```


---

## 🚀 Step-by-Step Setup & Running Guide

### **Step 1: Verify Database Connection**

Open `appsettings.json` and check the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

This uses **SQL Server LocalDB** (comes with Visual Studio).

### **Step 2: Apply Database Migrations**

Open **Package Manager Console** in Visual Studio:
- Go to: `Tools` → `NuGet Package Manager` → `Package Manager Console`

Run these commands:

```powershell
# This creates the database and tables
Update-Database
```

If you need to create a new migration (after model changes):
```powershell
Add-Migration YourMigrationName
Update-Database
```

### **Step 3: Run the Application**

Press **F5** or click the **Run** button in Visual Studio.

The application will open in your browser at: `https://localhost:XXXX`


---

## 🎯 How to Use the Application

### **1. Register a New User**
- Navigate to `/Account/Register`
- Create an account with email and password
- This uses ASP.NET Identity for authentication

### **2. Login**
- Go to `/Account/Login`
- Login with your credentials

### **3. Submit Student Admission**
- After login, go to `/Portal/Student/Admission`
- Fill in the form:
  - Application Number (must be unique)
  - Full Name
  - Email (must be unique)
  - Course/Program
- Click Submit

### **4. View Student Dashboard**
- After admission, you'll be redirected to the student dashboard
- Shows:
  - Student details
  - Hostel allocation (auto-assigned by DbSeeder)
  - Semester marks (sample data from DbSeeder)
  - **CGPA** (automatically calculated)
  - Link to view ID Card

### **5. View ID Card**
- Click "View ID Card" on the dashboard
- Shows a printable ID card with:
  - Unique Card Number (auto-generated: LPU-XXXXXX)
  - Student details
  - Issue date
- Click "Print ID Card" to print

### **6. View All Students**
- Go to `/Portal/Student` or `/Portal/Student/Index`
- Shows a list of all registered students


---

## 🔐 Unique Constraints Implemented

### 1. **Application Number** (Student)
- Enforced via FluentAPI in `ApplicationDbContext`
- Database will reject duplicate application numbers

### 2. **Unique Card Number** (IdCard)
- Auto-generated format: `LPU-XXXXXX` (6 random characters)
- Enforced via FluentAPI
- Generated in `StudentService.RegisterNewStudentAsync()`

### 3. **Email** (Student)
- Validated with `[EmailAddress]` attribute
- Should be unique in practice (add index if needed)

---

## 📊 Key Features Explained

### **1. Repository Pattern**

**Interface (`IStudentRepository.cs`):**
```csharp
Task<Student> GetStudentByIdAsync(int id);
Task AddStudentAsync(Student student);
Task<IEnumerable<Student>> GetAllStudentsAsync();
Task SaveChangesAsync();
```

**Implementation (`StudentRepository.cs`):**
- Uses `ApplicationDbContext` to interact with database
- Includes related entities using `.Include()`

**Benefits:**
- Testable (can mock repository)
- Separates data access from business logic
- Easy to switch database providers


### **2. Service Layer**

**Interface (`IStudentService.cs`):**
```csharp
Task RegisterNewStudentAsync(Student student);
double CalculateCGPA(IEnumerable<SemesterMark> marks);
```

**Implementation (`StudentService.cs`):**

**a) Auto ID Card Generation:**
```csharp
student.IdCard = new IdCard
{
    UniqueCardNumber = "LPU-" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
    IssueDate = DateTime.UtcNow
};
```

**b) CGPA Calculation:**
```csharp
public double CalculateCGPA(IEnumerable<SemesterMark> marks)
{
    if (marks == null || !marks.Any()) return 0;
    return marks.Average(m => m.SGPA);
}
```

**Benefits:**
- Business logic separated from controllers
- Reusable across multiple controllers
- Easy to test


### **3. Fluent API Configuration**

Located in `ApplicationDbContext.OnModelCreating()`:

```csharp
// Unique Constraints
modelBuilder.Entity<Student>().HasIndex(s => s.ApplicationNumber).IsUnique();
modelBuilder.Entity<IdCard>().HasIndex(i => i.UniqueCardNumber).IsUnique();

// One-to-One: Student ↔ IdCard
modelBuilder.Entity<Student>()
    .HasOne(s => s.IdCard)
    .WithOne(i => i.Student)
    .HasForeignKey<IdCard>(i => i.StudentId);

// One-to-One: Student ↔ HostelAllocation
modelBuilder.Entity<Student>()
    .HasOne(s => s.Hostel)
    .WithOne(h => h.Student)
    .HasForeignKey<HostelAllocation>(h => h.StudentId);

// One-to-Many: Student ↔ SemesterMarks (configured by convention)
```

**Why Fluent API?**
- More powerful than Data Annotations
- Keeps entity classes clean
- Better for complex relationships


### **4. Authentication & Authorization**

**Setup in `Program.cs`:**
```csharp
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

**Usage in Controllers:**
```csharp
[Authorize] // Only logged-in users can access
public class StudentController : Controller
{
    // ...
}
```

**Login/Register:**
- Handled by `AccountController`
- Uses `UserManager` and `SignInManager` from ASP.NET Identity


### **5. Attribute Routing**

**Controller-level routing:**
```csharp
[Route("Portal/[controller]")]
public class StudentController : Controller
```

**Action-level routing:**
```csharp
[HttpGet("Admission")]              // /Portal/Student/Admission
[HttpGet("{id}/Dashboard")]         // /Portal/Student/5/Dashboard
[HttpGet("{id}/IdCard")]            // /Portal/Student/5/IdCard
```

**Benefits:**
- Clean, readable URLs
- RESTful API design
- Better SEO

---

## 🧪 Testing the Application

### **Test Case 1: Student Registration**
1. Login to the system
2. Go to `/Portal/Student/Admission`
3. Fill form with:
   - Application Number: `APP2024001`
   - Full Name: `John Doe`
   - Email: `john@example.com`
   - Course: `B.Tech CSE`
4. Submit
5. Verify:
   - Student is created
   - ID Card is auto-generated
   - Redirected to dashboard

### **Test Case 2: Unique Constraints**
1. Try to register another student with same Application Number
2. Should get database error (unique constraint violation)

### **Test Case 3: CGPA Calculation**
1. View student dashboard
2. Check if CGPA is displayed
3. Verify calculation: Average of all SGPA values

### **Test Case 4: ID Card Generation**
1. Click "View ID Card" from dashboard
2. Verify unique card number format: `LPU-XXXXXX`
3. Test print functionality


---

## 🛠️ Common Issues & Solutions

### **Issue 1: Database Connection Error**
**Error:** "Cannot open database..."

**Solution:**
- Ensure SQL Server LocalDB is installed (comes with Visual Studio)
- Run `Update-Database` in Package Manager Console
- Check connection string in `appsettings.json`

### **Issue 2: Migration Errors**
**Error:** "Unable to create migration..."

**Solution:**
```powershell
# Remove last migration
Remove-Migration

# Create new migration
Add-Migration InitialCreate

# Apply to database
Update-Database
```

### **Issue 3: Unique Constraint Violation**
**Error:** "Cannot insert duplicate key..."

**Solution:**
- This is expected behavior for unique fields
- Change the Application Number or Email
- Or delete existing record from database

### **Issue 4: Navigation Properties are Null**
**Error:** Student.IdCard is null in view

**Solution:**
- Ensure `.Include()` is used in repository:
```csharp
return await _context.Students
    .Include(s => s.IdCard)
    .Include(s => s.Hostel)
    .Include(s => s.SemesterMarks)
    .FirstOrDefaultAsync(s => s.Id == id);
```


---

## 📚 Database Schema

### **Tables Created:**

1. **AspNetUsers** (Identity - for authentication)
2. **Students**
   - Id (PK)
   - ApplicationNumber (Unique)
   - FullName
   - Email
   - Course

3. **IdCards**
   - Id (PK)
   - StudentId (FK, Unique)
   - UniqueCardNumber (Unique)
   - IssueDate

4. **HostelAllocations**
   - Id (PK)
   - StudentId (FK, Unique)
   - BlockName
   - RoomNumber

5. **SemesterMarks**
   - Id (PK)
   - StudentId (FK)
   - Semester
   - TotalMarks
   - SGPA

### **Relationships:**
- Student → IdCard (1:1)
- Student → HostelAllocation (1:1)
- Student → SemesterMarks (1:Many)


---

## 🎓 Assignment Checklist

Use this to verify you've met all requirements:

- ✅ **ASP.NET MVC** - Yes (Controllers, Views, Models)
- ✅ **Entity Framework Code First** - Yes (Models → Database)
- ✅ **Services** - Yes (IStudentService, StudentService)
- ✅ **Repository** - Yes (IStudentRepository, StudentRepository)
- ✅ **Database Context** - Yes (ApplicationDbContext)
- ✅ **Database** - Yes (SQL Server LocalDB)
- ✅ **Fluent API** - Yes (Unique constraints, relationships)
- ✅ **Authentication** - Yes (ASP.NET Identity)
- ✅ **Attribute Routing** - Yes ([Route] attributes)
- ✅ **Student Application** - Yes (Admission form)
- ✅ **Hostel Allocation** - Yes (Auto-assigned)
- ✅ **Semester Marks** - Yes (With SGPA)
- ✅ **CGPA Calculation** - Yes (Average of SGPA)
- ✅ **ID Card Generation** - Yes (Unique card number)
- ✅ **Uniqueness** - Yes (Application Number, Card Number)

---

## 🚀 Next Steps (Optional Enhancements)

1. **Add Photo Upload** for ID cards
2. **Email Notifications** when ID card is generated
3. **PDF Generation** for ID cards
4. **Admin Panel** to manage students
5. **Search & Filter** functionality
6. **Role-based Authorization** (Admin, Student)
7. **Audit Logging** for all operations
8. **Unit Tests** for services and repositories

---

## 📞 Support

If you face any issues:
1. Check the error message carefully
2. Verify database connection
3. Ensure all migrations are applied
4. Check that all required packages are installed
5. Review the code in this documentation

**Good luck with your assignment! 🎉**
