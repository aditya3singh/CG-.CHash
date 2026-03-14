# 🎯 Quick Test Guide - Profile Picture Feature

## ⚡ 5-Minute Test

### Step 1: Open Application
- URL: `http://localhost:5284`
- Application should be running

### Step 2: Register
- Click **Register**
- Email: `student@lpu.com`
- Password: `Test@123`
- Confirm: `Test@123`
- Click **Register**

### Step 3: Login
- Auto-logged in after registration
- Or go to `/Account/Login`

### Step 4: Upload Picture During Admission
- Go to `/Portal/Student/Admission`
- **Upload Picture** (Required)
  - Click "Choose File"
  - Select any JPG/PNG image from your computer
  - Image preview appears
- Fill form:
  - Application Number: `APP2024001`
  - Full Name: `Test Student`
  - Email: `student@lpu.com`
  - Course: `B.Tech CSE`
- Click **Submit Application**

### Step 5: View Dashboard
- Picture displayed in left sidebar
- Shows student info
- Click **"Change Picture"** button

### Step 6: Change Picture
- Current picture shown
- Click "Choose File"
- Select different image
- Preview appears
- Click **"Update Picture"**
- Picture updated!

### Step 7: View ID Card
- Go back to dashboard
- Click **"View ID Card"**
- Picture displayed on ID card
- Click **"Print ID Card"** to print

---

## ✅ What to Verify

- [x] Picture uploads successfully
- [x] Preview shows before upload
- [x] Picture displays on dashboard
- [x] Picture displays on ID card
- [x] Change picture works
- [x] Old picture deleted
- [x] New picture displayed
- [x] No errors in console

---

## 🎨 Expected Results

### Admission Form
```
✓ File input with "Choose File" button
✓ Image preview section
✓ All form fields visible
✓ Submit button works
```

### Dashboard
```
✓ Profile picture in left sidebar
✓ Circular image with border
✓ Student name and course
✓ "Change Picture" button visible
✓ All student info displayed
```

### ID Card
```
✓ Student photo displayed
✓ Unique card number shown
✓ All details visible
✓ Print button works
```

### Change Picture
```
✓ Current picture shown
✓ File upload input
✓ New picture preview
✓ Update button works
✓ Picture changes on dashboard
```

---

## 🐛 If Something Goes Wrong

### Picture not uploading
- Check file format (JPG, PNG, GIF)
- Check file size (< 5MB)
- Check browser console for errors

### Picture not displaying
- Refresh page (Ctrl+F5)
- Check if ProfilePicturePath saved in database
- Check wwwroot/uploads/profiles/ folder

### Change picture not working
- Ensure logged in
- Check file permissions
- Try different image file

### Database errors
- Run: `dotnet ef database update`
- Check migration applied
- Restart application

---

## 📱 Test on Different Devices

### Desktop
- Chrome, Edge, Firefox
- Upload and change picture
- Print ID card

### Mobile
- Responsive design
- File upload works
- Picture displays correctly

---

## 🎓 Demo Script

**"Let me demonstrate the profile picture feature:"**

1. "First, I'll register a new student" → Show registration
2. "Now I'll submit admission with a profile picture" → Upload image
3. "The picture is displayed on the dashboard" → Show dashboard
4. "I can change the picture anytime" → Click "Change Picture"
5. "The picture also appears on the ID card" → Show ID card
6. "And it's printable" → Show print preview

**"All features working perfectly!"**

---

## 📊 Test Results Template

```
Test Date: ___________
Tester: ___________

Feature: Profile Picture Upload
Status: ✓ PASS / ✗ FAIL
Notes: _____________________

Feature: Picture Display on Dashboard
Status: ✓ PASS / ✗ FAIL
Notes: _____________________

Feature: Picture Display on ID Card
Status: ✓ PASS / ✗ FAIL
Notes: _____________________

Feature: Change Picture
Status: ✓ PASS / ✗ FAIL
Notes: _____________________

Feature: Image Preview
Status: ✓ PASS / ✗ FAIL
Notes: _____________________

Overall Status: ✓ PASS / ✗ FAIL
```

---

## 🚀 Performance Test

### Upload Speed
- Small image (< 1MB): < 1 second
- Medium image (1-3MB): 1-2 seconds
- Large image (3-5MB): 2-3 seconds

### Display Speed
- Dashboard loads: < 2 seconds
- ID card loads: < 1 second
- Picture changes: < 1 second

### Storage
- Each picture: ~100KB - 500KB
- 100 students: ~10-50MB
- 1000 students: ~100-500MB

---

## 📝 Test Cases

### TC-001: Upload Picture During Admission
**Steps:**
1. Go to admission form
2. Upload valid image
3. Fill form
4. Submit

**Expected:** Picture saved and displayed

### TC-002: Change Picture
**Steps:**
1. Go to dashboard
2. Click "Change Picture"
3. Upload new image
4. Click "Update"

**Expected:** Picture updated

### TC-003: View ID Card
**Steps:**
1. Go to dashboard
2. Click "View ID Card"
3. Verify picture

**Expected:** Picture on ID card

### TC-004: Invalid File
**Steps:**
1. Try to upload non-image
2. Try to upload > 5MB

**Expected:** Validation error

### TC-005: Persistence
**Steps:**
1. Upload picture
2. Logout
3. Login
4. Check dashboard

**Expected:** Picture still there

---

## 🎯 Success Criteria

- ✅ Picture uploads without errors
- ✅ Picture displays on dashboard
- ✅ Picture displays on ID card
- ✅ Change picture works
- ✅ Old picture deleted
- ✅ No console errors
- ✅ Responsive on mobile
- ✅ Print works correctly

**All criteria met = Feature Complete! 🎉**

---

## 📞 Quick Troubleshooting

| Issue | Solution |
|-------|----------|
| Picture not uploading | Check file format and size |
| Picture not displaying | Refresh page, check database |
| Change picture fails | Check file permissions |
| Database error | Run `dotnet ef database update` |
| Folder not found | Create `wwwroot/uploads/profiles/` |

---

**Ready to test! Good luck! 🚀**
