class Student : Person
{
    private int rollNo;

    // Child constructor
    public Student(string n, int a, int r)
        : base(n, a)   // 👈 sends values to parent constructor
    {
        rollNo = r;
    }

    public void ShowStudent()
    {
        ShowPerson(); // parent method
        Console.WriteLine("Roll No: " + rollNo);
    }
}
