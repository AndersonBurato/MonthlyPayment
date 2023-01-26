CREATE DATABASE [TRex]

USE [TRex]

CREATE TABLE Employee
(
    EmployeeId int IDENTITY(1,1),
    Name       varchar(255) NOT NULL,
    Salary     decimal NOT NULL,
    Email      varchar(255) NOT NULL,
    UserName   varchar(255) NOT NULL,
    Password   varchar(255) NOT NULL,
    Role       varchar(5) NOT NULL,
    PRIMARY KEY (EmployeeId)
)

INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Anderson Burato', 1000.00, 'anderson.burato@gmail.com', 'aburato', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Zinaida Olimpiada', 1000.00, 'anderson.burato@gmail.com', 'zolimpiada', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Derval Phelan', 1000.00, 'anderson.burato@gmail.com', 'dphelan', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Pasquale Erica', 1000.00, 'anderson.burato@gmail.com', 'perica', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Kouki Naomi', 1000.00, 'anderson.burato@gmail.com', 'knaomi', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Salary, Email, UserName, Password, Role)VALUES('Nataniel Belinha', 1000.00, 'anderson.burato@gmail.com', 'nbelinha', '1234', 'hr')

CREATE TABLE Payment
(
    EmployeeId int          NOT NULL,
    MonthYear  date         NOT NULL,
    Code       varchar(10) NOT NULL,
    Claimed    bit DEFAULT 0,
    PRIMARY KEY (EmployeeId, MonthYear),
    CONSTRAINT FK_Employee FOREIGN KEY (EmployeeId)
        REFERENCES Employee (EmployeeId)
)