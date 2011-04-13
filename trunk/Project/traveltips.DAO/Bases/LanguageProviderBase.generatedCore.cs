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
	/// This class is the base class for any <see cref="LanguageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LanguageProviderBaseCore : EntityProviderBase<traveltips.Entities.Language, traveltips.Entities.LanguageKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.LanguageKey key)
		{
			return Delete(transactionManager, key.IdLanguage);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLanguage">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 idLanguage)
		{
			return Delete(null, idLanguage);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 idLanguage);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override traveltips.Entities.Language Get(TransactionManager transactionManager, traveltips.Entities.LanguageKey key, int start, int pageLength)
		{
			return GetByIdLanguage(transactionManager, key.IdLanguage, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Language index.
		/// </summary>
		/// <param name="idLanguage"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public traveltips.Entities.Language GetByIdLanguage(System.Int32 idLanguage)
		{
			int count = -1;
			return GetByIdLanguage(null,idLanguage, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Language index.
		/// </summary>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public traveltips.Entities.Language GetByIdLanguage(System.Int32 idLanguage, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLanguage(null, idLanguage, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Language index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public traveltips.Entities.Language GetByIdLanguage(TransactionManager transactionManager, System.Int32 idLanguage)
		{
			int count = -1;
			return GetByIdLanguage(transactionManager, idLanguage, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Language index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public traveltips.Entities.Language GetByIdLanguage(TransactionManager transactionManager, System.Int32 idLanguage, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLanguage(transactionManager, idLanguage, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Language index.
		/// </summary>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public traveltips.Entities.Language GetByIdLanguage(System.Int32 idLanguage, int start, int pageLength, out int count)
		{
			return GetByIdLanguage(null, idLanguage, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Language index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLanguage"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Language"/> class.</returns>
		public abstract traveltips.Entities.Language GetByIdLanguage(TransactionManager transactionManager, System.Int32 idLanguage, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;Language&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;Language&gt;"/></returns>
		public static traveltips.Entities.TList<Language> Fill(IDataReader reader, traveltips.Entities.TList<Language> rows, int start, int pageLength)
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
			
			traveltips.Entities.Language c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Language")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.LanguageColumn.IdLanguage - 1))?(int)0:(System.Int32)reader[((int)traveltips.Entities.LanguageColumn.IdLanguage - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Language>(
			key.ToString(), // EntityTrackingKey
			"Language",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.Language();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLanguage = (System.Int32)reader["id_Language"];
			c.OriginalIdLanguage = c.IdLanguage;
			c.TenNn = reader.IsDBNull(reader.GetOrdinal("TenNN")) ? null : (System.String)reader["TenNN"];
			c.MaNn = reader.IsDBNull(reader.GetOrdinal("MaNN")) ? null : (System.String)reader["MaNN"];
			c.Mota = reader.IsDBNull(reader.GetOrdinal("Mota")) ? null : (System.Byte[])reader["Mota"];
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
		/// Refreshes the <see cref="traveltips.Entities.Language"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Language"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.Language entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLanguage = (System.Int32)reader["id_Language"];
			entity.OriginalIdLanguage = (System.Int32)reader["id_Language"];
			entity.TenNn = reader.IsDBNull(reader.GetOrdinal("TenNN")) ? null : (System.String)reader["TenNN"];
			entity.MaNn = reader.IsDBNull(reader.GetOrdinal("MaNN")) ? null : (System.String)reader["MaNN"];
			entity.Mota = reader.IsDBNull(reader.GetOrdinal("Mota")) ? null : (System.Byte[])reader["Mota"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.Language"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Language"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.Language entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLanguage = (System.Int32)dataRow["id_Language"];
			entity.OriginalIdLanguage = (System.Int32)dataRow["id_Language"];
			entity.TenNn = Convert.IsDBNull(dataRow["TenNN"]) ? null : (System.String)dataRow["TenNN"];
			entity.MaNn = Convert.IsDBNull(dataRow["MaNN"]) ? null : (System.String)dataRow["MaNN"];
			entity.Mota = Convert.IsDBNull(dataRow["Mota"]) ? null : (System.Byte[])dataRow["Mota"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.Language"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.Language Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.Language entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdLanguage methods when available
			
			#region LabelLanguageCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LabelLanguage>|LabelLanguageCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LabelLanguageCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LabelLanguageCollection = DataRepository.LabelLanguageProvider.GetByIdLanguage(transactionManager, entity.IdLanguage);

				if (deep && entity.LabelLanguageCollection.Count > 0)
				{
					deepHandles.Add("LabelLanguageCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<LabelLanguage>) DataRepository.LabelLanguageProvider.DeepLoad,
						new object[] { transactionManager, entity.LabelLanguageCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.Language object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.Language instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.Language Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.Language entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<LabelLanguage>
				if (CanDeepSave(entity.LabelLanguageCollection, "List<LabelLanguage>|LabelLanguageCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(LabelLanguage child in entity.LabelLanguageCollection)
					{
						if(child.IdLanguageSource != null)
							child.IdLanguage = child.IdLanguageSource.IdLanguage;
						else
							child.IdLanguage = entity.IdLanguage;

					}

					if (entity.LabelLanguageCollection.Count > 0 || entity.LabelLanguageCollection.DeletedItems.Count > 0)
					{
						DataRepository.LabelLanguageProvider.Save(transactionManager, entity.LabelLanguageCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< LabelLanguage >) DataRepository.LabelLanguageProvider.DeepSave,
							new object[] { transactionManager, entity.LabelLanguageCollection, deepSaveType, childTypes, innerList }
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
	
	#region LanguageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.Language</c>
	///</summary>
	public enum LanguageChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Language</c> as OneToMany for LabelLanguageCollection
		///</summary>
		[ChildEntityType(typeof(TList<LabelLanguage>))]
		LabelLanguageCollection,
	}
	
	#endregion LanguageChildEntityTypes
	
	#region LanguageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageFilterBuilder : SqlFilterBuilder<LanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		public LanguageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageFilterBuilder
	
	#region LanguageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LanguageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageParameterBuilder : ParameterizedSqlFilterBuilder<LanguageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		public LanguageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageParameterBuilder
} // end namespace
