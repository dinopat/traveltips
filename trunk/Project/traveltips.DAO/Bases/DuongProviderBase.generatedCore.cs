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
	/// This class is the base class for any <see cref="DuongProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DuongProviderBaseCore : EntityProviderBase<traveltips.Entities.Duong, traveltips.Entities.DuongKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.DuongKey key)
		{
			return Delete(transactionManager, key.IdDuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idDuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idDuong)
		{
			return Delete(null, idDuong);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDuong">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idDuong);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		FK_tbl_Duong_tbl_Quan Description: 
		/// </summary>
		/// <param name="idQuan"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		public traveltips.Entities.TList<Duong> GetByIdQuan(System.Int64? idQuan)
		{
			int count = -1;
			return GetByIdQuan(idQuan, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		FK_tbl_Duong_tbl_Quan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<Duong> GetByIdQuan(TransactionManager transactionManager, System.Int64? idQuan)
		{
			int count = -1;
			return GetByIdQuan(transactionManager, idQuan, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		FK_tbl_Duong_tbl_Quan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		public traveltips.Entities.TList<Duong> GetByIdQuan(TransactionManager transactionManager, System.Int64? idQuan, int start, int pageLength)
		{
			int count = -1;
			return GetByIdQuan(transactionManager, idQuan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		fkTblDuongTblQuan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuan"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		public traveltips.Entities.TList<Duong> GetByIdQuan(System.Int64? idQuan, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdQuan(null, idQuan, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		fkTblDuongTblQuan Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idQuan"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		public traveltips.Entities.TList<Duong> GetByIdQuan(System.Int64? idQuan, int start, int pageLength,out int count)
		{
			return GetByIdQuan(null, idQuan, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Duong_tbl_Quan key.
		///		FK_tbl_Duong_tbl_Quan Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idQuan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.Duong objects.</returns>
		public abstract traveltips.Entities.TList<Duong> GetByIdQuan(TransactionManager transactionManager, System.Int64? idQuan, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.Duong Get(TransactionManager transactionManager, traveltips.Entities.DuongKey key, int start, int pageLength)
		{
			return GetByIdDuong(transactionManager, key.IdDuong, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Duong index.
		/// </summary>
		/// <param name="idDuong"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public traveltips.Entities.Duong GetByIdDuong(System.Int64 idDuong)
		{
			int count = -1;
			return GetByIdDuong(null,idDuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Duong index.
		/// </summary>
		/// <param name="idDuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public traveltips.Entities.Duong GetByIdDuong(System.Int64 idDuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDuong(null, idDuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Duong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDuong"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public traveltips.Entities.Duong GetByIdDuong(TransactionManager transactionManager, System.Int64 idDuong)
		{
			int count = -1;
			return GetByIdDuong(transactionManager, idDuong, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Duong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public traveltips.Entities.Duong GetByIdDuong(TransactionManager transactionManager, System.Int64 idDuong, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDuong(transactionManager, idDuong, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Duong index.
		/// </summary>
		/// <param name="idDuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public traveltips.Entities.Duong GetByIdDuong(System.Int64 idDuong, int start, int pageLength, out int count)
		{
			return GetByIdDuong(null, idDuong, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Duong index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDuong"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Duong"/> class.</returns>
		public abstract traveltips.Entities.Duong GetByIdDuong(TransactionManager transactionManager, System.Int64 idDuong, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;Duong&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;Duong&gt;"/></returns>
		public static traveltips.Entities.TList<Duong> Fill(IDataReader reader, traveltips.Entities.TList<Duong> rows, int start, int pageLength)
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
			
			traveltips.Entities.Duong c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Duong")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.DuongColumn.IdDuong - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.DuongColumn.IdDuong - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Duong>(
			key.ToString(), // EntityTrackingKey
			"Duong",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.Duong();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdDuong = (System.Int64)reader["id_Duong"];
			c.OriginalIdDuong = c.IdDuong;
			c.IdQuan = reader.IsDBNull(reader.GetOrdinal("id_Quan")) ? null : (System.Int64?)reader["id_Quan"];
			c.TenDuong = reader.IsDBNull(reader.GetOrdinal("TenDuong")) ? null : (System.String)reader["TenDuong"];
			c.MaDuong = reader.IsDBNull(reader.GetOrdinal("MaDuong")) ? null : (System.Byte[])reader["MaDuong"];
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
		/// Refreshes the <see cref="traveltips.Entities.Duong"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Duong"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.Duong entity)
		{
			if (!reader.Read()) return;
			
			entity.IdDuong = (System.Int64)reader["id_Duong"];
			entity.OriginalIdDuong = (System.Int64)reader["id_Duong"];
			entity.IdQuan = reader.IsDBNull(reader.GetOrdinal("id_Quan")) ? null : (System.Int64?)reader["id_Quan"];
			entity.TenDuong = reader.IsDBNull(reader.GetOrdinal("TenDuong")) ? null : (System.String)reader["TenDuong"];
			entity.MaDuong = reader.IsDBNull(reader.GetOrdinal("MaDuong")) ? null : (System.Byte[])reader["MaDuong"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.Duong"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Duong"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.Duong entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdDuong = (System.Int64)dataRow["id_Duong"];
			entity.OriginalIdDuong = (System.Int64)dataRow["id_Duong"];
			entity.IdQuan = Convert.IsDBNull(dataRow["id_Quan"]) ? null : (System.Int64?)dataRow["id_Quan"];
			entity.TenDuong = Convert.IsDBNull(dataRow["TenDuong"]) ? null : (System.String)dataRow["TenDuong"];
			entity.MaDuong = Convert.IsDBNull(dataRow["MaDuong"]) ? null : (System.Byte[])dataRow["MaDuong"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.Duong"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.Duong Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.Duong entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdQuanSource	
			if (CanDeepLoad(entity, "Quan|IdQuanSource", deepLoadType, innerList) 
				&& entity.IdQuanSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdQuan ?? (long)0);
				Quan tmpEntity = EntityManager.LocateEntity<Quan>(EntityLocator.ConstructKeyFromPkItems(typeof(Quan), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdQuanSource = tmpEntity;
				else
					entity.IdQuanSource = DataRepository.QuanProvider.GetByIdQuan(transactionManager, (entity.IdQuan ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdQuanSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdQuanSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuanProvider.DeepLoad(transactionManager, entity.IdQuanSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdQuanSource
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.Duong object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.Duong instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.Duong Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.Duong entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdQuanSource
			if (CanDeepSave(entity, "Quan|IdQuanSource", deepSaveType, innerList) 
				&& entity.IdQuanSource != null)
			{
				DataRepository.QuanProvider.Save(transactionManager, entity.IdQuanSource);
				entity.IdQuan = entity.IdQuanSource.IdQuan;
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
	
	#region DuongChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.Duong</c>
	///</summary>
	public enum DuongChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Quan</c> at IdQuanSource
		///</summary>
		[ChildEntityType(typeof(Quan))]
		Quan,
		}
	
	#endregion DuongChildEntityTypes
	
	#region DuongFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongFilterBuilder : SqlFilterBuilder<DuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongFilterBuilder class.
		/// </summary>
		public DuongFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DuongFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DuongFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DuongFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DuongFilterBuilder
	
	#region DuongParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DuongColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongParameterBuilder : ParameterizedSqlFilterBuilder<DuongColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongParameterBuilder class.
		/// </summary>
		public DuongParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DuongParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DuongParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DuongParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DuongParameterBuilder
} // end namespace
