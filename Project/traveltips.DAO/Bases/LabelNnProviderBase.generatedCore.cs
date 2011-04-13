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
	/// This class is the base class for any <see cref="LabelNnProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LabelNnProviderBaseCore : EntityProviderBase<traveltips.Entities.LabelNn, traveltips.Entities.LabelNnKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.LabelNnKey key)
		{
			return Delete(transactionManager, key.IdLabel);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLabel">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLabel)
		{
			return Delete(null, idLabel);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLabel);		
		
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
		public override traveltips.Entities.LabelNn Get(TransactionManager transactionManager, traveltips.Entities.LabelNnKey key, int start, int pageLength)
		{
			return GetByIdLabel(transactionManager, key.IdLabel, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Label index.
		/// </summary>
		/// <param name="idLabel"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public traveltips.Entities.LabelNn GetByIdLabel(System.Int64 idLabel)
		{
			int count = -1;
			return GetByIdLabel(null,idLabel, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Label index.
		/// </summary>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public traveltips.Entities.LabelNn GetByIdLabel(System.Int64 idLabel, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLabel(null, idLabel, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Label index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public traveltips.Entities.LabelNn GetByIdLabel(TransactionManager transactionManager, System.Int64 idLabel)
		{
			int count = -1;
			return GetByIdLabel(transactionManager, idLabel, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Label index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public traveltips.Entities.LabelNn GetByIdLabel(TransactionManager transactionManager, System.Int64 idLabel, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLabel(transactionManager, idLabel, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Label index.
		/// </summary>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public traveltips.Entities.LabelNn GetByIdLabel(System.Int64 idLabel, int start, int pageLength, out int count)
		{
			return GetByIdLabel(null, idLabel, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Label index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLabel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LabelNn"/> class.</returns>
		public abstract traveltips.Entities.LabelNn GetByIdLabel(TransactionManager transactionManager, System.Int64 idLabel, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;LabelNn&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;LabelNn&gt;"/></returns>
		public static traveltips.Entities.TList<LabelNn> Fill(IDataReader reader, traveltips.Entities.TList<LabelNn> rows, int start, int pageLength)
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
			
			traveltips.Entities.LabelNn c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LabelNn")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.LabelNnColumn.IdLabel - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.LabelNnColumn.IdLabel - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LabelNn>(
			key.ToString(), // EntityTrackingKey
			"LabelNn",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.LabelNn();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLabel = (System.Int64)reader["id_Label"];
			c.OriginalIdLabel = c.IdLabel;
			c.MaLabel = reader.IsDBNull(reader.GetOrdinal("MaLabel")) ? null : (System.String)reader["MaLabel"];
			c.TenLabel = reader.IsDBNull(reader.GetOrdinal("TenLabel")) ? null : (System.String)reader["TenLabel"];
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
		/// Refreshes the <see cref="traveltips.Entities.LabelNn"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LabelNn"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.LabelNn entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLabel = (System.Int64)reader["id_Label"];
			entity.OriginalIdLabel = (System.Int64)reader["id_Label"];
			entity.MaLabel = reader.IsDBNull(reader.GetOrdinal("MaLabel")) ? null : (System.String)reader["MaLabel"];
			entity.TenLabel = reader.IsDBNull(reader.GetOrdinal("TenLabel")) ? null : (System.String)reader["TenLabel"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.LabelNn"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LabelNn"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.LabelNn entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLabel = (System.Int64)dataRow["id_Label"];
			entity.OriginalIdLabel = (System.Int64)dataRow["id_Label"];
			entity.MaLabel = Convert.IsDBNull(dataRow["MaLabel"]) ? null : (System.String)dataRow["MaLabel"];
			entity.TenLabel = Convert.IsDBNull(dataRow["TenLabel"]) ? null : (System.String)dataRow["TenLabel"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.LabelNn"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.LabelNn Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.LabelNn entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdLabel methods when available
			
			#region LabelLanguageCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LabelLanguage>|LabelLanguageCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'LabelLanguageCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.LabelLanguageCollection = DataRepository.LabelLanguageProvider.GetByIdLabel(transactionManager, entity.IdLabel);

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
		/// Deep Save the entire object graph of the traveltips.Entities.LabelNn object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.LabelNn instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.LabelNn Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.LabelNn entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.IdLabelSource != null)
							child.IdLabel = child.IdLabelSource.IdLabel;
						else
							child.IdLabel = entity.IdLabel;

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
	
	#region LabelNnChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.LabelNn</c>
	///</summary>
	public enum LabelNnChildEntityTypes
	{

		///<summary>
		/// Collection of <c>LabelNn</c> as OneToMany for LabelLanguageCollection
		///</summary>
		[ChildEntityType(typeof(TList<LabelLanguage>))]
		LabelLanguageCollection,
	}
	
	#endregion LabelNnChildEntityTypes
	
	#region LabelNnFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LabelNnColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnFilterBuilder : SqlFilterBuilder<LabelNnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnFilterBuilder class.
		/// </summary>
		public LabelNnFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelNnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelNnFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelNnFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelNnFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelNnFilterBuilder
	
	#region LabelNnParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LabelNnColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnParameterBuilder : ParameterizedSqlFilterBuilder<LabelNnColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnParameterBuilder class.
		/// </summary>
		public LabelNnParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelNnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelNnParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelNnParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelNnParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelNnParameterBuilder
} // end namespace
