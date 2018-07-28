USE MASTER
GO

DROP DATABASE IF EXISTS NewsApp
GO

CREATE DATABASE NewsApp
GO

USE NewsApp 
GO

CREATE TABLE News (
  Id int NOT NULL IDENTITY(1,1),
  Name varchar(200) NOT NULL,
  Description text NOT NULL,
  Category varchar(200) NOT NULL,
  Author varchar(200) NOT NULL,
  CreatedTimestamp DateTime NOT NULL,
  CONSTRAINT PK_News_Id PRIMARY KEY CLUSTERED (Id)
)
GO

INSERT INTO News (Name, Description, Category, Author, CreatedTimestamp)
VALUES ('Great News', 'short description', 'Local news', 'Luka','2018-07-27 22:34:09');