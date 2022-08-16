CREATE TABLE [dbo].[Customer](
	CustomerId int primary Key IDENTITY(1,1),
	Name varchar(50),
	Gender varchar(50),
	Age int,
	Adderss varchar(100) NULL,
	PhoneNumber int NULL,
	Citizenship varchar(12) NULL,
	RegisteredDate datetime )

CREATE TABLE Booking(
	BookingId [int] Primary Key IDENTITY(1,1) NOT NULL,
	CustomerId int foreign key References dbo.customer,
	CheckInDate datetime,
	CheckOutDate datetime,
	NoOfRooms varchar(100),
	Price Bigint )

create table Room(
RoomId int Primary key Identity (1,1), 
BookingID Int Foreign Key References dbo.Booking,
RoomNo varchar(100),
occupied varchar(100),
Price Bigint,
TypeOfRoom Varchar(50)
)

Create Table HotelStaff(
Id int Primary Key Identity (1,1),
StaffName nvarchar(100),
Age Int,
Gender nvarchar(5),
Addres nvarchar,
PhoneNumber nvarchar(10),
Position Nvarchar(20),
DateOfJoining DateTime,
Salary Bigint
)

CREATE TABLE Invoice(
	InvoiceId int Primary Key IDENTITY(1,1) NOT NULL,
	BookingId int foreign Key References dbo.Booking,
	CustomerId int Foreign Key References dbo.Customer,
	TotalPrice Bigint,
	isprinted nvarchar(100)
	)
      