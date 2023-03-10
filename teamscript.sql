USE [MVC_Hospital]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 20-02-2023 15:59:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[PatientID] [int] NOT NULL,
	[AppointmentDate] [datetime] NULL,
	[Appointment_Status] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK__Appointm__DCC1C959DF666361] PRIMARY KEY CLUSTERED 
(
	[AppointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](30) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK__Departme__014881AEBBD0926C] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[D_Name] [varchar](30) NOT NULL,
	[D_PhoneNo] [nvarchar](max) NOT NULL,
	[D_Email] [varchar](40) NULL,
	[Designation] [nvarchar](max) NULL,
	[DeptId] [int] NOT NULL,
	[D_Address] [nvarchar](max) NOT NULL,
	[D_ContactNo] [nvarchar](max) NULL,
	[D_Specialization] [varchar](100) NULL,
	[D_Gender] [nvarchar](max) NOT NULL,
	[D_DOB] [datetime] NOT NULL,
	[D_Status] [nvarchar](max) NULL,
	[D_Password] [varchar](50) NULL,
	[D_Cpassword] [varchar](50) NULL,
 CONSTRAINT [PK__Doctor__2DC00EDFEE23BB79] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[P_Name] [varchar](50) NULL,
	[P_PhoneNo] [varchar](50) NULL,
	[P_Email] [varchar](50) NOT NULL,
	[P_Address] [varchar](50) NULL,
	[P_BloodGroup] [varchar](50) NULL,
	[P_Gender] [varchar](50) NULL,
	[P_DOB] [datetime] NOT NULL,
	[P_Status] [varchar](50) NULL,
	[P_Image] [varchar](50) NULL,
	[P_Password] [varchar](50) NULL,
	[P_Cpassword] [varchar](50) NULL,
 CONSTRAINT [PK__Patient__970EC346BCB40F21] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NULL,
	[AvailableStartDay] [nvarchar](max) NULL,
	[AvailableEndDay] [nvarchar](max) NULL,
	[AvailableStartTime] [datetime] NULL,
	[AvailableEndTime] [datetime] NULL,
	[TimePerPatient] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Login]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[UserId] [varchar](50) NULL,
	[UserRole] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 20-02-2023 15:59:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RollName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Login] ON 

INSERT [dbo].[tbl_Login] ([LoginId], [Email], [Password], [UserId], [UserRole]) VALUES (3, N'admin@gmail.com', N'123', NULL, 1)
SET IDENTITY_INSERT [dbo].[tbl_Login] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

INSERT [dbo].[tbl_Role] ([RoleId], [RollName]) VALUES (1, N'Admin')
INSERT [dbo].[tbl_Role] ([RoleId], [RollName]) VALUES (2, N'Doctor')
INSERT [dbo].[tbl_Role] ([RoleId], [RollName]) VALUES (3, N'Patient')
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__5E508265EB3AC59C]    Script Date: 20-02-2023 15:59:18 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [UQ__Departme__5E508265EB3AC59C] UNIQUE NONCLUSTERED 
(
	[DeptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_Logi__1788CC4DAC00560D]    Script Date: 20-02-2023 15:59:18 ******/
ALTER TABLE [dbo].[tbl_Login] ADD UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Patie__3F466844] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK__Appointme__Patie__3F466844]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Presc__3E52440B] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK__Appointme__Presc__3E52440B]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK__Doctor__DeptId__33D4B598] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([DeptId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK__Doctor__DeptId__33D4B598]
GO
ALTER TABLE [dbo].[tbl_Login]  WITH CHECK ADD FOREIGN KEY([UserRole])
REFERENCES [dbo].[tbl_Role] ([RoleId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
