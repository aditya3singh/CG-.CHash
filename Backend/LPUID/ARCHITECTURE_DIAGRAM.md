# 🏗️ System Architecture Diagram

## 📊 Layered Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                         USER BROWSER                         │
│                    (Views - Razor Pages)                     │
└──────────────────────────┬──────────────────────────────────┘
                           │ HTTP Requests
                           ↓
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                        │
│                                                              │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │   Account    │  │    Student   │  │     Home     │     │
│  │  Controller  │  │  Controller  │  │  Controller  │     │
│  └──────────────┘  └──────────────┘  └──────────────┘     │
│         │                  │                  │             │
│         └──────────────────┼──────────────────┘             │
└────────────────────────────┼──────────────────────────────┘
                             │ Uses
                             ↓
┌─────────────────────────────────────────────────────────────┐
│                     SERVICE LAYER                            │
│                   (Business Logic)                           │
│                                                              │
│  ┌────────────────────────────────────────────────────┐    │
│  │           IStudentService / StudentService         │    │
│  │                                                     │    │
│  │  • RegisterNewStudentAsync()                       │    │
│  │    - Generates unique ID card (LPU-XXXXXX)        │    │
│  │    - Creates student record                        │    │
│  │                                                     │    │
│  │  • CalculateCGPA()                                 │    │
│  │    - Averages all semester SGPAs                   │    │
│  │    - Returns CGPA value                            │    │
│  └────────────────────────────────────────────────────┘    │
└────────────────────────────┼──────────────────────────────┘
                             │ Uses
                             ↓
┌─────────────────────────────────────────────────────────────┐
│                   REPOSITORY LAYER                           │
│                   (Data Access)                              │
│                                                              │
│  ┌────────────────────────────────────────────────────┐    │
│  │      IStudentRepository / StudentRepository        │    │
│  │                                                     │    │
│  │  • GetStudentByIdAsync()                           │    │
│  │  • GetAllStudentsAsync()                           │    │
│  │  • AddStudentAsync()                               │    │
│  │  • SaveChangesAsync()                              │    │
│  └────────────────────────────────────────────────────┘    │
└────────────────────────────┼──────────────────────────────┘
                             │ Uses
                             ↓
┌─────────────────────────────────────────────────────────────┐
│                    DATA LAYER                                │
│                                                              │
│  ┌────────────────────────────────────────────────────┐    │
│  │          ApplicationDbContext                       │    │
│  │          (Entity Framework Core)                    │    │
│  │                                                     │    │
│  │  • DbSet<Student>                                  │    │
│  │  • DbSet<IdCard>                                   │    │
│  │  • DbSet<HostelAllocation>                         │    │
│  │  • DbSet<SemesterMark>                             │    │
│  │                                                     │    │
│  │  • OnModelCreating() - Fluent API                  │    │
│  │    - Unique constraints                            │    │
│  │    - Relationships (1:1, 1:Many)                   │    │
│  └────────────────────────────────────────────────────┘    │
└────────────────────────────┼──────────────────────────────┘
                             │ Queries/Commands
                             ↓
┌─────────────────────────────────────────────────────────────┐
│                    DATABASE                                  │
│                 (SQL Server LocalDB)                         │
│                                                              │
│  Tables:                                                     │
│  • Students (ApplicationNumber UNIQUE)                       │
│  • IdCards (UniqueCardNumber UNIQUE)                         │
│  • HostelAllocations                                         │
│  • SemesterMarks                                             │
│  • AspNetUsers (Identity)                                    │
└─────────────────────────────────────────────────────────────┘
```

---

## 🔄 Request Flow Example

### Scenario: Student Admission

```
1. USER fills admission form
   ↓
2. POST /Portal/Student/Admission
   ↓
3. StudentController.Admission(student)
   ↓
4. _studentService.RegisterNewStudentAsync(student)
   │
   ├─→ Generate unique ID card: "LPU-A1B2C3"
   ├─→ Assign to student.IdCard
   └─→ Call repository
       ↓
5. _studentRepository.AddStudentAsync(student)
   ↓
6. ApplicationDbContext.Students.Add(student)
   ↓
7. SaveChangesAsync()
   ↓
8. SQL INSERT INTO Students, IdCards
   ↓
9. Return to Controller
   ↓
10. Redirect to Dashboard
    ↓
11. USER sees dashboard with ID card
```

---

## 🔗 Dependency Injection Flow

```
Program.cs (Startup)
│
├─→ Register Services:
│   builder.Services.AddScoped<IStudentRepository, StudentRepository>()
│   builder.Services.AddScoped<IStudentService, StudentService>()
│   builder.Services.AddDbContext<ApplicationDbContext>()
│
└─→ ASP.NET Core Container
    │
    └─→ When StudentController is requested:
        │
        ├─→ Inject IStudentService → StudentService instance
        │   │
        │   └─→ Inject IStudentRepository → StudentRepository instance
        │       │
        │       └─→ Inject ApplicationDbContext → DbContext instance
        │
        └─→ Controller ready with all dependencies
```

---

## 📦 Entity Relationships

```
┌─────────────────────┐
│      Student        │
│─────────────────────│
│ Id (PK)             │
│ ApplicationNumber ◄─┼─── UNIQUE
│ FullName            │
│ Email               │
│ Course              │
└──────┬──────────────┘
       │
       │ 1:1
       ├──────────────────────────┐
       │                          │
       ↓                          ↓
┌─────────────────┐      ┌──────────────────┐
│    IdCard       │      │ HostelAllocation │
│─────────────────│      │──────────────────│
│ Id (PK)         │      │ Id (PK)          │
│ StudentId (FK)  │      │ StudentId (FK)   │
│ UniqueCardNumber◄┼──UNIQUE  BlockName     │
│ IssueDate       │      │ RoomNumber       │
└─────────────────┘      └──────────────────┘
       
       ↓ 1:Many
       
