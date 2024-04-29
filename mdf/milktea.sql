USE [FifteaDBConnectionString]
go 

CREATE TABLE Products(
   productid INT           NOT NULL    IDENTITY    PRIMARY KEY,
productname varchar(50),
description varchar(250),
price money,
categoryid int,
isactive bit,
createdby int,
datecreated datetime
);

CREATE TABLE Category(
  categoryid INT           NOT NULL    IDENTITY    PRIMARY KEY,
name  varchar(50),
description varchar(250),
price money,
isactive bit,
createdby int,
datecreated datetime
 
);

CREATE TABLE Orders(
   orderid INT           NOT NULL    IDENTITY    PRIMARY KEY,
      productid int,
	   size int,
	   amount money,
categoryid int,
ishot bit,
staffid int,
datecreated datetime  
   );

   CREATE TABLE Staffs(
staffid INT           NOT NULL    IDENTITY    PRIMARY KEY,
firstname  varchar(50),
lastfname varchar(50),
middlename  varchar(50),
bdate date,
contactnum varchar(15),
address  varchar(50),
username  varchar(50),
password  varchar(50),
groupid int,
isactive bit,
createdby int,
datecreated datetime
   );

      CREATE TABLE SecurityGroups(
groupid INT           NOT NULL    IDENTITY    PRIMARY KEY,
name  varchar(50),
description varchar(50),
isactive bit,
createdby int,
datecreated datetime
   );