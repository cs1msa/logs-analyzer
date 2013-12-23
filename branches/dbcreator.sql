----------------------------------------db creator script-----------------------------------------

--------------------------------------Delete tables if exists-------------------------------------
IF OBJECT_ID('dbo.Events', 'U') IS NOT NULL
  DROP TABLE dbo.Events

IF OBJECT_ID('dbo.EventType', 'U') IS NOT NULL
  DROP TABLE dbo.EventType

IF OBJECT_ID('dbo.application', 'U') IS NOT NULL
  DROP TABLE dbo.application

IF OBJECT_ID('dbo.EventService', 'U') IS NOT NULL
  DROP TABLE dbo.EventService

IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL
  DROP TABLE dbo.Customer

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
  DROP TABLE dbo.Users


-------------------------------------------Create tables------------------------------------------
CREATE TABLE EventService
(
	ServiceId INT PRIMARY KEY IDENTITY(1,1),
	ServiceName VARCHAR(30) NOT NULL UNIQUE,
	Service_Description VARCHAR(MAX) DEFAULT ''
)

CREATE TABLE Customer
(
	CustomerId INT PRIMARY KEY IDENTITY(1,1),
	CustomerName VARCHAR(30) UNIQUE,
	CustomerDescrption VARCHAR(200) DEFAULT ''
)

CREATE TABLE Users 
(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(30) NOT NULL UNIQUE,
	UserDescription VARCHAR(200) DEFAULT ''
)

CREATE TABLE application
(
	AppId INT PRIMARY KEY IDENTITY(1,1),
	AppName VARCHAR(30) UNIQUE,
	AppAddress VARCHAR(30) UNIQUE,
	CustomerId INT,
	AppDescription VARCHAR(200) DEFAULT ''
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
)

CREATE TABLE EventType
(
	EventTypeId INT PRIMARY KEY IDENTITY(1,1),
	EventTypeName VARCHAR(30) UNIQUE NOT NULL,
	EventTypePriority SMALLINT NULL,
	EventTypeDescription VARCHAR(200)
)

CREATE TABLE Events
(
	EventId INT PRIMARY KEY IDENTITY(1,1),
	EventAppId INT,
	EventServiceId INT,
	EventTypeId INT,
	EventUserId INT,
	CustomerId INT,
	EventDate DATETIME NOT NULL,
	EventDescription VARCHAR(200)
	FOREIGN KEY (EventAppId) REFERENCES application(AppId),
	FOREIGN KEY (EventServiceId) REFERENCES EventService(ServiceId),
	FOREIGN KEY (EventTypeId) REFERENCES EventType(EventTypeId),
	FOREIGN KEY (EventUserId) REFERENCES Users(UserId),
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
)


