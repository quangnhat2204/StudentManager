USE [master]
GO
/****** Object:  Database [Quanlydiem]    Script Date: 12/22/2018 10:59:15 AM ******/
CREATE DATABASE [Quanlydiem]
 CONTAINMENT = NONE
GO
ALTER DATABASE [Quanlydiem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quanlydiem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quanlydiem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quanlydiem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quanlydiem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quanlydiem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quanlydiem] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quanlydiem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Quanlydiem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quanlydiem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quanlydiem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quanlydiem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quanlydiem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quanlydiem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quanlydiem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quanlydiem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quanlydiem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Quanlydiem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quanlydiem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quanlydiem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quanlydiem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quanlydiem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quanlydiem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quanlydiem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quanlydiem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quanlydiem] SET  MULTI_USER 
GO
ALTER DATABASE [Quanlydiem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quanlydiem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quanlydiem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quanlydiem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Quanlydiem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quanlydiem] SET QUERY_STORE = OFF
GO
USE [Quanlydiem]
GO
/****** Object:  User [NT SERVICE\ReportServer$SQLEXPRESS]    Script Date: 12/22/2018 10:59:16 AM ******/
CREATE USER [NT SERVICE\ReportServer$SQLEXPRESS] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [tblGIANG_VIEN]    Script Date: 12/22/2018 10:59:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblGIANG_VIEN](
	[MaGV] [nvarchar](10) NOT NULL,
	[TenGV] [nvarchar](30) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](20) NULL,
	[PhanLoaiGV] [nvarchar](20) NULL,
 CONSTRAINT [PK_tblGIANG_VIEN] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tblKET_QUA]    Script Date: 12/22/2018 10:59:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblKET_QUA](
	[MaSV] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[MaLop] [nvarchar](10) NULL,
	[MaMon] [nvarchar](10) NULL,
	[SoDVHT] [int] NULL,
	[DiemQuaTrinh] [float] NULL,
	[DiemThi] [float] NULL,
	[DiemTongKet] [float] NULL,
	[DiemRenLuyen] [float] NULL,
	[HocKi] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[NamHoc] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [tblKHOA]    Script Date: 12/22/2018 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblKHOA](
	[MaKhoa] [nvarchar](10) NOT NULL,
	[TenKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblKHOA] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tblLOGIN]    Script Date: 12/22/2018 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblLOGIN](
	[TenDN] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Quyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblLOGIN] PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC,
	[MatKhau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tblLOP]    Script Date: 12/22/2018 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblLOP](
	[MaKhoa] [nvarchar](10) NULL,
	[MaLop] [nvarchar](10) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblLOP] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tblMON]    Script Date: 12/22/2018 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblMON](
	[MaMon] [nvarchar](10) NOT NULL,
	[TenMon] [nvarchar](50) NOT NULL,
	[SoDVHT] [int] NOT NULL,
	[MaGV] [nvarchar](10) NULL,
	[HocKi] [int] NULL,
	[MaKhoa] [nchar](10) NULL,
 CONSTRAINT [PK_tblMON] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [tblSINH_VIEN]    Script Date: 12/22/2018 10:59:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblSINH_VIEN](
	[MaSv] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [nvarchar](10) NULL,
	[GioiTinh] [nvarchar](20) NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[MaLop] [nvarchar](10) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblSINH_VIEN] PRIMARY KEY CLUSTERED 
(
	[MaSv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH1      ', N'Trần Công Tú', N'Nam', N'0979  05 206', N'Quocvanict@gmail.com', N'Cơ Hữu              ')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH10', N'Nguyễn Trần Thi Văn', N'Nam', N'0988  23 233', N'hocgioiboy@gmail.com', N'Cơ Hữu')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH2', N'Nguyễn Tuyết Hạnh', N'Nữ', N'0979  05 113', N'gg@gmail.com', N'Cơ Hữu              ')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH3       ', N'Nguyễn Khắc Tín            ', N'Nam', N'0125 563 231', N' conga@gmail.com    ', N'Cơ Hữu')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH4       ', N'Lai Văn Phút', N'Nam', N'0979  05 676', N'phutboy@gmail.com', N'Cơ Hữu')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH5       ', N'Trần Văn Vĩ', N'Nam', N'0943 423 122', N'viboy@gmail.com', N'Cơ Hữu')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH6       ', N'Nguyễn Tuyết Nga', N'Nữ', N'0123 342 321', N'Ngababy@gmail.com', N'Cơ Hữu')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH7       ', N'Huỳnh Quang Chiến', N'Nam', N'0989 842 313', N'chiencute@gmail.com', N'Cơ hữu              ')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH8       ', N'Trần Thị Hạnh', N'Nữ', N'0129 842 398', N'hanhmongmo@gmail.com', N'Thỉnh giảng')
