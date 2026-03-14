# Usage Scenarios & Examples

## Scenario 1: New Student Admission with Hostel Assignment

**As an Admin**, I want to admit a new student and assign them a hostel room.

```http
POST /api/students
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "name": "Rahul Kumar",
  "email": "rahul@college.edu",
  "collegeName": "Engineering College",
  "hostel": {
    "roomNumber": "A-101",
    "blockName": "Block A"
  }
}
```

**Response**: Student created with hostel assignment in a single transaction.

---

## Scenario 2: Student Admission without Hostel (Day Scholar)

**As an Admin**, I want to admit a day scholar who doesn't need hostel.

```http
POST /api/students
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "name": "Priya Sharma",
  "email": "priya@college.edu",
  "collegeName": "Engineering College"
}
```

**Response**: Student created without hostel assignment.

---

## Scenario 3: Warden Changes Room Number

**As a Warden**, I need to move a student to a different room.

```http
PUT /api/hostels/student/5
Authorization: Bearer {warden_token}
Content-Type: application/json

{
  "roomNumber": "B-205",
  "blockName": "Block B"
}
```

**Response**: Hostel room updated. The system validates that B-205 is not already occupied.

---

## Scenario 4: Update Student Personal Details

**As an Admin**, I want to update a student's email or name.

```http
PUT /api/students/5
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "name": "Rahul Kumar Singh",
  "email": "rahul.singh@college.edu",
  "collegeName": "Engineering College"
}
```

**Response**: Student details updated. Hostel assignment remains unchanged.

---

## Scenario 5: Student Leaves - Remove from System

**As an Admin**, I want to remove a student who has left the college.

```http
DELETE /api/students/5
Authorization: Bearer {admin_token}
```

**Response**: Student deleted. Their hostel record is automatically removed (cascade delete).

---

## Scenario 6: View All Students and Their Rooms

**As a Warden**, I want to see all students and their hostel assignments.

```http
GET /api/students
Authorization: Bearer {warden_token}
```

**Response**:
```json
[
  {
    "id": 1,
    "name": "Rahul Kumar",
    "email": "rahul@college.edu",
    "collegeName": "Engineering College",
    "hostel": {
      "id": 1,
      "roomNumber": "A-101",
      "blockName": "Block A",
      "studentId": 1
    }
  },
  {
    "id": 2,
    "name": "Priya Sharma",
    "email": "priya@college.edu",
    "collegeName": "Engineering College",
    "hostel": null
  }
]
```

---

## Scenario 7: View All Hostel Occupancy

**As a Warden**, I want to see which rooms are occupied.

```http
GET /api/hostels
Authorization: Bearer {warden_token}
```

**Response**:
```json
[
  {
    "id": 1,
    "roomNumber": "A-101",
    "blockName": "Block A",
    "studentId": 1
  },
  {
    "id": 3,
    "roomNumber": "B-205",
    "blockName": "Block B",
    "studentId": 5
  }
]
```

---

## Scenario 8: Check Specific Student's Hostel

**As a Warden**, I want to find which room a specific student is in.

```http
GET /api/hostels/student/1
Authorization: Bearer {warden_token}
```

**Response**:
```json
{
  "id": 1,
  "roomNumber": "A-101",
  "blockName": "Block A",
  "studentId": 1
}
```

---

## Scenario 9: Remove Hostel Assignment (Student Becomes Day Scholar)

**As an Admin**, I want to remove a student's hostel assignment.

```http
DELETE /api/hostels/student/1
Authorization: Bearer {admin_token}
```

**Response**: Hostel record deleted. Student record remains intact.

---

## Error Scenarios

### Attempting to Assign Occupied Room

```http
POST /api/students
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "name": "New Student",
  "email": "new@college.edu",
  "collegeName": "Engineering College",
  "hostel": {
    "roomNumber": "A-101",
    "blockName": "Block A"
  }
}
```

**Response**: `400 Bad Request`
```json
{
  "message": "This room is already occupied."
}
```

### Warden Trying to Delete Student

```http
DELETE /api/students/1
Authorization: Bearer {warden_token}
```

**Response**: `403 Forbidden` - Wardens can only update hostel details, not delete students.

### Duplicate Email Registration

```http
POST /api/students
Authorization: Bearer {admin_token}
Content-Type: application/json

{
  "name": "Another Student",
  "email": "rahul@college.edu",
  "collegeName": "Engineering College"
}
```

**Response**: `400 Bad Request`
```json
{
  "message": "A student with this email already exists."
}
```

### Unauthorized Access

```http
GET /api/students
```

**Response**: `401 Unauthorized` - No token provided.

---

## Multi-Step Workflow: Complete Student Lifecycle

### Step 1: Register Admin
```http
POST /api/auth/register
{
  "username": "admin",
  "email": "admin@college.edu",
  "password": "Admin@123",
  "fullName": "College Admin",
  "role": "Admin"
}
```

### Step 2: Login
```http
POST /api/auth/login
{
  "username": "admin",
  "password": "Admin@123"
}
```
Save the token.

### Step 3: Admit Student with Hostel
```http
POST /api/students
Authorization: Bearer {token}
{
  "name": "Student One",
  "email": "student1@college.edu",
  "collegeName": "Engineering College",
  "hostel": {
    "roomNumber": "101",
    "blockName": "A"
  }
}
```

### Step 4: Register Warden
```http
POST /api/auth/register
{
  "username": "warden",
  "email": "warden@college.edu",
  "password": "Warden@123",
  "fullName": "Hostel Warden",
  "role": "Warden"
}
```

### Step 5: Warden Changes Room
```http
PUT /api/hostels/student/1
Authorization: Bearer {warden_token}
{
  "roomNumber": "205",
  "blockName": "B"
}
```

### Step 6: View Updated Student
```http
GET /api/students/1
Authorization: Bearer {token}
```

### Step 7: Student Graduates - Remove
```http
DELETE /api/students/1
Authorization: Bearer {admin_token}
```

---

## Advanced Queries (Future Extensions)

These would require additional endpoints:

1. **Find all students in a specific college**
   - Filter students by collegeName

2. **Find all available rooms in a block**
   - Query hostels, find gaps in room numbers

3. **Find all students without hostel**
   - Filter students where hostel is null

4. **Room occupancy report**
   - Group by block, count occupied rooms

5. **Student search by name or email**
   - Add search parameters to GET /api/students
