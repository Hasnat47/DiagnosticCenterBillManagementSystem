USE [master]
GO
/****** Object:  Database [DiagnosticCenterBillManagmentSystemC#30DB]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE DATABASE [DiagnosticCenterBillManagmentSystemC#30DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagnosticCenterBillManagmentSystemC#30DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagmentSystemC#30DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagnosticCenterBillManagmentSystemC#30DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagmentSystemC#30DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagnosticCenterBillManagmentSystemC#30DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET  MULTI_USER 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DiagnosticCenterBillManagmentSystemC#30DB]
GO
/****** Object:  Table [dbo].[PatientTest]    Script Date: 11/5/2016 6:34:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestSetupId] [int] NULL,
	[TestTypeId] [int] NULL,
	[TestDate] [date] NULL,
	[Fee] [decimal](10, 2) NULL,
	[TestRequestId] [int] NULL,
 CONSTRAINT [PK_PatientTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestRequest]    Script Date: 11/5/2016 6:34:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillNo] [varchar](50) NULL,
	[PatientName] [varchar](100) NULL,
	[DOB] [date] NULL,
	[MobileNo] [varchar](11) NULL,
	[TestDate] [date] NULL,
	[Total] [decimal](10, 2) NULL,
	[PaymentStatus] [varchar](50) NULL,
 CONSTRAINT [PK_TestRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestSetup]    Script Date: 11/5/2016 6:34:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NULL,
	[Fee] [decimal](10, 2) NULL,
	[TestTypeSetupId] [int] NULL,
 CONSTRAINT [PK_TestSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestTypeSetup]    Script Date: 11/5/2016 6:34:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestTypeSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](100) NULL,
 CONSTRAINT [PK_TestTypeSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TestRequest_1]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_TestRequest_1] ON [dbo].[TestRequest]
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TestRequest_2]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestRequest_2] ON [dbo].[TestRequest]
(
	[MobileNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestRequest_3]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_TestRequest_3] ON [dbo].[TestRequest]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TestSetup]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestSetup] ON [dbo].[TestSetup]
(
	[TestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TestTypeSetup]    Script Date: 11/5/2016 6:34:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TestTypeSetup] ON [dbo].[TestTypeSetup]
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientTest_TestSetup] FOREIGN KEY([TestRequestId])
REFERENCES [dbo].[TestRequest] ([Id])
GO
ALTER TABLE [dbo].[PatientTest] CHECK CONSTRAINT [FK_PatientTest_TestSetup]
GO
ALTER TABLE [dbo].[PatientTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientTest_TestSetup1] FOREIGN KEY([TestSetupId])
REFERENCES [dbo].[TestSetup] ([Id])
GO
ALTER TABLE [dbo].[PatientTest] CHECK CONSTRAINT [FK_PatientTest_TestSetup1]
GO
ALTER TABLE [dbo].[PatientTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientTest_TestTypeSetup] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestTypeSetup] ([Id])
GO
ALTER TABLE [dbo].[PatientTest] CHECK CONSTRAINT [FK_PatientTest_TestTypeSetup]
GO
ALTER TABLE [dbo].[TestSetup]  WITH CHECK ADD  CONSTRAINT [FK_TestSetup_TestTypeSetup] FOREIGN KEY([TestTypeSetupId])
REFERENCES [dbo].[TestTypeSetup] ([Id])
GO
ALTER TABLE [dbo].[TestSetup] CHECK CONSTRAINT [FK_TestSetup_TestTypeSetup]
GO
USE [master]
GO
ALTER DATABASE [DiagnosticCenterBillManagmentSystemC#30DB] SET  READ_WRITE 
GO
