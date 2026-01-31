use Sales;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    City VARCHAR(50) NOT NULL,
    Region VARCHAR(50) NOT NULL
);

-- Table 2: SalesPersons
CREATE TABLE SalesPersons (
    SalesPersonID INT PRIMARY KEY,
    SalesPersonName VARCHAR(100) NOT NULL,
    Department VARCHAR(50),
    HireDate DATE
);

-- Table 3: Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    Description VARCHAR(255)
);

-- Table 4: Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID) 
        REFERENCES Categories(CategoryID)
);

-- Table 5: Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT NOT NULL,
    SalesPersonID INT NOT NULL,
    OrderDate DATE NOT NULL,
    OrderStatus VARCHAR(20) DEFAULT 'Pending',
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) 
        REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Orders_SalesPersons FOREIGN KEY (SalesPersonID) 
        REFERENCES SalesPersons(SalesPersonID)
);

-- Table 6: OrderDetails (Junction table for many-to-many relationship)
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10, 2) NOT NULL,
    Discount DECIMAL(5, 2) DEFAULT 0.00,
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) 
        REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductID) 
        REFERENCES Products(ProductID),
    CONSTRAINT UQ_OrderDetails_OrderProduct UNIQUE (OrderID, ProductID)
);





----------------------------------------------------------------------------------------

use Sales;

-- QUESTION 2:
WITH OrderTotals AS (
    SELECT 
        Orders.OrderID, SUM(OrderDetails.Quantity * OrderDetails.UnitPrice) AS TotalSales
        FROM Orders INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID GROUP BY Orders.OrderID
),
RankedOrders AS (
    SELECT OrderID, TotalSales, ROW_NUMBER() OVER (ORDER BY TotalSales DESC) AS RowNum FROM OrderTotals
)
SELECT OrderID, TotalSales FROM RankedOrders WHERE RowNum = 3;

-- QUESTION 3: 
SELECT 
    SalesPersons.SalesPersonName, SUM(OrderDetails.Quantity * OrderDetails.UnitPrice) AS TotalSalesAmount
    FROM SalesPersons INNER JOIN Orders ON SalesPersons.SalesPersonID = Orders.SalesPersonID 
    INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
    GROUP BY SalesPersons.SalesPersonID, SalesPersons.SalesPersonName
    HAVING SUM(OrderDetails.Quantity * OrderDetails.UnitPrice) > 60000 ORDER BY TotalSalesAmount DESC;



-- QUESTION 5:
SELECT 
    UPPER(Customers.CustomerName) AS CustomerName, Orders.OrderID, Orders.OrderDate,
    DATENAME(MONTH, Orders.OrderDate) AS OrderMonth,
    DATEPART(YEAR, Orders.OrderDate) AS OrderYear
FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID 
WHERE Orders.OrderDate >= '2026-01-01' AND Orders.OrderDate < '2026-02-01' ORDER BY Orders.OrderDate;