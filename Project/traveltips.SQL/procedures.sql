
Use [traveltips]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_QuocGia table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_Get_List

AS


				
				SELECT
					[id_QuocGia],
					[TenQG],
					[MaQG],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_QuocGia]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_QuocGia table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_QuocGia] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_QuocGia])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_QuocGia]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_QuocGia]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_QuocGia], O.[TenQG], O.[MaQG], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_QuocGia] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_QuocGia] = PageIndex.[id_QuocGia]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_QuocGia]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_QuocGia table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_Insert
(

	@IdQuocGia bigint   ,

	@TenQg nvarchar (100)  ,

	@MaQg varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_QuocGia]
					(
					[id_QuocGia]
					,[TenQG]
					,[MaQG]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdQuocGia
					,@TenQg
					,@MaQg
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_QuocGia table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_Update
(

	@IdQuocGia bigint   ,

	@OriginalIdQuocGia bigint   ,

	@TenQg nvarchar (100)  ,

	@MaQg varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_QuocGia]
				SET
					[id_QuocGia] = @IdQuocGia
					,[TenQG] = @TenQg
					,[MaQG] = @MaQg
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_QuocGia] = @OriginalIdQuocGia 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_QuocGia table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_Delete
(

	@IdQuocGia bigint   
)
AS


				DELETE FROM [dbo].[tbl_QuocGia] WITH (ROWLOCK) 
				WHERE
					[id_QuocGia] = @IdQuocGia
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_GetByIdQuocGia procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_GetByIdQuocGia') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_GetByIdQuocGia
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_QuocGia table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_GetByIdQuocGia
(

	@IdQuocGia bigint   
)
AS


				SELECT
					[id_QuocGia],
					[TenQG],
					[MaQG],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_QuocGia]
				WHERE
					[id_QuocGia] = @IdQuocGia
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_QuocGia_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_QuocGia_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_QuocGia_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_QuocGia table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_QuocGia_Find
(

	@SearchUsingOR bit   = null ,

	@IdQuocGia bigint   = null ,

	@TenQg nvarchar (100)  = null ,

	@MaQg varchar (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_QuocGia]
	, [TenQG]
	, [MaQG]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_QuocGia]
    WHERE 
	 ([id_QuocGia] = @IdQuocGia OR @IdQuocGia is null)
	AND ([TenQG] = @TenQg OR @TenQg is null)
	AND ([MaQG] = @MaQg OR @MaQg is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_QuocGia]
	, [TenQG]
	, [MaQG]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_QuocGia]
    WHERE 
	 ([id_QuocGia] = @IdQuocGia AND @IdQuocGia is not null)
	OR ([TenQG] = @TenQg AND @TenQg is not null)
	OR ([MaQG] = @MaQg AND @MaQg is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Admin table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_Get_List

AS


				
				SELECT
					[id_Admin],
					[TenDangNhap],
					[Email],
					[Password],
					[HoTen],
					[DienThoai],
					[Flag]
				FROM
					[dbo].[tbl_Admin]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Admin table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Admin] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Admin])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Admin]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Admin]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Admin], O.[TenDangNhap], O.[Email], O.[Password], O.[HoTen], O.[DienThoai], O.[Flag]
				FROM
				    [dbo].[tbl_Admin] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Admin] = PageIndex.[id_Admin]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Admin]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Admin table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_Insert
(

	@IdAdmin bigint   ,

	@TenDangNhap varchar (50)  ,

	@Email varchar (50)  ,

	@Password nvarchar (50)  ,

	@HoTen varchar (200)  ,

	@DienThoai varchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Admin]
					(
					[id_Admin]
					,[TenDangNhap]
					,[Email]
					,[Password]
					,[HoTen]
					,[DienThoai]
					,[Flag]
					)
				VALUES
					(
					@IdAdmin
					,@TenDangNhap
					,@Email
					,@Password
					,@HoTen
					,@DienThoai
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Admin table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_Update
(

	@IdAdmin bigint   ,

	@OriginalIdAdmin bigint   ,

	@TenDangNhap varchar (50)  ,

	@Email varchar (50)  ,

	@Password nvarchar (50)  ,

	@HoTen varchar (200)  ,

	@DienThoai varchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Admin]
				SET
					[id_Admin] = @IdAdmin
					,[TenDangNhap] = @TenDangNhap
					,[Email] = @Email
					,[Password] = @Password
					,[HoTen] = @HoTen
					,[DienThoai] = @DienThoai
					,[Flag] = @Flag
				WHERE
[id_Admin] = @OriginalIdAdmin 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Admin table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_Delete
(

	@IdAdmin bigint   
)
AS


				DELETE FROM [dbo].[tbl_Admin] WITH (ROWLOCK) 
				WHERE
					[id_Admin] = @IdAdmin
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_GetByIdAdmin procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_GetByIdAdmin') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_GetByIdAdmin
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Admin table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_GetByIdAdmin
(

	@IdAdmin bigint   
)
AS


				SELECT
					[id_Admin],
					[TenDangNhap],
					[Email],
					[Password],
					[HoTen],
					[DienThoai],
					[Flag]
				FROM
					[dbo].[tbl_Admin]
				WHERE
					[id_Admin] = @IdAdmin
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Admin_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Admin_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Admin_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Admin table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Admin_Find
(

	@SearchUsingOR bit   = null ,

	@IdAdmin bigint   = null ,

	@TenDangNhap varchar (50)  = null ,

	@Email varchar (50)  = null ,

	@Password nvarchar (50)  = null ,

	@HoTen varchar (200)  = null ,

	@DienThoai varchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Admin]
	, [TenDangNhap]
	, [Email]
	, [Password]
	, [HoTen]
	, [DienThoai]
	, [Flag]
    FROM
	[dbo].[tbl_Admin]
    WHERE 
	 ([id_Admin] = @IdAdmin OR @IdAdmin is null)
	AND ([TenDangNhap] = @TenDangNhap OR @TenDangNhap is null)
	AND ([Email] = @Email OR @Email is null)
	AND ([Password] = @Password OR @Password is null)
	AND ([HoTen] = @HoTen OR @HoTen is null)
	AND ([DienThoai] = @DienThoai OR @DienThoai is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Admin]
	, [TenDangNhap]
	, [Email]
	, [Password]
	, [HoTen]
	, [DienThoai]
	, [Flag]
    FROM
	[dbo].[tbl_Admin]
    WHERE 
	 ([id_Admin] = @IdAdmin AND @IdAdmin is not null)
	OR ([TenDangNhap] = @TenDangNhap AND @TenDangNhap is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([HoTen] = @HoTen AND @HoTen is not null)
	OR ([DienThoai] = @DienThoai AND @DienThoai is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_SanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_Get_List

AS


				
				SELECT
					[id_SanPham],
					[id_CongTy],
					[id_LoaiSP],
					[id_TuDien],
					[TenSP],
					[MaSP],
					[Gia],
					[MoTaNgan],
					[MoTaChiTiet],
					[AnhMinhHoa],
					[Flag]
				FROM
					[dbo].[tbl_SanPham]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_SanPham table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_SanPham] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_SanPham])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_SanPham]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_SanPham]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_SanPham], O.[id_CongTy], O.[id_LoaiSP], O.[id_TuDien], O.[TenSP], O.[MaSP], O.[Gia], O.[MoTaNgan], O.[MoTaChiTiet], O.[AnhMinhHoa], O.[Flag]
				FROM
				    [dbo].[tbl_SanPham] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_SanPham] = PageIndex.[id_SanPham]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_SanPham]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_SanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_Insert
(

	@IdSanPham bigint   ,

	@IdCongTy bigint   ,

	@IdLoaiSp bigint   ,

	@IdTuDien bigint   ,

	@TenSp nvarchar (255)  ,

	@MaSp varchar (50)  ,

	@Gia money   ,

	@MoTaNgan nvarchar (255)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@AnhMinhHoa varbinary (500)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_SanPham]
					(
					[id_SanPham]
					,[id_CongTy]
					,[id_LoaiSP]
					,[id_TuDien]
					,[TenSP]
					,[MaSP]
					,[Gia]
					,[MoTaNgan]
					,[MoTaChiTiet]
					,[AnhMinhHoa]
					,[Flag]
					)
				VALUES
					(
					@IdSanPham
					,@IdCongTy
					,@IdLoaiSp
					,@IdTuDien
					,@TenSp
					,@MaSp
					,@Gia
					,@MoTaNgan
					,@MoTaChiTiet
					,@AnhMinhHoa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_SanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_Update
(

	@IdSanPham bigint   ,

	@OriginalIdSanPham bigint   ,

	@IdCongTy bigint   ,

	@IdLoaiSp bigint   ,

	@IdTuDien bigint   ,

	@TenSp nvarchar (255)  ,

	@MaSp varchar (50)  ,

	@Gia money   ,

	@MoTaNgan nvarchar (255)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@AnhMinhHoa varbinary (500)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_SanPham]
				SET
					[id_SanPham] = @IdSanPham
					,[id_CongTy] = @IdCongTy
					,[id_LoaiSP] = @IdLoaiSp
					,[id_TuDien] = @IdTuDien
					,[TenSP] = @TenSp
					,[MaSP] = @MaSp
					,[Gia] = @Gia
					,[MoTaNgan] = @MoTaNgan
					,[MoTaChiTiet] = @MoTaChiTiet
					,[AnhMinhHoa] = @AnhMinhHoa
					,[Flag] = @Flag
				WHERE
[id_SanPham] = @OriginalIdSanPham 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_SanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_Delete
(

	@IdSanPham bigint   
)
AS


				DELETE FROM [dbo].[tbl_SanPham] WITH (ROWLOCK) 
				WHERE
					[id_SanPham] = @IdSanPham
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_GetByIdLoaiSp procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_GetByIdLoaiSp') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_GetByIdLoaiSp
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_SanPham table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_GetByIdLoaiSp
(

	@IdLoaiSp bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_SanPham],
					[id_CongTy],
					[id_LoaiSP],
					[id_TuDien],
					[TenSP],
					[MaSP],
					[Gia],
					[MoTaNgan],
					[MoTaChiTiet],
					[AnhMinhHoa],
					[Flag]
				FROM
					[dbo].[tbl_SanPham]
				WHERE
					[id_LoaiSP] = @IdLoaiSp
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_GetByIdSanPham procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_GetByIdSanPham') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_GetByIdSanPham
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_SanPham table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_GetByIdSanPham
(

	@IdSanPham bigint   
)
AS


				SELECT
					[id_SanPham],
					[id_CongTy],
					[id_LoaiSP],
					[id_TuDien],
					[TenSP],
					[MaSP],
					[Gia],
					[MoTaNgan],
					[MoTaChiTiet],
					[AnhMinhHoa],
					[Flag]
				FROM
					[dbo].[tbl_SanPham]
				WHERE
					[id_SanPham] = @IdSanPham
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_SanPham_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_SanPham_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_SanPham_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_SanPham table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_SanPham_Find
(

	@SearchUsingOR bit   = null ,

	@IdSanPham bigint   = null ,

	@IdCongTy bigint   = null ,

	@IdLoaiSp bigint   = null ,

	@IdTuDien bigint   = null ,

	@TenSp nvarchar (255)  = null ,

	@MaSp varchar (50)  = null ,

	@Gia money   = null ,

	@MoTaNgan nvarchar (255)  = null ,

	@MoTaChiTiet nvarchar (MAX)  = null ,

	@AnhMinhHoa varbinary (500)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_SanPham]
	, [id_CongTy]
	, [id_LoaiSP]
	, [id_TuDien]
	, [TenSP]
	, [MaSP]
	, [Gia]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [AnhMinhHoa]
	, [Flag]
    FROM
	[dbo].[tbl_SanPham]
    WHERE 
	 ([id_SanPham] = @IdSanPham OR @IdSanPham is null)
	AND ([id_CongTy] = @IdCongTy OR @IdCongTy is null)
	AND ([id_LoaiSP] = @IdLoaiSp OR @IdLoaiSp is null)
	AND ([id_TuDien] = @IdTuDien OR @IdTuDien is null)
	AND ([TenSP] = @TenSp OR @TenSp is null)
	AND ([MaSP] = @MaSp OR @MaSp is null)
	AND ([Gia] = @Gia OR @Gia is null)
	AND ([MoTaNgan] = @MoTaNgan OR @MoTaNgan is null)
	AND ([MoTaChiTiet] = @MoTaChiTiet OR @MoTaChiTiet is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_SanPham]
	, [id_CongTy]
	, [id_LoaiSP]
	, [id_TuDien]
	, [TenSP]
	, [MaSP]
	, [Gia]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [AnhMinhHoa]
	, [Flag]
    FROM
	[dbo].[tbl_SanPham]
    WHERE 
	 ([id_SanPham] = @IdSanPham AND @IdSanPham is not null)
	OR ([id_CongTy] = @IdCongTy AND @IdCongTy is not null)
	OR ([id_LoaiSP] = @IdLoaiSp AND @IdLoaiSp is not null)
	OR ([id_TuDien] = @IdTuDien AND @IdTuDien is not null)
	OR ([TenSP] = @TenSp AND @TenSp is not null)
	OR ([MaSP] = @MaSp AND @MaSp is not null)
	OR ([Gia] = @Gia AND @Gia is not null)
	OR ([MoTaNgan] = @MoTaNgan AND @MoTaNgan is not null)
	OR ([MoTaChiTiet] = @MoTaChiTiet AND @MoTaChiTiet is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_LoaiSP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_Get_List

AS


				
				SELECT
					[id_LoaiSP],
					[id_LoaiSPCha],
					[TenLoaiSP],
					[MaLoaiSP],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_LoaiSP]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_LoaiSP table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_LoaiSP] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_LoaiSP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_LoaiSP]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LoaiSP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_LoaiSP], O.[id_LoaiSPCha], O.[TenLoaiSP], O.[MaLoaiSP], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_LoaiSP] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_LoaiSP] = PageIndex.[id_LoaiSP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LoaiSP]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_LoaiSP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_Insert
