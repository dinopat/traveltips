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
	/// This class is the base class for any <see cref="SanPhamProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SanPhamProviderBaseCore : EntityProviderBase<traveltips.Entities.SanPham, traveltips.Entities.SanPhamKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.SanPhamKey key)
		{
			return Delete(transactionManager, key.IdSanPham);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idSanPham">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idSanPham)
		{
			return Delete(null, idSanPham);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idSanPham);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		FK_tbl_SanPham_tbl_LoaiSP Description: 
		/// </summary>
		/// <param name="idLoaiSp"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		public traveltips.Entities.TList<SanPham> GetByIdLoaiSp(System.Int64? idLoaiSp)
		{
			int count = -1;
			return GetByIdLoaiSp(idLoaiSp, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		FK_tbl_SanPham_tbl_LoaiSP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<SanPham> GetByIdLoaiSp(TransactionManager transactionManager, System.Int64? idLoaiSp)
		{
			int count = -1;
			return GetByIdLoaiSp(transactionManager, idLoaiSp, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		FK_tbl_SanPham_tbl_LoaiSP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		public traveltips.Entities.TList<SanPham> GetByIdLoaiSp(TransactionManager transactionManager, System.Int64? idLoaiSp, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiSp(transactionManager, idLoaiSp, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		fkTblSanPhamTblLoaiSp Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLoaiSp"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		public traveltips.Entities.TList<SanPham> GetByIdLoaiSp(System.Int64? idLoaiSp, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdLoaiSp(null, idLoaiSp, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		fkTblSanPhamTblLoaiSp Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLoaiSp"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		public traveltips.Entities.TList<SanPham> GetByIdLoaiSp(System.Int64? idLoaiSp, int start, int pageLength,out int count)
		{
			return GetByIdLoaiSp(null, idLoaiSp, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_SanPham_tbl_LoaiSP key.
		///		FK_tbl_SanPham_tbl_LoaiSP Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.SanPham objects.</returns>
		public abstract traveltips.Entities.TList<SanPham> GetByIdLoaiSp(TransactionManager transactionManager, System.Int64? idLoaiSp, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.SanPham Get(TransactionManager transactionManager, traveltips.Entities.SanPhamKey key, int start, int pageLength)
		{
			return GetByIdSanPham(transactionManager, key.IdSanPham, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_SanPham index.
		/// </summary>
		/// <param name="idSanPham"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public traveltips.Entities.SanPham GetByIdSanPham(System.Int64 idSanPham)
		{
			int count = -1;
			return GetByIdSanPham(null,idSanPham, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_SanPham index.
		/// </summary>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public traveltips.Entities.SanPham GetByIdSanPham(System.Int64 idSanPham, int start, int pageLength)
		{
			int count = -1;
			return GetByIdSanPham(null, idSanPham, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_SanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public traveltips.Entities.SanPham GetByIdSanPham(TransactionManager transactionManager, System.Int64 idSanPham)
		{
			int count = -1;
			return GetByIdSanPham(transactionManager, idSanPham, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_SanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public traveltips.Entities.SanPham GetByIdSanPham(TransactionManager transactionManager, System.Int64 idSanPham, int start, int pageLength)
		{
			int count = -1;
			return GetByIdSanPham(transactionManager, idSanPham, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_SanPham index.
		/// </summary>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public traveltips.Entities.SanPham GetByIdSanPham(System.Int64 idSanPham, int start, int pageLength, out int count)
		{
			return GetByIdSanPham(null, idSanPham, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_SanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.SanPham"/> class.</returns>
		public abstract traveltips.Entities.SanPham GetByIdSanPham(TransactionManager transactionManager, System.Int64 idSanPham, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;SanPham&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;SanPham&gt;"/></returns>
		public static traveltips.Entities.TList<SanPham> Fill(IDataReader reader, traveltips.Entities.TList<SanPham> rows, int start, int pageLength)
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
			
			traveltips.Entities.SanPham c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("SanPham")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.SanPhamColumn.IdSanPham - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.SanPhamColumn.IdSanPham - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<SanPham>(
			key.ToString(), // EntityTrackingKey
			"SanPham",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.SanPham();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdSanPham = (System.Int64)reader["id_SanPham"];
			c.OriginalIdSanPham = c.IdSanPham;
			c.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			c.IdLoaiSp = reader.IsDBNull(reader.GetOrdinal("id_LoaiSP")) ? null : (System.Int64?)reader["id_LoaiSP"];
			c.IdTuDien = reader.IsDBNull(reader.GetOrdinal("id_TuDien")) ? null : (System.Int64?)reader["id_TuDien"];
			c.TenSp = reader.IsDBNull(reader.GetOrdinal("TenSP")) ? null : (System.String)reader["TenSP"];
			c.MaSp = reader.IsDBNull(reader.GetOrdinal("MaSP")) ? null : (System.String)reader["MaSP"];
			c.Gia = reader.IsDBNull(reader.GetOrdinal("Gia")) ? null : (System.Decimal?)reader["Gia"];
			c.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			c.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			c.AnhMinhHoa = reader.IsDBNull(reader.GetOrdinal("AnhMinhHoa")) ? null : (System.Byte[])reader["AnhMinhHoa"];
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
		/// Refreshes the <see cref="traveltips.Entities.SanPham"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.SanPham"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.SanPham entity)
		{
			if (!reader.Read()) return;
			
			entity.IdSanPham = (System.Int64)reader["id_SanPham"];
			entity.OriginalIdSanPham = (System.Int64)reader["id_SanPham"];
			entity.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			entity.IdLoaiSp = reader.IsDBNull(reader.GetOrdinal("id_LoaiSP")) ? null : (System.Int64?)reader["id_LoaiSP"];
			entity.IdTuDien = reader.IsDBNull(reader.GetOrdinal("id_TuDien")) ? null : (System.Int64?)reader["id_TuDien"];
			entity.TenSp = reader.IsDBNull(reader.GetOrdinal("TenSP")) ? null : (System.String)reader["TenSP"];
			entity.MaSp = reader.IsDBNull(reader.GetOrdinal("MaSP")) ? null : (System.String)reader["MaSP"];
			entity.Gia = reader.IsDBNull(reader.GetOrdinal("Gia")) ? null : (System.Decimal?)reader["Gia"];
			entity.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			entity.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			entity.AnhMinhHoa = reader.IsDBNull(reader.GetOrdinal("AnhMinhHoa")) ? null : (System.Byte[])reader["AnhMinhHoa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.SanPham"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.SanPham"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.SanPham entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdSanPham = (System.Int64)dataRow["id_SanPham"];
			entity.OriginalIdSanPham = (System.Int64)dataRow["id_SanPham"];
			entity.IdCongTy = Convert.IsDBNull(dataRow["id_CongTy"]) ? null : (System.Int64?)dataRow["id_CongTy"];
			entity.IdLoaiSp = Convert.IsDBNull(dataRow["id_LoaiSP"]) ? null : (System.Int64?)dataRow["id_LoaiSP"];
			entity.IdTuDien = Convert.IsDBNull(dataRow["id_TuDien"]) ? null : (System.Int64?)dataRow["id_TuDien"];
			entity.TenSp = Convert.IsDBNull(dataRow["TenSP"]) ? null : (System.String)dataRow["TenSP"];
			entity.MaSp = Convert.IsDBNull(dataRow["MaSP"]) ? null : (System.String)dataRow["MaSP"];
			entity.Gia = Convert.IsDBNull(dataRow["Gia"]) ? null : (System.Decimal?)dataRow["Gia"];
			entity.MoTaNgan = Convert.IsDBNull(dataRow["MoTaNgan"]) ? null : (System.String)dataRow["MoTaNgan"];
			entity.MoTaChiTiet = Convert.IsDBNull(dataRow["MoTaChiTiet"]) ? null : (System.String)dataRow["MoTaChiTiet"];
			entity.AnhMinhHoa = Convert.IsDBNull(dataRow["AnhMinhHoa"]) ? null : (System.Byte[])dataRow["AnhMinhHoa"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.SanPham"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.SanPham Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.SanPham entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdSanPhamSource	
			if (CanDeepLoad(entity, "CongTy|IdSanPhamSource", deepLoadType, innerList) 
				&& entity.IdSanPhamSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdSanPham;
				CongTy tmpEntity = EntityManager.LocateEntity<CongTy>(EntityLocator.ConstructKeyFromPkItems(typeof(CongTy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdSanPhamSource = tmpEntity;
				else
					entity.IdSanPhamSource = DataRepository.CongTyProvider.GetByIdCongTy(transactionManager, entity.IdSanPham);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdSanPhamSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdSanPhamSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CongTyProvider.DeepLoad(transactionManager, entity.IdSanPhamSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdSanPhamSource

			#region IdLoaiSpSource	
			if (CanDeepLoad(entity, "LoaiSp|IdLoaiSpSource", deepLoadType, innerList) 
				&& entity.IdLoaiSpSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdLoaiSp ?? (long)0);
				LoaiSp tmpEntity = EntityManager.LocateEntity<LoaiSp>(EntityLocator.ConstructKeyFromPkItems(typeof(LoaiSp), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdLoaiSpSource = tmpEntity;
				else
					entity.IdLoaiSpSource = DataRepository.LoaiSpProvider.GetByIdLoaiSp(transactionManager, (entity.IdLoaiSp ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdLoaiSpSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdLoaiSpSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LoaiSpProvider.DeepLoad(transactionManager, entity.IdLoaiSpSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdLoaiSpSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdSanPham methods when available
			
			#region ThuocTinhSanPhamCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ThuocTinhSanPham>|ThuocTinhSanPhamCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ThuocTinhSanPhamCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ThuocTinhSanPhamCollection = DataRepository.ThuocTinhSanPhamProvider.GetByIdSanPham(transactionManager, entity.IdSanPham);

				if (deep && entity.ThuocTinhSanPhamCollection.Count > 0)
				{
					deepHandles.Add("ThuocTinhSanPhamCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ThuocTinhSanPham>) DataRepository.ThuocTinhSanPhamProvider.DeepLoad,
						new object[] { transactionManager, entity.ThuocTinhSanPhamCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.SanPham object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.SanPham instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.SanPham Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.SanPham entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdSanPhamSource
			if (CanDeepSave(entity, "CongTy|IdSanPhamSource", deepSaveType, innerList) 
				&& entity.IdSanPhamSource != null)
			{
				DataRepository.CongTyProvider.Save(transactionManager, entity.IdSanPhamSource);
				entity.IdSanPham = entity.IdSanPhamSource.IdCongTy;
			}
			#endregion 
			
			#region IdLoaiSpSource
			if (CanDeepSave(entity, "LoaiSp|IdLoaiSpSource", deepSaveType, innerList) 
				&& entity.IdLoaiSpSource != null)
			{
				DataRepository.LoaiSpProvider.Save(transactionManager, entity.IdLoaiSpSource);
				entity.IdLoaiSp = entity.IdLoaiSpSource.IdLoaiSp;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<ThuocTinhSanPham>
				if (CanDeepSave(entity.ThuocTinhSanPhamCollection, "List<ThuocTinhSanPham>|ThuocTinhSanPhamCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ThuocTinhSanPham child in entity.ThuocTinhSanPhamCollection)
					{
						if(child.IdSanPhamSource != null)
							child.IdSanPham = child.IdSanPhamSource.IdSanPham;
						else
							child.IdSanPham = entity.IdSanPham;

					}

					if (entity.ThuocTinhSanPhamCollection.Count > 0 || entity.ThuocTinhSanPhamCollection.DeletedItems.Count > 0)
					{
						DataRepository.ThuocTinhSanPhamProvider.Save(transactionManager, entity.ThuocTinhSanPhamCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< ThuocTinhSanPham >) DataRepository.ThuocTinhSanPhamProvider.DeepSave,
							new object[] { transactionManager, entity.ThuocTinhSanPhamCollection, deepSaveType, childTypes, innerList }
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
	
	#region SanPhamChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.SanPham</c>
	///</summary>
	public enum SanPhamChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CongTy</c> at IdSanPhamSource
		///</summary>
		[ChildEntityType(typeof(CongTy))]
		CongTy,
			
		///<summary>
		/// Composite Property for <c>LoaiSp</c> at IdLoaiSpSource
		///</summary>
		[ChildEntityType(typeof(LoaiSp))]
		LoaiSp,
	
		///<summary>
		/// Collection of <c>SanPham</c> as OneToMany for ThuocTinhSanPhamCollection
		///</summary>
		[ChildEntityType(typeof(TList<ThuocTinhSanPham>))]
		ThuocTinhSanPhamCollection,
	}
	
	#endregion SanPhamChildEntityTypes
	
	#region SanPhamFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamFilterBuilder : SqlFilterBuilder<SanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamFilterBuilder class.
		/// </summary>
		public SanPhamFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SanPhamFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SanPhamFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SanPhamFilterBuilder
	
	#region SanPhamParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamParameterBuilder : ParameterizedSqlFilterBuilder<SanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamParameterBuilder class.
		/// </summary>
		public SanPhamParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SanPhamParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SanPhamParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SanPhamParameterBuilder
} // end namespace
