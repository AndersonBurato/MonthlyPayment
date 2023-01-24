CREATE DATABASE TRex

USE TRex

CREATE TABLE Employee
(
    EmployeeId int IDENTITY(1,1),
    Name       varchar(255) NOT NULL,
    Email      varchar(255) NOT NULL,
    UserName   varchar(255) NOT NULL,
    Password   varchar(255) NOT NULL,
    Role       varchar(255) NOT NULL,
    PRIMARY KEY (EmployeeId)
)

INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Anderson Burato', 'anderson.burato@gmail.com', 'aburato', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Zinaida Olimpiada', 'anderson.burato@gmail.com', 'zolimpiada', '1234', 'employee')
INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Derval Phelan', 'anderson.burato@gmail.com', 'dphelan', '4321', 'employee')
INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Pasquale Erica', 'anderson.burato@gmail.com', 'perica', '4321', 'employee')
INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Kouki Naomi', 'anderson.burato@gmail.com', 'knaomi', '4321', 'employee')
INSERT INTO dbo.Employee(Name, Email, UserName, Password, Role)VALUES('Nataniel Belinha', 'anderson.burato@gmail.com', 'nbelinha', '1234', 'hr')

CREATE TABLE Payment
(
    EmployeeId int          NOT NULL,
    MonthYear  date         NOT NULL,
    Code       varchar(255) NOT NULL,
    Claimed    bit DEFAULT 0,
    PRIMARY KEY (EmployeeId, MonthYear),
    CONSTRAINT FK_Employee FOREIGN KEY (EmployeeId)
        REFERENCES Employee (EmployeeId)
)