(

	@IdLoaiSp bigint   ,

	@IdLoaiSpCha bigint   ,

	@TenLoaiSp nvarchar (255)  ,

	@MaLoaiSp varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_LoaiSP]
					(
					[id_LoaiSP]
					,[id_LoaiSPCha]
					,[TenLoaiSP]
					,[MaLoaiSP]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdLoaiSp
					,@IdLoaiSpCha
					,@TenLoaiSp
					,@MaLoaiSp
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_LoaiSP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_Update
(

	@IdLoaiSp bigint   ,

	@OriginalIdLoaiSp bigint   ,

	@IdLoaiSpCha bigint   ,

	@TenLoaiSp nvarchar (255)  ,

	@MaLoaiSp varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_LoaiSP]
				SET
					[id_LoaiSP] = @IdLoaiSp
					,[id_LoaiSPCha] = @IdLoaiSpCha
					,[TenLoaiSP] = @TenLoaiSp
					,[MaLoaiSP] = @MaLoaiSp
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_LoaiSP] = @OriginalIdLoaiSp 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_LoaiSP table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_Delete
(

	@IdLoaiSp bigint   
)
AS


				DELETE FROM [dbo].[tbl_LoaiSP] WITH (ROWLOCK) 
				WHERE
					[id_LoaiSP] = @IdLoaiSp
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_GetByIdLoaiSp procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_GetByIdLoaiSp') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_GetByIdLoaiSp
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_LoaiSP table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_GetByIdLoaiSp
(

	@IdLoaiSp bigint   
)
AS


				SELECT
					[id_LoaiSP],
					[id_LoaiSPCha],
					[TenLoaiSP],
					[MaLoaiSP],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_LoaiSP]
				WHERE
					[id_LoaiSP] = @IdLoaiSp
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LoaiSP_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LoaiSP_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LoaiSP_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_LoaiSP table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LoaiSP_Find
(

	@SearchUsingOR bit   = null ,

	@IdLoaiSp bigint   = null ,

	@IdLoaiSpCha bigint   = null ,

	@TenLoaiSp nvarchar (255)  = null ,

	@MaLoaiSp varchar (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_LoaiSP]
	, [id_LoaiSPCha]
	, [TenLoaiSP]
	, [MaLoaiSP]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_LoaiSP]
    WHERE 
	 ([id_LoaiSP] = @IdLoaiSp OR @IdLoaiSp is null)
	AND ([id_LoaiSPCha] = @IdLoaiSpCha OR @IdLoaiSpCha is null)
	AND ([TenLoaiSP] = @TenLoaiSp OR @TenLoaiSp is null)
	AND ([MaLoaiSP] = @MaLoaiSp OR @MaLoaiSp is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_LoaiSP]
	, [id_LoaiSPCha]
	, [TenLoaiSP]
	, [MaLoaiSP]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_LoaiSP]
    WHERE 
	 ([id_LoaiSP] = @IdLoaiSp AND @IdLoaiSp is not null)
	OR ([id_LoaiSPCha] = @IdLoaiSpCha AND @IdLoaiSpCha is not null)
	OR ([TenLoaiSP] = @TenLoaiSp AND @TenLoaiSp is not null)
	OR ([MaLoaiSP] = @MaLoaiSp AND @MaLoaiSp is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_ThanhPho table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_Get_List

AS


				
				SELECT
					[id_ThanhPho],
					[id_QuocGia],
					[TenTP],
					[MaTP],
					[Mota],
					[Flag]
				FROM
					[dbo].[tbl_ThanhPho]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_ThanhPho table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_ThanhPho] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_ThanhPho])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_ThanhPho]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThanhPho]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_ThanhPho], O.[id_QuocGia], O.[TenTP], O.[MaTP], O.[Mota], O.[Flag]
				FROM
				    [dbo].[tbl_ThanhPho] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_ThanhPho] = PageIndex.[id_ThanhPho]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThanhPho]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_ThanhPho table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_Insert
(

	@IdThanhPho bigint   ,

	@IdQuocGia bigint   ,

	@TenTp nvarchar (100)  ,

	@MaTp varchar (50)  ,

	@Mota nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_ThanhPho]
					(
					[id_ThanhPho]
					,[id_QuocGia]
					,[TenTP]
					,[MaTP]
					,[Mota]
					,[Flag]
					)
				VALUES
					(
					@IdThanhPho
					,@IdQuocGia
					,@TenTp
					,@MaTp
					,@Mota
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_ThanhPho table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_Update
(

	@IdThanhPho bigint   ,

	@OriginalIdThanhPho bigint   ,

	@IdQuocGia bigint   ,

	@TenTp nvarchar (100)  ,

	@MaTp varchar (50)  ,

	@Mota nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_ThanhPho]
				SET
					[id_ThanhPho] = @IdThanhPho
					,[id_QuocGia] = @IdQuocGia
					,[TenTP] = @TenTp
					,[MaTP] = @MaTp
					,[Mota] = @Mota
					,[Flag] = @Flag
				WHERE
[id_ThanhPho] = @OriginalIdThanhPho 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_ThanhPho table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_Delete
(

	@IdThanhPho bigint   
)
AS


				DELETE FROM [dbo].[tbl_ThanhPho] WITH (ROWLOCK) 
				WHERE
					[id_ThanhPho] = @IdThanhPho
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_GetByIdQuocGia procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_GetByIdQuocGia') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_GetByIdQuocGia
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThanhPho table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_GetByIdQuocGia
(

	@IdQuocGia bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_ThanhPho],
					[id_QuocGia],
					[TenTP],
					[MaTP],
					[Mota],
					[Flag]
				FROM
					[dbo].[tbl_ThanhPho]
				WHERE
					[id_QuocGia] = @IdQuocGia
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_GetByIdThanhPho procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_GetByIdThanhPho') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_GetByIdThanhPho
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThanhPho table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_GetByIdThanhPho
(

	@IdThanhPho bigint   
)
AS


				SELECT
					[id_ThanhPho],
					[id_QuocGia],
					[TenTP],
					[MaTP],
					[Mota],
					[Flag]
				FROM
					[dbo].[tbl_ThanhPho]
				WHERE
					[id_ThanhPho] = @IdThanhPho
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThanhPho_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThanhPho_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThanhPho_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_ThanhPho table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThanhPho_Find
(

	@SearchUsingOR bit   = null ,

	@IdThanhPho bigint   = null ,

	@IdQuocGia bigint   = null ,

	@TenTp nvarchar (100)  = null ,

	@MaTp varchar (50)  = null ,

	@Mota nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_ThanhPho]
	, [id_QuocGia]
	, [TenTP]
	, [MaTP]
	, [Mota]
	, [Flag]
    FROM
	[dbo].[tbl_ThanhPho]
    WHERE 
	 ([id_ThanhPho] = @IdThanhPho OR @IdThanhPho is null)
	AND ([id_QuocGia] = @IdQuocGia OR @IdQuocGia is null)
	AND ([TenTP] = @TenTp OR @TenTp is null)
	AND ([MaTP] = @MaTp OR @MaTp is null)
	AND ([Mota] = @Mota OR @Mota is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_ThanhPho]
	, [id_QuocGia]
	, [TenTP]
	, [MaTP]
	, [Mota]
	, [Flag]
    FROM
	[dbo].[tbl_ThanhPho]
    WHERE 
	 ([id_ThanhPho] = @IdThanhPho AND @IdThanhPho is not null)
	OR ([id_QuocGia] = @IdQuocGia AND @IdQuocGia is not null)
	OR ([TenTP] = @TenTp AND @TenTp is not null)
	OR ([MaTP] = @MaTp AND @MaTp is not null)
	OR ([Mota] = @Mota AND @Mota is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_ThuocTinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_Get_List

AS


				
				SELECT
					[id_ThuocTinh],
					[TenThuocTinh],
					[MaThuocTinh],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinh]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_ThuocTinh table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_ThuocTinh] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_ThuocTinh])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_ThuocTinh]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThuocTinh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_ThuocTinh], O.[TenThuocTinh], O.[MaThuocTinh], O.[Flag]
				FROM
				    [dbo].[tbl_ThuocTinh] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_ThuocTinh] = PageIndex.[id_ThuocTinh]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThuocTinh]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_ThuocTinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_Insert
(

	@IdThuocTinh bigint   ,

	@TenThuocTinh nvarchar (50)  ,

	@MaThuocTinh varchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_ThuocTinh]
					(
					[id_ThuocTinh]
					,[TenThuocTinh]
					,[MaThuocTinh]
					,[Flag]
					)
				VALUES
					(
					@IdThuocTinh
					,@TenThuocTinh
					,@MaThuocTinh
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_ThuocTinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_Update
(

	@IdThuocTinh bigint   ,

	@OriginalIdThuocTinh bigint   ,

	@TenThuocTinh nvarchar (50)  ,

	@MaThuocTinh varchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_ThuocTinh]
				SET
					[id_ThuocTinh] = @IdThuocTinh
					,[TenThuocTinh] = @TenThuocTinh
					,[MaThuocTinh] = @MaThuocTinh
					,[Flag] = @Flag
				WHERE
[id_ThuocTinh] = @OriginalIdThuocTinh 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_ThuocTinh table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_Delete
(

	@IdThuocTinh bigint   
)
AS


				DELETE FROM [dbo].[tbl_ThuocTinh] WITH (ROWLOCK) 
				WHERE
					[id_ThuocTinh] = @IdThuocTinh
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_GetByIdThuocTinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_GetByIdThuocTinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_GetByIdThuocTinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThuocTinh table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_GetByIdThuocTinh
(

	@IdThuocTinh bigint   
)
AS


				SELECT
					[id_ThuocTinh],
					[TenThuocTinh],
					[MaThuocTinh],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinh]
				WHERE
					[id_ThuocTinh] = @IdThuocTinh
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinh_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinh_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinh_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_ThuocTinh table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinh_Find
(

	@SearchUsingOR bit   = null ,

	@IdThuocTinh bigint   = null ,

	@TenThuocTinh nvarchar (50)  = null ,

	@MaThuocTinh varchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_ThuocTinh]
	, [TenThuocTinh]
	, [MaThuocTinh]
	, [Flag]
    FROM
	[dbo].[tbl_ThuocTinh]
    WHERE 
	 ([id_ThuocTinh] = @IdThuocTinh OR @IdThuocTinh is null)
	AND ([TenThuocTinh] = @TenThuocTinh OR @TenThuocTinh is null)
	AND ([MaThuocTinh] = @MaThuocTinh OR @MaThuocTinh is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_ThuocTinh]
	, [TenThuocTinh]
	, [MaThuocTinh]
	, [Flag]
    FROM
	[dbo].[tbl_ThuocTinh]
    WHERE 
	 ([id_ThuocTinh] = @IdThuocTinh AND @IdThuocTinh is not null)
	OR ([TenThuocTinh] = @TenThuocTinh AND @TenThuocTinh is not null)
	OR ([MaThuocTinh] = @MaThuocTinh AND @MaThuocTinh is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_TuDien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_Get_List

AS


				
				SELECT
					[id_TuDien],
					[id_DanhMuc],
					[TenTu],
					[MaTu],
					[NhomTu],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_TuDien]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_TuDien table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_TuDien] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_TuDien])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_TuDien]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_TuDien]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_TuDien], O.[id_DanhMuc], O.[TenTu], O.[MaTu], O.[NhomTu], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_TuDien] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_TuDien] = PageIndex.[id_TuDien]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_TuDien]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_TuDien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_Insert
