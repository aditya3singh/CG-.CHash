class DiagnosisService
{
    public void Evaluate(
        in int age,
        ref string condition,
        out string riskLevel,
        params int[] testScores)
    {
        int total = 0;

        // Local function
        int Average()
        {
            foreach (int s in testScores)
                total += s;
            return total / testScores.Length;
        }
        static string Risk(int avg)
        {
            return avg > 70 ? "High" : "Low";
        }

        int avgScore = Average();
        condition = avgScore > 60 ? "Critical" : "Stable";
        riskLevel = Risk(avgScore);
    }
}
