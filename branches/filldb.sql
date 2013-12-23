------------------------------------------------Date generator------------------------------

-------------------------------------------EventService-------------------------------------
DELETE FROM Events
DELETE FROM EventService
DBCC CHECKIDENT('EventService', RESEED, 0)

INSERT INTO EventService(ServiceName, Service_Description) 
VALUES('ExampleService1','ExampleServiceDescription1')

INSERT INTO EventService(ServiceName, Service_Description) 
VALUES('ExampleService2','ExampleServiceDescription2')

INSERT INTO EventService(ServiceName, Service_Description) 
VALUES('ExampleService3','ExampleServiceDescription3')

INSERT INTO EventService(ServiceName, Service_Description) 
VALUES('ExampleService4','ExampleServiceDescription4')

-------------------------------------Customer------------------------------------------
IF OBJECT_ID('dbo.cust_help', 'U') IS NOT NULL
  DROP TABLE dbo.cust_help

CREATE TABLE cust_help 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(30)
)

INSERT INTO cust_help (name)
VALUES ('Paul_Newman'),
('Oxy23'),
('AlexPC'),
('John_Kowalski21'),
('myUserName213'),
('Lebinski23234'),
('Angelayoung22'),
('random_username22'),
('GeorgeBusz'),
('programmerEla11')


DELETE FROM Customer

DBCC CHECKIDENT('Customer', RESEED, 0)

DECLARE @i INT

SET @i = 1;

WHILE @i<300
BEGIN
	INSERT INTO Customer(CustomerName, CustomerDescrption)
	VALUES (
	(SELECT name + CONVERT(VARCHAR(3),@i) FROM cust_help WHERE id = (FLOOR(RAND() * (10)) + 1)), 
	'ExampleDescription' + CONVERT(VARCHAR(3),@i))

	SET @i = @i + 1;
END

DROP TABLE cust_help


------------------------------------------Users----------------------------------------------
IF OBJECT_ID('dbo.user_help', 'U') IS NOT NULL
  DROP TABLE dbo.user_help

CREATE TABLE user_help 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	name varchar(30)
)

INSERT INTO user_help (name)
VALUES ('AndrewRosicky22'),
('JohnCrouch11'),
('NatalieStallone23'),
('MichaelFajfer23'),
('LeticiaOgrana23'),
('bestuseronworld2'),
('lysamenda_smith3'),
('chicodepadova1'),
('PastorKlaster2'),
('UserNameOfUser23')

DELETE FROM Users
DBCC CHECKIDENT('Users', RESEED, 0)

--DECLARE @i INT
SET @i = 1;

WHILE @i<100
BEGIN
	INSERT INTO Users(UserName, UserDescription)
	VALUES (
	(SELECT name + CONVERT(VARCHAR(3),@i) FROM user_help WHERE id = (FLOOR(RAND() * (10)) + 1)), 
	'ExampleUserDescription' + CONVERT(VARCHAR(3),@i))

	SET @i = @i + 1;
END

DROP TABLE user_help

-----------------------------------------------site--------------------------------------------------

DELETE FROM application 
DBCC CHECKIDENT('application', RESEED, 0)

INSERT INTO application(AppName, AppAddress, AppDescription)
VALUES ('Paint', 'C:\Windows\Paint', 'Pinting program'),
('Oracle.exe', 'C:\ProgramFiles\Oracle', 'Database program from Oracle'),
('Gadu-gadu', 'C:\GaduGadu\gg10', 'Communicator'),
('VisualStudio', 'C:\ProgramFiles\VS', 'Developer environment from microsoft'),
('Notepad', 'C:\windows\notepadFolder', 'Simple Notepad'),
('MSSQL', 'C:\System\Programs\MS', 'SQL Server from microsoft'),
('PES2009', 'C:\Play\PES', 'Football game in free time'),
('Skype','C:\System\Programs\Skype','Communicator Skype'),
('IceTower','C:\Play\Ice','Game for relax'),
('Word','C:\System\Programs\Word','Microsoft Word'),
('Fifa','C:\Play\Fifa','game for relax'),
('OutLook','C:\System\Programs\Outlook','Mail Program'),
('Graph','C:\System\Programs\Graph','Econometric program'),
('BattleField','C:\Play\BF','Game for programmers'),
('explorer','C:\windows\system','explorer of windows'),
('eclipse','C:\System\Programs\eclipse','java program'),
('Sopcast','C:\online\sopcast','streaming online'),
('Adobe','C:\System\Programs\Adobe','Adobe Reader'),
('Xamarin','C:\Addons\XamarinStudio','Addon to VS'),
('ibm','C:\System\Programs\ibm','One of IBM programs to test')


-----------------------------------------EventType-------------------------------------------
DELETE FROM EventType
DBCC CHECKIDENT('EventType', RESEED, 0)

INSERT INTO EventType(EventTypeName, EventTypePriority, EventTypeDescription)
VALUES ('click', 1 , 'Just clicking somewhere on website'),
('ClickOnLink', 3, 'Clicking on hiperlink'),
('Withdrawal', 2, 'Step back'),
('Exit', 4, 'Exit from website'),
('ClickOnButton',2 , 'Clicking on button'),
('OpenWebsite',5 , 'Opening this webiste'),
('CloseAdd',2 , 'Close the advertisment'),
('OpenFromGoogle',3 , 'Open website directly from google'),
('Register',4 , 'New user on webiste'),
('Log out',3 , 'Log out from webiste')


----------------------------------------Events-----------------------------------------------

	DBCC CHECKIDENT('Events', RESEED, 0)


	--DECLARE @i INT
	SET @i = 1;

	WHILE @i<3134
	BEGIN

		INSERT INTO Events( EventAppId, EventServiceId, EventTypeId, 
							EventUserId, CustomerId, EventDate, EventDescription)
		VALUES (
		((FLOOR(RAND() * (20)) + 1)), -- EventSiteId
		((FLOOR(RAND() * (4)) + 1)), --EventServiceId
		((FLOOR(RAND() * (10)) + 1)), --EventTypeId
		((FLOOR(RAND() * (99)) + 1)), --EventTypeId
		((FLOOR(RAND() * (299)) + 1)), --EventTypeId
		(DATEADD(day, (ABS(CHECKSUM(NEWID())) % 65530), 0)),
		'ExampleDescription' + CONVERT(VARCHAR(3),@i))

		SET @i = @i + 1

	END