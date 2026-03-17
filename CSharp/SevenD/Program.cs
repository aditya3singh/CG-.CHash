using System;

class Program
{
    static void Main(string[] args)
    {
        // Arrays.Arr();
        // Clear.ClearArr();
        // Clear.CopyArr();
        // ReSizess.ReSizessArr();
        // Collections.CollectionsArr();
        // HashTabless.HashTablessArr();
        // Stacks.StacksArr();
        // Dictionary.DictionaryArr();
        // MergererSorted.MergererSortedArr();
        // Frequency.FrequencyArr();

        // Console.WriteLine("Enter the word");
        // string input = Console.ReadLine();
        // string result = Assignment.CleanseAndInvert(input);
        // Console.WriteLine(result);

        PayRoll payroll = new PayRoll();
        while (true)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Select Employee Type (1-Full Time, 2-Contract): ");
                int empType = int.Parse(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                string empName = Console.ReadLine();

                Console.Write("Enter Hourly Rate: ");
                double hourlyRate = double.Parse(Console.ReadLine());

                double[] weeklyHours = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Enter weekly hours (Week {i + 1}): ");
                    weeklyHours[i] = double.Parse(Console.ReadLine());
                }

                if (empType == 1)
                {
                    Console.Write("Enter Monthly Bonus: ");
                    double monthlyBonus = double.Parse(Console.ReadLine());
                    FullTimeEmployee fullTimeEmp = new FullTimeEmployee
                    {
                        EmployeeName = empName,
                        HourlyRate = hourlyRate,
                        MonthlyBonus = monthlyBonus,
                        weeklyHours = weeklyHours
                    };
                    payroll.RegisterEmployee(fullTimeEmp);
                }
                else
                {
                    ContractEmployee contractEmp = new ContractEmployee
                    {
                        EmployeeName = empName,
                        HourlyRate = hourlyRate,
                        weeklyHours = weeklyHours
                    };
                    payroll.RegisterEmployee(contractEmp);
                }

                Console.WriteLine("Employee registered successfully");
            }
            else if (choice == 2)
            {
                Console.Write("Enter hours threshold: ");
                double hoursThreshold = double.Parse(Console.ReadLine());
                
                var overtimeCounts = payroll.GetOvertimeWeekCounts(PayRoll.PayrollBoard, hoursThreshold);
                
                if (overtimeCounts.Count == 0)
                    Console.WriteLine("No overtime recorded this month");
                
                foreach (var kvp in overtimeCounts)
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
            else if (choice == 3)
            {
                double averagePay = payroll.CalculateAverageMonthlyPay();
                Console.WriteLine($"Overall average monthly pay: {averagePay}");
            }
            else if (choice == 4)
            {
                Console.WriteLine("Logging off — Payroll processed successfully!");
                break;
            }
        }
    }
}
