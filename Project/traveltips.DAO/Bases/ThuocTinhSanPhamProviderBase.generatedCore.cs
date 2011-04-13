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
	/// This class is the base class for any <see cref="ThuocTinhSanPhamProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ThuocTinhSanPhamProviderBaseCore : EntityProviderBase<traveltips.Entities.ThuocTinhSanPham, traveltips.Entities.ThuocTinhSanPhamKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.ThuocTinhSanPhamKey key)
		{
			return Delete(transactionManager, key.IdTtsp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idTtsp">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idTtsp)
		{
			return Delete(null, idTtsp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTtsp">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idTtsp);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh Description: 
		/// </summary>
		/// <param name="idThuocTinh"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(System.Int64? idThuocTinh)
		{
			int count = -1;
			return GetByIdThuocTinh(idThuocTinh, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(TransactionManager transactionManager, System.Int64? idThuocTinh)
		{
			int count = -1;
			return GetByIdThuocTinh(transactionManager, idThuocTinh, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(TransactionManager transactionManager, System.Int64? idThuocTinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThuocTinh(transactionManager, idThuocTinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		fkTblThuocTinhSanPhamTblThuocTinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idThuocTinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(System.Int64? idThuocTinh, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdThuocTinh(null, idThuocTinh, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		fkTblThuocTinhSanPhamTblThuocTinh Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idThuocTinh"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(System.Int64? idThuocTinh, int start, int pageLength,out int count)
		{
			return GetByIdThuocTinh(null, idThuocTinh, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh key.
		///		FK_tbl_ThuocTinhSanPham_tbl_ThuocTinh Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public abstract traveltips.Entities.TList<ThuocTinhSanPham> GetByIdThuocTinh(TransactionManager transactionManager, System.Int64? idThuocTinh, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		FK_tbl_ThuocTinhSanPham_tbl_SanPham Description: 
		/// </summary>
		/// <param name="idSanPham"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(System.Int64? idSanPham)
		{
			int count = -1;
			return GetByIdSanPham(idSanPham, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		FK_tbl_ThuocTinhSanPham_tbl_SanPham Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(TransactionManager transactionManager, System.Int64? idSanPham)
		{
			int count = -1;
			return GetByIdSanPham(transactionManager, idSanPham, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		FK_tbl_ThuocTinhSanPham_tbl_SanPham Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(TransactionManager transactionManager, System.Int64? idSanPham, int start, int pageLength)
		{
			int count = -1;
			return GetByIdSanPham(transactionManager, idSanPham, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		fkTblThuocTinhSanPhamTblSanPham Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idSanPham"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(System.Int64? idSanPham, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdSanPham(null, idSanPham, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		fkTblThuocTinhSanPhamTblSanPham Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idSanPham"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(System.Int64? idSanPham, int start, int pageLength,out int count)
		{
			return GetByIdSanPham(null, idSanPham, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThuocTinhSanPham_tbl_SanPham key.
		///		FK_tbl_ThuocTinhSanPham_tbl_SanPham Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThuocTinhSanPham objects.</returns>
		public abstract traveltips.Entities.TList<ThuocTinhSanPham> GetByIdSanPham(TransactionManager transactionManager, System.Int64? idSanPham, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.ThuocTinhSanPham Get(TransactionManager transactionManager, traveltips.Entities.ThuocTinhSanPhamKey key, int start, int pageLength)
		{
			return GetByIdTtsp(transactionManager, key.IdTtsp, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="idTtsp"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(System.Int64 idTtsp)
		{
			int count = -1;
			return GetByIdTtsp(null,idTtsp, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="idTtsp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(System.Int64 idTtsp, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTtsp(null, idTtsp, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTtsp"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(TransactionManager transactionManager, System.Int64 idTtsp)
		{
			int count = -1;
			return GetByIdTtsp(transactionManager, idTtsp, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTtsp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(TransactionManager transactionManager, System.Int64 idTtsp, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTtsp(transactionManager, idTtsp, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="idTtsp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(System.Int64 idTtsp, int start, int pageLength, out int count)
		{
			return GetByIdTtsp(null, idTtsp, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinhSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTtsp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinhSanPham"/> class.</returns>
		public abstract traveltips.Entities.ThuocTinhSanPham GetByIdTtsp(TransactionManager transactionManager, System.Int64 idTtsp, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;ThuocTinhSanPham&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;ThuocTinhSanPham&gt;"/></returns>
		public static traveltips.Entities.TList<ThuocTinhSanPham> Fill(IDataReader reader, traveltips.Entities.TList<ThuocTinhSanPham> rows, int start, int pageLength)
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
			
			traveltips.Entities.ThuocTinhSanPham c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ThuocTinhSanPham")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.ThuocTinhSanPhamColumn.IdTtsp - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.ThuocTinhSanPhamColumn.IdTtsp - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ThuocTinhSanPham>(
			key.ToString(), // EntityTrackingKey
			"ThuocTinhSanPham",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.ThuocTinhSanPham();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdTtsp = (System.Int64)reader["id_TTSP"];
			c.OriginalIdTtsp = c.IdTtsp;
			c.IdSanPham = reader.IsDBNull(reader.GetOrdinal("id_SanPham")) ? null : (System.Int64?)reader["id_SanPham"];
			c.IdThuocTinh = reader.IsDBNull(reader.GetOrdinal("id_ThuocTinh")) ? null : (System.Int64?)reader["id_ThuocTinh"];
			c.Value1 = reader.IsDBNull(reader.GetOrdinal("Value1")) ? null : (System.String)reader["Value1"];
			c.Value2 = reader.IsDBNull(reader.GetOrdinal("Value2")) ? null : (System.String)reader["Value2"];
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
		/// Refreshes the <see cref="traveltips.Entities.ThuocTinhSanPham"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinhSanPham"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.ThuocTinhSanPham entity)
		{
			if (!reader.Read()) return;
			
			entity.IdTtsp = (System.Int64)reader["id_TTSP"];
			entity.OriginalIdTtsp = (System.Int64)reader["id_TTSP"];
			entity.IdSanPham = reader.IsDBNull(reader.GetOrdinal("id_SanPham")) ? null : (System.Int64?)reader["id_SanPham"];
			entity.IdThuocTinh = reader.IsDBNull(reader.GetOrdinal("id_ThuocTinh")) ? null : (System.Int64?)reader["id_ThuocTinh"];
			entity.Value1 = reader.IsDBNull(reader.GetOrdinal("Value1")) ? null : (System.String)reader["Value1"];
			entity.Value2 = reader.IsDBNull(reader.GetOrdinal("Value2")) ? null : (System.String)reader["Value2"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.ThuocTinhSanPham"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinhSanPham"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.ThuocTinhSanPham entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdTtsp = (System.Int64)dataRow["id_TTSP"];
			entity.OriginalIdTtsp = (System.Int64)dataRow["id_TTSP"];
			entity.IdSanPham = Convert.IsDBNull(dataRow["id_SanPham"]) ? null : (System.Int64?)dataRow["id_SanPham"];
			entity.IdThuocTinh = Convert.IsDBNull(dataRow["id_ThuocTinh"]) ? null : (System.Int64?)dataRow["id_ThuocTinh"];
			entity.Value1 = Convert.IsDBNull(dataRow["Value1"]) ? null : (System.String)dataRow["Value1"];
			entity.Value2 = Convert.IsDBNull(dataRow["Value2"]) ? null : (System.String)dataRow["Value2"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinhSanPham"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.ThuocTinhSanPham Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.ThuocTinhSanPham entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdThuocTinhSource	
			if (CanDeepLoad(entity, "ThuocTinh|IdThuocTinhSource", deepLoadType, innerList) 
				&& entity.IdThuocTinhSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdThuocTinh ?? (long)0);
				ThuocTinh tmpEntity = EntityManager.LocateEntity<ThuocTinh>(EntityLocator.ConstructKeyFromPkItems(typeof(ThuocTinh), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdThuocTinhSource = tmpEntity;
				else
					entity.IdThuocTinhSource = DataRepository.ThuocTinhProvider.GetByIdThuocTinh(transactionManager, (entity.IdThuocTinh ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdThuocTinhSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdThuocTinhSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ThuocTinhProvider.DeepLoad(transactionManager, entity.IdThuocTinhSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdThuocTinhSource

			#region IdSanPhamSource	
			if (CanDeepLoad(entity, "SanPham|IdSanPhamSource", deepLoadType, innerList) 
				&& entity.IdSanPhamSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdSanPham ?? (long)0);
				SanPham tmpEntity = EntityManager.LocateEntity<SanPham>(EntityLocator.ConstructKeyFromPkItems(typeof(SanPham), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdSanPhamSource = tmpEntity;
				else
					entity.IdSanPhamSource = DataRepository.SanPhamProvider.GetByIdSanPham(transactionManager, (entity.IdSanPham ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdSanPhamSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdSanPhamSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SanPhamProvider.DeepLoad(transactionManager, entity.IdSanPhamSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdSanPhamSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.ThuocTinhSanPham object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.ThuocTinhSanPham instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.ThuocTinhSanPham Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.ThuocTinhSanPham entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdThuocTinhSource
			if (CanDeepSave(entity, "ThuocTinh|IdThuocTinhSource", deepSaveType, innerList) 
				&& entity.IdThuocTinhSource != null)
			{
				DataRepository.ThuocTinhProvider.Save(transactionManager, entity.IdThuocTinhSource);
				entity.IdThuocTinh = entity.IdThuocTinhSource.IdThuocTinh;
			}
			#endregion 
			
			#region IdSanPhamSource
			if (CanDeepSave(entity, "SanPham|IdSanPhamSource", deepSaveType, innerList) 
				&& entity.IdSanPhamSource != null)
			{
				DataRepository.SanPhamProvider.Save(transactionManager, entity.IdSanPhamSource);
				entity.IdSanPham = entity.IdSanPhamSource.IdSanPham;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
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
	
	#region ThuocTinhSanPhamChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.ThuocTinhSanPham</c>
	///</summary>
	public enum ThuocTinhSanPhamChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ThuocTinh</c> at IdThuocTinhSource
		///</summary>
		[ChildEntityType(typeof(ThuocTinh))]
		ThuocTinh,
			
		///<summary>
		/// Composite Property for <c>SanPham</c> at IdSanPhamSource
		///</summary>
		[ChildEntityType(typeof(SanPham))]
		SanPham,
		}
	
	#endregion ThuocTinhSanPhamChildEntityTypes
	
	#region ThuocTinhSanPhamFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ThuocTinhSanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamFilterBuilder : SqlFilterBuilder<ThuocTinhSanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilterBuilder class.
		/// </summary>
		public ThuocTinhSanPhamFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhSanPhamFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhSanPhamFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhSanPhamFilterBuilder
	
	#region ThuocTinhSanPhamParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ThuocTinhSanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamParameterBuilder : ParameterizedSqlFilterBuilder<ThuocTinhSanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamParameterBuilder class.
		/// </summary>
		public ThuocTinhSanPhamParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhSanPhamParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhSanPhamParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhSanPhamParameterBuilder
} // end namespace
