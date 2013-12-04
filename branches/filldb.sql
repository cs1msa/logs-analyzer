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

DELETE FROM site 
DBCC CHECKIDENT('site', RESEED, 0)

INSERT INTO site (SiteName, SiteAddress, SiteDescription)
VALUES ('Wirtualna Polska', 'www.wp', 'News from Poland'),
('onet', 'www.onet', 'Again news from Poland'),
('Football goal', 'www.goal.pl', 'football site'),
('Google', 'www.google.com', 'ask google'),
('JuvePoland', 'www.juvepoland.com', 'Juventus fan website'),
('Amazon', 'www.amazon.com', 'online book shop'),
('YouTube', 'www.youtube.com', 'Movies database'),
('joemonster','www.joemonster.org','funny movies etc.'),
('allegro','www.allegro.pl','online shoping'),
('microsoft','microsoft.com','official microsoft webiste'),
('stack over flow','www.stackoverflow.com','forum for programmers'),
('facebook','www.facebook.com','database of people'),
('twitter','www.twitter.com','database of people activities'),
('linkedin','www.linkedin.com','database of specialists'),
('sggw','www.sggw.com','webiste of sggw university'),
('code guru','www.codeguru.com','database of code'),
('yahoo','www.yahoo.com','news from world'),
('pracuj','www.pracuj.pl','job offers in Poland'),
('oracle','www.oracle.com','official website of oracle'),
('ibm','www.ibm.com','official website of ibm')


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

		INSERT INTO Events( EventSiteId, EventServiceId, EventTypeId, 
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