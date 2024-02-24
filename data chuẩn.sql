use master;
go

if exists (select * from sysdatabases where name='[BDS_Test]')
	drop database [BDS_Test]
go

create database [BDS_Test]
go

USE [BDS_Test]
GO
/****** Object:  Table [dbo].[BatDongSan]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatDongSan](
	[MaBatDongSan] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](255) NULL,
	[MoTa] [nvarchar](255) NULL,
	[Gia] [decimal](10, 2) NULL,
	[DienTich] [float] NULL,
	[ViTri] [nvarchar](255) NULL,
	[Anh] [text] NULL,
	[TienNghi] [nvarchar](50) NULL,
	[ThongTinLienHe] [nvarchar](255) NULL,
	[NgayTao] [date] NULL,
	[NgaySua] [date] NULL,
	[MaDaiLy] [int] NULL,
	[TrangThai] [bit] NULL,
	[PhapLy] [nvarchar](50) NULL,
	[urlmap] [text] NULL,
 CONSTRAINT [PK__BatDongS__7B550270D713ABF6] PRIMARY KEY CLUSTERED 
(
	[MaBatDongSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoDich]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDich](
	[MaGiaoDich] [int] IDENTITY(1,1) NOT NULL,
	[MaBatDongSan] [int] NULL,
	[MaNguoiMua] [int] NULL,
	[MaNguoiBan] [int] NULL,
	[NgayGiaoDich] [date] NULL,
	[Gia] [decimal](10, 2) NULL,
 CONSTRAINT [PK__GiaoDich__0A2A24EBAEECF761] PRIMARY KEY CLUSTERED 
(
	[MaGiaoDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongCK]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongCK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaTK] [int] NOT NULL,
	[MoiGioi_ID] [int] NOT NULL,
	[Ma_GD] [int] NOT NULL,
	[Ngay] [datetime] NOT NULL,
	[ChietKhau] [float] NOT NULL,
 CONSTRAINT [PK_HopDongCK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHeNguoiDung]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHeNguoiDung](
	[MaLienHe] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaBatDongSan] [int] NULL,
	[NgayLienHe] [date] NULL,
	[NguoiPhuTrach] [int] NULL,
	[TrangThai] [bit] NULL,
	[GhiChu] [nvarchar](255) NULL,
	[TenNguoiDat] [nvarchar](255) NULL,
	[SDT] [nvarchar](20) NULL,
 CONSTRAINT [PK__LienHeNg__0E73388A7DAF8164] PRIMARY KEY CLUSTERED 
(
	[MaLienHe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoiGioi]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoiGioi](
	[MaDaiLy] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Passowd] [varchar](255) NULL,
 CONSTRAINT [PK__DaiLy__069B00B3C1EC4467] PRIMARY KEY CLUSTERED 
(
	[MaDaiLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Password] [varchar](255) NULL,
 CONSTRAINT [PK__NguoiDun__C539D762FD7AC91E] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanXet]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanXet](
	[MaNhanXet] [int] IDENTITY(1,1) NOT NULL,
	[MaBatDongSan] [int] NULL,
	[MaNguoiDung] [int] NULL,
	[DanhGia] [int] NULL,
	[BinhLuan] [nvarchar](255) NULL,
 CONSTRAINT [PK__NhanXet__9A47B216DF9E0BD5] PRIMARY KEY CLUSTERED 
(
	[MaNhanXet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](255) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Quyen_id] [int] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuThich]    Script Date: 8/10/2023 9:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuThich](
	[MaNguoiDung] [int] NOT NULL,
	[MaBatDongSan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC,
	[MaBatDongSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BatDongSan] ON 

INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (2, N'Nhà 4 tầng', N'sadsad', CAST(32556.00 AS Decimal(10, 2)), 300, N'Đường 3 Tháng 2, Phường 12, Quận 10, TPHCM', N'~/Content/Images/hinh1.jpg', N'gần bệnh viện', N'Thanh Binh', CAST(N'2023-05-13' AS Date), CAST(N'2023-06-12' AS Date), 1, 1, N'có sổ đỏ r', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3919.498834552381!2d106.6738629!3d10.7730542!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f26f114d311%3A0x9210c10eca077dbe!2zxJAuIDMgVGjDoW5nIDIsIFBoxrDhu51uZyAxMiAoUXXhuq1uIDEwKSwgUXXhuq1uIDEwLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1688643735859!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (3, N'Sala', N'mat tien', CAST(30000000.00 AS Decimal(10, 2)), 200, N'Sư Vạn Hạnh, phường 4, Quận 10', N'~/Content/Images/hinh1.jpg', N'gần công viên', N'Thanh Bình', CAST(N'2023-05-07' AS Date), NULL, 1, 1, N'Có sổ đỏ', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3919.498834552381!2d106.6738629!3d10.7730542!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f26f114d311%3A0x9210c10eca077dbe!2zxJAuIDMgVGjDoW5nIDIsIFBoxrDhu51uZyAxMiAoUXXhuq1uIDEwKSwgUXXhuq1uIDEwLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1688643735859!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (4, N'Nhà 5 tầng', N'hs-sv', CAST(35000.00 AS Decimal(10, 2)), 20, N'Vĩnh Viễn', N'~/Content/Images/hinh1.jpg', N'gần siêu thị', N'Thanh Binh', CAST(N'2023-03-07' AS Date), NULL, 1, 1, N'Có sổ đỏ', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3919.498834552381!2d106.6738629!3d10.7730542!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f26f114d311%3A0x9210c10eca077dbe!2zxJAuIDMgVGjDoW5nIDIsIFBoxrDhu51uZyAxMiAoUXXhuq1uIDEwKSwgUXXhuq1uIDEwLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1688643735859!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (5, N'Nhà trọ ', N'hs-sv', CAST(40000.00 AS Decimal(10, 2)), 30, N'Lý Thường Kiệt', N'~/Content/Images/hinh1.jpg', N'gần chợ', N'Thanh Binh', CAST(N'2023-06-07' AS Date), NULL, 1, 1, N'Có sổ đỏ', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3919.498834552381!2d106.6738629!3d10.7730542!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f26f114d311%3A0x9210c10eca077dbe!2zxJAuIDMgVGjDoW5nIDIsIFBoxrDhu51uZyAxMiAoUXXhuq1uIDEwKSwgUXXhuq1uIDEwLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1688643735859!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (6, N'Chung cư', N'Vincom', CAST(5000000.00 AS Decimal(10, 2)), 50, N'Phạm Ngũ Lão', N'~/Content/Images/hinh1.jpg', N'gần khu vui chơi', N'Thanh Binh', CAST(N'2023-08-07' AS Date), NULL, 1, 0, N'Có sổ đỏ', N'https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3919.498834552381!2d106.6738629!3d10.7730542!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f26f114d311%3A0x9210c10eca077dbe!2zxJAuIDMgVGjDoW5nIDIsIFBoxrDhu51uZyAxMiAoUXXhuq1uIDEwKSwgUXXhuq1uIDEwLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1688643735859!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
INSERT [dbo].[BatDongSan] ([MaBatDongSan], [TieuDe], [MoTa], [Gia], [DienTich], [ViTri], [Anh], [TienNghi], [ThongTinLienHe], [NgayTao], [NgaySua], [MaDaiLy], [TrangThai], [PhapLy], [urlmap]) VALUES (1024, N'Nhà 5 tầng', N'đẹp lắm', CAST(100000.00 AS Decimal(10, 2)), 300, N'kế Huflit Hoocmon', N'~/Content/Images/tepnguyen.png', N'gần bệnh viện', N'binh nè', NULL, NULL, 1, 0, NULL, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.2900403236995!2d106.59805157481915!3d10.865530357544307!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752b088de30f3b%3A0xd2140740d360f705!2zVHLGsOG7nW5nIMSQ4bqhaSBo4buNYyBOZ2_huqFpIG5n4buvIC0gVGluIGjhu41jIFRQLiBIQ00gKEhVRkxJVCkgLSBDxqEgc-G7nyBIw7NjIE3DtG4!5e0!3m2!1svi!2s!4v1690540181010!5m2!1svi!2s" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade')
SET IDENTITY_INSERT [dbo].[BatDongSan] OFF
GO
SET IDENTITY_INSERT [dbo].[GiaoDich] ON 

INSERT [dbo].[GiaoDich] ([MaGiaoDich], [MaBatDongSan], [MaNguoiMua], [MaNguoiBan], [NgayGiaoDich], [Gia]) VALUES (1, 3, 2, 1, CAST(N'2023-07-11' AS Date), CAST(23000.00 AS Decimal(10, 2)))
INSERT [dbo].[GiaoDich] ([MaGiaoDich], [MaBatDongSan], [MaNguoiMua], [MaNguoiBan], [NgayGiaoDich], [Gia]) VALUES (12, 3, 6, 1, CAST(N'2023-07-11' AS Date), CAST(30000000.00 AS Decimal(10, 2)))
INSERT [dbo].[GiaoDich] ([MaGiaoDich], [MaBatDongSan], [MaNguoiMua], [MaNguoiBan], [NgayGiaoDich], [Gia]) VALUES (13, 2, 6, 1, CAST(N'2023-07-11' AS Date), CAST(32556.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[GiaoDich] OFF
GO
SET IDENTITY_INSERT [dbo].[HopDongCK] ON 

INSERT [dbo].[HopDongCK] ([ID], [MaTK], [MoiGioi_ID], [Ma_GD], [Ngay], [ChietKhau]) VALUES (1, 1, 1, 1, CAST(N'2023-07-11T00:00:00.000' AS DateTime), 12000)
INSERT [dbo].[HopDongCK] ([ID], [MaTK], [MoiGioi_ID], [Ma_GD], [Ngay], [ChietKhau]) VALUES (2, 1, 1, 1, CAST(N'2023-07-11T00:00:00.000' AS DateTime), 2300)
SET IDENTITY_INSERT [dbo].[HopDongCK] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHeNguoiDung] ON 

INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (1, 1, 2, CAST(N'2023-12-09' AS Date), NULL, NULL, N'hào hảo', N'Dương', N'0123456789')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (2, 6, 2, CAST(N'2023-07-21' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (3, 6, 2, CAST(N'2023-07-21' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (4, 6, 2, CAST(N'2023-07-21' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (5, 6, 2, CAST(N'2023-07-21' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (6, 6, 2, CAST(N'2023-09-29' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
INSERT [dbo].[LienHeNguoiDung] ([MaLienHe], [MaNguoiDung], [MaBatDongSan], [NgayLienHe], [NguoiPhuTrach], [TrangThai], [GhiChu], [TenNguoiDat], [SDT]) VALUES (7, 6, 2, CAST(N'2023-09-29' AS Date), NULL, NULL, N'hoà hảo', NULL, N'01234594')
SET IDENTITY_INSERT [dbo].[LienHeNguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[MoiGioi] ON 

INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (0, N'Thành Long', N'thanhlong@gmail.com', N'0121369745', NULL, NULL)
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (1, N'Bình', N'Binh@gmail.com', N'01213400096', N'hào hảo', N'123456')
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (2, N'Oanh', N'oanh@gmail.com', N'12348548', N'', N'123456')
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (3, N'Nhung', N'Nhung@gmail.com', N'26556514', NULL, N'123456')
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (4, N'ThanhLong', N'tl@gmail.com', N'1514551514', NULL, N'123456')
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (5, N'Nghia', N'nghia@gmail.com', N'15365754', NULL, NULL)
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (6, N'lep', N'lep@gmail.com', N'0121369745', NULL, NULL)
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (7, N'Ngân', N'ngan@gmail.com', N'1514551514', N'hoahao', NULL)
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (8, N'binh@gmail.com', N'binh2@gmail.com', N'01213697452', N'hoahao', N'12345678a')
INSERT [dbo].[MoiGioi] ([MaDaiLy], [Ten], [Email], [DienThoai], [DiaChi], [Passowd]) VALUES (9, N'2343', N'binh3@gmail.com', N'01213697454', N'hoahao', N'12345678a')
SET IDENTITY_INSERT [dbo].[MoiGioi] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (1, N'Oanh', N'oanh@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (6, N'Binh', N'binh@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (7, N'Tú', N'Tu@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (13, N'Binh', N'lethanh@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (14, N'binhle', N'binhle@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (15, N'lethanhbinh', N'ltb@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (16, N'Binh', N'lep@gmail.com', NULL, NULL, N'123456')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [Email], [DienThoai], [DiaChi], [Password]) VALUES (17, N'Binh', N'kha@gmail.com', NULL, NULL, N'123456')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanXet] ON 

INSERT [dbo].[NhanXet] ([MaNhanXet], [MaBatDongSan], [MaNguoiDung], [DanhGia], [BinhLuan]) VALUES (3, NULL, 6, NULL, N'binh')
INSERT [dbo].[NhanXet] ([MaNhanXet], [MaBatDongSan], [MaNguoiDung], [DanhGia], [BinhLuan]) VALUES (4, NULL, 6, NULL, N'tôi muốn mua bánh')
INSERT [dbo].[NhanXet] ([MaNhanXet], [MaBatDongSan], [MaNguoiDung], [DanhGia], [BinhLuan]) VALUES (5, NULL, 1, NULL, N'tôi có thể giúp gì cho bạn')
SET IDENTITY_INSERT [dbo].[NhanXet] OFF
GO
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([ID], [TenQuyen]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [Password], [Quyen_id]) VALUES (1, N'Bình', N'123456', 1)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[BatDongSan]  WITH CHECK ADD  CONSTRAINT [FK__BatDongSa__MaDai__2B3F6F97] FOREIGN KEY([MaDaiLy])
REFERENCES [dbo].[MoiGioi] ([MaDaiLy])
GO
ALTER TABLE [dbo].[BatDongSan] CHECK CONSTRAINT [FK__BatDongSa__MaDai__2B3F6F97]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK__GiaoDich__MaBatD__3C69FB99] FOREIGN KEY([MaBatDongSan])
REFERENCES [dbo].[BatDongSan] ([MaBatDongSan])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK__GiaoDich__MaBatD__3C69FB99]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK__GiaoDich__MaNguo__3F466844] FOREIGN KEY([MaNguoiBan])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK__GiaoDich__MaNguo__3F466844]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_GiaoDich_MoiGioi] FOREIGN KEY([MaNguoiBan])
REFERENCES [dbo].[MoiGioi] ([MaDaiLy])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_GiaoDich_MoiGioi]
GO
ALTER TABLE [dbo].[HopDongCK]  WITH CHECK ADD  CONSTRAINT [FK_HopDongCK_GiaoDich] FOREIGN KEY([Ma_GD])
REFERENCES [dbo].[GiaoDich] ([MaGiaoDich])
GO
ALTER TABLE [dbo].[HopDongCK] CHECK CONSTRAINT [FK_HopDongCK_GiaoDich]
GO
ALTER TABLE [dbo].[HopDongCK]  WITH CHECK ADD  CONSTRAINT [FK_HopDongCK_MoiGioi] FOREIGN KEY([MoiGioi_ID])
REFERENCES [dbo].[MoiGioi] ([MaDaiLy])
GO
ALTER TABLE [dbo].[HopDongCK] CHECK CONSTRAINT [FK_HopDongCK_MoiGioi]
GO
ALTER TABLE [dbo].[HopDongCK]  WITH CHECK ADD  CONSTRAINT [FK_HopDongCK_TaiKhoan] FOREIGN KEY([MaTK])
REFERENCES [dbo].[TaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[HopDongCK] CHECK CONSTRAINT [FK_HopDongCK_TaiKhoan]
GO
ALTER TABLE [dbo].[LienHeNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK__LienHeNgu__MaBat__35BCFE0A] FOREIGN KEY([MaBatDongSan])
REFERENCES [dbo].[BatDongSan] ([MaBatDongSan])
GO
ALTER TABLE [dbo].[LienHeNguoiDung] CHECK CONSTRAINT [FK__LienHeNgu__MaBat__35BCFE0A]
GO
ALTER TABLE [dbo].[LienHeNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK__LienHeNgu__MaNgu__34C8D9D1] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[LienHeNguoiDung] CHECK CONSTRAINT [FK__LienHeNgu__MaNgu__34C8D9D1]
GO
ALTER TABLE [dbo].[LienHeNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_LienHeNguoiDung_TaiKhoan] FOREIGN KEY([NguoiPhuTrach])
REFERENCES [dbo].[TaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[LienHeNguoiDung] CHECK CONSTRAINT [FK_LienHeNguoiDung_TaiKhoan]
GO
ALTER TABLE [dbo].[NhanXet]  WITH CHECK ADD  CONSTRAINT [FK__NhanXet__MaBatDo__38996AB5] FOREIGN KEY([MaBatDongSan])
REFERENCES [dbo].[BatDongSan] ([MaBatDongSan])
GO
ALTER TABLE [dbo].[NhanXet] CHECK CONSTRAINT [FK__NhanXet__MaBatDo__38996AB5]
GO
ALTER TABLE [dbo].[NhanXet]  WITH CHECK ADD  CONSTRAINT [FK__NhanXet__MaNguoi__398D8EEE] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[NhanXet] CHECK CONSTRAINT [FK__NhanXet__MaNguoi__398D8EEE]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_Quyen] FOREIGN KEY([Quyen_id])
REFERENCES [dbo].[Quyen] ([ID])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_Quyen]
GO
ALTER TABLE [dbo].[YeuThich]  WITH CHECK ADD  CONSTRAINT [FK__YeuThich__MaBatD__31EC6D26] FOREIGN KEY([MaBatDongSan])
REFERENCES [dbo].[BatDongSan] ([MaBatDongSan])
GO
ALTER TABLE [dbo].[YeuThich] CHECK CONSTRAINT [FK__YeuThich__MaBatD__31EC6D26]
GO
ALTER TABLE [dbo].[YeuThich]  WITH CHECK ADD  CONSTRAINT [FK__YeuThich__MaNguo__30F848ED] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[YeuThich] CHECK CONSTRAINT [FK__YeuThich__MaNguo__30F848ED]
GO
