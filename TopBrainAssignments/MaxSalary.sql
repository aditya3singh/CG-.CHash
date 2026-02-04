use TopBrains

create table Employee(Id int, Name nvarchar(30),Dept nvarchar(10), Salary decimal(10,2))
insert into Employee
values
(1,'Shubhanshu','CSE',100000),
(2,'Ananya','ML',120000),
(3,'Amrita','MEC',70000),
(4,'Mritunjay','ML',95000),
(5,'Ayush','CSE',80000)


select Employee.Dept, Employee.Name, Employee.Salary FROM  Employee 
JOIN (SELECT Employee.Dept, MAX(Salary) AS MaxSalary FROM Employee GROUP BY Dept)
maximum_salaries ON Employee.Dept = maximum_salaries.Dept AND Salary = maximum_salaries.MaxSalary;