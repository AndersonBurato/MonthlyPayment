CREATE TABLE Employee
(
    EmployeeId int IDENTITY(1,1),
    Name       varchar(255) NOT NULL,
    UserName   varchar(255) NOT NULL,
    Password   varchar(255) NOT NULL,
    Role       varchar(255) NOT NULL,
    PRIMARY KEY (EmployeeId)
) INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Anderson Burato', 'aburato', '1234', 'employee')
INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Nataniel Belinha', 'nbelinha', '1234', 'hr')
INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Zinaida Olimpiada', 'zolimpiada', '1234', 'employee')
INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Derval Phelan', 'dphelan', '4321', 'employee')
INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Pasquale Erica', 'perica', '4321', 'employee')
INSERT INTO dbo.Employee(Name, UserName, Password, Role)VALUES('Kouki Naomi', 'knaomi', '4321', 'employee')

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