class Patient
{
    public int PatientId { get; }
    public string Name { get; set; }
    public int Age { get; set; }

    private string medicalHistory = ""; 

    public Patient()
    {
        PatientId = 0;
        Name = "Unknown";
        Age = 0;
    }

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }

    public Patient(int id, string name)
    {
        PatientId = id;
        Name = name;
    }

    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }

    public string GetMedicalHistory()
    {
        return medicalHistory;
    }
}
