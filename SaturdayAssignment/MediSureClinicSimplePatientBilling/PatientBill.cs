using System;

class PatientBill
{
    public string BillId { get; set; }
    public string PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal GrossAmount { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal FinalPayable { get; private set; }

    public static PatientBill LastBill { get; private set; }
    public static bool HasLastBill { get; private set; } = false;

    public static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();
        Console.Write("Enter Bill Id: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string insuranceInput = Console.ReadLine();
        bill.HasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

        Console.Write("Enter Consultation Fee: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
        {
            Console.WriteLine("Consultation Fee must be greater than 0.");
            return;
        }
        bill.ConsultationFee = consultationFee;

        Console.Write("Enter Lab Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
        {
            Console.WriteLine("Lab Charges must be 0 or greater.");
            return;
        }
        bill.LabCharges = labCharges;

        Console.Write("Enter Medicine Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
        {
            Console.WriteLine("Medicine Charges must be 0 or greater.");
            return;
        }
        bill.MedicineCharges = medicineCharges;

        bill.CalculateAmounts();
        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        bill.DisplayBillSummary();
    }

    private void CalculateAmounts()
    {
        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;
        DiscountAmount = HasInsurance ? GrossAmount * 0.10m : 0;
        FinalPayable = GrossAmount - DiscountAmount;
    }

    private void DisplayBillSummary()
    {
        Console.WriteLine($"Gross Amount: {GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {FinalPayable:F2}");
    }

    public static void ViewLastBill()
    {
        if (!HasLastBill)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        PatientBill bill = LastBill;
        Console.WriteLine("\n Last Bill ");
        Console.WriteLine($"BillId: {bill.BillId}");
        Console.WriteLine($"Patient: {bill.PatientName}");
        Console.WriteLine($"Insured: {(bill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {bill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {bill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {bill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}