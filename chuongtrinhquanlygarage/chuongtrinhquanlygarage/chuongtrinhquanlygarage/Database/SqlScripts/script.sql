USE [master]
GO
/****** Object:  Database [QLSuaXe]    Script Date: 1/6/2025 8:09:50 AM ******/
CREATE DATABASE [QLSuaXe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLSuaXe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLSuaXe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLSuaXe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLSuaXe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLSuaXe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSuaXe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSuaXe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSuaXe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSuaXe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSuaXe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSuaXe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSuaXe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLSuaXe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSuaXe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSuaXe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSuaXe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSuaXe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSuaXe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSuaXe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSuaXe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSuaXe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLSuaXe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSuaXe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSuaXe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSuaXe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSuaXe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSuaXe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSuaXe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSuaXe] SET RECOVERY FULL 
GO
ALTER DATABASE [QLSuaXe] SET  MULTI_USER 
GO
ALTER DATABASE [QLSuaXe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSuaXe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLSuaXe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLSuaXe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLSuaXe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLSuaXe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLSuaXe', N'ON'
GO
ALTER DATABASE [QLSuaXe] SET QUERY_STORE = OFF
GO
USE [QLSuaXe]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[customerID] [varchar](15) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](255) NOT NULL,
	[phoneNumber] [varchar](15) NOT NULL,
	[email] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[employeeID] [nvarchar](5) NOT NULL,
	[employeeName] [nvarchar](40) NOT NULL,
	[phoneNumber] [varchar](15) NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[empTypeID] [varchar](5) NOT NULL,
	[baseSalary] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empType]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empType](
	[empTypeID] [varchar](5) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[empTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[invoiceID] [varchar](10) NOT NULL,
	[RepairOrderID] [nvarchar](10) NOT NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[total] [int] NOT NULL,
	[method] [nvarchar](30) NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[employeeName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[invoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[motors]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[motors](
	[licensePlate] [varchar](11) NOT NULL,
	[customerID] [varchar](15) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[year] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[licensePlate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parts]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parts](
	[partID] [nvarchar](5) NOT NULL,
	[partName] [nvarchar](255) NULL,
	[quantity] [int] NOT NULL,
	[price] [bigint] NOT NULL,
	[buyPrice] [bigint] NOT NULL,
	[employeePrice] [bigint] NOT NULL,
	[unit] [nvarchar](20) NULL,
	[limitStock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[partID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepairDetail]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepairDetail](
	[partID] [nvarchar](5) NOT NULL,
	[RepairOrderID] [nvarchar](10) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[partID] ASC,
	[RepairOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepairOrder]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepairOrder](
	[RepairOrderID] [nvarchar](10) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[licensePlate] [varchar](11) NOT NULL,
	[employeeID] [nvarchar](5) NOT NULL,
	[note] [nvarchar](100) NULL,
	[total] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[RepairOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/6/2025 8:09:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userID] [nvarchar](5) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[role] [varchar](10) NOT NULL,
	[employeeID] [nvarchar](5) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000004', N'Dat', N'213123', N'123123123', N'dat@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000006', N'Yasuo', N'1232543', N'1235464', N'yasuo@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000008', N'asd', N'asd', N'213213', N'asdsada')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000009', N'Zedtt7', N'123asdasd', N'0912324352', N'sadsad@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000011', N'Duy Hưn', N'12341asda', N'0918424312', N'hung@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000013', N'Jack', N'dsf213asd', N'0911234546', N'jack@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000015', N'Demon1', N'asdasd23', N'0954667898', N'demon@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000016', N'Hoa', N'asdad2', N'0923423232', N'aspas@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000017', N'Hoàng Nguyễn', N'21321asdas', N'0934334223', N'hoangne@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000018', N'Tú', N'Thủ Đức', N'0923232321', N'tu123@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000019', N'Duy Khang', N'123 tran hugn dao', N'0923324322', N'khan@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000020', N'Nam', N'2313asd', N'0762321232', N'nam@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000021', N'Khc', N'2321asd', N'0732322322', N'hoang@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000022', N'Nguyen', N'12312313123', N'0763831221', N'nguyen@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000023', N'John Doe', N'123 Lý Thái Tổ p3 q10', N'0978222222', N'john@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000024', N'Vu Minh X', N'789 Duong YZA, Quan 24, TP.HCM', N'0912345701', N'vuminhx@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000025', N'Bui Thi Y', N'123 Duong BCD, Quan 25, TP.HCM', N'0912345702', N'buithiy@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000026', N'Hoang Quang Z', N'456 Duong EFG, Quan 26, TP.HCM', N'0912345703', N'hoangquangz@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000027', N'Ngo Minh AA', N'789 Duong HIJ, Quan 27, TP.HCM', N'0912345704', N'ngominhaa@gmail.com')
INSERT [dbo].[customers] ([customerID], [name], [address], [phoneNumber], [email]) VALUES (N'KH00000028', N'Doan Thi BB', N'123 Duong KLM, Quan 28, TP.HCM', N'0912345705', N'doanthibb@gmail.com')
GO
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0001', N'Khang Nguyen', N'0293221232', N'Nam', N'khang@gmail.com', N'ET01', 0)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0002', N'Minh', N'0987434232', N'Nam', N'sad@gmail.com', N'ET04', 15000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0003', N'Khan', N'0873423212', N'Nam', N'asd@gmail.com', N'ET01', 5000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0004', N'Tu', N'0981232312', N'Nữ', N'tumop@gmail.com', N'ET02', 10000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0005', N'Khang', N'0753232232', N'Nam', N'khanga123@gmail.com', N'ET05', 10000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0006', N'Tu', N'0823232122', N'Nữ', N'tu@gmail.com', N'ET04', 10000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0007', N'sad', N'0962132112', N'Nữ', N'sadasd@gmail.com', N'ET01', 1231300023)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0009', N'concho', N'0943532422', N'Nữ', N'sada@gmail.com', N'ET02', 231211333)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0010', N'Tú', N'0923232122', N'Khác', N'asda@gmail.com', N'ET01', 1000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0011', N'John Doe', N'0912324389', N'Nữ', N'john@gmail.com', N'ET01', 20000000)
INSERT [dbo].[employees] ([employeeID], [employeeName], [phoneNumber], [gender], [email], [empTypeID], [baseSalary]) VALUES (N'E0012', N'Hoan', N'0972321222', N'Nam', N'hoangngu@gmail.com', N'ET01', 1231313222)
GO
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET01', N'Quản Lý')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET02', N'Thu Ngân')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET03', N'Giám Đốc')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET04', N'Kỹ Thuật Viên')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET05', N'Tiếp Thị')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET06', N'Trợ Giúp')
INSERT [dbo].[empType] ([empTypeID], [name]) VALUES (N'ET07', N'Chăm Sóc Khách Hàng')
GO
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000001', N'RP00000004', CAST(N'2024-12-19T01:16:47.580' AS DateTime), CAST(N'2024-12-20T18:26:49.493' AS DateTime), 47000, N'Chuyển khoản', N'Duy Khang', N'Minh')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000002', N'RP00000005', CAST(N'2024-12-19T10:23:10.637' AS DateTime), CAST(N'2024-12-20T21:37:58.427' AS DateTime), 2500000, N'Tiền mặt', N'Jack', N'Minh')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000003', N'RP00000002', CAST(N'2024-12-18T07:55:38.540' AS DateTime), CAST(N'2024-12-20T22:19:35.987' AS DateTime), 90000, N'Chuyển khoản', N'Duy Hưn', N'Minh')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000004', N'RP00000003', CAST(N'2024-12-18T09:07:54.920' AS DateTime), CAST(N'2024-12-20T22:19:35.987' AS DateTime), 50000, N'Chuyển khoản', N'Tú', N'Tu')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000005', N'RP00000001', CAST(N'2024-12-15T22:28:47.157' AS DateTime), CAST(N'2024-12-20T22:19:35.987' AS DateTime), 50000, N'Tiền mặt', N'Hoa', N'Tu')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000006', N'RP00000007', CAST(N'2024-12-21T10:48:03.050' AS DateTime), CAST(N'2024-12-21T11:50:36.177' AS DateTime), 50000, N'Tiền mặt', N'Duy Hưn', N'Tu')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000007', N'RP00000009', CAST(N'2024-12-22T00:11:36.237' AS DateTime), CAST(N'2024-12-24T00:14:19.000' AS DateTime), 200000, N'Tiền mặt', N'John Doe', N'Tu')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000008', N'RP00000010', CAST(N'2024-12-22T00:36:04.690' AS DateTime), CAST(N'2024-12-22T00:35:44.613' AS DateTime), 72000, N'Chuyển khoản', N'Vu Minh X', N'Minh')
INSERT [dbo].[Invoice] ([invoiceID], [RepairOrderID], [CheckIn], [CheckOut], [total], [method], [customerName], [employeeName]) VALUES (N'HD00000009', N'RP00000006', CAST(N'2024-12-20T23:32:11.963' AS DateTime), CAST(N'2024-12-22T16:44:14.930' AS DateTime), 1050000, N'Chuyển khoản', N'Zedtt7', N'Minh')
GO
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'40H5-12345', N'KH00000017', N'Honda Blade', 2015)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'50H1-23123', N'KH00000015', N'Suzuki Raider 150', 2014)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'57H1-43433', N'KH00000022', N'AirbLade', 0)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'59B2-1234', N'KH00000019', N'Honda SH350i', 2021)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'59H1-12345', N'KH00000009', N'Honda CBR500R', 2021)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'59H2-23123', N'KH00000020', N'yamaha', 2022)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'59H7-12345', N'KH00000021', N'AirBlade', 2022)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'59H9-12345', N'KH00000011', N'Honda CBR500R', 2000)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'60H1-12345', N'KH00000013', N'Honda CBR500R', 2013)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'60H2-12345', N'KH00000018', N'Suzuki Burgman Street', 2022)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'76H5-12323', N'KH00000016', N'Yamaha Jupiter', 2021)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'80A1-12345', N'KH00000023', N'AirBlade', 2019)
INSERT [dbo].[motors] ([licensePlate], [customerID], [model], [year]) VALUES (N'80H2-11111', N'KH00000024', N'Dream Thai', 2015)
GO
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P001', N'Piston', 44, 20000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P002', N'Xéc măng', 0, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P003', N'Bugi đánh lửa', 18, 5000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P004', N'Cam, cò', 20, 25000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P005', N'Lọc nhớt', 40, 10000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P006', N'Lọc gió', 40, 8000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P007', N'Bình xăng con', 0, 35000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P008', N'Bơm xăng', 8, 25000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P009', N'Bơm nhớt', 13, 22000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P010', N'Dây curoa', 50, 12000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P011', N'Dây xích và nhông, đĩa', 30, 18000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P012', N'Lò xo côn', 35, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P013', N'Lá côn', 40, 10000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P014', N'Bố nồi', 19, 22000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P015', N'Ắc quy', 10, 70000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P016', N'Rơ-le đề', 20, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P017', N'Mô-tơ đề', 10, 50000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P018', N'IC', 30, 30000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P019', N'Cuộn điện', 30, 18000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P020', N'Đèn pha', 40, 35000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P021', N'Đèn hậu', 40, 25000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P022', N'Đèn xi nhan', 50, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P023', N'Dây điện', 60, 5000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P024', N'Còi xe', 50, 7000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P025', N'Má phanh', 60, 10000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P026', N'Đĩa phanh', 25, 40000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P027', N'Dầu phanh', 30, 5000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P028', N'Tay phanh', 20, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P029', N'Phuộc trước', 15, 80000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P030', N'Phuộc sau', 15, 90000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P031', N'Gắp xe', 10, 45000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P032', N'Chân chống', 50, 7000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P033', N'Lốp xe', 20, 150000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P034', N'Ruột xe', 20, 40000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P035', N'Niềng xe', 15, 25000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P036', N'Moay ơ', 30, 20000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P037', N'Vành nan hoa', 30, 35000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P038', N'Tay ga', 40, 10000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P039', N'Dây ga', 50, 8000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P040', N'Tay côn', 40, 12000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P041', N'Dây côn', 50, 10000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P042', N'Gương chiếu hậu', 30, 15000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P043', N'Yên xe', 20, 70000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P044', N'Lọc nước làm mát', 15, 20000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P045', N'Bình xăng', 16, 25000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P046', N'Ống pô', 25, 30000, 0, 0, NULL, 0)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P047', N'Gioăng các loại', 100, 3000, 2000, 2000, N'Cai', 2)
INSERT [dbo].[parts] ([partID], [partName], [quantity], [price], [buyPrice], [employeePrice], [unit], [limitStock]) VALUES (N'P048', N'Banh xe vip pro', 62, 100000, 200000, 200000, N'Banh', 5)
GO
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P001', N'RP00000001', 2, 20000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P001', N'RP00000002', 1, 20000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P001', N'RP00000003', 2, 20000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P003', N'RP00000001', 2, 5000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P003', N'RP00000002', 4, 5000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P003', N'RP00000003', 2, 5000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P003', N'RP00000008', 1, 5000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P003', N'RP00000011', 1, 5000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P004', N'RP00000002', 2, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P004', N'RP00000007', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P004', N'RP00000010', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P004', N'RP00000012', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P008', N'RP00000004', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P008', N'RP00000008', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P008', N'RP00000009', 4, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P008', N'RP00000013', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P009', N'RP00000004', 1, 22000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P009', N'RP00000008', 1, 22000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P014', N'RP00000010', 1, 22000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P045', N'RP00000006', 2, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P045', N'RP00000007', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P045', N'RP00000010', 1, 25000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P048', N'RP00000005', 25, 100000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P048', N'RP00000006', 10, 100000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P048', N'RP00000009', 1, 100000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P048', N'RP00000011', 1, 100000)
INSERT [dbo].[RepairDetail] ([partID], [RepairOrderID], [quantity], [price]) VALUES (N'P048', N'RP00000013', 1, 100000)
GO
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000001', CAST(N'2024-12-15T22:28:47.157' AS DateTime), N'Hoàn Thành', N'76H5-12323', N'E0006', N'sadsada', 50000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000002', CAST(N'2024-12-18T07:55:38.540' AS DateTime), N'Hoàn Thành', N'59H9-12345', N'E0002', N'Hu cai gi do. Tong ket la gi do', 90000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000003', CAST(N'2024-12-18T09:07:54.920' AS DateTime), N'Hoàn Thành', N'60H2-12345', N'E0006', N'sadad', 50000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000004', CAST(N'2024-12-19T01:16:47.580' AS DateTime), N'Hoàn Thành', N'59B2-1234', N'E0002', N'oke bro', 47000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000005', CAST(N'2024-12-19T10:23:10.637' AS DateTime), N'Hoàn Thành', N'60H1-12345', N'E0002', N'dsadsad', 2500000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000006', CAST(N'2024-12-20T23:32:11.963' AS DateTime), N'Hoàn Thành', N'59H1-12345', N'E0002', N'sdfdsfsdfs', 1050000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000007', CAST(N'2024-12-21T10:48:03.050' AS DateTime), N'Hoàn Thành', N'59H9-12345', N'E0006', N'ghrghrh', 50000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000008', CAST(N'2024-12-21T11:50:04.937' AS DateTime), N'Chờ', N'40H5-12345', N'E0002', N'xdsaxasd', 52000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000009', CAST(N'2024-12-22T00:11:36.237' AS DateTime), N'Hoàn Thành', N'80A1-12345', N'E0006', N'Xe bị hư phuộc, thay cái mới nha', 200000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000010', CAST(N'2024-12-22T00:36:04.690' AS DateTime), N'Hoàn Thành', N'80H2-11111', N'E0002', N'asdsadsa', 72000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000011', CAST(N'2024-12-22T09:01:34.853' AS DateTime), N'Chờ', N'59H1-12345', N'E0002', N'aasdasd', 105000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000012', CAST(N'2024-12-22T16:48:27.643' AS DateTime), N'Hoàn Thành', N'80H2-11111', N'E0002', N'erdsf', 25000)
INSERT [dbo].[RepairOrder] ([RepairOrderID], [createdAt], [status], [licensePlate], [employeeID], [note], [total]) VALUES (N'RP00000013', CAST(N'2024-12-25T08:04:53.020' AS DateTime), N'Chờ', N'80A1-12345', N'E0002', N'.poun', 125000)
GO
INSERT [dbo].[users] ([userID], [username], [password], [role], [employeeID], [createdAt], [updatedAt]) VALUES (N'U0005', N'admin', N'$2a$12$4S1oS7XuyZ8wy.SOf5h7BOfASkhSC9WhPJDDVziagdpXWhffMZSI.', N'admin', N'E0001', CAST(N'2024-12-10T08:36:18.823' AS DateTime), NULL)
INSERT [dbo].[users] ([userID], [username], [password], [role], [employeeID], [createdAt], [updatedAt]) VALUES (N'U0006', N'admintest', N'$2a$12$tbzViJtXPLVog3mJ2yj0.ev9R4kFjuHgqNH0lkJGYil9kMZYDnAaG', N'user', N'E0005', CAST(N'2024-12-11T10:02:04.807' AS DateTime), NULL)
INSERT [dbo].[users] ([userID], [username], [password], [role], [employeeID], [createdAt], [updatedAt]) VALUES (N'U0007', N'cashier', N'$2a$12$mwFRVpIOTpYSVAATqRRD1OmWT8UbuJVYt4JweLmm1.1kKkPjvhCcW', N'user', N'E0009', CAST(N'2024-12-25T10:56:20.857' AS DateTime), NULL)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__employee__AB6E6164D517EEE7]    Script Date: 1/6/2025 8:09:51 AM ******/
ALTER TABLE [dbo].[employees] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__users__F3DBC5722CBB6A2D]    Script Date: 1/6/2025 8:09:51 AM ******/
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[parts] ADD  DEFAULT ((0)) FOR [buyPrice]
GO
ALTER TABLE [dbo].[parts] ADD  DEFAULT ((0)) FOR [employeePrice]
GO
ALTER TABLE [dbo].[parts] ADD  DEFAULT ((0)) FOR [limitStock]
GO
ALTER TABLE [dbo].[RepairOrder] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ('employee') FOR [role]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD FOREIGN KEY([empTypeID])
REFERENCES [dbo].[empType] ([empTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([RepairOrderID])
REFERENCES [dbo].[RepairOrder] ([RepairOrderID])
GO
ALTER TABLE [dbo].[motors]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[customers] ([customerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RepairDetail]  WITH CHECK ADD FOREIGN KEY([partID])
REFERENCES [dbo].[parts] ([partID])
GO
ALTER TABLE [dbo].[RepairDetail]  WITH CHECK ADD FOREIGN KEY([RepairOrderID])
REFERENCES [dbo].[RepairOrder] ([RepairOrderID])
GO
ALTER TABLE [dbo].[RepairOrder]  WITH CHECK ADD FOREIGN KEY([employeeID])
REFERENCES [dbo].[employees] ([employeeID])
GO
ALTER TABLE [dbo].[RepairOrder]  WITH CHECK ADD FOREIGN KEY([licensePlate])
REFERENCES [dbo].[motors] ([licensePlate])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD FOREIGN KEY([employeeID])
REFERENCES [dbo].[employees] ([employeeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [CK_users_role] CHECK  (([role]='user' OR [role]='admin'))
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [CK_users_role]
GO
USE [master]
GO
ALTER DATABASE [QLSuaXe] SET  READ_WRITE 
GO