┌─────────────────┐
│  SemesterMark   │
│─────────────────│
│ Id (PK)         │
│ StudentId (FK)  │
│ Semester        │
│ TotalMarks      │
│ SGPA            │
└─────────────────┘
```

---

## 🔐 Authentication Flow

```
1. User Registration
   ↓
   AccountController.Register(model)
   ↓
   UserManager.CreateAsync(user, password)
   ↓
   Password hashed & stored in AspNetUsers
   ↓
   SignInManager.SignInAsync(user)
   ↓
   Cookie created
   ↓
   User logged in

2. Accessing Protected Route
   ↓
   Request to /Portal/Student/Admission
   ↓
   [Authorize] attribute checks cookie
   ↓
   If valid → Allow access
   If invalid → Redirect to /Account/Login
```

---

## 🎯 Data Flow: CGPA Calculation

```
Student Dashboard Request
│
├─→ StudentController.Dashboard(id)
│   │
│   ├─→ _studentRepository.GetStudentByIdAsync(id)
│   │   │
│   │   └─→ Include SemesterMarks
│   │       │
│   │       └─→ Return Student with marks
│   │
│   ├─→ _studentService.CalculateCGPA(student.SemesterMarks)
│   │   │
│   │   └─→ marks.Average(m => m.SGPA)
│   │       │
│   │       └─→ Return CGPA value
│   │
│   └─→ ViewBag.CGPA = cgpa
│       │
│       └─→ Return View(student)
│
└─→ Dashboard.cshtml displays CGPA
```

---

## 🏭 Code First Migration Flow

```
1. Create/Modify Models
   (Student.cs, IdCard.cs, etc.)
   ↓
2. Add-Migration InitialCreate
   ↓
   EF Core analyzes models
   ↓
   Generates migration file
   (20260309095438_InitialCreate.cs)
   ↓
3. Update-Database
   ↓
   Reads migration file
   ↓
   Generates SQL commands
   ↓
   Executes on database
   ↓
   Creates tables with:
   - Columns from properties
   - Constraints from Fluent API
   - Relationships from navigation properties
   ↓
4. Database ready!
```

---

## 🔧 Fluent API Configuration

```
ApplicationDbContext.OnModelCreating()
│
├─→ Unique Constraints:
│   modelBuilder.Entity<Student>()
│       .HasIndex(s => s.ApplicationNumber).IsUnique()
│   
│   modelBuilder.Entity<IdCard>()
│       .HasIndex(i => i.UniqueCardNumber).IsUnique()
│
├─→ One-to-One Relationships:
│   modelBuilder.Entity<Student>()
│       .HasOne(s => s.IdCard)
│       .WithOne(i => i.Student)
│       .HasForeignKey<IdCard>(i => i.StudentId)
│
│   modelBuilder.Entity<Student>()
│       .HasOne(s => s.Hostel)
│       .WithOne(h => h.Student)
│       .HasForeignKey<HostelAllocation>(h => h.StudentId)
│
└─→ One-to-Many (by convention):
    Student.SemesterMarks → ICollection<SemesterMark>
```

---

## 📱 URL Routing Structure

```
Attribute Routing:

[Route("Portal/[controller]")]
public class StudentController
│
├─→ [HttpGet]
│   Index() → /Portal/Student
│
├─→ [HttpGet("Admission")]
│   Admission() → /Portal/Student/Admission
│
├─→ [HttpPost("Admission")]
│   Admission(student) → POST /Portal/Student/Admission
│
├─→ [HttpGet("{id}/Dashboard")]
│   Dashboard(id) → /Portal/Student/5/Dashboard
│
└─→ [HttpGet("{id}/IdCard")]
    IdCard(id) → /Portal/Student/5/IdCard
```

---

## 🎨 View Rendering Flow

```
Controller Action
│
├─→ return View(model)
│   │
│   └─→ Looks for: Views/Student/Dashboard.cshtml
│       │
│       ├─→ @model LPUID.Models.Student
│       │
│       ├─→ Uses _Layout.cshtml (master page)
│       │
│       ├─→ Renders HTML with model data
│       │
│       └─→ Returns HTML to browser
│
└─→ Browser displays page
```

---

## 🔄 Complete System Flow

```
┌──────────┐
│  Browser │
└────┬─────┘
     │ 1. HTTP Request
     ↓
┌──────────────┐
│  Controller  │ ← [Authorize] checks authentication
└────┬─────────┘
     │ 2. Calls Service
     ↓
┌──────────────┐
│   Service    │ ← Business Logic (CGPA, ID generation)
└────┬─────────┘
     │ 3. Calls Repository
     ↓
┌──────────────┐
│  Repository  │ ← Data Access (CRUD operations)
└────┬─────────┘
     │ 4. Uses DbContext
     ↓
┌──────────────┐
│  DbContext   │ ← Fluent API configuration
└────┬─────────┘
     │ 5. SQL Query
     ↓
┌──────────────┐
│   Database   │ ← SQL Server LocalDB
└────┬─────────┘
     │ 6. Returns Data
     ↓
┌──────────────┐
│  Repository  │
└────┬─────────┘
     │ 7. Returns Entity
     ↓
┌──────────────┐
│   Service    │
└────┬─────────┘
     │ 8. Returns Result
     ↓
┌──────────────┐
│  Controller  │
└────┬─────────┘
     │ 9. Returns View
     ↓
┌──────────────┐
│    View      │ ← Razor rendering
└────┬─────────┘
     │ 10. HTML Response
     ↓
┌──────────┐
│  Browser │
└──────────┘
```

---

**Use these diagrams to explain your architecture during presentation! 📊**
