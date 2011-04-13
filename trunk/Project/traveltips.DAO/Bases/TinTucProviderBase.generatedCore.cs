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
	/// This class is the base class for any <see cref="TinTucProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TinTucProviderBaseCore : EntityProviderBase<traveltips.Entities.TinTuc, traveltips.Entities.TinTucKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.TinTucKey key)
		{
			return Delete(transactionManager, key.IdTinTuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idTinTuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idTinTuc)
		{
			return Delete(null, idTinTuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTinTuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idTinTuc);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		FK_tbl_TinTuc_tbl_CongTy Description: 
		/// </summary>
		/// <param name="idCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		public traveltips.Entities.TList<TinTuc> GetByIdCongTy(System.Int64? idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(idCongTy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		FK_tbl_TinTuc_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<TinTuc> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		FK_tbl_TinTuc_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		public traveltips.Entities.TList<TinTuc> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		fkTblTinTucTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongTy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		public traveltips.Entities.TList<TinTuc> GetByIdCongTy(System.Int64? idCongTy, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdCongTy(null, idCongTy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		fkTblTinTucTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongTy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		public traveltips.Entities.TList<TinTuc> GetByIdCongTy(System.Int64? idCongTy, int start, int pageLength,out int count)
		{
			return GetByIdCongTy(null, idCongTy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_TinTuc_tbl_CongTy key.
		///		FK_tbl_TinTuc_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.TinTuc objects.</returns>
		public abstract traveltips.Entities.TList<TinTuc> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.TinTuc Get(TransactionManager transactionManager, traveltips.Entities.TinTucKey key, int start, int pageLength)
		{
			return GetByIdTinTuc(transactionManager, key.IdTinTuc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="idTinTuc"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public traveltips.Entities.TinTuc GetByIdTinTuc(System.Int64 idTinTuc)
		{
			int count = -1;
			return GetByIdTinTuc(null,idTinTuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="idTinTuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public traveltips.Entities.TinTuc GetByIdTinTuc(System.Int64 idTinTuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTinTuc(null, idTinTuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTinTuc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public traveltips.Entities.TinTuc GetByIdTinTuc(TransactionManager transactionManager, System.Int64 idTinTuc)
		{
			int count = -1;
			return GetByIdTinTuc(transactionManager, idTinTuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTinTuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public traveltips.Entities.TinTuc GetByIdTinTuc(TransactionManager transactionManager, System.Int64 idTinTuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTinTuc(transactionManager, idTinTuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="idTinTuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public traveltips.Entities.TinTuc GetByIdTinTuc(System.Int64 idTinTuc, int start, int pageLength, out int count)
		{
			return GetByIdTinTuc(null, idTinTuc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TinTuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTinTuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TinTuc"/> class.</returns>
		public abstract traveltips.Entities.TinTuc GetByIdTinTuc(TransactionManager transactionManager, System.Int64 idTinTuc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;TinTuc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;TinTuc&gt;"/></returns>
		public static traveltips.Entities.TList<TinTuc> Fill(IDataReader reader, traveltips.Entities.TList<TinTuc> rows, int start, int pageLength)
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
			
			traveltips.Entities.TinTuc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("TinTuc")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.TinTucColumn.IdTinTuc - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.TinTucColumn.IdTinTuc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<TinTuc>(
			key.ToString(), // EntityTrackingKey
			"TinTuc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.TinTuc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdTinTuc = (System.Int64)reader["id_TinTuc"];
			c.OriginalIdTinTuc = c.IdTinTuc;
			c.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			c.TieuDe = reader.IsDBNull(reader.GetOrdinal("TieuDe")) ? null : (System.String)reader["TieuDe"];
			c.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			c.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			c.KhuyenMai = reader.IsDBNull(reader.GetOrdinal("KhuyenMai")) ? null : (System.Boolean?)reader["KhuyenMai"];
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
		/// Refreshes the <see cref="traveltips.Entities.TinTuc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.TinTuc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.TinTuc entity)
		{
			if (!reader.Read()) return;
			
			entity.IdTinTuc = (System.Int64)reader["id_TinTuc"];
			entity.OriginalIdTinTuc = (System.Int64)reader["id_TinTuc"];
			entity.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			entity.TieuDe = reader.IsDBNull(reader.GetOrdinal("TieuDe")) ? null : (System.String)reader["TieuDe"];
			entity.MoTaNgan = reader.IsDBNull(reader.GetOrdinal("MoTaNgan")) ? null : (System.String)reader["MoTaNgan"];
			entity.MoTaChiTiet = reader.IsDBNull(reader.GetOrdinal("MoTaChiTiet")) ? null : (System.String)reader["MoTaChiTiet"];
			entity.KhuyenMai = reader.IsDBNull(reader.GetOrdinal("KhuyenMai")) ? null : (System.Boolean?)reader["KhuyenMai"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.TinTuc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.TinTuc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.TinTuc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdTinTuc = (System.Int64)dataRow["id_TinTuc"];
			entity.OriginalIdTinTuc = (System.Int64)dataRow["id_TinTuc"];
			entity.IdCongTy = Convert.IsDBNull(dataRow["id_CongTy"]) ? null : (System.Int64?)dataRow["id_CongTy"];
			entity.TieuDe = Convert.IsDBNull(dataRow["TieuDe"]) ? null : (System.String)dataRow["TieuDe"];
			entity.MoTaNgan = Convert.IsDBNull(dataRow["MoTaNgan"]) ? null : (System.String)dataRow["MoTaNgan"];
			entity.MoTaChiTiet = Convert.IsDBNull(dataRow["MoTaChiTiet"]) ? null : (System.String)dataRow["MoTaChiTiet"];
			entity.KhuyenMai = Convert.IsDBNull(dataRow["KhuyenMai"]) ? null : (System.Boolean?)dataRow["KhuyenMai"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.TinTuc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.TinTuc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.TinTuc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdCongTySource	
			if (CanDeepLoad(entity, "CongTy|IdCongTySource", deepLoadType, innerList) 
				&& entity.IdCongTySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdCongTy ?? (long)0);
				CongTy tmpEntity = EntityManager.LocateEntity<CongTy>(EntityLocator.ConstructKeyFromPkItems(typeof(CongTy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdCongTySource = tmpEntity;
				else
					entity.IdCongTySource = DataRepository.CongTyProvider.GetByIdCongTy(transactionManager, (entity.IdCongTy ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdCongTySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdCongTySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CongTyProvider.DeepLoad(transactionManager, entity.IdCongTySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdCongTySource
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.TinTuc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.TinTuc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.TinTuc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.TinTuc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdCongTySource
			if (CanDeepSave(entity, "CongTy|IdCongTySource", deepSaveType, innerList) 
				&& entity.IdCongTySource != null)
			{
				DataRepository.CongTyProvider.Save(transactionManager, entity.IdCongTySource);
				entity.IdCongTy = entity.IdCongTySource.IdCongTy;
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
	
	#region TinTucChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.TinTuc</c>
	///</summary>
	public enum TinTucChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CongTy</c> at IdCongTySource
		///</summary>
		[ChildEntityType(typeof(CongTy))]
		CongTy,
		}
	
	#endregion TinTucChildEntityTypes
	
	#region TinTucFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TinTucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucFilterBuilder : SqlFilterBuilder<TinTucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucFilterBuilder class.
		/// </summary>
		public TinTucFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TinTucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TinTucFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TinTucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TinTucFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TinTucFilterBuilder
	
	#region TinTucParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TinTucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucParameterBuilder : ParameterizedSqlFilterBuilder<TinTucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucParameterBuilder class.
		/// </summary>
		public TinTucParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TinTucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TinTucParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TinTucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TinTucParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TinTucParameterBuilder
} // end namespace
