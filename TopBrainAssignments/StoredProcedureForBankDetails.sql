use TopBrainsAssignments;

-- Table 1: Customers
CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);
-- Table 2: Accounts
CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), -- Savings / Current
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
-- Table 3: Transactions
CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), -- Deposit / Withdraw
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);
-- Table 4: Bonus
CREATE TABLE Bonus
(
    BonusID INT PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

-- 2 Sample Data Customers
INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');
        -- Accounts
INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);
-- Transactions
INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000);




use TopBrainsAssignments;
/*

-- 1
Question 1 – Stored Procedure (Date Range + Aggregation)
Write a stored procedure that accepts:
@StartDate, @EndDate, @AccountID

Output:
Total Deposited Amount during the given period
Total Withdrawn Amount during the given period
The procedure should return both values in a single result.
*/

Create proc GetTransactionSummary
@StartDate Date,
@EndDate Date,
@AccountId int

as begin
select 
ISNULL(sum(case when TransactionType = 'Deposit' then Amount else 0 end), 0) as TotalDeposited,
ISNULL(SUM(case when TransactionType = 'Withdraw' then Amount else 0 end), 0) as TotalWithdrawn

from Transactions where AccountID = @AccountId and TransactionDate between @StartDate and @EndDate;
end;

EXEC GetTransactionSummary 
    @StartDate = '2024-01-01',
    @EndDate = '2024-01-31',
    @AccountID = 101;


/*Question 2 – Monthly Bonus Update (Business Rule + Grouping)
Bank policy:
If an account’s total deposited amount in a month exceeds ₹50,000. The customer is eligible for a bonus of ₹1,000

Task:
Identify eligible accounts month-wise
Insert bonus records into the Bonus table
Bonus should be credited only once per account per month
*/
USE TopBrainsAssignments;

create proc processmonthlybonus
as
begin
    set nocount on;

insert into bonus (bonusid, accountid, bonusmonth, bonusyear, bonusamount, createddate)
    select
        row_number() over (
            order by monthlydata.accountid,
                 monthlydata.bonusmonth,
                 monthlydata.bonusyear
        )
        + isnull((select max(bonusid) from bonus), 0),
    monthlydata.accountid,
    monthlydata.bonusmonth,
    monthlydata.bonusyear,
        1000,
    getdate()
    from
    (
        select
            transactions.accountid,
        month(transactions.transactiondate) as bonusmonth,
        year(transactions.transactiondate) as bonusyear
        from transactions
        where transactions.transactiontype = 'deposit'
        group by
            transactions.accountid,
        month(transactions.transactiondate),
        year(transactions.transactiondate)
        having sum(transactions.amount) > 50000
    ) as monthlydata
    where not exists
    (
        select 1
        from bonus
        where bonus.accountid = monthlydata.accountid
          and bonus.bonusmonth = monthlydata.bonusmonth
          and bonus.bonusyear  = monthlydata.bonusyear
    );
end;

exec processmonthlybonus;


--question 3

create proc usp_userInfo
as
begin
create table #userinfo (customername nvarchar(50), accountnumber nvarchar(50), currentbalance decimal(12,2));
insert into #userinfo (customername, accountnumber, currentbalance)
select customers.customername, accounts.accountnumber,
sum( case when transactions.transactiontype = 'deposit' then transactions.amount when transactions.transactiontype = 'withdraw' then - transactions.amount else 0 end ) as currentbalance

from customers inner join accounts on customers.customerid = accounts.customerid inner join transactions  on transactions.accountid = accounts.accountid
group by customers.customername, accounts.accountnumber;

select* from #userinfo
end

exec usp_userInfo

