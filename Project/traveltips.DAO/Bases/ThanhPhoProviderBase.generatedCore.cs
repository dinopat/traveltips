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
	/// This class is the base class for any <see cref="ThanhPhoProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ThanhPhoProviderBaseCore : EntityProviderBase<traveltips.Entities.ThanhPho, traveltips.Entities.ThanhPhoKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.ThanhPhoKey key)
		{
			return Delete(transactionManager, key.IdThanhPho);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idThanhPho">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idThanhPho)
		{
			return Delete(null, idThanhPho);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idThanhPho);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		FK_tbl_ThanhPho_tbl_QuocGia Description: 
		/// </summary>
		/// <param name="idQuocGia"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		public traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(System.Int64? idQuocGia)
		{
			int count = -1;
			return GetByIdQuocGia(idQuocGia, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		FK_tbl_ThanhPho_tbl_QuocGia Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuocGia"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(TransactionManager transactionManager, System.Int64? idQuocGia)
		{
			int count = -1;
			return GetByIdQuocGia(transactionManager, idQuocGia, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		FK_tbl_ThanhPho_tbl_QuocGia Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuocGia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		public traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(TransactionManager transactionManager, System.Int64? idQuocGia, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuocGia(transactionManager, idQuocGia, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		fkTblThanhPhoTblQuocGia Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuocGia"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		public traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(System.Int64? idQuocGia, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuocGia(null, idQuocGia, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		fkTblThanhPhoTblQuocGia Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuocGia"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		public traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(System.Int64? idQuocGia, int start, int pageLength,out int count)
		{
			return GetByIdQuocGia(null, idQuocGia, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_ThanhPho_tbl_QuocGia key.
		///		FK_tbl_ThanhPho_tbl_QuocGia Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuocGia"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.ThanhPho objects.</returns>
		public abstract traveltips.Entities.TList<ThanhPho> GetByIdQuocGia(TransactionManager transactionManager, System.Int64? idQuocGia, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.ThanhPho Get(TransactionManager transactionManager, traveltips.Entities.ThanhPhoKey key, int start, int pageLength)
		{
			return GetByIdThanhPho(transactionManager, key.IdThanhPho, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="idThanhPho"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public traveltips.Entities.ThanhPho GetByIdThanhPho(System.Int64 idThanhPho)
		{
			int count = -1;
			return GetByIdThanhPho(null,idThanhPho, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public traveltips.Entities.ThanhPho GetByIdThanhPho(System.Int64 idThanhPho, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThanhPho(null, idThanhPho, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public traveltips.Entities.ThanhPho GetByIdThanhPho(TransactionManager transactionManager, System.Int64 idThanhPho)
		{
			int count = -1;
			return GetByIdThanhPho(transactionManager, idThanhPho, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public traveltips.Entities.ThanhPho GetByIdThanhPho(TransactionManager transactionManager, System.Int64 idThanhPho, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThanhPho(transactionManager, idThanhPho, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public traveltips.Entities.ThanhPho GetByIdThanhPho(System.Int64 idThanhPho, int start, int pageLength, out int count)
		{
			return GetByIdThanhPho(null, idThanhPho, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThanhPho index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThanhPho"/> class.</returns>
		public abstract traveltips.Entities.ThanhPho GetByIdThanhPho(TransactionManager transactionManager, System.Int64 idThanhPho, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;ThanhPho&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;ThanhPho&gt;"/></returns>
		public static traveltips.Entities.TList<ThanhPho> Fill(IDataReader reader, traveltips.Entities.TList<ThanhPho> rows, int start, int pageLength)
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
			
			traveltips.Entities.ThanhPho c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ThanhPho")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.ThanhPhoColumn.IdThanhPho - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.ThanhPhoColumn.IdThanhPho - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ThanhPho>(
			key.ToString(), // EntityTrackingKey
			"ThanhPho",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.ThanhPho();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdThanhPho = (System.Int64)reader["id_ThanhPho"];
			c.OriginalIdThanhPho = c.IdThanhPho;
			c.IdQuocGia = reader.IsDBNull(reader.GetOrdinal("id_QuocGia")) ? null : (System.Int64?)reader["id_QuocGia"];
			c.TenTp = reader.IsDBNull(reader.GetOrdinal("TenTP")) ? null : (System.String)reader["TenTP"];
			c.MaTp = reader.IsDBNull(reader.GetOrdinal("MaTP")) ? null : (System.String)reader["MaTP"];
			c.Mota = reader.IsDBNull(reader.GetOrdinal("Mota")) ? null : (System.String)reader["Mota"];
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
		/// Refreshes the <see cref="traveltips.Entities.ThanhPho"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThanhPho"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.ThanhPho entity)
		{
			if (!reader.Read()) return;
			
			entity.IdThanhPho = (System.Int64)reader["id_ThanhPho"];
			entity.OriginalIdThanhPho = (System.Int64)reader["id_ThanhPho"];
			entity.IdQuocGia = reader.IsDBNull(reader.GetOrdinal("id_QuocGia")) ? null : (System.Int64?)reader["id_QuocGia"];
			entity.TenTp = reader.IsDBNull(reader.GetOrdinal("TenTP")) ? null : (System.String)reader["TenTP"];
			entity.MaTp = reader.IsDBNull(reader.GetOrdinal("MaTP")) ? null : (System.String)reader["MaTP"];
			entity.Mota = reader.IsDBNull(reader.GetOrdinal("Mota")) ? null : (System.String)reader["Mota"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.ThanhPho"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThanhPho"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.ThanhPho entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdThanhPho = (System.Int64)dataRow["id_ThanhPho"];
			entity.OriginalIdThanhPho = (System.Int64)dataRow["id_ThanhPho"];
			entity.IdQuocGia = Convert.IsDBNull(dataRow["id_QuocGia"]) ? null : (System.Int64?)dataRow["id_QuocGia"];
			entity.TenTp = Convert.IsDBNull(dataRow["TenTP"]) ? null : (System.String)dataRow["TenTP"];
			entity.MaTp = Convert.IsDBNull(dataRow["MaTP"]) ? null : (System.String)dataRow["MaTP"];
			entity.Mota = Convert.IsDBNull(dataRow["Mota"]) ? null : (System.String)dataRow["Mota"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.ThanhPho"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.ThanhPho Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.ThanhPho entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdQuocGiaSource	
			if (CanDeepLoad(entity, "QuocGia|IdQuocGiaSource", deepLoadType, innerList) 
				&& entity.IdQuocGiaSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdQuocGia ?? (long)0);
				QuocGia tmpEntity = EntityManager.LocateEntity<QuocGia>(EntityLocator.ConstructKeyFromPkItems(typeof(QuocGia), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdQuocGiaSource = tmpEntity;
				else
					entity.IdQuocGiaSource = DataRepository.QuocGiaProvider.GetByIdQuocGia(transactionManager, (entity.IdQuocGia ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdQuocGiaSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdQuocGiaSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuocGiaProvider.DeepLoad(transactionManager, entity.IdQuocGiaSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdQuocGiaSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdThanhPho methods when available
			
			#region QuanCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Quan>|QuanCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuanCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuanCollection = DataRepository.QuanProvider.GetByIdThanhPho(transactionManager, entity.IdThanhPho);

				if (deep && entity.QuanCollection.Count > 0)
				{
					deepHandles.Add("QuanCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Quan>) DataRepository.QuanProvider.DeepLoad,
						new object[] { transactionManager, entity.QuanCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.ThanhPho object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.ThanhPho instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.ThanhPho Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.ThanhPho entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdQuocGiaSource
			if (CanDeepSave(entity, "QuocGia|IdQuocGiaSource", deepSaveType, innerList) 
				&& entity.IdQuocGiaSource != null)
			{
				DataRepository.QuocGiaProvider.Save(transactionManager, entity.IdQuocGiaSource);
				entity.IdQuocGia = entity.IdQuocGiaSource.IdQuocGia;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<Quan>
				if (CanDeepSave(entity.QuanCollection, "List<Quan>|QuanCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Quan child in entity.QuanCollection)
					{
						if(child.IdThanhPhoSource != null)
							child.IdThanhPho = child.IdThanhPhoSource.IdThanhPho;
						else
							child.IdThanhPho = entity.IdThanhPho;

					}

					if (entity.QuanCollection.Count > 0 || entity.QuanCollection.DeletedItems.Count > 0)
					{
						DataRepository.QuanProvider.Save(transactionManager, entity.QuanCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Quan >) DataRepository.QuanProvider.DeepSave,
							new object[] { transactionManager, entity.QuanCollection, deepSaveType, childTypes, innerList }
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
	
	#region ThanhPhoChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.ThanhPho</c>
	///</summary>
	public enum ThanhPhoChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>QuocGia</c> at IdQuocGiaSource
		///</summary>
		[ChildEntityType(typeof(QuocGia))]
		QuocGia,
	
		///<summary>
		/// Collection of <c>ThanhPho</c> as OneToMany for QuanCollection
		///</summary>
		[ChildEntityType(typeof(TList<Quan>))]
		QuanCollection,
	}
	
	#endregion ThanhPhoChildEntityTypes
	
	#region ThanhPhoFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ThanhPhoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThanhPho"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThanhPhoFilterBuilder : SqlFilterBuilder<ThanhPhoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilterBuilder class.
		/// </summary>
		public ThanhPhoFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThanhPhoFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThanhPhoFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThanhPhoFilterBuilder
	
	#region ThanhPhoParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ThanhPhoColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThanhPho"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThanhPhoParameterBuilder : ParameterizedSqlFilterBuilder<ThanhPhoColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThanhPhoParameterBuilder class.
		/// </summary>
		public ThanhPhoParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThanhPhoParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThanhPhoParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThanhPhoParameterBuilder
} // end namespace
