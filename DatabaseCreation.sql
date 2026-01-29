CREATE DATABASE SurveyConfigrator 
USE SurveyConfigrator

CREATE TABLE Questions(
Id uniqueidentifier PRIMARY KEY , 
QuestionText VARCHAR(MAX) NOT NULL,
QuestionOrder INT NOT NULL, 
QuestionType INT NOT NULL
)

CREATE TABLE SliderQuestion (
Id  uniqueidentifier PRIMARY KEY , 
StartValue INT  NOT NULL CHECK(StartValue BETWEEN 0 and 99) , 
EndValue INT NOT NULL CHECK(EndValue BETWEEN 0 and 99),
StartCaption VARCHAR(MAX) NOT NULL , 
EndCaption VARCHAR(MAX) NOT NULL
CONSTRAINT FK_SliderQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)

CREATE TABLE SmileyFacesQuestion (
Id  uniqueidentifier PRIMARY KEY , 
SmileyCount INT  NOT NULL CHECK(SmileyCount BETWEEN 2 AND 5) 
CONSTRAINT FK_SmileyFacesQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)

CREATE TABLE StarsQuestion (
Id  uniqueidentifier PRIMARY KEY , 
StarsCount INT  NOT NULL CHECK(StarsCount BETWEEN 1 AND 10) 
 CONSTRAINT FK_StarsQuestion_Questions
        FOREIGN KEY (Id) REFERENCES Questions(Id)
        ON DELETE CASCADE
)

CREATE TABLE DatabaseChangeTracker (
LastModified DATETIME2 NOT NULL
)

INSERT INTO DatabaseChangeTracker (LastModified) VALUES (SYSDATETIME());

