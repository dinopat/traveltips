USE [traveltips]
GO
/****** Object:  Table [dbo].[tbl_DanhMuc]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DanhMuc](
	[id_DanhMuc] [bigint] IDENTITY(1,1) NOT NULL,
	[id_DMCha] [bigint] NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
	[MaDanhMuc] [varchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[id_DanhMuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ChuCongTy]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ChuCongTy](
	[id_ChuCongTy] [bigint] IDENTITY(1,1) NOT NULL,
	[TenChuCongTy] [nvarchar](200) NULL,
	[TenCongTy] [nvarchar](200) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[DienThoaiCD] [varchar](50) NULL,
	[DienThoaiDD] [varchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ChuCongTy] PRIMARY KEY CLUSTERED 
(
	[id_ChuCongTy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Admin]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Admin](
	[id_Admin] [bigint] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[HoTen] [nvarchar](200) NULL,
	[DienThoai] [varchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Admin] PRIMARY KEY CLUSTERED 
(
	[id_Admin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_KhuVuc]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_KhuVuc](
	[id_KhuVuc] [bigint] IDENTITY(1,1) NOT NULL,
	[TenKV] [nvarchar](255) NULL,
	[MaKV] [varbinary](50) NULL,
	[MoTa] [nvarchar](1000) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_KhuVuc] PRIMARY KEY CLUSTERED 
(
	[id_KhuVuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_LoaiSP]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_LoaiSP](
	[id_LoaiSP] [bigint] IDENTITY(1,1) NOT NULL,
	[id_LoaiSPCha] [bigint] NULL,
	[TenLoaiSP] [nvarchar](255) NULL,
	[MaLoaiSP] [varchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[id_LoaiSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Language]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Language](
	[id_Language] [int] IDENTITY(1,1) NOT NULL,
	[TenNN] [varchar](50) NULL,
	[MaNN] [varchar](50) NULL,
	[Mota] [varchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Language] PRIMARY KEY CLUSTERED 
(
	[id_Language] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_LabelNN]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_LabelNN](
	[id_Label] [bigint] IDENTITY(1,1) NOT NULL,
	[MaLabel] [varchar](50) NULL,
	[TenLabel] [varchar](50) NULL,
	[MoTa] [varchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Label] PRIMARY KEY CLUSTERED 
(
	[id_Label] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_User](
	[id_User] [bigint] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[HoTen] [nvarchar](255) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[DienThoai] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id_User] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_TuDien]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_TuDien](
	[id_TuDien] [bigint] IDENTITY(1,1) NOT NULL,
	[id_DanhMuc] [bigint] NULL,
	[TenTu] [nvarchar](50) NULL,
	[MaTu] [varchar](50) NULL,
	[NhomTu] [varchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_TuDien] PRIMARY KEY CLUSTERED 
(
	[id_TuDien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NhomTu: Dai dien cho mot nhom nhat dinh phai co tu dien (phuc vu cho viec Load len theo nhom). Vi du: Mon An, Thuc Uong, Quoc Gia, Tinh, Thanh Pho,......' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_TuDien', @level2type=N'COLUMN',@level2name=N'NhomTu'
GO
/****** Object:  Table [dbo].[tbl_QuocGia]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_QuocGia](
	[id_QuocGia] [bigint] IDENTITY(1,1) NOT NULL,
	[TenQG] [nvarchar](100) NULL,
	[MaQG] [varchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_QuocGia] PRIMARY KEY CLUSTERED 
(
	[id_QuocGia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ThuocTinh]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ThuocTinh](
	[id_ThuocTinh] [bigint] IDENTITY(1,1) NOT NULL,
	[TenThuocTinh] [nvarchar](50) NULL,
	[MaThuocTinh] [varchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ThuocTinh] PRIMARY KEY CLUSTERED 
(
	[id_ThuocTinh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_ThanhPho]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ThanhPho](
	[id_ThanhPho] [bigint] IDENTITY(1,1) NOT NULL,
	[id_QuocGia] [bigint] NULL,
	[TenTP] [nvarchar](100) NULL,
	[MaTP] [varchar](50) NULL,
	[Mota] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ThanhPho] PRIMARY KEY CLUSTERED 
(
	[id_ThanhPho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_LabelLanguage]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LabelLanguage](
	[id_LabelLanguage] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Language] [int] NULL,
	[id_Label] [bigint] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_LabelLanguage] PRIMARY KEY CLUSTERED 
(
	[id_LabelLanguage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_CongTy](
	[id_CongTy] [bigint] IDENTITY(1,1) NOT NULL,
	[id_ChuCongTy] [bigint] NULL,
	[id_DanhMuc] [bigint] NULL,
	[id_QuocGia] [bigint] NULL,
	[id_ThanhPho] [bigint] NULL,
	[id_Quan] [bigint] NULL,
	[id_Duong] [bigint] NULL,
	[id_KhuVuc] [bigint] NULL,
	[SoNha] [varchar](10) NULL,
	[DienThoaiCD] [varchar](50) NULL,
	[DienThoaiDD] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[HinhThucTT] [nvarchar](200) NULL,
	[ThoiGianPV] [nvarchar](50) NULL,
	[AnhMinhHoa] [varchar](500) NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[MoTaNgan] [nvarchar](500) NULL,
	[MoTaChiTiet] [nvarchar](max) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_CongTy] PRIMARY KEY CLUSTERED 
(
	[id_CongTy] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Luu duoi dang: Tu;den' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_CongTy', @level2type=N'COLUMN',@level2name=N'ThoiGianPV'
GO
/****** Object:  Table [dbo].[tbl_Comment]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Comment](
	[id_Comment] [bigint] IDENTITY(1,1) NOT NULL,
	[id_User] [bigint] NULL,
	[id_Congty] [bigint] NULL,
	[TieuDe] [nvarchar](200) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Feedback] PRIMARY KEY CLUSTERED 
(
	[id_Comment] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id trong table Label' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Comment', @level2type=N'COLUMN',@level2name=N'TieuDe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id truy xuat trong bang Label' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Comment', @level2type=N'COLUMN',@level2name=N'NoiDung'
GO
/****** Object:  Table [dbo].[tbl_Gallery]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Gallery](
	[id_Gallery] [bigint] IDENTITY(1,1) NOT NULL,
	[id_CongTy] [bigint] NULL,
	[TenAnh] [nvarchar](50) NULL,
	[DuongDan] [nvarchar](500) NULL,
	[MoTa] [varchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Gallery] PRIMARY KEY CLUSTERED 
(
	[id_Gallery] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SanPham]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SanPham](
	[id_SanPham] [bigint] IDENTITY(1,1) NOT NULL,
	[id_CongTy] [bigint] NULL,
	[id_LoaiSP] [bigint] NULL,
	[id_TuDien] [bigint] NULL,
	[TenSP] [nvarchar](255) NULL,
	[MaSP] [varchar](50) NULL,
	[Gia] [money] NULL,
	[MoTaNgan] [nvarchar](255) NULL,
	[MoTaChiTiet] [nvarchar](max) NULL,
	[AnhMinhHoa] [varbinary](500) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_SanPham] PRIMARY KEY CLUSTERED 
(
	[id_SanPham] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MaSP, TenSP duoc lay tu bang Tu Dien' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SanPham', @level2type=N'COLUMN',@level2name=N'id_TuDien'
GO
/****** Object:  Table [dbo].[tbl_Quan]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Quan](
	[id_Quan] [bigint] IDENTITY(1,1) NOT NULL,
	[id_ThanhPho] [bigint] NULL,
	[TenQuan] [nvarchar](50) NULL,
	[MaQuan] [varchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Quan] PRIMARY KEY CLUSTERED 
(
	[id_Quan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_DichVu]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DichVu](
	[id_DichVu] [bigint] IDENTITY(1,1) NOT NULL,
	[id_CongTy] [bigint] NULL,
	[TenDV] [nvarchar](50) NULL,
	[MaDV] [varchar](50) NULL,
	[MotaNgan] [nvarchar](200) NULL,
	[MotaChiTiet] [nvarchar](max) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_DichVu] PRIMARY KEY CLUSTERED 
(
	[id_DichVu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_TinTuc]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TinTuc](
	[id_TinTuc] [bigint] IDENTITY(1,1) NOT NULL,
	[id_CongTy] [bigint] NULL,
	[TieuDe] [nvarchar](200) NULL,
	[MoTaNgan] [nvarchar](500) NULL,
	[MoTaChiTiet] [nvarchar](max) NULL,
	[KhuyenMai] [bit] NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_TinTuc] PRIMARY KEY CLUSTERED 
(
	[id_TinTuc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ThuocTinhSanPham]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ThuocTinhSanPham](
	[id_TTSP] [bigint] IDENTITY(1,1) NOT NULL,
	[id_SanPham] [bigint] NULL,
	[id_ThuocTinh] [bigint] NULL,
	[Value1] [nvarchar](255) NULL,
	[Value2] [nvarchar](255) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_ThuocTinhSanPham] PRIMARY KEY CLUSTERED 
(
	[id_TTSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Duong]    Script Date: 04/17/2011 10:49:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Duong](
	[id_Duong] [bigint] IDENTITY(1,1) NOT NULL,
	[id_Quan] [bigint] NULL,
	[TenDuong] [nvarchar](50) NULL,
	[MaDuong] [varbinary](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[Flag] [tinyint] NULL,
 CONSTRAINT [PK_tbl_Duong] PRIMARY KEY CLUSTERED 
(
	[id_Duong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_tbl_Comment_tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_Comment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Comment_tbl_CongTy] FOREIGN KEY([id_Congty])
REFERENCES [dbo].[tbl_CongTy] ([id_CongTy])
GO
ALTER TABLE [dbo].[tbl_Comment] CHECK CONSTRAINT [FK_tbl_Comment_tbl_CongTy]
GO
/****** Object:  ForeignKey [FK_tbl_Comment_tbl_User]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_Comment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Comment_tbl_User] FOREIGN KEY([id_User])
REFERENCES [dbo].[tbl_User] ([id_User])
GO
ALTER TABLE [dbo].[tbl_Comment] CHECK CONSTRAINT [FK_tbl_Comment_tbl_User]
GO
/****** Object:  ForeignKey [FK_tbl_CongTy_tbl_ChuCongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_CongTy]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CongTy_tbl_ChuCongTy] FOREIGN KEY([id_ChuCongTy])
REFERENCES [dbo].[tbl_ChuCongTy] ([id_ChuCongTy])
GO
ALTER TABLE [dbo].[tbl_CongTy] CHECK CONSTRAINT [FK_tbl_CongTy_tbl_ChuCongTy]
GO
/****** Object:  ForeignKey [FK_tbl_CongTy_tbl_DanhMuc]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_CongTy]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CongTy_tbl_DanhMuc] FOREIGN KEY([id_DanhMuc])
REFERENCES [dbo].[tbl_DanhMuc] ([id_DanhMuc])
GO
ALTER TABLE [dbo].[tbl_CongTy] CHECK CONSTRAINT [FK_tbl_CongTy_tbl_DanhMuc]
GO
/****** Object:  ForeignKey [FK_tbl_DichVu_tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_DichVu]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DichVu_tbl_CongTy] FOREIGN KEY([id_DichVu])
REFERENCES [dbo].[tbl_CongTy] ([id_CongTy])
GO
ALTER TABLE [dbo].[tbl_DichVu] CHECK CONSTRAINT [FK_tbl_DichVu_tbl_CongTy]
GO
/****** Object:  ForeignKey [FK_tbl_Duong_tbl_Quan]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_Duong]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Duong_tbl_Quan] FOREIGN KEY([id_Quan])
REFERENCES [dbo].[tbl_Quan] ([id_Quan])
GO
ALTER TABLE [dbo].[tbl_Duong] CHECK CONSTRAINT [FK_tbl_Duong_tbl_Quan]
GO
/****** Object:  ForeignKey [FK_tbl_Gallery_tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_Gallery]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Gallery_tbl_CongTy] FOREIGN KEY([id_CongTy])
REFERENCES [dbo].[tbl_CongTy] ([id_CongTy])
GO
ALTER TABLE [dbo].[tbl_Gallery] CHECK CONSTRAINT [FK_tbl_Gallery_tbl_CongTy]
GO
/****** Object:  ForeignKey [FK_tbl_LabelLanguage_tbl_Label]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_LabelLanguage]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LabelLanguage_tbl_Label] FOREIGN KEY([id_Label])
REFERENCES [dbo].[tbl_LabelNN] ([id_Label])
GO
ALTER TABLE [dbo].[tbl_LabelLanguage] CHECK CONSTRAINT [FK_tbl_LabelLanguage_tbl_Label]
GO
/****** Object:  ForeignKey [FK_tbl_LabelLanguage_tbl_Language]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_LabelLanguage]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LabelLanguage_tbl_Language] FOREIGN KEY([id_Language])
REFERENCES [dbo].[tbl_Language] ([id_Language])
GO
ALTER TABLE [dbo].[tbl_LabelLanguage] CHECK CONSTRAINT [FK_tbl_LabelLanguage_tbl_Language]
GO
/****** Object:  ForeignKey [FK_tbl_Quan_tbl_ThanhPho]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_Quan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Quan_tbl_ThanhPho] FOREIGN KEY([id_ThanhPho])
REFERENCES [dbo].[tbl_ThanhPho] ([id_ThanhPho])
GO
ALTER TABLE [dbo].[tbl_Quan] CHECK CONSTRAINT [FK_tbl_Quan_tbl_ThanhPho]
GO
/****** Object:  ForeignKey [FK_tbl_SanPham_tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SanPham_tbl_CongTy] FOREIGN KEY([id_SanPham])
REFERENCES [dbo].[tbl_CongTy] ([id_CongTy])
GO
ALTER TABLE [dbo].[tbl_SanPham] CHECK CONSTRAINT [FK_tbl_SanPham_tbl_CongTy]
GO
/****** Object:  ForeignKey [FK_tbl_SanPham_tbl_LoaiSP]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SanPham_tbl_LoaiSP] FOREIGN KEY([id_LoaiSP])
REFERENCES [dbo].[tbl_LoaiSP] ([id_LoaiSP])
GO
ALTER TABLE [dbo].[tbl_SanPham] CHECK CONSTRAINT [FK_tbl_SanPham_tbl_LoaiSP]
GO
/****** Object:  ForeignKey [FK_tbl_ThanhPho_tbl_QuocGia]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_ThanhPho]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ThanhPho_tbl_QuocGia] FOREIGN KEY([id_QuocGia])
REFERENCES [dbo].[tbl_QuocGia] ([id_QuocGia])
GO
ALTER TABLE [dbo].[tbl_ThanhPho] CHECK CONSTRAINT [FK_tbl_ThanhPho_tbl_QuocGia]
GO
/****** Object:  ForeignKey [FK_tbl_ThuocTinhSanPham_tbl_SanPham]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_ThuocTinhSanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ThuocTinhSanPham_tbl_SanPham] FOREIGN KEY([id_SanPham])
REFERENCES [dbo].[tbl_SanPham] ([id_SanPham])
GO
ALTER TABLE [dbo].[tbl_ThuocTinhSanPham] CHECK CONSTRAINT [FK_tbl_ThuocTinhSanPham_tbl_SanPham]
GO
/****** Object:  ForeignKey [FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_ThuocTinhSanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh] FOREIGN KEY([id_ThuocTinh])
REFERENCES [dbo].[tbl_ThuocTinh] ([id_ThuocTinh])
GO
ALTER TABLE [dbo].[tbl_ThuocTinhSanPham] CHECK CONSTRAINT [FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh]
GO
/****** Object:  ForeignKey [FK_tbl_TinTuc_tbl_CongTy]    Script Date: 04/17/2011 10:49:54 ******/
ALTER TABLE [dbo].[tbl_TinTuc]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TinTuc_tbl_CongTy] FOREIGN KEY([id_CongTy])
REFERENCES [dbo].[tbl_CongTy] ([id_CongTy])
GO
ALTER TABLE [dbo].[tbl_TinTuc] CHECK CONSTRAINT [FK_tbl_TinTuc_tbl_CongTy]
GO