(

	@IdTuDien bigint   ,

	@IdDanhMuc bigint   ,

	@TenTu nvarchar (50)  ,

	@MaTu nchar (10)  ,

	@NhomTu varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_TuDien]
					(
					[id_TuDien]
					,[id_DanhMuc]
					,[TenTu]
					,[MaTu]
					,[NhomTu]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdTuDien
					,@IdDanhMuc
					,@TenTu
					,@MaTu
					,@NhomTu
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_TuDien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_Update
(

	@IdTuDien bigint   ,

	@OriginalIdTuDien bigint   ,

	@IdDanhMuc bigint   ,

	@TenTu nvarchar (50)  ,

	@MaTu nchar (10)  ,

	@NhomTu varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_TuDien]
				SET
					[id_TuDien] = @IdTuDien
					,[id_DanhMuc] = @IdDanhMuc
					,[TenTu] = @TenTu
					,[MaTu] = @MaTu
					,[NhomTu] = @NhomTu
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_TuDien] = @OriginalIdTuDien 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_TuDien table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_Delete
(

	@IdTuDien bigint   
)
AS


				DELETE FROM [dbo].[tbl_TuDien] WITH (ROWLOCK) 
				WHERE
					[id_TuDien] = @IdTuDien
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_GetByIdTuDien procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_GetByIdTuDien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_GetByIdTuDien
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_TuDien table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_GetByIdTuDien
(

	@IdTuDien bigint   
)
AS


				SELECT
					[id_TuDien],
					[id_DanhMuc],
					[TenTu],
					[MaTu],
					[NhomTu],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_TuDien]
				WHERE
					[id_TuDien] = @IdTuDien
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TuDien_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TuDien_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TuDien_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_TuDien table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TuDien_Find
(

	@SearchUsingOR bit   = null ,

	@IdTuDien bigint   = null ,

	@IdDanhMuc bigint   = null ,

	@TenTu nvarchar (50)  = null ,

	@MaTu nchar (10)  = null ,

	@NhomTu varchar (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_TuDien]
	, [id_DanhMuc]
	, [TenTu]
	, [MaTu]
	, [NhomTu]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_TuDien]
    WHERE 
	 ([id_TuDien] = @IdTuDien OR @IdTuDien is null)
	AND ([id_DanhMuc] = @IdDanhMuc OR @IdDanhMuc is null)
	AND ([TenTu] = @TenTu OR @TenTu is null)
	AND ([MaTu] = @MaTu OR @MaTu is null)
	AND ([NhomTu] = @NhomTu OR @NhomTu is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_TuDien]
	, [id_DanhMuc]
	, [TenTu]
	, [MaTu]
	, [NhomTu]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_TuDien]
    WHERE 
	 ([id_TuDien] = @IdTuDien AND @IdTuDien is not null)
	OR ([id_DanhMuc] = @IdDanhMuc AND @IdDanhMuc is not null)
	OR ([TenTu] = @TenTu AND @TenTu is not null)
	OR ([MaTu] = @MaTu AND @MaTu is not null)
	OR ([NhomTu] = @NhomTu AND @NhomTu is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Quan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_Get_List

AS


				
				SELECT
					[id_Quan],
					[id_ThanhPho],
					[TenQuan],
					[MaQuan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Quan]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Quan table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Quan] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Quan])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Quan]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Quan]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Quan], O.[id_ThanhPho], O.[TenQuan], O.[MaQuan], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_Quan] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Quan] = PageIndex.[id_Quan]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Quan]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Quan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_Insert
(

	@IdQuan bigint   ,

	@IdThanhPho bigint   ,

	@TenQuan nvarchar (50)  ,

	@MaQuan varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Quan]
					(
					[id_Quan]
					,[id_ThanhPho]
					,[TenQuan]
					,[MaQuan]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdQuan
					,@IdThanhPho
					,@TenQuan
					,@MaQuan
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Quan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_Update
(

	@IdQuan bigint   ,

	@OriginalIdQuan bigint   ,

	@IdThanhPho bigint   ,

	@TenQuan nvarchar (50)  ,

	@MaQuan varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Quan]
				SET
					[id_Quan] = @IdQuan
					,[id_ThanhPho] = @IdThanhPho
					,[TenQuan] = @TenQuan
					,[MaQuan] = @MaQuan
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_Quan] = @OriginalIdQuan 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Quan table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_Delete
(

	@IdQuan bigint   
)
AS


				DELETE FROM [dbo].[tbl_Quan] WITH (ROWLOCK) 
				WHERE
					[id_Quan] = @IdQuan
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_GetByIdThanhPho procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_GetByIdThanhPho') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_GetByIdThanhPho
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Quan table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_GetByIdThanhPho
(

	@IdThanhPho bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_Quan],
					[id_ThanhPho],
					[TenQuan],
					[MaQuan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Quan]
				WHERE
					[id_ThanhPho] = @IdThanhPho
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_GetByIdQuan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_GetByIdQuan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_GetByIdQuan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Quan table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_GetByIdQuan
(

	@IdQuan bigint   
)
AS


				SELECT
					[id_Quan],
					[id_ThanhPho],
					[TenQuan],
					[MaQuan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Quan]
				WHERE
					[id_Quan] = @IdQuan
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Quan_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Quan_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Quan_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Quan table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Quan_Find
(

	@SearchUsingOR bit   = null ,

	@IdQuan bigint   = null ,

	@IdThanhPho bigint   = null ,

	@TenQuan nvarchar (50)  = null ,

	@MaQuan varchar (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Quan]
	, [id_ThanhPho]
	, [TenQuan]
	, [MaQuan]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Quan]
    WHERE 
	 ([id_Quan] = @IdQuan OR @IdQuan is null)
	AND ([id_ThanhPho] = @IdThanhPho OR @IdThanhPho is null)
	AND ([TenQuan] = @TenQuan OR @TenQuan is null)
	AND ([MaQuan] = @MaQuan OR @MaQuan is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Quan]
	, [id_ThanhPho]
	, [TenQuan]
	, [MaQuan]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Quan]
    WHERE 
	 ([id_Quan] = @IdQuan AND @IdQuan is not null)
	OR ([id_ThanhPho] = @IdThanhPho AND @IdThanhPho is not null)
	OR ([TenQuan] = @TenQuan AND @TenQuan is not null)
	OR ([MaQuan] = @MaQuan AND @MaQuan is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_TinTuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_Get_List

AS


				
				SELECT
					[id_TinTuc],
					[id_CongTy],
					[TieuDe],
					[MoTaNgan],
					[MoTaChiTiet],
					[KhuyenMai],
					[Flag]
				FROM
					[dbo].[tbl_TinTuc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_TinTuc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_TinTuc] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_TinTuc])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_TinTuc]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_TinTuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_TinTuc], O.[id_CongTy], O.[TieuDe], O.[MoTaNgan], O.[MoTaChiTiet], O.[KhuyenMai], O.[Flag]
				FROM
				    [dbo].[tbl_TinTuc] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_TinTuc] = PageIndex.[id_TinTuc]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_TinTuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_TinTuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_Insert
(

	@IdTinTuc bigint   ,

	@IdCongTy bigint   ,

	@TieuDe nvarchar (200)  ,

	@MoTaNgan nvarchar (500)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@KhuyenMai bit   ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_TinTuc]
					(
					[id_TinTuc]
					,[id_CongTy]
					,[TieuDe]
					,[MoTaNgan]
					,[MoTaChiTiet]
					,[KhuyenMai]
					,[Flag]
					)
				VALUES
					(
					@IdTinTuc
					,@IdCongTy
					,@TieuDe
					,@MoTaNgan
					,@MoTaChiTiet
					,@KhuyenMai
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_TinTuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_Update
(

	@IdTinTuc bigint   ,

	@OriginalIdTinTuc bigint   ,

	@IdCongTy bigint   ,

	@TieuDe nvarchar (200)  ,

	@MoTaNgan nvarchar (500)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@KhuyenMai bit   ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_TinTuc]
				SET
					[id_TinTuc] = @IdTinTuc
					,[id_CongTy] = @IdCongTy
					,[TieuDe] = @TieuDe
					,[MoTaNgan] = @MoTaNgan
					,[MoTaChiTiet] = @MoTaChiTiet
					,[KhuyenMai] = @KhuyenMai
					,[Flag] = @Flag
				WHERE
[id_TinTuc] = @OriginalIdTinTuc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_TinTuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_Delete
(

	@IdTinTuc bigint   
)
AS


				DELETE FROM [dbo].[tbl_TinTuc] WITH (ROWLOCK) 
				WHERE
					[id_TinTuc] = @IdTinTuc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_GetByIdCongTy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_GetByIdCongTy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_GetByIdCongTy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_TinTuc table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_GetByIdCongTy
(

	@IdCongTy bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_TinTuc],
					[id_CongTy],
					[TieuDe],
					[MoTaNgan],
					[MoTaChiTiet],
					[KhuyenMai],
					[Flag]
				FROM
					[dbo].[tbl_TinTuc]
				WHERE
					[id_CongTy] = @IdCongTy
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_GetByIdTinTuc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_GetByIdTinTuc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_GetByIdTinTuc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_TinTuc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_GetByIdTinTuc
(

	@IdTinTuc bigint   
)
AS


				SELECT
					[id_TinTuc],
					[id_CongTy],
					[TieuDe],
					[MoTaNgan],
					[MoTaChiTiet],
					[KhuyenMai],
					[Flag]
				FROM
					[dbo].[tbl_TinTuc]
				WHERE
					[id_TinTuc] = @IdTinTuc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_TinTuc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_TinTuc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_TinTuc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_TinTuc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_TinTuc_Find
(

	@SearchUsingOR bit   = null ,

	@IdTinTuc bigint   = null ,

	@IdCongTy bigint   = null ,

	@TieuDe nvarchar (200)  = null ,

	@MoTaNgan nvarchar (500)  = null ,

	@MoTaChiTiet nvarchar (MAX)  = null ,

	@KhuyenMai bit   = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_TinTuc]
	, [id_CongTy]
	, [TieuDe]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [KhuyenMai]
	, [Flag]
    FROM
	[dbo].[tbl_TinTuc]
    WHERE 
	 ([id_TinTuc] = @IdTinTuc OR @IdTinTuc is null)
	AND ([id_CongTy] = @IdCongTy OR @IdCongTy is null)
	AND ([TieuDe] = @TieuDe OR @TieuDe is null)
	AND ([MoTaNgan] = @MoTaNgan OR @MoTaNgan is null)
	AND ([MoTaChiTiet] = @MoTaChiTiet OR @MoTaChiTiet is null)
	AND ([KhuyenMai] = @KhuyenMai OR @KhuyenMai is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_TinTuc]
	, [id_CongTy]
	, [TieuDe]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [KhuyenMai]
	, [Flag]
    FROM
	[dbo].[tbl_TinTuc]
    WHERE 
	 ([id_TinTuc] = @IdTinTuc AND @IdTinTuc is not null)
	OR ([id_CongTy] = @IdCongTy AND @IdCongTy is not null)
	OR ([TieuDe] = @TieuDe AND @TieuDe is not null)
	OR ([MoTaNgan] = @MoTaNgan AND @MoTaNgan is not null)
	OR ([MoTaChiTiet] = @MoTaChiTiet AND @MoTaChiTiet is not null)
	OR ([KhuyenMai] = @KhuyenMai AND @KhuyenMai is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_ThuocTinhSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_Get_List

AS


				
				SELECT
					[id_TTSP],
					[id_SanPham],
					[id_ThuocTinh],
					[Value1],
					[Value2],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinhSanPham]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_ThuocTinhSanPham table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_TTSP] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_TTSP])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_TTSP]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThuocTinhSanPham]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_TTSP], O.[id_SanPham], O.[id_ThuocTinh], O.[Value1], O.[Value2], O.[Flag]
				FROM
				    [dbo].[tbl_ThuocTinhSanPham] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_TTSP] = PageIndex.[id_TTSP]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ThuocTinhSanPham]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_ThuocTinhSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_Insert
