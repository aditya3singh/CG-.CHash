/*
PayRollPro – OOPS + Collections Based Problem Statement (C# Console App)
Scenario-based assessment question (StreamBuzz-style pattern)

You are developing a C# console application for PayRollPro, an HR payroll platform that tracks employees’ working hours over 4 weeks and calculates monthly pay using OOPS (Inheritance + Polymorphism).
Each employee’s name and weekly work hours are recorded using a base class, and pay is calculated differently depending on the employee type.
Functionalities
1) Class Design (OOPS Requirement)
In class EmployeeRecord (Abstract Base Class), implement the below-given public properties.
Datatype
Properties
string
EmployeeName
double[]
WeeklyHours

Also, implement the below-given public abstract method:
public abstract double GetMonthlyPay();
In class FullTimeEmployee : EmployeeRecord, implement the below-given public properties.
Datatype
Properties
double
HourlyRate
double
MonthlyBonus

Override GetMonthlyPay() to return:
(Sum of all WeeklyHours × HourlyRate) + MonthlyBonus
In class ContractEmployee : EmployeeRecord, implement the below-given public property.
Datatype
Properties
double
HourlyRate

Override GetMonthlyPay() to return:
(Sum of all WeeklyHours × HourlyRate)
2) Static Collection
public static List<EmployeeRecord> PayrollBoard – In the code template, it is already provided.
3) Implement the below-given methods
Method
Description
public void RegisterEmployee(EmployeeRecord record)
This method is used to register an employee record into the PayrollBoard property.
public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
This method counts the number of weeks in which each employee’s WeeklyHours are greater than or equal to the given hoursThreshold. Return a dictionary where key = EmployeeName, value = number of qualifying weeks. If no employee meets the threshold even once, return an empty dictionary.
public double CalculateAverageMonthlyPay()
This method calculates and returns the average monthly pay of all employees in PayrollBoard using polymorphism (i.e., calling GetMonthlyPay() for each employee). If no employees exist, return 0.

In Program class, Main method
Get values from the user.
Call the methods accordingly and display the result.
When choice 1 is selected: prompt the user to choose employee type (1-Full Time, 2-Contract), input EmployeeName, WeeklyHours for four weeks, HourlyRate, and (for Full Time) MonthlyBonus; create the appropriate object and print "Employee registered successfully".
When choice 2 is selected: prompt the user to input hoursThreshold, call GetOvertimeWeekCounts, and print EmployeeName - Count for each employee. If the method returns an empty dictionary, display "No overtime recorded this month".
When choice 3 is selected: print "Overall average monthly pay: <average>".
When choice 4 is selected: display "Logging off — Payroll processed successfully!" and terminate the program.
Note
Keep the methods and classes as public.
Please read the method rules clearly.
Do not use Environment.Exit() to terminate the program.
Do not change the given code template.
In the Sample Input/Output provided, the values in bold correspond to the input given by the user.
Sample Input / Output
1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
1

Select Employee Type (1-Full Time, 2-Contract):
1

Enter Employee Name:
Priya

Enter Hourly Rate:
500

Enter Monthly Bonus:
5000

Enter weekly hours (Week 1 to 4):
40
42
45
38

Employee registered successfully

---

1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
1

Select Employee Type (1-Full Time, 2-Contract):
2

Enter Employee Name:
Arjun

Enter Hourly Rate:
400

Enter weekly hours (Week 1 to 4):
30
35
40
45

Employee registered successfully

---

1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
2

Enter hours threshold:
40

Priya - 3
Arjun - 2

---

1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
2

Enter hours threshold:
60

No overtime recorded this month

---

1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
3

Overall average monthly pay: 73750

---

1. Register Employee
2. Show Overtime Summary
3. Calculate Average Monthly Pay
4. Exit

Enter your choice:
4

Logging off — Payroll processed successfully!



*/
using System;
using System.Collections.Generic;

public abstract class EmployeeRecord
{
    public string EmployeeName {get; set;}
    public double[] weeklyHours {get; set;}
    public abstract double GetMonthlyPay();
}
public class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public double MonthlyBonus{get; set;}
    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach(double hours in weeklyHours)
        {
            totalHours += hours;
        }
        return (totalHours * HourlyRate) + MonthlyBonus;
    }


}

public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach(double hours in weeklyHours)
        {
            totalHours += hours;
        }
        return totalHours * HourlyRate;
    }
}
public class PayRoll
{
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();
    public void RegisterEmployee(EmployeeRecord record)
    {
        PayRoll.PayrollBoard.Add(record);
    }
    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> overtimeCounts = new Dictionary<string, int>();
        foreach(EmployeeRecord record in records)
        {
            int count = 0;
            foreach(double hours in record.weeklyHours)
            {
                if(hours >= hoursThreshold)
                {
                    count++;
                }

            }
            if(count > 0)
            {
                overtimeCounts.Add(record.EmployeeName, count);

            }

        }
        return overtimeCounts;
    }
    public double CalculateAverageMonthlyPay()
    {
        if(PayRoll.PayrollBoard.Count == 0)
        {
            return 0;
        }
        double totalPay = 0;
        foreach(EmployeeRecord record in PayRoll.PayrollBoard)
        {
            totalPay += record.GetMonthlyPay();
        }
        return totalPay / PayRoll.PayrollBoard.Count;

    }

}
