class MedicalRecord
{
    private string diagnosis = ""; 
    private string history = "";  

    public void UpdateRecord(string diag, string hist)
    {
        diagnosis = diag;
        history = hist;
    }

    public string ViewRecord()
    {
        return $"Diagnosis: {diagnosis}, History: {history}";
    }
}