(

	@IdTtsp bigint   ,

	@IdSanPham bigint   ,

	@IdThuocTinh bigint   ,

	@Value1 nvarchar (255)  ,

	@Value2 nvarchar (255)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_ThuocTinhSanPham]
					(
					[id_TTSP]
					,[id_SanPham]
					,[id_ThuocTinh]
					,[Value1]
					,[Value2]
					,[Flag]
					)
				VALUES
					(
					@IdTtsp
					,@IdSanPham
					,@IdThuocTinh
					,@Value1
					,@Value2
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_ThuocTinhSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_Update
(

	@IdTtsp bigint   ,

	@OriginalIdTtsp bigint   ,

	@IdSanPham bigint   ,

	@IdThuocTinh bigint   ,

	@Value1 nvarchar (255)  ,

	@Value2 nvarchar (255)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_ThuocTinhSanPham]
				SET
					[id_TTSP] = @IdTtsp
					,[id_SanPham] = @IdSanPham
					,[id_ThuocTinh] = @IdThuocTinh
					,[Value1] = @Value1
					,[Value2] = @Value2
					,[Flag] = @Flag
				WHERE
[id_TTSP] = @OriginalIdTtsp 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_ThuocTinhSanPham table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_Delete
(

	@IdTtsp bigint   
)
AS


				DELETE FROM [dbo].[tbl_ThuocTinhSanPham] WITH (ROWLOCK) 
				WHERE
					[id_TTSP] = @IdTtsp
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_GetByIdThuocTinh procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_GetByIdThuocTinh') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdThuocTinh
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThuocTinhSanPham table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdThuocTinh
(

	@IdThuocTinh bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_TTSP],
					[id_SanPham],
					[id_ThuocTinh],
					[Value1],
					[Value2],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinhSanPham]
				WHERE
					[id_ThuocTinh] = @IdThuocTinh
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_GetByIdSanPham procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_GetByIdSanPham') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdSanPham
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThuocTinhSanPham table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdSanPham
(

	@IdSanPham bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_TTSP],
					[id_SanPham],
					[id_ThuocTinh],
					[Value1],
					[Value2],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinhSanPham]
				WHERE
					[id_SanPham] = @IdSanPham
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_GetByIdTtsp procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_GetByIdTtsp') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdTtsp
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ThuocTinhSanPham table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_GetByIdTtsp
(

	@IdTtsp bigint   
)
AS


				SELECT
					[id_TTSP],
					[id_SanPham],
					[id_ThuocTinh],
					[Value1],
					[Value2],
					[Flag]
				FROM
					[dbo].[tbl_ThuocTinhSanPham]
				WHERE
					[id_TTSP] = @IdTtsp
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ThuocTinhSanPham_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ThuocTinhSanPham_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ThuocTinhSanPham_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_ThuocTinhSanPham table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ThuocTinhSanPham_Find
(

	@SearchUsingOR bit   = null ,

	@IdTtsp bigint   = null ,

	@IdSanPham bigint   = null ,

	@IdThuocTinh bigint   = null ,

	@Value1 nvarchar (255)  = null ,

	@Value2 nvarchar (255)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_TTSP]
	, [id_SanPham]
	, [id_ThuocTinh]
	, [Value1]
	, [Value2]
	, [Flag]
    FROM
	[dbo].[tbl_ThuocTinhSanPham]
    WHERE 
	 ([id_TTSP] = @IdTtsp OR @IdTtsp is null)
	AND ([id_SanPham] = @IdSanPham OR @IdSanPham is null)
	AND ([id_ThuocTinh] = @IdThuocTinh OR @IdThuocTinh is null)
	AND ([Value1] = @Value1 OR @Value1 is null)
	AND ([Value2] = @Value2 OR @Value2 is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_TTSP]
	, [id_SanPham]
	, [id_ThuocTinh]
	, [Value1]
	, [Value2]
	, [Flag]
    FROM
	[dbo].[tbl_ThuocTinhSanPham]
    WHERE 
	 ([id_TTSP] = @IdTtsp AND @IdTtsp is not null)
	OR ([id_SanPham] = @IdSanPham AND @IdSanPham is not null)
	OR ([id_ThuocTinh] = @IdThuocTinh AND @IdThuocTinh is not null)
	OR ([Value1] = @Value1 AND @Value1 is not null)
	OR ([Value2] = @Value2 AND @Value2 is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Language table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_Get_List

AS


				
				SELECT
					[id_Language],
					[TenNN],
					[MaNN],
					[Mota],
					[Flag]
				FROM
					[dbo].[tbl_Language]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Language table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Language] int 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Language])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Language]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Language]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Language], O.[TenNN], O.[MaNN], O.[Mota], O.[Flag]
				FROM
				    [dbo].[tbl_Language] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Language] = PageIndex.[id_Language]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Language]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Language table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_Insert
(

	@IdLanguage int   ,

	@TenNn varchar (50)  ,

	@MaNn varchar (50)  ,

	@Mota varbinary (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Language]
					(
					[id_Language]
					,[TenNN]
					,[MaNN]
					,[Mota]
					,[Flag]
					)
				VALUES
					(
					@IdLanguage
					,@TenNn
					,@MaNn
					,@Mota
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Language table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_Update
(

	@IdLanguage int   ,

	@OriginalIdLanguage int   ,

	@TenNn varchar (50)  ,

	@MaNn varchar (50)  ,

	@Mota varbinary (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Language]
				SET
					[id_Language] = @IdLanguage
					,[TenNN] = @TenNn
					,[MaNN] = @MaNn
					,[Mota] = @Mota
					,[Flag] = @Flag
				WHERE
[id_Language] = @OriginalIdLanguage 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Language table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_Delete
(

	@IdLanguage int   
)
AS


				DELETE FROM [dbo].[tbl_Language] WITH (ROWLOCK) 
				WHERE
					[id_Language] = @IdLanguage
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_GetByIdLanguage procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_GetByIdLanguage') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_GetByIdLanguage
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Language table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_GetByIdLanguage
(

	@IdLanguage int   
)
AS


				SELECT
					[id_Language],
					[TenNN],
					[MaNN],
					[Mota],
					[Flag]
				FROM
					[dbo].[tbl_Language]
				WHERE
					[id_Language] = @IdLanguage
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Language_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Language_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Language_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Language table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Language_Find
(

	@SearchUsingOR bit   = null ,

	@IdLanguage int   = null ,

	@TenNn varchar (50)  = null ,

	@MaNn varchar (50)  = null ,

	@Mota varbinary (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Language]
	, [TenNN]
	, [MaNN]
	, [Mota]
	, [Flag]
    FROM
	[dbo].[tbl_Language]
    WHERE 
	 ([id_Language] = @IdLanguage OR @IdLanguage is null)
	AND ([TenNN] = @TenNn OR @TenNn is null)
	AND ([MaNN] = @MaNn OR @MaNn is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Language]
	, [TenNN]
	, [MaNN]
	, [Mota]
	, [Flag]
    FROM
	[dbo].[tbl_Language]
    WHERE 
	 ([id_Language] = @IdLanguage AND @IdLanguage is not null)
	OR ([TenNN] = @TenNn AND @TenNn is not null)
	OR ([MaNN] = @MaNn AND @MaNn is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_LabelNN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_Get_List

AS


				
				SELECT
					[id_Label],
					[MaLabel],
					[TenLabel],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_LabelNN]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_LabelNN table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Label] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Label])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Label]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LabelNN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Label], O.[MaLabel], O.[TenLabel], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_LabelNN] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Label] = PageIndex.[id_Label]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LabelNN]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_LabelNN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_Insert
(

	@IdLabel bigint   ,

	@MaLabel varchar (50)  ,

	@TenLabel varchar (50)  ,

	@MoTa varchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_LabelNN]
					(
					[id_Label]
					,[MaLabel]
					,[TenLabel]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdLabel
					,@MaLabel
					,@TenLabel
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_LabelNN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_Update
(

	@IdLabel bigint   ,

	@OriginalIdLabel bigint   ,

	@MaLabel varchar (50)  ,

	@TenLabel varchar (50)  ,

	@MoTa varchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_LabelNN]
				SET
					[id_Label] = @IdLabel
					,[MaLabel] = @MaLabel
					,[TenLabel] = @TenLabel
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_Label] = @OriginalIdLabel 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_LabelNN table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_Delete
(

	@IdLabel bigint   
)
AS


				DELETE FROM [dbo].[tbl_LabelNN] WITH (ROWLOCK) 
				WHERE
					[id_Label] = @IdLabel
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_GetByIdLabel procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_GetByIdLabel') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_GetByIdLabel
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_LabelNN table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_GetByIdLabel
(

	@IdLabel bigint   
)
AS


				SELECT
					[id_Label],
					[MaLabel],
					[TenLabel],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_LabelNN]
				WHERE
					[id_Label] = @IdLabel
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelNN_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelNN_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelNN_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_LabelNN table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelNN_Find
(

	@SearchUsingOR bit   = null ,

	@IdLabel bigint   = null ,

	@MaLabel varchar (50)  = null ,

	@TenLabel varchar (50)  = null ,

	@MoTa varchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Label]
	, [MaLabel]
	, [TenLabel]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_LabelNN]
    WHERE 
	 ([id_Label] = @IdLabel OR @IdLabel is null)
	AND ([MaLabel] = @MaLabel OR @MaLabel is null)
	AND ([TenLabel] = @TenLabel OR @TenLabel is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Label]
	, [MaLabel]
	, [TenLabel]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_LabelNN]
    WHERE 
	 ([id_Label] = @IdLabel AND @IdLabel is not null)
	OR ([MaLabel] = @MaLabel AND @MaLabel is not null)
	OR ([TenLabel] = @TenLabel AND @TenLabel is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_DanhMuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_Get_List

AS


				
				SELECT
					[id_DanhMuc],
					[id_DMCha],
					[TenDanhMuc],
					[MaDanhMuc],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_DanhMuc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_DanhMuc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_DanhMuc] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_DanhMuc])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_DanhMuc]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_DanhMuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_DanhMuc], O.[id_DMCha], O.[TenDanhMuc], O.[MaDanhMuc], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_DanhMuc] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_DanhMuc] = PageIndex.[id_DanhMuc]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_DanhMuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_DanhMuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_Insert
(

	@IdDanhMuc bigint   ,

	@IdDmCha bigint   ,

	@TenDanhMuc nvarchar (50)  ,

	@MaDanhMuc varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_DanhMuc]
					(
					[id_DanhMuc]
					,[id_DMCha]
					,[TenDanhMuc]
					,[MaDanhMuc]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdDanhMuc
					,@IdDmCha
					,@TenDanhMuc
					,@MaDanhMuc
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_DanhMuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_Update
(

	@IdDanhMuc bigint   ,

	@OriginalIdDanhMuc bigint   ,

	@IdDmCha bigint   ,

	@TenDanhMuc nvarchar (50)  ,

	@MaDanhMuc varchar (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_DanhMuc]
				SET
					[id_DanhMuc] = @IdDanhMuc
					,[id_DMCha] = @IdDmCha
					,[TenDanhMuc] = @TenDanhMuc
					,[MaDanhMuc] = @MaDanhMuc
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_DanhMuc] = @OriginalIdDanhMuc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_DanhMuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_Delete
(

	@IdDanhMuc bigint   
)
AS


				DELETE FROM [dbo].[tbl_DanhMuc] WITH (ROWLOCK) 
				WHERE
					[id_DanhMuc] = @IdDanhMuc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_GetByIdDanhMuc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_GetByIdDanhMuc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_GetByIdDanhMuc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_DanhMuc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_GetByIdDanhMuc
(

	@IdDanhMuc bigint   
)
AS


				SELECT
					[id_DanhMuc],
					[id_DMCha],
					[TenDanhMuc],
					[MaDanhMuc],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_DanhMuc]
				WHERE
					[id_DanhMuc] = @IdDanhMuc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DanhMuc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DanhMuc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DanhMuc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_DanhMuc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DanhMuc_Find
