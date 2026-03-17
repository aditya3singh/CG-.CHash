using System;
using System.Collections.Generic;

namespace CollegeApi.Models;

public partial class Hostel
{
    public int Id { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
