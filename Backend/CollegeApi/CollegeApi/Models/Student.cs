using System;
using System.Collections.Generic;

namespace CollegeApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Hostel? Hostel { get; set; }
}