(

	@SearchUsingOR bit   = null ,

	@IdDanhMuc bigint   = null ,

	@IdDmCha bigint   = null ,

	@TenDanhMuc nvarchar (50)  = null ,

	@MaDanhMuc varchar (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_DanhMuc]
	, [id_DMCha]
	, [TenDanhMuc]
	, [MaDanhMuc]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_DanhMuc]
    WHERE 
	 ([id_DanhMuc] = @IdDanhMuc OR @IdDanhMuc is null)
	AND ([id_DMCha] = @IdDmCha OR @IdDmCha is null)
	AND ([TenDanhMuc] = @TenDanhMuc OR @TenDanhMuc is null)
	AND ([MaDanhMuc] = @MaDanhMuc OR @MaDanhMuc is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_DanhMuc]
	, [id_DMCha]
	, [TenDanhMuc]
	, [MaDanhMuc]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_DanhMuc]
    WHERE 
	 ([id_DanhMuc] = @IdDanhMuc AND @IdDanhMuc is not null)
	OR ([id_DMCha] = @IdDmCha AND @IdDmCha is not null)
	OR ([TenDanhMuc] = @TenDanhMuc AND @TenDanhMuc is not null)
	OR ([MaDanhMuc] = @MaDanhMuc AND @MaDanhMuc is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_ChuCongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_Get_List

AS


				
				SELECT
					[id_ChuCongTy],
					[TenChuCongTy],
					[TenCongTy],
					[TenDangNhap],
					[Password],
					[DiaChi],
					[DienThoaiCD],
					[DienThoaiDD],
					[NgayTao],
					[NgayKetThuc],
					[Flag]
				FROM
					[dbo].[tbl_ChuCongTy]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_ChuCongTy table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_ChuCongTy] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_ChuCongTy])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_ChuCongTy]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ChuCongTy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_ChuCongTy], O.[TenChuCongTy], O.[TenCongTy], O.[TenDangNhap], O.[Password], O.[DiaChi], O.[DienThoaiCD], O.[DienThoaiDD], O.[NgayTao], O.[NgayKetThuc], O.[Flag]
				FROM
				    [dbo].[tbl_ChuCongTy] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_ChuCongTy] = PageIndex.[id_ChuCongTy]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_ChuCongTy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_ChuCongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_Insert
(

	@IdChuCongTy bigint   ,

	@TenChuCongTy nvarchar (200)  ,

	@TenCongTy nvarchar (200)  ,

	@TenDangNhap varchar (50)  ,

	@Password nvarchar (50)  ,

	@DiaChi nvarchar (255)  ,

	@DienThoaiCd varchar (50)  ,

	@DienThoaiDd varchar (50)  ,

	@NgayTao datetime   ,

	@NgayKetThuc datetime   ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_ChuCongTy]
					(
					[id_ChuCongTy]
					,[TenChuCongTy]
					,[TenCongTy]
					,[TenDangNhap]
					,[Password]
					,[DiaChi]
					,[DienThoaiCD]
					,[DienThoaiDD]
					,[NgayTao]
					,[NgayKetThuc]
					,[Flag]
					)
				VALUES
					(
					@IdChuCongTy
					,@TenChuCongTy
					,@TenCongTy
					,@TenDangNhap
					,@Password
					,@DiaChi
					,@DienThoaiCd
					,@DienThoaiDd
					,@NgayTao
					,@NgayKetThuc
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_ChuCongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_Update
(

	@IdChuCongTy bigint   ,

	@OriginalIdChuCongTy bigint   ,

	@TenChuCongTy nvarchar (200)  ,

	@TenCongTy nvarchar (200)  ,

	@TenDangNhap varchar (50)  ,

	@Password nvarchar (50)  ,

	@DiaChi nvarchar (255)  ,

	@DienThoaiCd varchar (50)  ,

	@DienThoaiDd varchar (50)  ,

	@NgayTao datetime   ,

	@NgayKetThuc datetime   ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_ChuCongTy]
				SET
					[id_ChuCongTy] = @IdChuCongTy
					,[TenChuCongTy] = @TenChuCongTy
					,[TenCongTy] = @TenCongTy
					,[TenDangNhap] = @TenDangNhap
					,[Password] = @Password
					,[DiaChi] = @DiaChi
					,[DienThoaiCD] = @DienThoaiCd
					,[DienThoaiDD] = @DienThoaiDd
					,[NgayTao] = @NgayTao
					,[NgayKetThuc] = @NgayKetThuc
					,[Flag] = @Flag
				WHERE
[id_ChuCongTy] = @OriginalIdChuCongTy 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_ChuCongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_Delete
(

	@IdChuCongTy bigint   
)
AS


				DELETE FROM [dbo].[tbl_ChuCongTy] WITH (ROWLOCK) 
				WHERE
					[id_ChuCongTy] = @IdChuCongTy
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_GetByIdChuCongTy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_GetByIdChuCongTy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_GetByIdChuCongTy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_ChuCongTy table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_GetByIdChuCongTy
(

	@IdChuCongTy bigint   
)
AS


				SELECT
					[id_ChuCongTy],
					[TenChuCongTy],
					[TenCongTy],
					[TenDangNhap],
					[Password],
					[DiaChi],
					[DienThoaiCD],
					[DienThoaiDD],
					[NgayTao],
					[NgayKetThuc],
					[Flag]
				FROM
					[dbo].[tbl_ChuCongTy]
				WHERE
					[id_ChuCongTy] = @IdChuCongTy
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_ChuCongTy_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_ChuCongTy_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_ChuCongTy_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_ChuCongTy table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_ChuCongTy_Find
(

	@SearchUsingOR bit   = null ,

	@IdChuCongTy bigint   = null ,

	@TenChuCongTy nvarchar (200)  = null ,

	@TenCongTy nvarchar (200)  = null ,

	@TenDangNhap varchar (50)  = null ,

	@Password nvarchar (50)  = null ,

	@DiaChi nvarchar (255)  = null ,

	@DienThoaiCd varchar (50)  = null ,

	@DienThoaiDd varchar (50)  = null ,

	@NgayTao datetime   = null ,

	@NgayKetThuc datetime   = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_ChuCongTy]
	, [TenChuCongTy]
	, [TenCongTy]
	, [TenDangNhap]
	, [Password]
	, [DiaChi]
	, [DienThoaiCD]
	, [DienThoaiDD]
	, [NgayTao]
	, [NgayKetThuc]
	, [Flag]
    FROM
	[dbo].[tbl_ChuCongTy]
    WHERE 
	 ([id_ChuCongTy] = @IdChuCongTy OR @IdChuCongTy is null)
	AND ([TenChuCongTy] = @TenChuCongTy OR @TenChuCongTy is null)
	AND ([TenCongTy] = @TenCongTy OR @TenCongTy is null)
	AND ([TenDangNhap] = @TenDangNhap OR @TenDangNhap is null)
	AND ([Password] = @Password OR @Password is null)
	AND ([DiaChi] = @DiaChi OR @DiaChi is null)
	AND ([DienThoaiCD] = @DienThoaiCd OR @DienThoaiCd is null)
	AND ([DienThoaiDD] = @DienThoaiDd OR @DienThoaiDd is null)
	AND ([NgayTao] = @NgayTao OR @NgayTao is null)
	AND ([NgayKetThuc] = @NgayKetThuc OR @NgayKetThuc is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_ChuCongTy]
	, [TenChuCongTy]
	, [TenCongTy]
	, [TenDangNhap]
	, [Password]
	, [DiaChi]
	, [DienThoaiCD]
	, [DienThoaiDD]
	, [NgayTao]
	, [NgayKetThuc]
	, [Flag]
    FROM
	[dbo].[tbl_ChuCongTy]
    WHERE 
	 ([id_ChuCongTy] = @IdChuCongTy AND @IdChuCongTy is not null)
	OR ([TenChuCongTy] = @TenChuCongTy AND @TenChuCongTy is not null)
	OR ([TenCongTy] = @TenCongTy AND @TenCongTy is not null)
	OR ([TenDangNhap] = @TenDangNhap AND @TenDangNhap is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([DiaChi] = @DiaChi AND @DiaChi is not null)
	OR ([DienThoaiCD] = @DienThoaiCd AND @DienThoaiCd is not null)
	OR ([DienThoaiDD] = @DienThoaiDd AND @DienThoaiDd is not null)
	OR ([NgayTao] = @NgayTao AND @NgayTao is not null)
	OR ([NgayKetThuc] = @NgayKetThuc AND @NgayKetThuc is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_CongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_Get_List

AS


				
				SELECT
					[id_CongTy],
					[id_ChuCongTy],
					[id_DanhMuc],
					[id_QuocGia],
					[id_ThanhPho],
					[id_Quan],
					[id_Duong],
					[id_KhuVuc],
					[SoNha],
					[DienThoaiCD],
					[DienThoaiDD],
					[Fax],
					[Email],
					[Website],
					[HinhThucTT],
					[ThoiGianPV],
					[AnhMinhHoa],
					[GhiChu],
					[MoTaNgan],
					[MoTaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_CongTy]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_CongTy table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_CongTy] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_CongTy])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_CongTy]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_CongTy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_CongTy], O.[id_ChuCongTy], O.[id_DanhMuc], O.[id_QuocGia], O.[id_ThanhPho], O.[id_Quan], O.[id_Duong], O.[id_KhuVuc], O.[SoNha], O.[DienThoaiCD], O.[DienThoaiDD], O.[Fax], O.[Email], O.[Website], O.[HinhThucTT], O.[ThoiGianPV], O.[AnhMinhHoa], O.[GhiChu], O.[MoTaNgan], O.[MoTaChiTiet], O.[Flag]
				FROM
				    [dbo].[tbl_CongTy] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_CongTy] = PageIndex.[id_CongTy]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_CongTy]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_CongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_Insert
