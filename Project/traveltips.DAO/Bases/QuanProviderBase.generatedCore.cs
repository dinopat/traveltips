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
	/// This class is the base class for any <see cref="QuanProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuanProviderBaseCore : EntityProviderBase<traveltips.Entities.Quan, traveltips.Entities.QuanKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.QuanKey key)
		{
			return Delete(transactionManager, key.IdQuan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idQuan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idQuan)
		{
			return Delete(null, idQuan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idQuan);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		FK_tbl_Quan_tbl_ThanhPho Description: 
		/// </summary>
		/// <param name="idThanhPho"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		public traveltips.Entities.TList<Quan> GetByIdThanhPho(System.Int64? idThanhPho)
		{
			int count = -1;
			return GetByIdThanhPho(idThanhPho, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		FK_tbl_Quan_tbl_ThanhPho Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<Quan> GetByIdThanhPho(TransactionManager transactionManager, System.Int64? idThanhPho)
		{
			int count = -1;
			return GetByIdThanhPho(transactionManager, idThanhPho, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		FK_tbl_Quan_tbl_ThanhPho Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		public traveltips.Entities.TList<Quan> GetByIdThanhPho(TransactionManager transactionManager, System.Int64? idThanhPho, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThanhPho(transactionManager, idThanhPho, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		fkTblQuanTblThanhPho Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idThanhPho"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		public traveltips.Entities.TList<Quan> GetByIdThanhPho(System.Int64? idThanhPho, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdThanhPho(null, idThanhPho, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		fkTblQuanTblThanhPho Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idThanhPho"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		public traveltips.Entities.TList<Quan> GetByIdThanhPho(System.Int64? idThanhPho, int start, int pageLength,out int count)
		{
			return GetByIdThanhPho(null, idThanhPho, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Quan_tbl_ThanhPho key.
		///		FK_tbl_Quan_tbl_ThanhPho Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThanhPho"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.Quan objects.</returns>
		public abstract traveltips.Entities.TList<Quan> GetByIdThanhPho(TransactionManager transactionManager, System.Int64? idThanhPho, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.Quan Get(TransactionManager transactionManager, traveltips.Entities.QuanKey key, int start, int pageLength)
		{
			return GetByIdQuan(transactionManager, key.IdQuan, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Quan index.
		/// </summary>
		/// <param name="idQuan"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public traveltips.Entities.Quan GetByIdQuan(System.Int64 idQuan)
		{
			int count = -1;
			return GetByIdQuan(null,idQuan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Quan index.
		/// </summary>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public traveltips.Entities.Quan GetByIdQuan(System.Int64 idQuan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuan(null, idQuan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Quan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public traveltips.Entities.Quan GetByIdQuan(TransactionManager transactionManager, System.Int64 idQuan)
		{
			int count = -1;
			return GetByIdQuan(transactionManager, idQuan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Quan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public traveltips.Entities.Quan GetByIdQuan(TransactionManager transactionManager, System.Int64 idQuan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuan(transactionManager, idQuan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Quan index.
		/// </summary>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public traveltips.Entities.Quan GetByIdQuan(System.Int64 idQuan, int start, int pageLength, out int count)
		{
			return GetByIdQuan(null, idQuan, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Quan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Quan"/> class.</returns>
		public abstract traveltips.Entities.Quan GetByIdQuan(TransactionManager transactionManager, System.Int64 idQuan, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;Quan&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;Quan&gt;"/></returns>
		public static traveltips.Entities.TList<Quan> Fill(IDataReader reader, traveltips.Entities.TList<Quan> rows, int start, int pageLength)
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
			
			traveltips.Entities.Quan c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Quan")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.QuanColumn.IdQuan - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.QuanColumn.IdQuan - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Quan>(
			key.ToString(), // EntityTrackingKey
			"Quan",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.Quan();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdQuan = (System.Int64)reader["id_Quan"];
			c.OriginalIdQuan = c.IdQuan;
			c.IdThanhPho = reader.IsDBNull(reader.GetOrdinal("id_ThanhPho")) ? null : (System.Int64?)reader["id_ThanhPho"];
			c.TenQuan = reader.IsDBNull(reader.GetOrdinal("TenQuan")) ? null : (System.String)reader["TenQuan"];
			c.MaQuan = reader.IsDBNull(reader.GetOrdinal("MaQuan")) ? null : (System.String)reader["MaQuan"];
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
		/// Refreshes the <see cref="traveltips.Entities.Quan"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Quan"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.Quan entity)
		{
			if (!reader.Read()) return;
			
			entity.IdQuan = (System.Int64)reader["id_Quan"];
			entity.OriginalIdQuan = (System.Int64)reader["id_Quan"];
			entity.IdThanhPho = reader.IsDBNull(reader.GetOrdinal("id_ThanhPho")) ? null : (System.Int64?)reader["id_ThanhPho"];
			entity.TenQuan = reader.IsDBNull(reader.GetOrdinal("TenQuan")) ? null : (System.String)reader["TenQuan"];
			entity.MaQuan = reader.IsDBNull(reader.GetOrdinal("MaQuan")) ? null : (System.String)reader["MaQuan"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.Quan"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Quan"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.Quan entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdQuan = (System.Int64)dataRow["id_Quan"];
			entity.OriginalIdQuan = (System.Int64)dataRow["id_Quan"];
			entity.IdThanhPho = Convert.IsDBNull(dataRow["id_ThanhPho"]) ? null : (System.Int64?)dataRow["id_ThanhPho"];
			entity.TenQuan = Convert.IsDBNull(dataRow["TenQuan"]) ? null : (System.String)dataRow["TenQuan"];
			entity.MaQuan = Convert.IsDBNull(dataRow["MaQuan"]) ? null : (System.String)dataRow["MaQuan"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.Quan"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.Quan Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.Quan entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdThanhPhoSource	
			if (CanDeepLoad(entity, "ThanhPho|IdThanhPhoSource", deepLoadType, innerList) 
				&& entity.IdThanhPhoSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdThanhPho ?? (long)0);
				ThanhPho tmpEntity = EntityManager.LocateEntity<ThanhPho>(EntityLocator.ConstructKeyFromPkItems(typeof(ThanhPho), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdThanhPhoSource = tmpEntity;
				else
					entity.IdThanhPhoSource = DataRepository.ThanhPhoProvider.GetByIdThanhPho(transactionManager, (entity.IdThanhPho ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdThanhPhoSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdThanhPhoSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ThanhPhoProvider.DeepLoad(transactionManager, entity.IdThanhPhoSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdThanhPhoSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdQuan methods when available
			
			#region DuongCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Duong>|DuongCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DuongCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DuongCollection = DataRepository.DuongProvider.GetByIdQuan(transactionManager, entity.IdQuan);

				if (deep && entity.DuongCollection.Count > 0)
				{
					deepHandles.Add("DuongCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Duong>) DataRepository.DuongProvider.DeepLoad,
						new object[] { transactionManager, entity.DuongCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.Quan object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.Quan instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.Quan Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.Quan entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdThanhPhoSource
			if (CanDeepSave(entity, "ThanhPho|IdThanhPhoSource", deepSaveType, innerList) 
				&& entity.IdThanhPhoSource != null)
			{
				DataRepository.ThanhPhoProvider.Save(transactionManager, entity.IdThanhPhoSource);
				entity.IdThanhPho = entity.IdThanhPhoSource.IdThanhPho;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<Delegate, object> deepHandles = new Dictionary<Delegate, object>();
	
			#region List<Duong>
				if (CanDeepSave(entity.DuongCollection, "List<Duong>|DuongCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Duong child in entity.DuongCollection)
					{
						if(child.IdQuanSource != null)
							child.IdQuan = child.IdQuanSource.IdQuan;
						else
							child.IdQuan = entity.IdQuan;

					}

					if (entity.DuongCollection.Count > 0 || entity.DuongCollection.DeletedItems.Count > 0)
					{
						DataRepository.DuongProvider.Save(transactionManager, entity.DuongCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Duong >) DataRepository.DuongProvider.DeepSave,
							new object[] { transactionManager, entity.DuongCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuanChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.Quan</c>
	///</summary>
	public enum QuanChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ThanhPho</c> at IdThanhPhoSource
		///</summary>
		[ChildEntityType(typeof(ThanhPho))]
		ThanhPho,
	
		///<summary>
		/// Collection of <c>Quan</c> as OneToMany for DuongCollection
		///</summary>
		[ChildEntityType(typeof(TList<Duong>))]
		DuongCollection,
	}
	
	#endregion QuanChildEntityTypes
	
	#region QuanFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanFilterBuilder : SqlFilterBuilder<QuanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanFilterBuilder class.
		/// </summary>
		public QuanFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanFilterBuilder
	
	#region QuanParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanParameterBuilder : ParameterizedSqlFilterBuilder<QuanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanParameterBuilder class.
		/// </summary>
		public QuanParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanParameterBuilder
} // end namespace
