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
	/// This class is the base class for any <see cref="GalleryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GalleryProviderBaseCore : EntityProviderBase<traveltips.Entities.Gallery, traveltips.Entities.GalleryKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.GalleryKey key)
		{
			return Delete(transactionManager, key.IdGallery);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idGallery">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idGallery)
		{
			return Delete(null, idGallery);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGallery">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idGallery);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		FK_tbl_Gallery_tbl_CongTy Description: 
		/// </summary>
		/// <param name="idCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		public traveltips.Entities.TList<Gallery> GetByIdCongTy(System.Int64? idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(idCongTy, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		FK_tbl_Gallery_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<Gallery> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		FK_tbl_Gallery_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		public traveltips.Entities.TList<Gallery> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCongTy(transactionManager, idCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		fkTblGalleryTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongTy"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		public traveltips.Entities.TList<Gallery> GetByIdCongTy(System.Int64? idCongTy, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdCongTy(null, idCongTy, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		fkTblGalleryTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongTy"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		public traveltips.Entities.TList<Gallery> GetByIdCongTy(System.Int64? idCongTy, int start, int pageLength,out int count)
		{
			return GetByIdCongTy(null, idCongTy, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Gallery_tbl_CongTy key.
		///		FK_tbl_Gallery_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.Gallery objects.</returns>
		public abstract traveltips.Entities.TList<Gallery> GetByIdCongTy(TransactionManager transactionManager, System.Int64? idCongTy, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.Gallery Get(TransactionManager transactionManager, traveltips.Entities.GalleryKey key, int start, int pageLength)
		{
			return GetByIdGallery(transactionManager, key.IdGallery, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Gallery index.
		/// </summary>
		/// <param name="idGallery"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public traveltips.Entities.Gallery GetByIdGallery(System.Int64 idGallery)
		{
			int count = -1;
			return GetByIdGallery(null,idGallery, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Gallery index.
		/// </summary>
		/// <param name="idGallery"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public traveltips.Entities.Gallery GetByIdGallery(System.Int64 idGallery, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGallery(null, idGallery, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Gallery index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGallery"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public traveltips.Entities.Gallery GetByIdGallery(TransactionManager transactionManager, System.Int64 idGallery)
		{
			int count = -1;
			return GetByIdGallery(transactionManager, idGallery, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Gallery index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGallery"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public traveltips.Entities.Gallery GetByIdGallery(TransactionManager transactionManager, System.Int64 idGallery, int start, int pageLength)
		{
			int count = -1;
			return GetByIdGallery(transactionManager, idGallery, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Gallery index.
		/// </summary>
		/// <param name="idGallery"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public traveltips.Entities.Gallery GetByIdGallery(System.Int64 idGallery, int start, int pageLength, out int count)
		{
			return GetByIdGallery(null, idGallery, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Gallery index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idGallery"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Gallery"/> class.</returns>
		public abstract traveltips.Entities.Gallery GetByIdGallery(TransactionManager transactionManager, System.Int64 idGallery, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;Gallery&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;Gallery&gt;"/></returns>
		public static traveltips.Entities.TList<Gallery> Fill(IDataReader reader, traveltips.Entities.TList<Gallery> rows, int start, int pageLength)
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
			
			traveltips.Entities.Gallery c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Gallery")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.GalleryColumn.IdGallery - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.GalleryColumn.IdGallery - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Gallery>(
			key.ToString(), // EntityTrackingKey
			"Gallery",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.Gallery();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdGallery = (System.Int64)reader["id_Gallery"];
			c.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			c.TenAnh = reader.IsDBNull(reader.GetOrdinal("TenAnh")) ? null : (System.String)reader["TenAnh"];
			c.DuongDan = reader.IsDBNull(reader.GetOrdinal("DuongDan")) ? null : (System.String)reader["DuongDan"];
			c.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
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
		/// Refreshes the <see cref="traveltips.Entities.Gallery"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Gallery"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.Gallery entity)
		{
			if (!reader.Read()) return;
			
			entity.IdGallery = (System.Int64)reader["id_Gallery"];
			entity.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			entity.TenAnh = reader.IsDBNull(reader.GetOrdinal("TenAnh")) ? null : (System.String)reader["TenAnh"];
			entity.DuongDan = reader.IsDBNull(reader.GetOrdinal("DuongDan")) ? null : (System.String)reader["DuongDan"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.Gallery"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Gallery"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.Gallery entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdGallery = (System.Int64)dataRow["id_Gallery"];
			entity.IdCongTy = Convert.IsDBNull(dataRow["id_CongTy"]) ? null : (System.Int64?)dataRow["id_CongTy"];
			entity.TenAnh = Convert.IsDBNull(dataRow["TenAnh"]) ? null : (System.String)dataRow["TenAnh"];
			entity.DuongDan = Convert.IsDBNull(dataRow["DuongDan"]) ? null : (System.String)dataRow["DuongDan"];
			entity.MoTa = Convert.IsDBNull(dataRow["MoTa"]) ? null : (System.String)dataRow["MoTa"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.Gallery"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.Gallery Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.Gallery entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the traveltips.Entities.Gallery object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.Gallery instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.Gallery Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.Gallery entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region GalleryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.Gallery</c>
	///</summary>
	public enum GalleryChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CongTy</c> at IdCongTySource
		///</summary>
		[ChildEntityType(typeof(CongTy))]
		CongTy,
		}
	
	#endregion GalleryChildEntityTypes
	
	#region GalleryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GalleryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryFilterBuilder : SqlFilterBuilder<GalleryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryFilterBuilder class.
		/// </summary>
		public GalleryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GalleryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GalleryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GalleryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GalleryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GalleryFilterBuilder
	
	#region GalleryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GalleryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryParameterBuilder : ParameterizedSqlFilterBuilder<GalleryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryParameterBuilder class.
		/// </summary>
		public GalleryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GalleryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GalleryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GalleryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GalleryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GalleryParameterBuilder
} // end namespace