(

	@IdCongTy bigint   ,

	@IdChuCongTy bigint   ,

	@IdDanhMuc bigint   ,

	@IdQuocGia bigint   ,

	@IdThanhPho bigint   ,

	@IdQuan bigint   ,

	@IdDuong bigint   ,

	@IdKhuVuc bigint   ,

	@SoNha varchar (10)  ,

	@DienThoaiCd varchar (50)  ,

	@DienThoaiDd varchar (50)  ,

	@Fax varchar (50)  ,

	@Email varchar (50)  ,

	@Website varchar (50)  ,

	@HinhThucTt varchar (50)  ,

	@ThoiGianPv varchar (50)  ,

	@AnhMinhHoa varchar (500)  ,

	@GhiChu nvarchar (1000)  ,

	@MoTaNgan nvarchar (500)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_CongTy]
					(
					[id_CongTy]
					,[id_ChuCongTy]
					,[id_DanhMuc]
					,[id_QuocGia]
					,[id_ThanhPho]
					,[id_Quan]
					,[id_Duong]
					,[id_KhuVuc]
					,[SoNha]
					,[DienThoaiCD]
					,[DienThoaiDD]
					,[Fax]
					,[Email]
					,[Website]
					,[HinhThucTT]
					,[ThoiGianPV]
					,[AnhMinhHoa]
					,[GhiChu]
					,[MoTaNgan]
					,[MoTaChiTiet]
					,[Flag]
					)
				VALUES
					(
					@IdCongTy
					,@IdChuCongTy
					,@IdDanhMuc
					,@IdQuocGia
					,@IdThanhPho
					,@IdQuan
					,@IdDuong
					,@IdKhuVuc
					,@SoNha
					,@DienThoaiCd
					,@DienThoaiDd
					,@Fax
					,@Email
					,@Website
					,@HinhThucTt
					,@ThoiGianPv
					,@AnhMinhHoa
					,@GhiChu
					,@MoTaNgan
					,@MoTaChiTiet
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_CongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_Update
(

	@IdCongTy bigint   ,

	@OriginalIdCongTy bigint   ,

	@IdChuCongTy bigint   ,

	@IdDanhMuc bigint   ,

	@IdQuocGia bigint   ,

	@IdThanhPho bigint   ,

	@IdQuan bigint   ,

	@IdDuong bigint   ,

	@IdKhuVuc bigint   ,

	@SoNha varchar (10)  ,

	@DienThoaiCd varchar (50)  ,

	@DienThoaiDd varchar (50)  ,

	@Fax varchar (50)  ,

	@Email varchar (50)  ,

	@Website varchar (50)  ,

	@HinhThucTt varchar (50)  ,

	@ThoiGianPv varchar (50)  ,

	@AnhMinhHoa varchar (500)  ,

	@GhiChu nvarchar (1000)  ,

	@MoTaNgan nvarchar (500)  ,

	@MoTaChiTiet nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_CongTy]
				SET
					[id_CongTy] = @IdCongTy
					,[id_ChuCongTy] = @IdChuCongTy
					,[id_DanhMuc] = @IdDanhMuc
					,[id_QuocGia] = @IdQuocGia
					,[id_ThanhPho] = @IdThanhPho
					,[id_Quan] = @IdQuan
					,[id_Duong] = @IdDuong
					,[id_KhuVuc] = @IdKhuVuc
					,[SoNha] = @SoNha
					,[DienThoaiCD] = @DienThoaiCd
					,[DienThoaiDD] = @DienThoaiDd
					,[Fax] = @Fax
					,[Email] = @Email
					,[Website] = @Website
					,[HinhThucTT] = @HinhThucTt
					,[ThoiGianPV] = @ThoiGianPv
					,[AnhMinhHoa] = @AnhMinhHoa
					,[GhiChu] = @GhiChu
					,[MoTaNgan] = @MoTaNgan
					,[MoTaChiTiet] = @MoTaChiTiet
					,[Flag] = @Flag
				WHERE
[id_CongTy] = @OriginalIdCongTy 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_CongTy table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_Delete
(

	@IdCongTy bigint   
)
AS


				DELETE FROM [dbo].[tbl_CongTy] WITH (ROWLOCK) 
				WHERE
					[id_CongTy] = @IdCongTy
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_GetByIdChuCongTy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_GetByIdChuCongTy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_GetByIdChuCongTy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_CongTy table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_GetByIdChuCongTy
(

	@IdChuCongTy bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_CongTy],
					[id_ChuCongTy],
					[id_DanhMuc],
					[id_QuocGia],
					[id_ThanhPho],
					[id_Quan],
					[id_Duong],
					[id_KhuVuc],
					[SoNha],
					[DienThoaiCD],
					[DienThoaiDD],
					[Fax],
					[Email],
					[Website],
					[HinhThucTT],
					[ThoiGianPV],
					[AnhMinhHoa],
					[GhiChu],
					[MoTaNgan],
					[MoTaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_CongTy]
				WHERE
					[id_ChuCongTy] = @IdChuCongTy
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_GetByIdDanhMuc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_GetByIdDanhMuc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_GetByIdDanhMuc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_CongTy table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_GetByIdDanhMuc
(

	@IdDanhMuc bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_CongTy],
					[id_ChuCongTy],
					[id_DanhMuc],
					[id_QuocGia],
					[id_ThanhPho],
					[id_Quan],
					[id_Duong],
					[id_KhuVuc],
					[SoNha],
					[DienThoaiCD],
					[DienThoaiDD],
					[Fax],
					[Email],
					[Website],
					[HinhThucTT],
					[ThoiGianPV],
					[AnhMinhHoa],
					[GhiChu],
					[MoTaNgan],
					[MoTaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_CongTy]
				WHERE
					[id_DanhMuc] = @IdDanhMuc
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_GetByIdCongTy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_GetByIdCongTy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_GetByIdCongTy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_CongTy table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_GetByIdCongTy
(

	@IdCongTy bigint   
)
AS


				SELECT
					[id_CongTy],
					[id_ChuCongTy],
					[id_DanhMuc],
					[id_QuocGia],
					[id_ThanhPho],
					[id_Quan],
					[id_Duong],
					[id_KhuVuc],
					[SoNha],
					[DienThoaiCD],
					[DienThoaiDD],
					[Fax],
					[Email],
					[Website],
					[HinhThucTT],
					[ThoiGianPV],
					[AnhMinhHoa],
					[GhiChu],
					[MoTaNgan],
					[MoTaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_CongTy]
				WHERE
					[id_CongTy] = @IdCongTy
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_CongTy_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_CongTy_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_CongTy_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_CongTy table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_CongTy_Find
(

	@SearchUsingOR bit   = null ,

	@IdCongTy bigint   = null ,

	@IdChuCongTy bigint   = null ,

	@IdDanhMuc bigint   = null ,

	@IdQuocGia bigint   = null ,

	@IdThanhPho bigint   = null ,

	@IdQuan bigint   = null ,

	@IdDuong bigint   = null ,

	@IdKhuVuc bigint   = null ,

	@SoNha varchar (10)  = null ,

	@DienThoaiCd varchar (50)  = null ,

	@DienThoaiDd varchar (50)  = null ,

	@Fax varchar (50)  = null ,

	@Email varchar (50)  = null ,

	@Website varchar (50)  = null ,

	@HinhThucTt varchar (50)  = null ,

	@ThoiGianPv varchar (50)  = null ,

	@AnhMinhHoa varchar (500)  = null ,

	@GhiChu nvarchar (1000)  = null ,

	@MoTaNgan nvarchar (500)  = null ,

	@MoTaChiTiet nvarchar (MAX)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_CongTy]
	, [id_ChuCongTy]
	, [id_DanhMuc]
	, [id_QuocGia]
	, [id_ThanhPho]
	, [id_Quan]
	, [id_Duong]
	, [id_KhuVuc]
	, [SoNha]
	, [DienThoaiCD]
	, [DienThoaiDD]
	, [Fax]
	, [Email]
	, [Website]
	, [HinhThucTT]
	, [ThoiGianPV]
	, [AnhMinhHoa]
	, [GhiChu]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [Flag]
    FROM
	[dbo].[tbl_CongTy]
    WHERE 
	 ([id_CongTy] = @IdCongTy OR @IdCongTy is null)
	AND ([id_ChuCongTy] = @IdChuCongTy OR @IdChuCongTy is null)
	AND ([id_DanhMuc] = @IdDanhMuc OR @IdDanhMuc is null)
	AND ([id_QuocGia] = @IdQuocGia OR @IdQuocGia is null)
	AND ([id_ThanhPho] = @IdThanhPho OR @IdThanhPho is null)
	AND ([id_Quan] = @IdQuan OR @IdQuan is null)
	AND ([id_Duong] = @IdDuong OR @IdDuong is null)
	AND ([id_KhuVuc] = @IdKhuVuc OR @IdKhuVuc is null)
	AND ([SoNha] = @SoNha OR @SoNha is null)
	AND ([DienThoaiCD] = @DienThoaiCd OR @DienThoaiCd is null)
	AND ([DienThoaiDD] = @DienThoaiDd OR @DienThoaiDd is null)
	AND ([Fax] = @Fax OR @Fax is null)
	AND ([Email] = @Email OR @Email is null)
	AND ([Website] = @Website OR @Website is null)
	AND ([HinhThucTT] = @HinhThucTt OR @HinhThucTt is null)
	AND ([ThoiGianPV] = @ThoiGianPv OR @ThoiGianPv is null)
	AND ([AnhMinhHoa] = @AnhMinhHoa OR @AnhMinhHoa is null)
	AND ([GhiChu] = @GhiChu OR @GhiChu is null)
	AND ([MoTaNgan] = @MoTaNgan OR @MoTaNgan is null)
	AND ([MoTaChiTiet] = @MoTaChiTiet OR @MoTaChiTiet is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_CongTy]
	, [id_ChuCongTy]
	, [id_DanhMuc]
	, [id_QuocGia]
	, [id_ThanhPho]
	, [id_Quan]
	, [id_Duong]
	, [id_KhuVuc]
	, [SoNha]
	, [DienThoaiCD]
	, [DienThoaiDD]
	, [Fax]
	, [Email]
	, [Website]
	, [HinhThucTT]
	, [ThoiGianPV]
	, [AnhMinhHoa]
	, [GhiChu]
	, [MoTaNgan]
	, [MoTaChiTiet]
	, [Flag]
    FROM
	[dbo].[tbl_CongTy]
    WHERE 
	 ([id_CongTy] = @IdCongTy AND @IdCongTy is not null)
	OR ([id_ChuCongTy] = @IdChuCongTy AND @IdChuCongTy is not null)
	OR ([id_DanhMuc] = @IdDanhMuc AND @IdDanhMuc is not null)
	OR ([id_QuocGia] = @IdQuocGia AND @IdQuocGia is not null)
	OR ([id_ThanhPho] = @IdThanhPho AND @IdThanhPho is not null)
	OR ([id_Quan] = @IdQuan AND @IdQuan is not null)
	OR ([id_Duong] = @IdDuong AND @IdDuong is not null)
	OR ([id_KhuVuc] = @IdKhuVuc AND @IdKhuVuc is not null)
	OR ([SoNha] = @SoNha AND @SoNha is not null)
	OR ([DienThoaiCD] = @DienThoaiCd AND @DienThoaiCd is not null)
	OR ([DienThoaiDD] = @DienThoaiDd AND @DienThoaiDd is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([HinhThucTT] = @HinhThucTt AND @HinhThucTt is not null)
	OR ([ThoiGianPV] = @ThoiGianPv AND @ThoiGianPv is not null)
	OR ([AnhMinhHoa] = @AnhMinhHoa AND @AnhMinhHoa is not null)
	OR ([GhiChu] = @GhiChu AND @GhiChu is not null)
	OR ([MoTaNgan] = @MoTaNgan AND @MoTaNgan is not null)
	OR ([MoTaChiTiet] = @MoTaChiTiet AND @MoTaChiTiet is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Comment table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_Get_List

AS


				
				SELECT
					[id_Comment],
					[id_User],
					[id_Congty],
					[TieuDe],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_Comment]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Comment table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Comment] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Comment])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Comment]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Comment]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Comment], O.[id_User], O.[id_Congty], O.[TieuDe], O.[NoiDung], O.[Flag]
				FROM
				    [dbo].[tbl_Comment] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Comment] = PageIndex.[id_Comment]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Comment]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Comment table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_Insert
(

	@IdComment bigint   ,

	@IdUser bigint   ,

	@IdCongty bigint   ,

	@TieuDe varchar (50)  ,

	@NoiDung varchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Comment]
					(
					[id_Comment]
					,[id_User]
					,[id_Congty]
					,[TieuDe]
					,[NoiDung]
					,[Flag]
					)
				VALUES
					(
					@IdComment
					,@IdUser
					,@IdCongty
					,@TieuDe
					,@NoiDung
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Comment table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_Update
(

	@IdComment bigint   ,

	@OriginalIdComment bigint   ,

	@IdUser bigint   ,

	@IdCongty bigint   ,

	@TieuDe varchar (50)  ,

	@NoiDung varchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Comment]
				SET
					[id_Comment] = @IdComment
					,[id_User] = @IdUser
					,[id_Congty] = @IdCongty
					,[TieuDe] = @TieuDe
					,[NoiDung] = @NoiDung
					,[Flag] = @Flag
				WHERE
[id_Comment] = @OriginalIdComment 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Comment table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_Delete
(

	@IdComment bigint   
)
AS


				DELETE FROM [dbo].[tbl_Comment] WITH (ROWLOCK) 
				WHERE
					[id_Comment] = @IdComment
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_GetByIdCongty procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_GetByIdCongty') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_GetByIdCongty
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Comment table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_GetByIdCongty
(

	@IdCongty bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_Comment],
					[id_User],
					[id_Congty],
					[TieuDe],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_Comment]
				WHERE
					[id_Congty] = @IdCongty
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_GetByIdUser procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_GetByIdUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_GetByIdUser
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Comment table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_GetByIdUser
(

	@IdUser bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_Comment],
					[id_User],
					[id_Congty],
					[TieuDe],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_Comment]
				WHERE
					[id_User] = @IdUser
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_GetByIdComment procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_GetByIdComment') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_GetByIdComment
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Comment table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_GetByIdComment
(

	@IdComment bigint   
)
AS


				SELECT
					[id_Comment],
					[id_User],
					[id_Congty],
					[TieuDe],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_Comment]
				WHERE
					[id_Comment] = @IdComment
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Comment_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Comment_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Comment_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Comment table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Comment_Find
(

	@SearchUsingOR bit   = null ,

	@IdComment bigint   = null ,

	@IdUser bigint   = null ,

	@IdCongty bigint   = null ,

	@TieuDe varchar (50)  = null ,

	@NoiDung varchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Comment]
	, [id_User]
	, [id_Congty]
	, [TieuDe]
	, [NoiDung]
	, [Flag]
    FROM
	[dbo].[tbl_Comment]
    WHERE 
	 ([id_Comment] = @IdComment OR @IdComment is null)
	AND ([id_User] = @IdUser OR @IdUser is null)
	AND ([id_Congty] = @IdCongty OR @IdCongty is null)
	AND ([TieuDe] = @TieuDe OR @TieuDe is null)
	AND ([NoiDung] = @NoiDung OR @NoiDung is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Comment]
	, [id_User]
	, [id_Congty]
	, [TieuDe]
	, [NoiDung]
	, [Flag]
    FROM
	[dbo].[tbl_Comment]
    WHERE 
	 ([id_Comment] = @IdComment AND @IdComment is not null)
	OR ([id_User] = @IdUser AND @IdUser is not null)
	OR ([id_Congty] = @IdCongty AND @IdCongty is not null)
	OR ([TieuDe] = @TieuDe AND @TieuDe is not null)
	OR ([NoiDung] = @NoiDung AND @NoiDung is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_DichVu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_Get_List

AS


				
				SELECT
					[id_DichVu],
					[id_CongTy],
					[TenDV],
					[MaDV],
					[MotaNgan],
					[MotaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_DichVu]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_DichVu table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_DichVu] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_DichVu])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_DichVu]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_DichVu]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_DichVu], O.[id_CongTy], O.[TenDV], O.[MaDV], O.[MotaNgan], O.[MotaChiTiet], O.[Flag]
				FROM
				    [dbo].[tbl_DichVu] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_DichVu] = PageIndex.[id_DichVu]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_DichVu]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_DichVu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_Insert
