static class InputHelper
{
    public static void ValidateAge(int age)
    {
        if (age <= 0)
            throw new Exception("Invalid patient age");
    }

    public static void ValidateAmount(double amount)
    {
        if (amount < 0)
            throw new Exception("Invalid billing amount");
    }
}
