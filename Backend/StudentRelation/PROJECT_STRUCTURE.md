# Project Structure

```
StudentRelation/
│
├── Controllers/
│   ├── AuthController.cs          # Authentication endpoints (register/login)
│   ├── StudentsController.cs      # Student CRUD operations
│   └── HostelsController.cs       # Hostel management operations
│
├── Data/
│   └── ApplicationDbContext.cs    # EF Core DbContext with 1:1 relationship config
│
├── DTOs/
│   ├── AuthDto.cs                 # Register, Login, AuthResponse DTOs
│   ├── StudentDto.cs              # Student DTOs (Get, Create, Update)
│   └── HostelDto.cs               # Hostel DTOs (Get, Create, Update)
│
├── Models/
│   ├── Student.cs                 # Student entity
│   ├── Hostel.cs                  # Hostel entity (1:1 with Student)
│   └── ApplicationUser.cs         # Identity user with custom properties
│
├── Services/
│   ├── IStudentService.cs         # Student service interface
│   ├── StudentService.cs          # Student business logic
│   ├── IHostelService.cs          # Hostel service interface
│   ├── HostelService.cs           # Hostel business logic
│   ├── IAuthService.cs            # Auth service interface
│   └── AuthService.cs             # JWT token generation & user management
│
├── Program.cs                     # Application configuration & DI setup
├── appsettings.json              # Configuration (DB, JWT settings)
├── StudentRelation.csproj        # Project dependencies
├── StudentRelation.http          # HTTP test requests
└── README.md                     # API documentation
```

## Key Design Decisions

### 1. Repository/Service Pattern
- Controllers are thin, delegating to services
- Services contain business logic and validation
- Easy to test and maintain

### 2. DTOs for Data Transfer
- Prevents over-posting attacks
- Separates internal models from API contracts
- Different DTOs for Create/Update/Get operations

### 3. 1:1 Relationship Implementation
```csharp
// In ApplicationDbContext.cs
modelBuilder.Entity<Student>()
    .HasOne(s => s.Hostel)
    .WithOne(h => h.Student)
    .HasForeignKey<Hostel>(h => h.StudentId)
    .OnDelete(DeleteBehavior.Cascade);
```

### 4. Role-Based Authorization
- Three roles: Admin, Warden, Student
- Attribute-based authorization on controllers
- JWT claims include user roles

### 5. Validation Logic
- Email uniqueness check
- Room availability check (no double-booking)
- Atomic transactions for student + hostel creation

## API Flow Examples

### Creating a Student with Hostel
1. Request hits `StudentsController.CreateStudent()`
2. Controller calls `StudentService.CreateStudentAsync()`
3. Service validates email uniqueness
4. Service validates room availability
5. Service creates Student entity with Hostel navigation property
6. EF Core saves both in single transaction
7. Returns StudentDto with nested HostelDto

### Updating Hostel Room (Warden Access)
1. Request hits `HostelsController.UpdateHostel()`
2. Authorization checks for Admin or Warden role
3. Controller calls `HostelService.UpdateHostelAsync()`
4. Service finds hostel by StudentId
5. Service validates new room isn't occupied
6. Service updates room details
7. Returns updated HostelDto

### Authentication Flow
1. User registers via `AuthController.Register()`
2. Password hashed by Identity
3. User assigned to specified role
4. User logs in via `AuthController.Login()`
5. `AuthService` generates JWT with claims
6. Token returned to client
7. Client includes token in Authorization header
8. JWT middleware validates token on each request

## Database Relationships

```
┌─────────────────┐
│    Students     │
├─────────────────┤
│ Id (PK)         │◄─────┐
│ Name            │      │
│ Email           │      │ 1:1
│ CollegeName     │      │
└─────────────────┘      │
                         │
                    ┌────┴────────────┐
                    │    Hostels      │
                    ├─────────────────┤
                    │ Id (PK)         │
                    │ RoomNumber      │
                    │ BlockName       │
                    │ StudentId (FK)  │
                    └─────────────────┘
```

## Security Features

1. **Password Requirements**: Enforced by Identity
2. **JWT Tokens**: Expire after 60 minutes
3. **Role-Based Access**: Different permissions per role
4. **HTTPS**: Enforced in production
5. **DTOs**: Prevent mass assignment vulnerabilities

## Extensibility Points

Want to add more features? Here's where to start:

- **Add College entity**: Create Models/College.cs, update Student with FK
- **Add attendance**: Create new entity with FK to Student
- **Add fees**: Create new service and controller
- **Add notifications**: Inject IEmailService into controllers
- **Add file uploads**: Add document storage for student records