(

	@IdDichVu bigint   ,

	@IdCongTy nchar (10)  ,

	@TenDv nvarchar (50)  ,

	@MaDv varchar (50)  ,

	@MotaNgan nvarchar (200)  ,

	@MotaChiTiet nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_DichVu]
					(
					[id_DichVu]
					,[id_CongTy]
					,[TenDV]
					,[MaDV]
					,[MotaNgan]
					,[MotaChiTiet]
					,[Flag]
					)
				VALUES
					(
					@IdDichVu
					,@IdCongTy
					,@TenDv
					,@MaDv
					,@MotaNgan
					,@MotaChiTiet
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_DichVu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_Update
(

	@IdDichVu bigint   ,

	@OriginalIdDichVu bigint   ,

	@IdCongTy nchar (10)  ,

	@TenDv nvarchar (50)  ,

	@MaDv varchar (50)  ,

	@MotaNgan nvarchar (200)  ,

	@MotaChiTiet nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_DichVu]
				SET
					[id_DichVu] = @IdDichVu
					,[id_CongTy] = @IdCongTy
					,[TenDV] = @TenDv
					,[MaDV] = @MaDv
					,[MotaNgan] = @MotaNgan
					,[MotaChiTiet] = @MotaChiTiet
					,[Flag] = @Flag
				WHERE
[id_DichVu] = @OriginalIdDichVu 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_DichVu table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_Delete
(

	@IdDichVu bigint   
)
AS


				DELETE FROM [dbo].[tbl_DichVu] WITH (ROWLOCK) 
				WHERE
					[id_DichVu] = @IdDichVu
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_GetByIdDichVu procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_GetByIdDichVu') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_GetByIdDichVu
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_DichVu table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_GetByIdDichVu
(

	@IdDichVu bigint   
)
AS


				SELECT
					[id_DichVu],
					[id_CongTy],
					[TenDV],
					[MaDV],
					[MotaNgan],
					[MotaChiTiet],
					[Flag]
				FROM
					[dbo].[tbl_DichVu]
				WHERE
					[id_DichVu] = @IdDichVu
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_DichVu_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_DichVu_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_DichVu_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_DichVu table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_DichVu_Find
(

	@SearchUsingOR bit   = null ,

	@IdDichVu bigint   = null ,

	@IdCongTy nchar (10)  = null ,

	@TenDv nvarchar (50)  = null ,

	@MaDv varchar (50)  = null ,

	@MotaNgan nvarchar (200)  = null ,

	@MotaChiTiet nvarchar (MAX)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_DichVu]
	, [id_CongTy]
	, [TenDV]
	, [MaDV]
	, [MotaNgan]
	, [MotaChiTiet]
	, [Flag]
    FROM
	[dbo].[tbl_DichVu]
    WHERE 
	 ([id_DichVu] = @IdDichVu OR @IdDichVu is null)
	AND ([id_CongTy] = @IdCongTy OR @IdCongTy is null)
	AND ([TenDV] = @TenDv OR @TenDv is null)
	AND ([MaDV] = @MaDv OR @MaDv is null)
	AND ([MotaNgan] = @MotaNgan OR @MotaNgan is null)
	AND ([MotaChiTiet] = @MotaChiTiet OR @MotaChiTiet is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_DichVu]
	, [id_CongTy]
	, [TenDV]
	, [MaDV]
	, [MotaNgan]
	, [MotaChiTiet]
	, [Flag]
    FROM
	[dbo].[tbl_DichVu]
    WHERE 
	 ([id_DichVu] = @IdDichVu AND @IdDichVu is not null)
	OR ([id_CongTy] = @IdCongTy AND @IdCongTy is not null)
	OR ([TenDV] = @TenDv AND @TenDv is not null)
	OR ([MaDV] = @MaDv AND @MaDv is not null)
	OR ([MotaNgan] = @MotaNgan AND @MotaNgan is not null)
	OR ([MotaChiTiet] = @MotaChiTiet AND @MotaChiTiet is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_LabelLanguage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_Get_List

AS


				
				SELECT
					[id_LabelLanguage],
					[id_Language],
					[id_Label],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_LabelLanguage]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_LabelLanguage table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_LabelLanguage] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_LabelLanguage])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_LabelLanguage]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LabelLanguage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_LabelLanguage], O.[id_Language], O.[id_Label], O.[NoiDung], O.[Flag]
				FROM
				    [dbo].[tbl_LabelLanguage] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_LabelLanguage] = PageIndex.[id_LabelLanguage]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_LabelLanguage]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_LabelLanguage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_Insert
(

	@IdLabelLanguage bigint   ,

	@IdLanguage int   ,

	@IdLabel bigint   ,

	@NoiDung nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_LabelLanguage]
					(
					[id_LabelLanguage]
					,[id_Language]
					,[id_Label]
					,[NoiDung]
					,[Flag]
					)
				VALUES
					(
					@IdLabelLanguage
					,@IdLanguage
					,@IdLabel
					,@NoiDung
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_LabelLanguage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_Update
(

	@IdLabelLanguage bigint   ,

	@OriginalIdLabelLanguage bigint   ,

	@IdLanguage int   ,

	@IdLabel bigint   ,

	@NoiDung nvarchar (MAX)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_LabelLanguage]
				SET
					[id_LabelLanguage] = @IdLabelLanguage
					,[id_Language] = @IdLanguage
					,[id_Label] = @IdLabel
					,[NoiDung] = @NoiDung
					,[Flag] = @Flag
				WHERE
[id_LabelLanguage] = @OriginalIdLabelLanguage 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_LabelLanguage table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_Delete
(

	@IdLabelLanguage bigint   
)
AS


				DELETE FROM [dbo].[tbl_LabelLanguage] WITH (ROWLOCK) 
				WHERE
					[id_LabelLanguage] = @IdLabelLanguage
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_GetByIdLabel procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_GetByIdLabel') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_GetByIdLabel
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_LabelLanguage table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_GetByIdLabel
(

	@IdLabel bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_LabelLanguage],
					[id_Language],
					[id_Label],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_LabelLanguage]
				WHERE
					[id_Label] = @IdLabel
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_GetByIdLanguage procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_GetByIdLanguage') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_GetByIdLanguage
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_LabelLanguage table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_GetByIdLanguage
(

	@IdLanguage int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_LabelLanguage],
					[id_Language],
					[id_Label],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_LabelLanguage]
				WHERE
					[id_Language] = @IdLanguage
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_GetByIdLabelLanguage procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_GetByIdLabelLanguage') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_GetByIdLabelLanguage
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_LabelLanguage table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_GetByIdLabelLanguage
(

	@IdLabelLanguage bigint   
)
AS


				SELECT
					[id_LabelLanguage],
					[id_Language],
					[id_Label],
					[NoiDung],
					[Flag]
				FROM
					[dbo].[tbl_LabelLanguage]
				WHERE
					[id_LabelLanguage] = @IdLabelLanguage
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_LabelLanguage_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_LabelLanguage_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_LabelLanguage_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_LabelLanguage table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_LabelLanguage_Find
(

	@SearchUsingOR bit   = null ,

	@IdLabelLanguage bigint   = null ,

	@IdLanguage int   = null ,

	@IdLabel bigint   = null ,

	@NoiDung nvarchar (MAX)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_LabelLanguage]
	, [id_Language]
	, [id_Label]
	, [NoiDung]
	, [Flag]
    FROM
	[dbo].[tbl_LabelLanguage]
    WHERE 
	 ([id_LabelLanguage] = @IdLabelLanguage OR @IdLabelLanguage is null)
	AND ([id_Language] = @IdLanguage OR @IdLanguage is null)
	AND ([id_Label] = @IdLabel OR @IdLabel is null)
	AND ([NoiDung] = @NoiDung OR @NoiDung is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_LabelLanguage]
	, [id_Language]
	, [id_Label]
	, [NoiDung]
	, [Flag]
    FROM
	[dbo].[tbl_LabelLanguage]
    WHERE 
	 ([id_LabelLanguage] = @IdLabelLanguage AND @IdLabelLanguage is not null)
	OR ([id_Language] = @IdLanguage AND @IdLanguage is not null)
	OR ([id_Label] = @IdLabel AND @IdLabel is not null)
	OR ([NoiDung] = @NoiDung AND @NoiDung is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Duong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_Get_List

AS


				
				SELECT
					[id_Duong],
					[id_Quan],
					[TenDuong],
					[MaDuong],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Duong]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Duong table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Duong] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Duong])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Duong]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Duong]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Duong], O.[id_Quan], O.[TenDuong], O.[MaDuong], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_Duong] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Duong] = PageIndex.[id_Duong]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Duong]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Duong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_Insert
(

	@IdDuong bigint   ,

	@IdQuan bigint   ,

	@TenDuong nvarchar (50)  ,

	@MaDuong varbinary (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Duong]
					(
					[id_Duong]
					,[id_Quan]
					,[TenDuong]
					,[MaDuong]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdDuong
					,@IdQuan
					,@TenDuong
					,@MaDuong
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Duong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_Update
(

	@IdDuong bigint   ,

	@OriginalIdDuong bigint   ,

	@IdQuan bigint   ,

	@TenDuong nvarchar (50)  ,

	@MaDuong varbinary (50)  ,

	@MoTa nvarchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Duong]
				SET
					[id_Duong] = @IdDuong
					,[id_Quan] = @IdQuan
					,[TenDuong] = @TenDuong
					,[MaDuong] = @MaDuong
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_Duong] = @OriginalIdDuong 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Duong table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_Delete
(

	@IdDuong bigint   
)
AS


				DELETE FROM [dbo].[tbl_Duong] WITH (ROWLOCK) 
				WHERE
					[id_Duong] = @IdDuong
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_GetByIdQuan procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_GetByIdQuan') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_GetByIdQuan
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Duong table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_GetByIdQuan
(

	@IdQuan bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_Duong],
					[id_Quan],
					[TenDuong],
					[MaDuong],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Duong]
				WHERE
					[id_Quan] = @IdQuan
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_GetByIdDuong procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_GetByIdDuong') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_GetByIdDuong
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Duong table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_GetByIdDuong
(

	@IdDuong bigint   
)
AS


				SELECT
					[id_Duong],
					[id_Quan],
					[TenDuong],
					[MaDuong],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Duong]
				WHERE
					[id_Duong] = @IdDuong
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Duong_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Duong_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Duong_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Duong table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Duong_Find
(

	@SearchUsingOR bit   = null ,

	@IdDuong bigint   = null ,

	@IdQuan bigint   = null ,

	@TenDuong nvarchar (50)  = null ,

	@MaDuong varbinary (50)  = null ,

	@MoTa nvarchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Duong]
	, [id_Quan]
	, [TenDuong]
	, [MaDuong]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Duong]
    WHERE 
	 ([id_Duong] = @IdDuong OR @IdDuong is null)
	AND ([id_Quan] = @IdQuan OR @IdQuan is null)
	AND ([TenDuong] = @TenDuong OR @TenDuong is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Duong]
	, [id_Quan]
	, [TenDuong]
	, [MaDuong]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Duong]
    WHERE 
	 ([id_Duong] = @IdDuong AND @IdDuong is not null)
	OR ([id_Quan] = @IdQuan AND @IdQuan is not null)
	OR ([TenDuong] = @TenDuong AND @TenDuong is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_KhuVuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_Get_List

AS


				
				SELECT
					[id_KhuVuc],
					[TenKV],
					[MaKV],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_KhuVuc]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_KhuVuc table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_KhuVuc] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_KhuVuc])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_KhuVuc]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_KhuVuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_KhuVuc], O.[TenKV], O.[MaKV], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_KhuVuc] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_KhuVuc] = PageIndex.[id_KhuVuc]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_KhuVuc]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_KhuVuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_Insert
