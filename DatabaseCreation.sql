
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'SurveyConfigrator')
BEGIN
    CREATE DATABASE testDatabase
END;
Go
USE testDatabase
Go

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Questions')
BEGIN
CREATE TABLE Questions(
Id INT IDENTITY (1,1) PRIMARY KEY , 
QuestionText VARCHAR(MAX) NOT NULL,
QuestionOrder INT NOT NULL, 
QuestionType INT NOT NULL
)
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SliderQuestion')
BEGIN
CREATE TABLE SliderQuestion (
Id  INT  PRIMARY KEY , 
StartValue INT  NOT NULL CHECK(StartValue BETWEEN 0 and 99) , 
EndValue INT NOT NULL CHECK(EndValue BETWEEN 1 and 100),
StartCaption VARCHAR(MAX) NOT NULL , 
EndCaption VARCHAR(MAX) NOT NULL
CONSTRAINT FK_SliderQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SmileyFacesQuestion')
BEGIN
CREATE TABLE SmileyFacesQuestion (
Id  INT  PRIMARY KEY , 
SmileyCount INT  NOT NULL CHECK(SmileyCount BETWEEN 2 AND 5) 
CONSTRAINT FK_SmileyFacesQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'StarsQuestion')
BEGIN
CREATE TABLE StarsQuestion (
Id  INT  PRIMARY KEY , 
StarsCount INT  NOT NULL CHECK(StarsCount BETWEEN 1 AND 10) 
 CONSTRAINT FK_StarsQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)

END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DatabaseChangeTracker')
BEGIN
CREATE TABLE DatabaseChangeTracker (
LastModified DATETIME2 NOT NULL
)

INSERT INTO DatabaseChangeTracker (LastModified) VALUES (SYSDATETIME());
END