INSERT [tblGIANG_VIEN] ([MaGV], [TenGV], [GioiTinh], [Phone], [Email], [PhanLoaiGV]) VALUES (N'CH9       ', N'Hoàng Thị Hà', N'Nữ', N'0988  23 239', N'                    ', N'Thỉnh giảng')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC01', N'Đặng Minh Hùng', N'TCNH1', N'CNMLN', 5, 4.2, 9, 6.6, 80, 1, N'', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'T06', N'Đoàn Minh Hiếu', N'08T2', N'Pascal', 4, 6.5, 5.5, 6, 60, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC03', N'Lê Thị Ngọc Bích', N'TCNH1', N'CNMLN', 5, 10, 7.4, 8.7, 71, 1, N'', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133043', N'Nguyễn Quang Nhật', N'08T2', N'Pascal', 4, 0.5, 2.1, 1.3, 65, 1, N'Thi lại', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC06', N'Nguyễn Thế Phong', N'TCNH1', N'CNMLN', 5, 5.3, 7.1, 6.2, 60, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC05', N'Nguyễn Thị Nhung', N'TCNH1', N'CNMLN', 5, 5, 4.8, 4.9, 70, 1, N'', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'T04', N'Nguyễn Thị Thu Hiền', N'08T2', N'Pascal', 4, 2, 8, 5, 80, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC04', N'Nguyễn Văn Đạo', N'TCNH1', N'CNMLN', 5, 8, 8.8, 8.4, 50, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'T05', N'Trần Minh Đoàn', N'08T2', N'Pascal', 4, 9, 5, 7, 75, 1, N'', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133001', N'Võ Đình An', N'17133', N'Pascal', 4, 8, 6, 7, 80, 1, N'', N'2017-2018')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133010', N'Vũ Anh Thái Dương', N'08T2', N'Pascal', 4, 5.6, 5, 5.3, 70, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'TC02', N'Vũ Đức Dũng', N'TCNH1', N'CNMLN', 5, 7, 7.6, 7.3, 85, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'17133', N'CSDL', 4, 9, 10, 9.5, 82, 2, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'17133', N'CNMLN', 5, 6, 7, 6.5, 85, 3, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133001', N'Võ Đình An', N'17133', N'Pascal', 4, 8, 9, 8.5, 85, 2, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'17133', N'Pascal', 4, 5, 10, 5, 70, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'17133', N'PPT', 4, 9, 9.5, 9.25, 75, 1, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'17133', N'OOP', 4, 8, 7.5, 7.75, 60, 3, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133001', N'Võ Đình An', N'17133', N'OOP', 4, 9, 10, 9.5, 80, 3, N'', N'2018-2019')
INSERT [tblKET_QUA] ([MaSV], [HoTen], [MaLop], [MaMon], [SoDVHT], [DiemQuaTrinh], [DiemThi], [DiemTongKet], [DiemRenLuyen], [HocKi], [GhiChu], [NamHoc]) VALUES (N'17133002', N'Vỏ Phú Cường', N'17133', N'OOP', 4, 8, 7, 7.5, 70, 3, N'', N'2018-2019')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'CKCTM', N'Cơ khí chế tạo máy')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'CNM', N'Công nghệ may')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'CNTT', N'Công nghệ thông tin             ')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'DDT', N'Điện-Điện tử')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'KT', N'Kế toán')
INSERT [tblKHOA] ([MaKhoa], [TenKhoa]) VALUES (N'NNA', N'Ngôn ngữ Anh')
INSERT [tblLOGIN] ([TenDN], [MatKhau], [HoTen], [GioiTinh], [Phone], [Email], [Quyen]) VALUES (N'17133043', N'1234', N'Nguyễn Quang Nhật', N'Nam', N'0914 588 795', N'2204nguyenquangnhat@gmail.com', N'SinhVien')
INSERT [tblLOGIN] ([TenDN], [MatKhau], [HoTen], [GioiTinh], [Phone], [Email], [Quyen]) VALUES (N'admin', N'1234', N'Nguyễn Quang Nhật', N'Nam', N'0914588795', N'17133043@student.hcmute.edu.vn', N'GiangVien')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'DDT', N'08T1', N'08T1')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CKCTM', N'08T2', N'08T2')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'17113', N'17113A')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'17123', N'17113B')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNTT', N'17133', N'17133C')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'KT', N'17148', N'17148A')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'CNM', N'17159', N'17159C')
INSERT [tblLOP] ([MaKhoa], [MaLop], [TenLop]) VALUES (N'NNA', N'NNA1', N'NNA1')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'CNMLN', N'Chủ nghĩa MLNin', 5, N'CH7', 1, N'KT        ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'CSDL', N'Cơ Sở Dữ Liệu', 4, N'CH9', 2, N'CNTT      ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'OOP', N'Lập trình hướng đối tượng', 4, N'CH10', 3, N'CNTT      ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'Pascal', N'Pascal', 4, N'CH4', 1, N'CNTT      ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'PPT', N'Phương Pháp tính ', 4, N'CH3', 2, N'CNTT      ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'TCTT', N'Tài chính tiền tệ', 5, N'CH5', 2, N'KT        ')
INSERT [tblMON] ([MaMon], [TenMon], [SoDVHT], [MaGV], [HocKi], [MaKhoa]) VALUES (N'XSTT', N'Xác suất thống kê', 4, N'CH7', 2, N'CKCTM     ')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133001', N'Võ Đình An', N'06/09/1999', N'Nam', N'Núi rừng tây nguyên', N'17133', N'0968596848')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133002', N'Vỏ Phú Cường', N'05/05/1999', N'Nam', N'Phú Yên', N'17133', N'0698523654')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133003', N'Mai Bình Nam', N'06/06/1999', N'Nam', N'Quảng Bình', N'17133', N'0369851236')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133004', N'Võ Trọng Diện', N'07/071999', N'Nữ', N'Phú Yên', N'17133', N'0698632598')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133006', N'Nguyễn Ngọc Đoan', N'25/06/1999', N'Chưa xác định', N'Phú Yên', N'17133', N'0965362589')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133010', N'Vũ Anh Thái Dương', N'05/02/1995', N'Nam', N'Sài Gòn', N'17133', N'0819584968')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133043', N'Nguyễn Quang Nhật', N'04/09/1999', N'Nam', N'Quảng Ngãi', N'17133', N'0962849865')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133045', N'Nguyễn Văn Tiến', N'25/10/1999', N'Nam', N'Bình Dương', N'17133', N'0965896523')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'17133065', N'Nguyễn Thế Phong', N'08/06/1999', N'Nam', N'Thành Phố Hồ Chí Minh', N'17133', N'0915849685')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'T04', N'Nguyễn Thị Thu Hiền', N'19/01/1999', N'Nữ', N'Hà Tây', N'08T2', N'0962846358')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'T05', N'Trần Minh Đoàn', N'24/02/1991', N'Nam', N'Hà Tĩnh', N'08T2', N'0916842954')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'T06', N'Đoàn Minh Hiếu', N'26/03/1997', N'Nam', N'Hà Nội', N'08T2', N'0935879548')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC01', N'Đặng Minh Hùng', N'21/03/1991', N'Nam', N'Bến Tre', N'NNA1', N'0169895895')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC02', N'Vũ Đức Dũng', N'12/05/1991', N'Nam', N'Bình Phước', N'NNA1', N'0938529959')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC03', N'Lê Thị Ngọc Bích', N'11/01/1991', N'Nữ', N'Bến Tre', N'NNA1', N'0169585995')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC04', N'Nguyễn Văn Đạo', N'18/04/1991', N'Nam', N'Thành Phố Hồ Chí Minh', N'NNA1', N'0369585895')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC05', N'Nguyễn Thị Nhung', N'11/08/1991', N'Nam', N'Thành Phố Hồ Chí Minh', N'NNA1', N'0968755955')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC06', N'Nguyễn Thế Phong', N'23/12/1999', N'Nam', N'Thành Phố Hồ Chí Minh', N'NNA1', N'0895848489')
INSERT [tblSINH_VIEN] ([MaSv], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaLop], [SoDienThoai]) VALUES (N'TC07', N'Nguyễn Quang Nhật', N'04/09/1999', N'Nam', N'Quảnng Ngãi', N'08T1', N'0936858484')
ALTER TABLE [tblKET_QUA]  WITH CHECK ADD  CONSTRAINT [FK_tblKET_QUA_tblMON1] FOREIGN KEY([MaMon])
REFERENCES [tblMON] ([MaMon])
GO
ALTER TABLE [tblKET_QUA] CHECK CONSTRAINT [FK_tblKET_QUA_tblMON1]
GO
ALTER TABLE [tblKET_QUA]  WITH CHECK ADD  CONSTRAINT [FK_tblKET_QUA_tblSINH_VIEN] FOREIGN KEY([MaSV])
REFERENCES [tblSINH_VIEN] ([MaSv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [tblKET_QUA] CHECK CONSTRAINT [FK_tblKET_QUA_tblSINH_VIEN]
GO
ALTER TABLE [tblLOP]  WITH CHECK ADD  CONSTRAINT [FK_tblLOP_tblKHOA] FOREIGN KEY([MaKhoa])
REFERENCES [tblKHOA] ([MaKhoa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [tblLOP] CHECK CONSTRAINT [FK_tblLOP_tblKHOA]
GO
ALTER TABLE [tblMON]  WITH CHECK ADD  CONSTRAINT [FK_tblMON_tblGIANG_VIEN] FOREIGN KEY([MaGV])
REFERENCES [tblGIANG_VIEN] ([MaGV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [tblMON] CHECK CONSTRAINT [FK_tblMON_tblGIANG_VIEN]
GO
ALTER TABLE [tblSINH_VIEN]  WITH CHECK ADD  CONSTRAINT [FK_tblSINH_VIEN_tblLOP] FOREIGN KEY([MaLop])
REFERENCES [tblLOP] ([MaLop])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [tblSINH_VIEN] CHECK CONSTRAINT [FK_tblSINH_VIEN_tblLOP]
GO
USE [master]
GO
ALTER DATABASE [Quanlydiem] SET  READ_WRITE 
GO