(

	@IdKhuVuc bigint   ,

	@TenKv nvarchar (255)  ,

	@MaKv varbinary (50)  ,

	@MoTa nvarchar (1000)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_KhuVuc]
					(
					[id_KhuVuc]
					,[TenKV]
					,[MaKV]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdKhuVuc
					,@TenKv
					,@MaKv
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_KhuVuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_Update
(

	@IdKhuVuc bigint   ,

	@OriginalIdKhuVuc bigint   ,

	@TenKv nvarchar (255)  ,

	@MaKv varbinary (50)  ,

	@MoTa nvarchar (1000)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_KhuVuc]
				SET
					[id_KhuVuc] = @IdKhuVuc
					,[TenKV] = @TenKv
					,[MaKV] = @MaKv
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_KhuVuc] = @OriginalIdKhuVuc 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_KhuVuc table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_Delete
(

	@IdKhuVuc bigint   
)
AS


				DELETE FROM [dbo].[tbl_KhuVuc] WITH (ROWLOCK) 
				WHERE
					[id_KhuVuc] = @IdKhuVuc
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_GetByIdKhuVuc procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_GetByIdKhuVuc') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_GetByIdKhuVuc
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_KhuVuc table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_GetByIdKhuVuc
(

	@IdKhuVuc bigint   
)
AS


				SELECT
					[id_KhuVuc],
					[TenKV],
					[MaKV],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_KhuVuc]
				WHERE
					[id_KhuVuc] = @IdKhuVuc
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_KhuVuc_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_KhuVuc_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_KhuVuc_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_KhuVuc table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_KhuVuc_Find
(

	@SearchUsingOR bit   = null ,

	@IdKhuVuc bigint   = null ,

	@TenKv nvarchar (255)  = null ,

	@MaKv varbinary (50)  = null ,

	@MoTa nvarchar (1000)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_KhuVuc]
	, [TenKV]
	, [MaKV]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_KhuVuc]
    WHERE 
	 ([id_KhuVuc] = @IdKhuVuc OR @IdKhuVuc is null)
	AND ([TenKV] = @TenKv OR @TenKv is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_KhuVuc]
	, [TenKV]
	, [MaKV]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_KhuVuc]
    WHERE 
	 ([id_KhuVuc] = @IdKhuVuc AND @IdKhuVuc is not null)
	OR ([TenKV] = @TenKv AND @TenKv is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_Get_List

AS


				
				SELECT
					[id_User],
					[TenDangNhap],
					[Password],
					[HoTen],
					[Email],
					[DiaChi],
					[DienThoai],
					[Website],
					[Avatar],
					[Flag]
				FROM
					[dbo].[tbl_User]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_User table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_User] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_User])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_User]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_User]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_User], O.[TenDangNhap], O.[Password], O.[HoTen], O.[Email], O.[DiaChi], O.[DienThoai], O.[Website], O.[Avatar], O.[Flag]
				FROM
				    [dbo].[tbl_User] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_User] = PageIndex.[id_User]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_User]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_Insert
(

	@IdUser bigint   ,

	@TenDangNhap varbinary (50)  ,

	@Password nvarchar (50)  ,

	@HoTen nvarchar (255)  ,

	@Email nvarchar (50)  ,

	@DiaChi nvarchar (255)  ,

	@DienThoai varbinary (50)  ,

	@Website nvarchar (50)  ,

	@Avatar varchar (500)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_User]
					(
					[id_User]
					,[TenDangNhap]
					,[Password]
					,[HoTen]
					,[Email]
					,[DiaChi]
					,[DienThoai]
					,[Website]
					,[Avatar]
					,[Flag]
					)
				VALUES
					(
					@IdUser
					,@TenDangNhap
					,@Password
					,@HoTen
					,@Email
					,@DiaChi
					,@DienThoai
					,@Website
					,@Avatar
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_Update
(

	@IdUser bigint   ,

	@OriginalIdUser bigint   ,

	@TenDangNhap varbinary (50)  ,

	@Password nvarchar (50)  ,

	@HoTen nvarchar (255)  ,

	@Email nvarchar (50)  ,

	@DiaChi nvarchar (255)  ,

	@DienThoai varbinary (50)  ,

	@Website nvarchar (50)  ,

	@Avatar varchar (500)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_User]
				SET
					[id_User] = @IdUser
					,[TenDangNhap] = @TenDangNhap
					,[Password] = @Password
					,[HoTen] = @HoTen
					,[Email] = @Email
					,[DiaChi] = @DiaChi
					,[DienThoai] = @DienThoai
					,[Website] = @Website
					,[Avatar] = @Avatar
					,[Flag] = @Flag
				WHERE
[id_User] = @OriginalIdUser 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_Delete
(

	@IdUser bigint   
)
AS


				DELETE FROM [dbo].[tbl_User] WITH (ROWLOCK) 
				WHERE
					[id_User] = @IdUser
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_GetByIdUser procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_GetByIdUser') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_GetByIdUser
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_User table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_GetByIdUser
(

	@IdUser bigint   
)
AS


				SELECT
					[id_User],
					[TenDangNhap],
					[Password],
					[HoTen],
					[Email],
					[DiaChi],
					[DienThoai],
					[Website],
					[Avatar],
					[Flag]
				FROM
					[dbo].[tbl_User]
				WHERE
					[id_User] = @IdUser
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_User_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_User_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_User_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_User table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_User_Find
(

	@SearchUsingOR bit   = null ,

	@IdUser bigint   = null ,

	@TenDangNhap varbinary (50)  = null ,

	@Password nvarchar (50)  = null ,

	@HoTen nvarchar (255)  = null ,

	@Email nvarchar (50)  = null ,

	@DiaChi nvarchar (255)  = null ,

	@DienThoai varbinary (50)  = null ,

	@Website nvarchar (50)  = null ,

	@Avatar varchar (500)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_User]
	, [TenDangNhap]
	, [Password]
	, [HoTen]
	, [Email]
	, [DiaChi]
	, [DienThoai]
	, [Website]
	, [Avatar]
	, [Flag]
    FROM
	[dbo].[tbl_User]
    WHERE 
	 ([id_User] = @IdUser OR @IdUser is null)
	AND ([Password] = @Password OR @Password is null)
	AND ([HoTen] = @HoTen OR @HoTen is null)
	AND ([Email] = @Email OR @Email is null)
	AND ([DiaChi] = @DiaChi OR @DiaChi is null)
	AND ([Website] = @Website OR @Website is null)
	AND ([Avatar] = @Avatar OR @Avatar is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_User]
	, [TenDangNhap]
	, [Password]
	, [HoTen]
	, [Email]
	, [DiaChi]
	, [DienThoai]
	, [Website]
	, [Avatar]
	, [Flag]
    FROM
	[dbo].[tbl_User]
    WHERE 
	 ([id_User] = @IdUser AND @IdUser is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([HoTen] = @HoTen AND @HoTen is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([DiaChi] = @DiaChi AND @DiaChi is not null)
	OR ([Website] = @Website AND @Website is not null)
	OR ([Avatar] = @Avatar AND @Avatar is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the tbl_Gallery table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_Get_List

AS


				
				SELECT
					[id_Gallery],
					[id_CongTy],
					[TenAnh],
					[DuongDan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Gallery]
					
				Select @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the tbl_Gallery table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_GetPaged
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				Create Table #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [id_Gallery] bigint 
				)
				
				-- Insert into the temp table
				declare @SQL as nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([id_Gallery])'
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' [id_Gallery]'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Gallery]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Populate the temp table
				exec sp_executesql @SQL

				-- Return paged results
				SELECT O.[id_Gallery], O.[id_CongTy], O.[TenAnh], O.[DuongDan], O.[MoTa], O.[Flag]
				FROM
				    [dbo].[tbl_Gallery] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[id_Gallery] = PageIndex.[id_Gallery]
				ORDER BY
				    PageIndex.IndexId
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[tbl_Gallery]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				exec sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the tbl_Gallery table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_Insert
(

	@IdGallery bigint   ,

	@IdCongTy bigint   ,

	@TenAnh nvarchar (50)  ,

	@DuongDan nvarchar (500)  ,

	@MoTa varchar (50)  ,

	@Flag tinyint   
)
AS


					
				INSERT INTO [dbo].[tbl_Gallery]
					(
					[id_Gallery]
					,[id_CongTy]
					,[TenAnh]
					,[DuongDan]
					,[MoTa]
					,[Flag]
					)
				VALUES
					(
					@IdGallery
					,@IdCongTy
					,@TenAnh
					,@DuongDan
					,@MoTa
					,@Flag
					)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the tbl_Gallery table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_Update
(

	@IdGallery bigint   ,

	@OriginalIdGallery bigint   ,

	@IdCongTy bigint   ,

	@TenAnh nvarchar (50)  ,

	@DuongDan nvarchar (500)  ,

	@MoTa varchar (50)  ,

	@Flag tinyint   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[tbl_Gallery]
				SET
					[id_Gallery] = @IdGallery
					,[id_CongTy] = @IdCongTy
					,[TenAnh] = @TenAnh
					,[DuongDan] = @DuongDan
					,[MoTa] = @MoTa
					,[Flag] = @Flag
				WHERE
[id_Gallery] = @OriginalIdGallery 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the tbl_Gallery table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_Delete
(

	@IdGallery bigint   
)
AS


				DELETE FROM [dbo].[tbl_Gallery] WITH (ROWLOCK) 
				WHERE
					[id_Gallery] = @IdGallery
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_GetByIdCongTy procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_GetByIdCongTy') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_GetByIdCongTy
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Gallery table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_GetByIdCongTy
(

	@IdCongTy bigint   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[id_Gallery],
					[id_CongTy],
					[TenAnh],
					[DuongDan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Gallery]
				WHERE
					[id_CongTy] = @IdCongTy
				
				Select @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_GetByIdGallery procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_GetByIdGallery') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_GetByIdGallery
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the tbl_Gallery table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_GetByIdGallery
(

	@IdGallery bigint   
)
AS


				SELECT
					[id_Gallery],
					[id_CongTy],
					[TenAnh],
					[DuongDan],
					[MoTa],
					[Flag]
				FROM
					[dbo].[tbl_Gallery]
				WHERE
					[id_Gallery] = @IdGallery
			Select @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.tbl_Gallery_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.tbl_Gallery_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.tbl_Gallery_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the tbl_Gallery table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.tbl_Gallery_Find
(

	@SearchUsingOR bit   = null ,

	@IdGallery bigint   = null ,

	@IdCongTy bigint   = null ,

	@TenAnh nvarchar (50)  = null ,

	@DuongDan nvarchar (500)  = null ,

	@MoTa varchar (50)  = null ,

	@Flag tinyint   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [id_Gallery]
	, [id_CongTy]
	, [TenAnh]
	, [DuongDan]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Gallery]
    WHERE 
	 ([id_Gallery] = @IdGallery OR @IdGallery is null)
	AND ([id_CongTy] = @IdCongTy OR @IdCongTy is null)
	AND ([TenAnh] = @TenAnh OR @TenAnh is null)
	AND ([DuongDan] = @DuongDan OR @DuongDan is null)
	AND ([MoTa] = @MoTa OR @MoTa is null)
	AND ([Flag] = @Flag OR @Flag is null)
						
  END
  ELSE
  BEGIN
    SELECT
	  [id_Gallery]
	, [id_CongTy]
	, [TenAnh]
	, [DuongDan]
	, [MoTa]
	, [Flag]
    FROM
	[dbo].[tbl_Gallery]
    WHERE 
	 ([id_Gallery] = @IdGallery AND @IdGallery is not null)
	OR ([id_CongTy] = @IdCongTy AND @IdCongTy is not null)
	OR ([TenAnh] = @TenAnh AND @TenAnh is not null)
	OR ([DuongDan] = @DuongDan AND @DuongDan is not null)
	OR ([MoTa] = @MoTa AND @MoTa is not null)
	OR ([Flag] = @Flag AND @Flag is not null)
	Select @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

