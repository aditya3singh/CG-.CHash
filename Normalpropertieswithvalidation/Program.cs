class Program
{
    static void Main()
    {
        
        Student s = new Student("REG2025001")
        {
            StudentId = 101,
            Name = "Aditya",
            Age = 21,
            Marks = 85,
            AdmissionYear = 2025
        };

        s.Password = "secure123";    
        s.Password = "123";

        s.Display();
    }
}
