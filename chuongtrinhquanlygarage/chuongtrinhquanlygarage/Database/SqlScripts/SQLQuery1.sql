CREATE TABLE customers (
    customerID    varchar(15)     NOT NULL,
    name          NVARCHAR(40)    NOT NULL,
    address       NVARCHAR(255)   NOT NULL,
    phoneNumber	  VARCHAR(15)     NOT NULL,
    email         VARCHAR(100)    NOT NULL,
    PRIMARY KEY CLUSTERED (customerID ASC)
);

create table motors (
	licensePlate varchar(11)      not null,
	customerID	 varchar(15)      not null,
	model		 varchar(50)	  not null,
	year		 int			  ,
	primary key clustered (licensePlate asc),
	FOREIGN KEY (customerID) REFERENCES customers(customerID) ON DELETE CASCADE ON UPDATE CASCADE
)

drop table customers

CREATE TABLE employees (
    employeeID    NVARCHAR(5)     NOT NULL,    -- Use string ID, e.g., "E0001"
    employeeName  NVARCHAR(40)    NOT NULL,
    phoneNumber   VARCHAR(15)     NOT NULL,
    gender        NVARCHAR(10)    NOT NULL,    -- Supports diverse options
    email         VARCHAR(100)    NOT NULL UNIQUE, -- Ensure email uniqueness
    empTypeID     VARCHAR(5)     NOT NULL,    -- Foreign key to empType table
    PRIMARY KEY CLUSTERED (employeeID ASC),
    FOREIGN KEY (empTypeID) REFERENCES empType(empTypeID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE users (
    userID        NVARCHAR(5)     NOT NULL,    -- Use string ID, e.g., "U0001"
    username      VARCHAR(50)     NOT NULL UNIQUE,
    password      VARCHAR(255)    NOT NULL,    -- Secure hashed password
    role          VARCHAR(10)     NOT NULL DEFAULT 'user',
    employeeID    NVARCHAR(5)     NOT NULL,    -- Foreign key to employees
    createdAt     DATETIME        NOT NULL DEFAULT GETDATE(),
    updatedAt     DATETIME        NULL,
    PRIMARY KEY CLUSTERED (userID ASC),
    FOREIGN KEY (employeeID) REFERENCES employees(employeeID) ON DELETE CASCADE ON UPDATE CASCADE,
    CHECK (role IN ('admin', 'user')) -- Role validation
);

create table empType(
	empTypeID        varchar(5)                not null,
	name             nvarchar(30)                    not null,
	PRIMARY KEY CLUSTERED (empTypeID ASC)
)

create table parts(
	partID        nvarchar(5)       not null,
	partName      nvarchar(30)      not null,
	quantity      int               not null,
	price         bigint            not null,
	buyPrice BIGINT NOT NULL DEFAULT 0,
    employeePrice BIGINT NOT NULL DEFAULT 0,
    unit NVARCHAR(20),
    limitStock INT NOT NULL DEFAULT 0;
	PRIMARY KEY CLUSTERED (partID ASC),
)

create table RepairOrder(
RepairOrderID          nvarchar(10)    not null,
createdAt              DATETIME        NOT NULL DEFAULT GETDATE(),
status                 nvarchar(20)     not null,
licensePlate           varchar(11)     not null,
employeeID             nvarchar(5)     not null,
total bigint,
note nvarchar(100)
PRIMARY KEY CLUSTERED (RepairOrderID ASC),
FOREIGN KEY (licensePlate) REFERENCES motors(licensePlate),
FOREIGN KEY (employeeID) REFERENCES employees(employeeID)
)

ALTER TABLE RepairOrder
ADD total bigint;

alter table RepairOrder
add note nvarchar(100)

CREATE TABLE RepairDetail (
    partID        nvarchar(5)   NOT NULL,
    RepairOrderID nvarchar(10)  NOT NULL,
    quantity      int           NOT NULL,
	price		  bigint        not null,
    PRIMARY KEY (partID, RepairOrderID),  -- Composite primary key
    FOREIGN KEY (partID) REFERENCES parts(partID),   -- Foreign key to the parts table
    FOREIGN KEY (RepairOrderID) REFERENCES RepairOrder(RepairOrderID)   -- Foreign key to the RepairOrder table
);

create table Invoice(
	invoiceID      varchar(10)     primary key    not null,
	RepairOrderID  nvarchar(10)    not null,
	CheckIn         datetime        not null,
	CheckOut         datetime        not null,
	total   int not null,
	method  nvarchar(30) not null,
	customerName nvarchar(50) not null,
	employeeName nvarchar(50) not null,
	foreign key (RepairOrderID) references RepairOrder(RepairOrderID)
)

INSERT INTO parts (partID, partName, quantity, price) VALUES
('P001', N'Piston', 20, 20000),
('P002', N'Xéc măng', 30, 15000),
('P003', N'Bugi đánh lửa', 50, 5000),
('P004', N'Cam, cò', 25, 25000),
('P005', N'Lọc nhớt', 40, 10000),
('P006', N'Lọc gió', 40, 8000),
('P007', N'Bình xăng con', 10, 35000),
('P008', N'Bơm xăng', 15, 25000),
('P009', N'Bơm nhớt', 15, 22000),
('P010', N'Dây curoa', 50, 12000),
('P011', N'Dây xích và nhông, đĩa', 30, 18000),
('P012', N'Lò xo côn', 35, 15000),
('P013', N'Lá côn', 40, 10000),
('P014', N'Bố nồi', 20, 22000),
('P015', N'Ắc quy', 10, 70000),
('P016', N'Rơ-le đề', 20, 15000),
('P017', N'Mô-tơ đề', 10, 50000),
('P018', N'IC', 30, 30000),
('P019', N'Cuộn điện', 30, 18000),
('P020', N'Đèn pha', 40, 35000),
('P021', N'Đèn hậu', 40, 25000),
('P022', N'Đèn xi nhan', 50, 15000),
('P023', N'Dây điện', 60, 5000),
('P024', N'Còi xe', 50, 7000),
('P025', N'Má phanh', 60, 10000),
('P026', N'Đĩa phanh', 25, 40000),
('P027', N'Dầu phanh', 30, 5000),
('P028', N'Tay phanh', 20, 15000),
('P029', N'Phuộc trước', 15, 80000),
('P030', N'Phuộc sau', 15, 90000),
('P031', N'Gắp xe', 10, 45000),
('P032', N'Chân chống', 50, 7000),
('P033', N'Lốp xe', 20, 150000),
('P034', N'Ruột xe', 20, 40000),
('P035', N'Niềng xe', 15, 25000),
('P036', N'Moay ơ', 30, 20000),
('P037', N'Vành nan hoa', 30, 35000),
('P038', N'Tay ga', 40, 10000),
('P039', N'Dây ga', 50, 8000),
('P040', N'Tay côn', 40, 12000),
('P041', N'Dây côn', 50, 10000),
('P042', N'Gương chiếu hậu', 30, 15000),
('P043', N'Yên xe', 20, 70000),
('P044', N'Lọc nước làm mát', 15, 20000),
('P045', N'Bình xăng', 20, 25000),
('P046', N'Ống pô', 25, 30000),
('P047', N'Gioăng các loại', 100, 3000),
('P048', N'Ốc vít, bu-lông', 500, 2000);

select ro.RepairOrderID, ro.createdAt, name, employeeName, total from RepairOrder ro join employees e on ro.employeeID = e.employeeID
						   join motors m on m.licensePlate = ro.licensePlate
						   join customers c on m.customerID = c.customerID where ro.RepairOrderID = 'RP00000001'

				alter table invoice
				drop column note
