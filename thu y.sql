USE [ClinicAnimal]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/1/2024 9:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Pass] [varchar](100) NULL,
	[EmployeeID] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[LastLogin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[PetID] [int] NULL,
	[EmployeeID] [int] NULL,
	[ServiceID] [int] NULL,
	[Note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[PhoneNumber] [char](10) NULL,
	[CustomerAddress] [nvarchar](max) NULL,
	[CustomerEmail] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[PhoneNumber] [char](10) NULL,
	[EmployeeEmail] [varchar](100) NULL,
	[HireDate] [date] NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[InvoiceDetailID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[PetID] [int] NULL,
	[MedicationID] [int] NULL,
	[ServiceID] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[SubTotal] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [date] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CustomerID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medications]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medications](
	[MedicationID] [int] IDENTITY(1,1) NOT NULL,
	[MedicationName] [nvarchar](100) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[StockQuantity] [int] NULL,
	[MedicationDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[InvoiceID] [int] NULL,
	[PaymentMethod] [nvarchar](100) NULL,
	[AmountPaid] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pets]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[PetID] [int] IDENTITY(1,1) NOT NULL,
	[PetName] [nvarchar](100) NULL,
	[Species] [nvarchar](100) NULL,
	[Breed] [nvarchar](50) NULL,
	[MedicalHistory] [nvarchar](max) NULL,
	[CustomerID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NULL,
	[RoleDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicess]    Script Date: 11/1/2024 9:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicess](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](100) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [Username], [Pass], [EmployeeID], [CreatedAt], [LastLogin]) VALUES (1, N'huy', N'123', 4, CAST(N'2024-10-31T00:00:00.000' AS DateTime), CAST(N'2024-10-31T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentID], [AppointmentDate], [CustomerID], [PetID], [EmployeeID], [ServiceID], [Note]) VALUES (1, CAST(N'2024-11-01T00:00:00.000' AS DateTime), 1, 1, 4, 2, N'Cần khám định kì')
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [PhoneNumber], [CustomerAddress], [CustomerEmail]) VALUES (1, N'Võ Minh Phát', N'0989772832', N'TP HCM', N'phat@gmail.com')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [PhoneNumber], [EmployeeEmail], [HireDate], [RoleID]) VALUES (4, N'Huỳnh Nhật Huy', N'0857160701', N'abc@gmail.com', CAST(N'2024-10-05' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Medications] ON 

INSERT [dbo].[Medications] ([MedicationID], [MedicationName], [UnitPrice], [StockQuantity], [MedicationDescription]) VALUES (1, N'ACETYLC', CAST(30000.00 AS Decimal(18, 2)), 50, N'HẠ SỐT NHANH, GIẢM ĐAU, KHÁNG VIÊM CHO HEO VÀ GIA CẦM')
INSERT [dbo].[Medications] ([MedicationID], [MedicationName], [UnitPrice], [StockQuantity], [MedicationDescription]) VALUES (2, N'ADE BC COMPLEX(HÒA TAN)', CAST(20000.00 AS Decimal(18, 2)), 50, N'BỔ SUNG DƯỠNG CHẤT CHO GIA SÚC

TĂNG KHẢ NĂNG KHÁNG BỆNH, TĂNG TRƯỞNG NHANH

')
SET IDENTITY_INSERT [dbo].[Medications] OFF
GO
SET IDENTITY_INSERT [dbo].[Pets] ON 

INSERT [dbo].[Pets] ([PetID], [PetName], [Species], [Breed], [MedicalHistory], [CustomerID]) VALUES (1, N'Bối', N'Mèo', N'Cái', N'Từng dùng thuốc bị rối loạn tiêu hóa', 1)
SET IDENTITY_INSERT [dbo].[Pets] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [RoleDescription]) VALUES (1, N'Bác sĩ', N'Tiêm phòng , khám , kê thuốc cho thú bị bệnh')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicess] ON 

INSERT [dbo].[Servicess] ([ServiceID], [ServiceName], [UnitPrice]) VALUES (1, N'Khám và điều trị bệnh', CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Servicess] ([ServiceID], [ServiceName], [UnitPrice]) VALUES (2, N'Triệt sản', CAST(600000.00 AS Decimal(18, 2)))
INSERT [dbo].[Servicess] ([ServiceID], [ServiceName], [UnitPrice]) VALUES (3, N'Chụp X-Quang', CAST(250000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Servicess] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [fk_Accounts_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [fk_Accounts_Employees]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [fk_Appointments_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [fk_Appointments_Customers]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [fk_Appointments_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [fk_Appointments_Employees]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [fk_Appointments_Pets] FOREIGN KEY([PetID])
REFERENCES [dbo].[Pets] ([PetID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [fk_Appointments_Pets]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [fk_Appointments_Servicess] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Servicess] ([ServiceID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [fk_Appointments_Servicess]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [fk_Employees_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [fk_Employees_Roles]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [fk_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [fk_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [fk_InvoiceDetails_Medications] FOREIGN KEY([MedicationID])
REFERENCES [dbo].[Medications] ([MedicationID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [fk_InvoiceDetails_Medications]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [fk_InvoiceDetails_Pets] FOREIGN KEY([PetID])
REFERENCES [dbo].[Pets] ([PetID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [fk_InvoiceDetails_Pets]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [fk_InvoiceDetails_Servicess] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Servicess] ([ServiceID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [fk_InvoiceDetails_Servicess]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [fk_Invoices_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [fk_Invoices_Customers]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [fk_Payments_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [fk_Payments_Invoices]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [fk_Pets_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [fk_Pets_Customers]
GO
