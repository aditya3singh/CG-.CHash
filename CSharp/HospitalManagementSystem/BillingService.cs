class BillingService
{
    public double ConsultationFee { get; set; }
    public double TestCharges { get; set; }
    public double RoomCharges { get; set; }

    public double CalculateTotal()
    {
        return ConsultationFee + TestCharges + RoomCharges;
    }

    public double CalculateTotal(double discount)
    {
        return CalculateTotal() - discount;
    }
}
