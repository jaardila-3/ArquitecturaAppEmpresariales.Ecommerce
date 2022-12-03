CREATE PROCEDURE CustomersInsert
(
	@CustomerID nchar (5) ,
	@CompanyName nvarchar (40) ,
	@ContactName nvarchar (30) NULL ,
	@ContactTitle nvarchar (30) NULL ,
	@Address nvarchar (60) NULL ,
	@City nvarchar (15) NULL ,
	@Region nvarchar (15) NULL ,
	@PostalCode nvarchar (10) NULL ,
	@Country nvarchar (15) NULL ,
	@Phone nvarchar (24) NULL ,
	@Fax nvarchar (24) NULL
)
AS
BEGIN

    INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
    VALUES(@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)

END
GO

CREATE PROCEDURE CustomersUpdate
(
	@CustomerID nchar (5) ,
	@CompanyName nvarchar (40) ,
	@ContactName nvarchar (30) NULL ,
	@ContactTitle nvarchar (30) NULL ,
	@Address nvarchar (60) NULL ,
	@City nvarchar (15) NULL ,
	@Region nvarchar (15) NULL ,
	@PostalCode nvarchar (10) NULL ,
	@Country nvarchar (15) NULL ,
	@Phone nvarchar (24) NULL ,
	@Fax nvarchar (24) NULL
)
AS
BEGIN

    UPDATE Customers
        SET
        CompanyName=@CompanyName,
        ContactName=@ContactName,
        ContactTitle=@ContactTitle,
        Address=@Address,
        City=@City,
        Region=@Region,
        PostalCode=@PostalCode,
        Country=@Country,
        Phone=@Phone,
        Fax=@Fax
    WHERE CustomerID=@CustomerID

END
GO

CREATE PROCEDURE CustomersDelete
(
	@CustomerID nchar (5)
)
AS
BEGIN

    DELETE Customers
    WHERE CustomerID=@CustomerID

END
GO

CREATE PROCEDURE CustomersList
AS
BEGIN

    SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax
    FROM Customers

END
GO

CREATE PROCEDURE CustomersGetByID
(
    @CustomerID nchar (5)
)
AS
BEGIN

    SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax
    FROM Customers
    WHERE CustomerID=@CustomerID

END
GO