class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public readonly string LicenseNumber;

    public static int TotalDoctors;

    static Doctor()
    {
        TotalDoctors = 0;
        Console.WriteLine("Doctor system initialized.");
    }

    public Doctor(string name, string spec, string license)
    {
        Name = name;
        Specialization = spec;
        LicenseNumber = license;
        TotalDoctors++;
    }


}


class Cardiologist : Doctor
{
    public Cardiologist(string name, string spec, string license)
        : base(name, spec, license)
    {
        Console.WriteLine($"Name for the parent: {Name}");
        Console.WriteLine($"Name for the parent: {Specialization}");
        Console.WriteLine($"Name for the parent: {LicenseNumber}");
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Total Doctors: {TotalDoctors}");
        Console.WriteLine($"Name for the parent: {Name}");
        Console.WriteLine($"Name for the parent: {Specialization}");
        Console.WriteLine($"Name for the parent: {LicenseNumber}");
    }
    
}