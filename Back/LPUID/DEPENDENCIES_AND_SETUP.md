# 📦 Dependencies & Setup Instructions

## ✅ NuGet Packages (Already Installed)

Your project already has all required dependencies in `LPUID.csproj`:

```xml
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.3" />
<PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="10.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.3" />
```

### What Each Package Does:

1. **Microsoft.AspNetCore.Identity.EntityFrameworkCore**
   - Provides authentication and user management
   - Handles login, registration, password hashing
   - Creates AspNetUsers, AspNetRoles tables

2. **Microsoft.AspNetCore.Identity.UI**
   - Pre-built UI components for Identity
   - Login/Register pages

3. **Microsoft.EntityFrameworkCore.SqlServer**
   - SQL Server database provider for EF Core
   - Enables Code First approach
   - Handles database operations

4. **Microsoft.EntityFrameworkCore.Tools**
   - Migration commands (Add-Migration, Update-Database)
   - Database scaffolding tools
   - Required for Package Manager Console commands

---

## 🔧 No Additional Installation Required!

**You don't need to install anything else.** All packages are already in your project.

---

## 🗄️ Database Setup

### Option 1: SQL Server LocalDB (Recommended - Already Configured)

Your `appsettings.json` is already set up:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

**LocalDB comes with Visual Studio** - no separate installation needed!

### Option 2: Full SQL Server (If you prefer)

If you want to use full SQL Server instead:

1. Install SQL Server Express (free): https://www.microsoft.com/sql-server/sql-server-downloads
2. Update connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

---

## 🚀 First-Time Setup Commands

Open **Package Manager Console** in Visual Studio:
`Tools` → `NuGet Package Manager` → `Package Manager Console`

### Create Database:
```powershell
Update-Database
```

This command:
- Creates the database
- Creates all tables (Students, IdCards, HostelAllocations, SemesterMarks, Identity tables)
- Applies all migrations

### If You Make Model Changes:
```powershell
Add-Migration YourMigrationName
Update-Database
```

---

## 🎯 Verify Installation

### Check if packages are installed:
1. Right-click on project → `Manage NuGet Packages`
2. Go to `Installed` tab
3. You should see all 4 packages listed above

### Check if database is created:
1. Open `View` → `SQL Server Object Explorer`
2. Expand `(localdb)\MSSQLLocalDB` → `Databases`
3. You should see `LPUID_Database`

---

## 🔍 What Gets Created in Database

When you run `Update-Database`, these tables are created:

### Identity Tables (for Authentication):
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- AspNetUserClaims
- AspNetUserLogins
- AspNetUserTokens
- AspNetRoleClaims

### Your Application Tables:
- **Students** (with unique ApplicationNumber)
- **IdCards** (with unique UniqueCardNumber)
- **HostelAllocations**
- **SemesterMarks**

---

## 📝 Configuration Files

### 1. appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LPUID_Database;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 2. Program.cs (Dependency Injection)
```csharp
// Database & Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Repository & Service
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
```

---

## ✅ Pre-Flight Checklist

Before running the application:

- [ ] Visual Studio is installed
- [ ] All NuGet packages are restored (automatic)
- [ ] `Update-Database` command executed successfully
- [ ] Database `LPUID_Database` exists
- [ ] No build errors

---

## 🐛 Common Setup Issues

### Issue: "Unable to resolve service for type ApplicationDbContext"
**Solution:** Ensure `AddDbContext` is in Program.cs before `builder.Build()`

### Issue: "A network-related error occurred"
**Solution:** 
- Check if SQL Server LocalDB is running
- Or change to full SQL Server connection string

### Issue: "Login failed for user"
**Solution:** Use `Trusted_Connection=True` in connection string

### Issue: "Package restore failed"
**Solution:**
```powershell
dotnet restore
```

---

## 🎓 For Your Teacher

**"All dependencies are already installed in the project. To run it:"**

1. Open project in Visual Studio
2. Open Package Manager Console
3. Run: `Update-Database`
4. Press F5 to run

**That's it! No manual package installation needed.**

---

## 📚 Additional Resources

- [Entity Framework Core Docs](https://docs.microsoft.com/ef/core/)
- [ASP.NET Identity Docs](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [ASP.NET MVC Docs](https://docs.microsoft.com/aspnet/core/mvc/overview)

---

**Your project is production-ready! 🚀**
