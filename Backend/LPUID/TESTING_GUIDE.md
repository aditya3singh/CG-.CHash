# 🧪 Complete Testing Guide

## ✅ Your Application is Running!

**URL:** http://localhost:5284

---

## 📋 Step-by-Step Testing Instructions

### Step 1: Register a New User (Authentication)

1. Open your browser and go to: **http://localhost:5284**
2. Click **Register** (or go to `http://localhost:5284/Account/Register`)
3. Fill in the registration form:
   - **Email**: `admin@lpu.com`
   - **Password**: `Admin@123`
   - **Confirm Password**: `Admin@123`
   
   **Note:** Password must have:
   - At least 6 characters
   - At least one uppercase letter (A-Z)
   - At least one lowercase letter (a-z)
   - At least one number (0-9)
   - At least one special character (@, #, $, etc.)

4. Click **Register**
5. You'll be automatically logged in

---

### Step 2: Login (If Not Already Logged In)

1. Go to: `http://localhost:5284/Account/Login`
2. Enter:
   - **Email**: `admin@lpu.com`
   - **Password**: `Admin@123`
3. Click **Login**

---

### Step 3: Submit Student Admission

1. After login, go to: **http://localhost:5284/Portal/Student/Admission**
2. Fill in the admission form:

   **Required Fields:**
   - **Application Number**: `APP-2026-001` (must be unique)
   - **Course/Program**: Select `B.Tech` from dropdown
   - **Full Name**: `Rajesh Kumar Singh`
   - **Email**: `rajesh.singh@lpu.in`

3. Click **Submit Application & Generate ID**

---

### Step 4: View Student Dashboard

After submission, you'll be automatically redirected to the student dashboard.

**What you'll see:**
- ✅ Student personal information
- ✅ Unique ID Card Number (auto-generated: `LPU-XXXXXX`)
- ✅ Hostel allocation details (auto-assigned)
- ✅ Semester marks (sample data)
- ✅ **CGPA** (automatically calculated from semester marks)
- ✅ Button to view ID Card

**Dashboard URL:** `http://localhost:5284/Portal/Student/{id}/Dashboard`

---

### Step 5: View ID Card

1. On the dashboard, click **"View ID Card"** button
2. You'll see a printable ID card with:
   - Unique Card Number (e.g., `LPU-A1B2C3`)
   - Student photo placeholder
   - Student details
   - Issue date
3. Click **"Print ID Card"** to print

**ID Card URL:** `http://localhost:5284/Portal/Student/{id}/IdCard`

---

### Step 6: View All Students

1. Go to: **http://localhost:5284/Portal/Student**
2. You'll see a list of all registered students
3. Click on any student to view their details

---

## 🎯 Test Multiple Students

Create more students to test uniqueness:

### Student 2:
- Application Number: `APP-2026-002`
- Course: `MBA`
- Full Name: `Priya Sharma`
- Email: `priya.sharma@lpu.in`

### Student 3:
- Application Number: `APP-2026-003`
- Course: `BCA`
- Full Name: `Amit Patel`
- Email: `amit.patel@lpu.in`

---

## ✅ Features to Demonstrate

### 1. Unique Constraints
**Test:** Try to create another student with the same Application Number
- Go to Admission form
- Use Application Number: `APP-2026-001` (already exists)
- Submit
- **Expected:** You should get an error (duplicate key violation)

### 2. CGPA Calculation
- View any student dashboard
- Check the CGPA value
- It's automatically calculated as: **Average of all semester SGPAs**

### 3. Automatic ID Card Generation
- Every new student automatically gets a unique ID card
- Format: `LPU-` + 6 random characters
- No duplicates possible

### 4. Hostel Allocation
- Students are automatically assigned hostel rooms
- Check the dashboard to see hostel details

### 5. Authentication
- Try accessing `/Portal/Student/Admission` without logging in
- You'll be redirected to login page
- This shows the `[Authorize]` attribute is working

---

## 🔍 URLs Quick Reference

| Page | URL |
|------|-----|
| Home | http://localhost:5284 |
| Register | http://localhost:5284/Account/Register |
| Login | http://localhost:5284/Account/Login |
| Admission Form | http://localhost:5284/Portal/Student/Admission |
| All Students | http://localhost:5284/Portal/Student |
| Student Dashboard | http://localhost:5284/Portal/Student/{id}/Dashboard |
| ID Card | http://localhost:5284/Portal/Student/{id}/IdCard |

---

## 🐛 Common Issues & Solutions

### Issue 1: "Cannot access /Portal/Student/Admission"
**Solution:** Make sure you're logged in first

### Issue 2: "Duplicate key error"
**Solution:** Change the Application Number to something unique

### Issue 3: "Page not found"
**Solution:** Make sure the application is running (check terminal)

### Issue 4: "CGPA shows 0"
**Solution:** The DbSeeder should add sample marks automatically. Check if SemesterMarks table has data.

---

## 📊 Database Verification

You can verify data in the database:

1. Open **SQL Server Object Explorer** in Visual Studio
2. Navigate to: `(localdb)\MSSQLLocalDB` → `Databases` → `LPUID_Database`
3. Expand **Tables**
4. Right-click on any table → **View Data**

**Tables to check:**
- `Students` - All student records
- `IdCards` - Unique ID cards
- `HostelAllocations` - Hostel assignments
- `SemesterMarks` - Semester-wise marks
- `AspNetUsers` - Registered users

---

## 🎓 For Your Teacher/Presentation

### Demo Flow:
1. **Show Authentication** → Register/Login
2. **Show Admission Form** → Submit student application
3. **Show Dashboard** → Point out CGPA, hostel, marks
4. **Show ID Card** → Unique card number, printable
5. **Show Code** → Repository, Service, Fluent API
6. **Show Database** → Tables and relationships

### Key Points to Mention:
- ✅ Repository Pattern for data access
- ✅ Service Layer for business logic
- ✅ Fluent API for database configuration
- ✅ Automatic ID generation using GUID
- ✅ CGPA calculation formula
- ✅ Unique constraints enforced
- ✅ ASP.NET Identity for authentication
- ✅ Attribute routing for clean URLs

---

## 🛑 To Stop the Application

When done testing:
1. Go to the terminal where `dotnet run` is running
2. Press **Ctrl+C**
3. Application will stop

---

## 🚀 To Restart

```bash
cd LPUID
dotnet run
```

Then open: http://localhost:5284

---

**Happy Testing! 🎉**
