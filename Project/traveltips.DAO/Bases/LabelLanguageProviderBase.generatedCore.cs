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
	/// This class is the base class for any <see cref="LabelLanguageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LabelLanguageProviderBaseCore : EntityProviderBase<traveltips.Entities.LabelLanguage, traveltips.Entities.LabelLanguageKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.LabelLanguageKey key)
		{
			return Delete(transactionManager, key.IdLabelLanguage);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLabelLanguage">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLabelLanguage)
		{
			return Delete(null, idLabelLanguage);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabelLanguage">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLabelLanguage);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		FK_tbl_LabelLanguage_tbl_Label Description: 
		/// </summary>
		/// <param name="idLabel"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLabel(System.Int64? idLabel)
		{
			int count = -1;
			return GetByIdLabel(idLabel, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		FK_tbl_LabelLanguage_tbl_Label Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLabel(TransactionManager transactionManager, System.Int64? idLabel)
		{
			int count = -1;
			return GetByIdLabel(transactionManager, idLabel, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		FK_tbl_LabelLanguage_tbl_Label Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLabel(TransactionManager transactionManager, System.Int64? idLabel, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLabel(transactionManager, idLabel, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		fkTblLabelLanguageTblLabel Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLabel"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLabel(System.Int64? idLabel, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdLabel(null, idLabel, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		fkTblLabelLanguageTblLabel Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLabel"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLabel(System.Int64? idLabel, int start, int pageLength,out int count)
		{
			return GetByIdLabel(null, idLabel, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Label key.
		///		FK_tbl_LabelLanguage_tbl_Label Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public abstract traveltips.Entities.TList<LabelLanguage> GetByIdLabel(TransactionManager transactionManager, System.Int64? idLabel, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		FK_tbl_LabelLanguage_tbl_Language Description: 
		/// </summary>
		/// <param name="idLanguage"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(System.Int32? idLanguage)
		{
			int count = -1;
			return GetByIdLanguage(idLanguage, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		FK_tbl_LabelLanguage_tbl_Language Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(TransactionManager transactionManager, System.Int32? idLanguage)
		{
			int count = -1;
			return GetByIdLanguage(transactionManager, idLanguage, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		FK_tbl_LabelLanguage_tbl_Language Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(TransactionManager transactionManager, System.Int32? idLanguage, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLanguage(transactionManager, idLanguage, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		fkTblLabelLanguageTblLanguage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLanguage"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(System.Int32? idLanguage, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdLanguage(null, idLanguage, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		fkTblLabelLanguageTblLanguage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idLanguage"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(System.Int32? idLanguage, int start, int pageLength,out int count)
		{
			return GetByIdLanguage(null, idLanguage, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_LabelLanguage_tbl_Language key.
		///		FK_tbl_LabelLanguage_tbl_Language Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.LabelLanguage objects.</returns>
		public abstract traveltips.Entities.TList<LabelLanguage> GetByIdLanguage(TransactionManager transactionManager, System.Int32? idLanguage, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.LabelLanguage Get(TransactionManager transactionManager, traveltips.Entities.LabelLanguageKey key, int start, int pageLength)
		{
			return GetByIdLabelLanguage(transactionManager, key.IdLabelLanguage, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="idLabelLanguage"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public traveltips.Entities.LabelLanguage GetByIdLabelLanguage(System.Int64 idLabelLanguage)
		{
			int count = -1;
			return GetByIdLabelLanguage(null,idLabelLanguage, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="idLabelLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public traveltips.Entities.LabelLanguage GetByIdLabelLanguage(System.Int64 idLabelLanguage, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLabelLanguage(null, idLabelLanguage, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabelLanguage"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public traveltips.Entities.LabelLanguage GetByIdLabelLanguage(TransactionManager transactionManager, System.Int64 idLabelLanguage)
		{
			int count = -1;
			return GetByIdLabelLanguage(transactionManager, idLabelLanguage, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabelLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public traveltips.Entities.LabelLanguage GetByIdLabelLanguage(TransactionManager transactionManager, System.Int64 idLabelLanguage, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLabelLanguage(transactionManager, idLabelLanguage, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="idLabelLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public traveltips.Entities.LabelLanguage GetByIdLabelLanguage(System.Int64 idLabelLanguage, int start, int pageLength, out int count)
		{
			return GetByIdLabelLanguage(null, idLabelLanguage, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LabelLanguage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabelLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelLanguage"/> class.</returns>
		public abstract traveltips.Entities.LabelLanguage GetByIdLabelLanguage(TransactionManager transactionManager, System.Int64 idLabelLanguage, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;LabelLanguage&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;LabelLanguage&gt;"/></returns>
		public static traveltips.Entities.TList<LabelLanguage> Fill(IDataReader reader, traveltips.Entities.TList<LabelLanguage> rows, int start, int pageLength)
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
			
			traveltips.Entities.LabelLanguage c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LabelLanguage")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.LabelLanguageColumn.IdLabelLanguage - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.LabelLanguageColumn.IdLabelLanguage - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LabelLanguage>(
			key.ToString(), // EntityTrackingKey
			"LabelLanguage",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.LabelLanguage();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLabelLanguage = (System.Int64)reader["id_LabelLanguage"];
			c.IdLanguage = reader.IsDBNull(reader.GetOrdinal("id_Language")) ? null : (System.Int32?)reader["id_Language"];
			c.IdLabel = reader.IsDBNull(reader.GetOrdinal("id_Label")) ? null : (System.Int64?)reader["id_Label"];
			c.NoiDung = reader.IsDBNull(reader.GetOrdinal("NoiDung")) ? null : (System.String)reader["NoiDung"];
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
		/// Refreshes the <see cref="traveltips.Entities.LabelLanguage"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LabelLanguage"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.LabelLanguage entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLabelLanguage = (System.Int64)reader["id_LabelLanguage"];
			entity.IdLanguage = reader.IsDBNull(reader.GetOrdinal("id_Language")) ? null : (System.Int32?)reader["id_Language"];
			entity.IdLabel = reader.IsDBNull(reader.GetOrdinal("id_Label")) ? null : (System.Int64?)reader["id_Label"];
			entity.NoiDung = reader.IsDBNull(reader.GetOrdinal("NoiDung")) ? null : (System.String)reader["NoiDung"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.LabelLanguage"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LabelLanguage"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.LabelLanguage entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLabelLanguage = (System.Int64)dataRow["id_LabelLanguage"];
			entity.IdLanguage = Convert.IsDBNull(dataRow["id_Language"]) ? null : (System.Int32?)dataRow["id_Language"];
			entity.IdLabel = Convert.IsDBNull(dataRow["id_Label"]) ? null : (System.Int64?)dataRow["id_Label"];
			entity.NoiDung = Convert.IsDBNull(dataRow["NoiDung"]) ? null : (System.String)dataRow["NoiDung"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.LabelLanguage"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.LabelLanguage Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.LabelLanguage entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdLabelSource	
			if (CanDeepLoad(entity, "LabelNn|IdLabelSource", deepLoadType, innerList) 
				&& entity.IdLabelSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdLabel ?? (long)0);
				LabelNn tmpEntity = EntityManager.LocateEntity<LabelNn>(EntityLocator.ConstructKeyFromPkItems(typeof(LabelNn), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdLabelSource = tmpEntity;
				else
					entity.IdLabelSource = DataRepository.LabelNnProvider.GetByIdLabel(transactionManager, (entity.IdLabel ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdLabelSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdLabelSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LabelNnProvider.DeepLoad(transactionManager, entity.IdLabelSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdLabelSource

			#region IdLanguageSource	
			if (CanDeepLoad(entity, "Language|IdLanguageSource", deepLoadType, innerList) 
				&& entity.IdLanguageSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdLanguage ?? (int)0);
				Language tmpEntity = EntityManager.LocateEntity<Language>(EntityLocator.ConstructKeyFromPkItems(typeof(Language), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdLanguageSource = tmpEntity;
				else
					entity.IdLanguageSource = DataRepository.LanguageProvider.GetByIdLanguage(transactionManager, (entity.IdLanguage ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdLanguageSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdLanguageSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LanguageProvider.DeepLoad(transactionManager, entity.IdLanguageSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdLanguageSource
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.LabelLanguage object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.LabelLanguage instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.LabelLanguage Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.LabelLanguage entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdLabelSource
			if (CanDeepSave(entity, "LabelNn|IdLabelSource", deepSaveType, innerList) 
				&& entity.IdLabelSource != null)
			{
				DataRepository.LabelNnProvider.Save(transactionManager, entity.IdLabelSource);
				entity.IdLabel = entity.IdLabelSource.IdLabel;
			}
			#endregion 
			
			#region IdLanguageSource
			if (CanDeepSave(entity, "Language|IdLanguageSource", deepSaveType, innerList) 
				&& entity.IdLanguageSource != null)
			{
				DataRepository.LanguageProvider.Save(transactionManager, entity.IdLanguageSource);
				entity.IdLanguage = entity.IdLanguageSource.IdLanguage;
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
	
	#region LabelLanguageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.LabelLanguage</c>
	///</summary>
	public enum LabelLanguageChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>LabelNn</c> at IdLabelSource
		///</summary>
		[ChildEntityType(typeof(LabelNn))]
		LabelNn,
			
		///<summary>
		/// Composite Property for <c>Language</c> at IdLanguageSource
		///</summary>
		[ChildEntityType(typeof(Language))]
		Language,
		}
	
	#endregion LabelLanguageChildEntityTypes
	
	#region LabelLanguageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LabelLanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageFilterBuilder : SqlFilterBuilder<LabelLanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilterBuilder class.
		/// </summary>
		public LabelLanguageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelLanguageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelLanguageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelLanguageFilterBuilder
	
	#region LabelLanguageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LabelLanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageParameterBuilder : ParameterizedSqlFilterBuilder<LabelLanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageParameterBuilder class.
		/// </summary>
		public LabelLanguageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelLanguageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelLanguageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelLanguageParameterBuilder
} // end namespace
