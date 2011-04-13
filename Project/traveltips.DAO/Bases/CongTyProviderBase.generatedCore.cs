#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using traveltips.Entities;
using traveltips.DAO;

#endregion

namespace traveltips.DAO.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CongTyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CongTyProviderBaseCore : EntityProviderBase<traveltips.Entities.CongTy, traveltips.Entities.CongTyKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.CongTyKey key)
		{
			return Delete(transactionManager, key.IdCongTy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idCongTy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idCongTy)
		{
			return Delete(null, idCongTy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idCongTy);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		FK_tbl_CongTy_tbl_ChuCongTy Description: 
		/// </summary>
		/// <param name="idChuCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdChuCongTy(System.Int64? idChuCongTy)
		{
			int count = -1;
			return GetByIdChuCongTy(idChuCongTy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		FK_tbl_CongTy_tbl_ChuCongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<CongTy> GetByIdChuCongTy(TransactionManager transactionManager, System.Int64? idChuCongTy)
		{
			int count = -1;
			return GetByIdChuCongTy(transactionManager, idChuCongTy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		FK_tbl_CongTy_tbl_ChuCongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdChuCongTy(TransactionManager transactionManager, System.Int64? idChuCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdChuCongTy(transactionManager, idChuCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		fkTblCongTyTblChuCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChuCongTy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdChuCongTy(System.Int64? idChuCongTy, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdChuCongTy(null, idChuCongTy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		fkTblCongTyTblChuCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idChuCongTy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdChuCongTy(System.Int64? idChuCongTy, int start, int pageLength,out int count)
		{
			return GetByIdChuCongTy(null, idChuCongTy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_ChuCongTy key.
		///		FK_tbl_CongTy_tbl_ChuCongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public abstract traveltips.Entities.TList<CongTy> GetByIdChuCongTy(TransactionManager transactionManager, System.Int64? idChuCongTy, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		FK_tbl_CongTy_tbl_DanhMuc Description: 
		/// </summary>
		/// <param name="idDanhMuc"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdDanhMuc(System.Int64? idDanhMuc)
		{
			int count = -1;
			return GetByIdDanhMuc(idDanhMuc, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		FK_tbl_CongTy_tbl_DanhMuc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<CongTy> GetByIdDanhMuc(TransactionManager transactionManager, System.Int64? idDanhMuc)
		{
			int count = -1;
			return GetByIdDanhMuc(transactionManager, idDanhMuc, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		FK_tbl_CongTy_tbl_DanhMuc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdDanhMuc(TransactionManager transactionManager, System.Int64? idDanhMuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDanhMuc(transactionManager, idDanhMuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		fkTblCongTyTblDanhMuc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDanhMuc"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdDanhMuc(System.Int64? idDanhMuc, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdDanhMuc(null, idDanhMuc, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		fkTblCongTyTblDanhMuc Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idDanhMuc"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public traveltips.Entities.TList<CongTy> GetByIdDanhMuc(System.Int64? idDanhMuc, int start, int pageLength,out int count)
		{
			return GetByIdDanhMuc(null, idDanhMuc, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_CongTy_tbl_DanhMuc key.
		///		FK_tbl_CongTy_tbl_DanhMuc Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.CongTy objects.</returns>
		public abstract traveltips.Entities.TList<CongTy> GetByIdDanhMuc(TransactionManager transactionManager, System.Int64? idDanhMuc, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override traveltips.Entities.CongTy Get(TransactionManager transactionManager, traveltips.Entities.CongTyKey key, int start, int pageLength)
		{
			return GetByIdCongTy(transactionManager, key.IdCongTy, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_CongTy index.
		/// </summary>
		/// <param name="idCongTy"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public traveltips.Entities.CongTy GetByIdCongTy(System.Int64 idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(null,idCongTy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_CongTy index.
		/// </summary>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public traveltips.Entities.CongTy GetByIdCongTy(System.Int64 idCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCongTy(null, idCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_CongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public traveltips.Entities.CongTy GetByIdCongTy(TransactionManager transactionManager, System.Int64 idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_CongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public traveltips.Entities.CongTy GetByIdCongTy(TransactionManager transactionManager, System.Int64 idCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_CongTy index.
		/// </summary>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public traveltips.Entities.CongTy GetByIdCongTy(System.Int64 idCongTy, int start, int pageLength, out int count)
		{
			return GetByIdCongTy(null, idCongTy, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_CongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.CongTy"/> class.</returns>
		public abstract traveltips.Entities.CongTy GetByIdCongTy(TransactionManager transactionManager, System.Int64 idCongTy, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;CongTy&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;CongTy&gt;"/></returns>
		public static traveltips.Entities.TList<CongTy> Fill(IDataReader reader, traveltips.Entities.TList<CongTy> rows, int start, int pageLength)
		{
		// advance to the starting row
		for (int i = 0; i < start; i++)
		{
			if (!reader.Read())
			return rows; // not enough rows, just return
		}
		for (int i = 0; i < pageLength; i++)
		{
			if (!reader.Read())
			break; // we are done
			string key = null;
			
			traveltips.Entities.CongTy c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("CongTy")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.CongTyColumn.IdCongTy - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.CongTyColumn.IdCongTy - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<CongTy>(
			key.ToString(), // EntityTrackingKey
			"CongTy",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.CongTy();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdCongTy = (System.Int64)reader["id_CongTy"];
			c.OriginalIdCongTy = c.IdCongTy;
			c.IdChuCongTy = reader.IsDBNull(reader.GetOrdinal("id_ChuCongTy")) ? null : (System.Int64?)reader["id_ChuCongTy"];
			c.IdDanhMuc = reader.IsDBNull(reader.GetOrdinal("id_DanhMuc")) ? null : (System.Int64?)reader["id_DanhMuc"];
			c.IdQuocGia = reader.IsDBNull(reader.GetOrdinal("id_QuocGia")) ? null : (System.Int64?)reader["id_QuocGia"];
			c.IdThanhPho = reader.IsDBNull(reader.GetOrdinal("id_ThanhPho")) ? null : (System.Int64?)reader["id_ThanhPho"];
			c.IdQuan = reader.IsDBNull(reader.GetOrdinal("id_Quan")) ? null : (System.Int64?)reader["id_Quan"];
			c.IdDuong = reader.IsDBNull(reader.GetOrdinal("id_Duong")) ? null : (System.Int64?)reader["id_Duong"];
			c.IdKhuVuc = reader.IsDBNull(reader.GetOrdinal("id_KhuVuc")) ? null : (System.Int64?)reader["id_KhuVuc"];
			c.SoNha = reader.IsDBNull(reader.GetOrdinal("SoNha")) ? null : (System.String)reader["SoNha"];
			c.DienThoaiCd = reader.IsDBNull(reader.GetOrdinal("DienThoaiCD")) ? null : (System.String)reader["DienThoaiCD"];
			c.DienThoaiDd = reader.IsDBNull(reader.GetOrdinal("DienThoaiDD")) ? null : (System.String)reader["DienThoaiDD"];
			c.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : (System.String)reader["Fax"];
			c.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			c.Website = reader.IsDBNull(reader.GetOrdinal("Website")) ? null : (System.String)reader["Website"];
			c.HinhThucTt = reader.IsDBNull(reader.GetOrdinal("HinhThucTT")) ? null : (System.String)reader["HinhThucTT"];
			c.ThoiGianPv = reader.IsDBNull(reader.GetOrdinal("ThoiGianPV")) ? null : (System.String)reader["ThoiGianPV"];
			c.AnhMinhHoa = reader.IsDBNull(reader.GetOrdinal("AnhMinhHoa")) ? null : (System.String)reader["AnhMinhHoa"];
			c.GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? null : (System.String)reader["GhiChu"];
			c.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			c.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			c.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			c.EntityTrackingKey = key;
			c.AcceptChanges();
			c.SuppressEntityEvents = false;
			}
			rows.Add(c);
		}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.CongTy"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.CongTy"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.CongTy entity)
		{
			if (!reader.Read()) return;
			
			entity.IdCongTy = (System.Int64)reader["id_CongTy"];
			entity.OriginalIdCongTy = (System.Int64)reader["id_CongTy"];
			entity.IdChuCongTy = reader.IsDBNull(reader.GetOrdinal("id_ChuCongTy")) ? null : (System.Int64?)reader["id_ChuCongTy"];
			entity.IdDanhMuc = reader.IsDBNull(reader.GetOrdinal("id_DanhMuc")) ? null : (System.Int64?)reader["id_DanhMuc"];
			entity.IdQuocGia = reader.IsDBNull(reader.GetOrdinal("id_QuocGia")) ? null : (System.Int64?)reader["id_QuocGia"];
			entity.IdThanhPho = reader.IsDBNull(reader.GetOrdinal("id_ThanhPho")) ? null : (System.Int64?)reader["id_ThanhPho"];
			entity.IdQuan = reader.IsDBNull(reader.GetOrdinal("id_Quan")) ? null : (System.Int64?)reader["id_Quan"];
			entity.IdDuong = reader.IsDBNull(reader.GetOrdinal("id_Duong")) ? null : (System.Int64?)reader["id_Duong"];
			entity.IdKhuVuc = reader.IsDBNull(reader.GetOrdinal("id_KhuVuc")) ? null : (System.Int64?)reader["id_KhuVuc"];
			entity.SoNha = reader.IsDBNull(reader.GetOrdinal("SoNha")) ? null : (System.String)reader["SoNha"];
			entity.DienThoaiCd = reader.IsDBNull(reader.GetOrdinal("DienThoaiCD")) ? null : (System.String)reader["DienThoaiCD"];
			entity.DienThoaiDd = reader.IsDBNull(reader.GetOrdinal("DienThoaiDD")) ? null : (System.String)reader["DienThoaiDD"];
			entity.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : (System.String)reader["Fax"];
			entity.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			entity.Website = reader.IsDBNull(reader.GetOrdinal("Website")) ? null : (System.String)reader["Website"];
			entity.HinhThucTt = reader.IsDBNull(reader.GetOrdinal("HinhThucTT")) ? null : (System.String)reader["HinhThucTT"];
			entity.ThoiGianPv = reader.IsDBNull(reader.GetOrdinal("ThoiGianPV")) ? null : (System.String)reader["ThoiGianPV"];
			entity.AnhMinhHoa = reader.IsDBNull(reader.GetOrdinal("AnhMinhHoa")) ? null : (System.String)reader["AnhMinhHoa"];
			entity.GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? null : (System.String)reader["GhiChu"];
			entity.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			entity.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.CongTy"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.CongTy"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.CongTy entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdCongTy = (System.Int64)dataRow["id_CongTy"];
			entity.OriginalIdCongTy = (System.Int64)dataRow["id_CongTy"];
			entity.IdChuCongTy = Convert.IsDBNull(dataRow["id_ChuCongTy"]) ? null : (System.Int64?)dataRow["id_ChuCongTy"];
			entity.IdDanhMuc = Convert.IsDBNull(dataRow["id_DanhMuc"]) ? null : (System.Int64?)dataRow["id_DanhMuc"];
			entity.IdQuocGia = Convert.IsDBNull(dataRow["id_QuocGia"]) ? null : (System.Int64?)dataRow["id_QuocGia"];
			entity.IdThanhPho = Convert.IsDBNull(dataRow["id_ThanhPho"]) ? null : (System.Int64?)dataRow["id_ThanhPho"];
			entity.IdQuan = Convert.IsDBNull(dataRow["id_Quan"]) ? null : (System.Int64?)dataRow["id_Quan"];
			entity.IdDuong = Convert.IsDBNull(dataRow["id_Duong"]) ? null : (System.Int64?)dataRow["id_Duong"];
			entity.IdKhuVuc = Convert.IsDBNull(dataRow["id_KhuVuc"]) ? null : (System.Int64?)dataRow["id_KhuVuc"];
			entity.SoNha = Convert.IsDBNull(dataRow["SoNha"]) ? null : (System.String)dataRow["SoNha"];
			entity.DienThoaiCd = Convert.IsDBNull(dataRow["DienThoaiCD"]) ? null : (System.String)dataRow["DienThoaiCD"];
			entity.DienThoaiDd = Convert.IsDBNull(dataRow["DienThoaiDD"]) ? null : (System.String)dataRow["DienThoaiDD"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Website = Convert.IsDBNull(dataRow["Website"]) ? null : (System.String)dataRow["Website"];
			entity.HinhThucTt = Convert.IsDBNull(dataRow["HinhThucTT"]) ? null : (System.String)dataRow["HinhThucTT"];
			entity.ThoiGianPv = Convert.IsDBNull(dataRow["ThoiGianPV"]) ? null : (System.String)dataRow["ThoiGianPV"];
			entity.AnhMinhHoa = Convert.IsDBNull(dataRow["AnhMinhHoa"]) ? null : (System.String)dataRow["AnhMinhHoa"];
			entity.GhiChu = Convert.IsDBNull(dataRow["GhiChu"]) ? null : (System.String)dataRow["GhiChu"];
			entity.MoTaNgan = Convert.IsDBNull(dataRow["MoTaNgan"]) ? null : (System.String)dataRow["MoTaNgan"];
			entity.MoTaChiTiet = Convert.IsDBNull(dataRow["MoTaChiTiet"]) ? null : (System.String)dataRow["MoTaChiTiet"];
			entity.Flag = Convert.IsDBNull(dataRow["Flag"]) ? null : (System.Byte?)dataRow["Flag"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="traveltips.Entities.CongTy"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.CongTy Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.CongTy entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdChuCongTySource	
			if (CanDeepLoad(entity, "ChuCongTy|IdChuCongTySource", deepLoadType, innerList) 
				&& entity.IdChuCongTySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdChuCongTy ?? (long)0);
				ChuCongTy tmpEntity = EntityManager.LocateEntity<ChuCongTy>(EntityLocator.ConstructKeyFromPkItems(typeof(ChuCongTy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdChuCongTySource = tmpEntity;
				else
					entity.IdChuCongTySource = DataRepository.ChuCongTyProvider.GetByIdChuCongTy(transactionManager, (entity.IdChuCongTy ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdChuCongTySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdChuCongTySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ChuCongTyProvider.DeepLoad(transactionManager, entity.IdChuCongTySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdChuCongTySource

			#region IdDanhMucSource	
			if (CanDeepLoad(entity, "DanhMuc|IdDanhMucSource", deepLoadType, innerList) 
				&& entity.IdDanhMucSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdDanhMuc ?? (long)0);
				DanhMuc tmpEntity = EntityManager.LocateEntity<DanhMuc>(EntityLocator.ConstructKeyFromPkItems(typeof(DanhMuc), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdDanhMucSource = tmpEntity;
				else
					entity.IdDanhMucSource = DataRepository.DanhMucProvider.GetByIdDanhMuc(transactionManager, (entity.IdDanhMuc ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdDanhMucSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdDanhMucSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DanhMucProvider.DeepLoad(transactionManager, entity.IdDanhMucSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdDanhMucSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdCongTy methods when available
			
			#region GalleryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Gallery>|GalleryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GalleryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.GalleryCollection = DataRepository.GalleryProvider.GetByIdCongTy(transactionManager, entity.IdCongTy);

				if (deep && entity.GalleryCollection.Count > 0)
				{
					deepHandles.Add("GalleryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Gallery>) DataRepository.GalleryProvider.DeepLoad,
						new object[] { transactionManager, entity.GalleryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region TinTucCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<TinTuc>|TinTucCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TinTucCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.TinTucCollection = DataRepository.TinTucProvider.GetByIdCongTy(transactionManager, entity.IdCongTy);

				if (deep && entity.TinTucCollection.Count > 0)
				{
					deepHandles.Add("TinTucCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<TinTuc>) DataRepository.TinTucProvider.DeepLoad,
						new object[] { transactionManager, entity.TinTucCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DichVu
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "DichVu|DichVu", deepLoadType, innerList))
			{
				entity.DichVu = DataRepository.DichVuProvider.GetByIdDichVu(transactionManager, entity.IdCongTy);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DichVu' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.DichVu != null)
				{
					deepHandles.Add("DichVu",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< DichVu >) DataRepository.DichVuProvider.DeepLoad,
						new object[] { transactionManager, entity.DichVu, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region CommentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Comment>|CommentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommentCollection = DataRepository.CommentProvider.GetByIdCongty(transactionManager, entity.IdCongTy);

				if (deep && entity.CommentCollection.Count > 0)
				{
					deepHandles.Add("CommentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Comment>) DataRepository.CommentProvider.DeepLoad,
						new object[] { transactionManager, entity.CommentCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SanPham
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "SanPham|SanPham", deepLoadType, innerList))
			{
				entity.SanPham = DataRepository.SanPhamProvider.GetByIdSanPham(transactionManager, entity.IdCongTy);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SanPham' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.SanPham != null)
				{
					deepHandles.Add("SanPham",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< SanPham >) DataRepository.SanPhamProvider.DeepLoad,
						new object[] { transactionManager, entity.SanPham, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the traveltips.Entities.CongTy object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.CongTy instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.CongTy Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.CongTy entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdChuCongTySource
			if (CanDeepSave(entity, "ChuCongTy|IdChuCongTySource", deepSaveType, innerList) 
				&& entity.IdChuCongTySource != null)
			{
				DataRepository.ChuCongTyProvider.Save(transactionManager, entity.IdChuCongTySource);
				entity.IdChuCongTy = entity.IdChuCongTySource.IdChuCongTy;
			}
			#endregion 
			
			#region IdDanhMucSource
			if (CanDeepSave(entity, "DanhMuc|IdDanhMucSource", deepSaveType, innerList) 
				&& entity.IdDanhMucSource != null)
			{
				DataRepository.DanhMucProvider.Save(transactionManager, entity.IdDanhMucSource);
				entity.IdDanhMuc = entity.IdDanhMucSource.IdDanhMuc;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();

			#region DichVu
			if (CanDeepSave(entity.DichVu, "DichVu|DichVu", deepSaveType, innerList))
			{

				if (entity.DichVu != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.DichVu.IdDichVu = entity.IdCongTy;
					DataRepository.DichVuProvider.Save(transactionManager, entity.DichVu);
					deepHandles.Add(
						(DeepSaveSingleHandle< DichVu >) DataRepository.DichVuProvider.DeepSave,
						new object[] { transactionManager, entity.DichVu, deepSaveType, childTypes, innerList }
					);
				}
			} 
			#endregion 

			#region SanPham
			if (CanDeepSave(entity.SanPham, "SanPham|SanPham", deepSaveType, innerList))
			{

				if (entity.SanPham != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.SanPham.IdSanPham = entity.IdCongTy;
					DataRepository.SanPhamProvider.Save(transactionManager, entity.SanPham);
					deepHandles.Add(
						(DeepSaveSingleHandle< SanPham >) DataRepository.SanPhamProvider.DeepSave,
						new object[] { transactionManager, entity.SanPham, deepSaveType, childTypes, innerList }
					);
				}
			} 
			#endregion 
	
			#region List<Gallery>
				if (CanDeepSave(entity.GalleryCollection, "List<Gallery>|GalleryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Gallery child in entity.GalleryCollection)
					{
						if(child.IdCongTySource != null)
							child.IdCongTy = child.IdCongTySource.IdCongTy;
						else
							child.IdCongTy = entity.IdCongTy;

					}

					if (entity.GalleryCollection.Count > 0 || entity.GalleryCollection.DeletedItems.Count > 0)
					{
						DataRepository.GalleryProvider.Save(transactionManager, entity.GalleryCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Gallery >) DataRepository.GalleryProvider.DeepSave,
							new object[] { transactionManager, entity.GalleryCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<TinTuc>
				if (CanDeepSave(entity.TinTucCollection, "List<TinTuc>|TinTucCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(TinTuc child in entity.TinTucCollection)
					{
						if(child.IdCongTySource != null)
							child.IdCongTy = child.IdCongTySource.IdCongTy;
						else
							child.IdCongTy = entity.IdCongTy;

					}

					if (entity.TinTucCollection.Count > 0 || entity.TinTucCollection.DeletedItems.Count > 0)
					{
						DataRepository.TinTucProvider.Save(transactionManager, entity.TinTucCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< TinTuc >) DataRepository.TinTucProvider.DeepSave,
							new object[] { transactionManager, entity.TinTucCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
	
			#region List<Comment>
				if (CanDeepSave(entity.CommentCollection, "List<Comment>|CommentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Comment child in entity.CommentCollection)
					{
						if(child.IdCongtySource != null)
							child.IdCongty = child.IdCongtySource.IdCongTy;
						else
							child.IdCongty = entity.IdCongTy;

					}

					if (entity.CommentCollection.Count > 0 || entity.CommentCollection.DeletedItems.Count > 0)
					{
						DataRepository.CommentProvider.Save(transactionManager, entity.CommentCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Comment >) DataRepository.CommentProvider.DeepSave,
							new object[] { transactionManager, entity.CommentCollection, deepSaveType, childTypes, innerList }
						);
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region CongTyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.CongTy</c>
	///</summary>
	public enum CongTyChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ChuCongTy</c> at IdChuCongTySource
		///</summary>
		[ChildEntityType(typeof(ChuCongTy))]
		ChuCongTy,
			
		///<summary>
		/// Composite Property for <c>DanhMuc</c> at IdDanhMucSource
		///</summary>
		[ChildEntityType(typeof(DanhMuc))]
		DanhMuc,
	
		///<summary>
		/// Collection of <c>CongTy</c> as OneToMany for GalleryCollection
		///</summary>
		[ChildEntityType(typeof(TList<Gallery>))]
		GalleryCollection,

		///<summary>
		/// Collection of <c>CongTy</c> as OneToMany for TinTucCollection
		///</summary>
		[ChildEntityType(typeof(TList<TinTuc>))]
		TinTucCollection,
		///<summary>
		/// Entity <c>DichVu</c> as OneToOne for DichVu
		///</summary>
		[ChildEntityType(typeof(DichVu))]
		DichVu,

		///<summary>
		/// Collection of <c>CongTy</c> as OneToMany for CommentCollection
		///</summary>
		[ChildEntityType(typeof(TList<Comment>))]
		CommentCollection,
		///<summary>
		/// Entity <c>SanPham</c> as OneToOne for SanPham
		///</summary>
		[ChildEntityType(typeof(SanPham))]
		SanPham,
	}
	
	#endregion CongTyChildEntityTypes
	
	#region CongTyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CongTyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyFilterBuilder : SqlFilterBuilder<CongTyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyFilterBuilder class.
		/// </summary>
		public CongTyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CongTyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CongTyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CongTyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CongTyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CongTyFilterBuilder
	
	#region CongTyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CongTyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyParameterBuilder : ParameterizedSqlFilterBuilder<CongTyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyParameterBuilder class.
		/// </summary>
		public CongTyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CongTyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CongTyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CongTyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CongTyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CongTyParameterBuilder
} // end namespace
