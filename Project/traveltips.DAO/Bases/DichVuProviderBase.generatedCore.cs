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
	/// This class is the base class for any <see cref="DichVuProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DichVuProviderBaseCore : EntityProviderBase<traveltips.Entities.DichVu, traveltips.Entities.DichVuKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.DichVuKey key)
		{
			return Delete(transactionManager, key.IdDichVu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idDichVu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idDichVu)
		{
			return Delete(null, idDichVu);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDichVu">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idDichVu);		
		
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
		public override traveltips.Entities.DichVu Get(TransactionManager transactionManager, traveltips.Entities.DichVuKey key, int start, int pageLength)
		{
			return GetByIdDichVu(transactionManager, key.IdDichVu, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_DichVu index.
		/// </summary>
		/// <param name="idDichVu"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public traveltips.Entities.DichVu GetByIdDichVu(System.Int64 idDichVu)
		{
			int count = -1;
			return GetByIdDichVu(null,idDichVu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DichVu index.
		/// </summary>
		/// <param name="idDichVu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public traveltips.Entities.DichVu GetByIdDichVu(System.Int64 idDichVu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDichVu(null, idDichVu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DichVu index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDichVu"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public traveltips.Entities.DichVu GetByIdDichVu(TransactionManager transactionManager, System.Int64 idDichVu)
		{
			int count = -1;
			return GetByIdDichVu(transactionManager, idDichVu, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DichVu index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDichVu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public traveltips.Entities.DichVu GetByIdDichVu(TransactionManager transactionManager, System.Int64 idDichVu, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDichVu(transactionManager, idDichVu, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DichVu index.
		/// </summary>
		/// <param name="idDichVu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public traveltips.Entities.DichVu GetByIdDichVu(System.Int64 idDichVu, int start, int pageLength, out int count)
		{
			return GetByIdDichVu(null, idDichVu, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DichVu index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDichVu"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DichVu"/> class.</returns>
		public abstract traveltips.Entities.DichVu GetByIdDichVu(TransactionManager transactionManager, System.Int64 idDichVu, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;DichVu&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;DichVu&gt;"/></returns>
		public static traveltips.Entities.TList<DichVu> Fill(IDataReader reader, traveltips.Entities.TList<DichVu> rows, int start, int pageLength)
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
			
			traveltips.Entities.DichVu c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("DichVu")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.DichVuColumn.IdDichVu - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.DichVuColumn.IdDichVu - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<DichVu>(
			key.ToString(), // EntityTrackingKey
			"DichVu",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.DichVu();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdDichVu = (System.Int64)reader["id_DichVu"];
			c.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			c.TenDv = reader.IsDBNull(reader.GetOrdinal("TenDV")) ? null : (System.String)reader["TenDV"];
			c.MaDv = reader.IsDBNull(reader.GetOrdinal("MaDV")) ? null : (System.String)reader["MaDV"];
			c.MotaNgan = reader.IsDBNull(reader.GetOrdinal("MotaNgan")) ? null : (System.String)reader["MotaNgan"];
			c.MotaChiTiet = reader.IsDBNull(reader.GetOrdinal("MotaChiTiet")) ? null : (System.String)reader["MotaChiTiet"];
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
		/// Refreshes the <see cref="traveltips.Entities.DichVu"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.DichVu"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.DichVu entity)
		{
			if (!reader.Read()) return;
			
			entity.IdDichVu = (System.Int64)reader["id_DichVu"];
			entity.IdCongTy = reader.IsDBNull(reader.GetOrdinal("id_CongTy")) ? null : (System.Int64?)reader["id_CongTy"];
			entity.TenDv = reader.IsDBNull(reader.GetOrdinal("TenDV")) ? null : (System.String)reader["TenDV"];
			entity.MaDv = reader.IsDBNull(reader.GetOrdinal("MaDV")) ? null : (System.String)reader["MaDV"];
			entity.MotaNgan = reader.IsDBNull(reader.GetOrdinal("MotaNgan")) ? null : (System.String)reader["MotaNgan"];
			entity.MotaChiTiet = reader.IsDBNull(reader.GetOrdinal("MotaChiTiet")) ? null : (System.String)reader["MotaChiTiet"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.DichVu"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.DichVu"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.DichVu entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdDichVu = (System.Int64)dataRow["id_DichVu"];
			entity.IdCongTy = Convert.IsDBNull(dataRow["id_CongTy"]) ? null : (System.Int64?)dataRow["id_CongTy"];
			entity.TenDv = Convert.IsDBNull(dataRow["TenDV"]) ? null : (System.String)dataRow["TenDV"];
			entity.MaDv = Convert.IsDBNull(dataRow["MaDV"]) ? null : (System.String)dataRow["MaDV"];
			entity.MotaNgan = Convert.IsDBNull(dataRow["MotaNgan"]) ? null : (System.String)dataRow["MotaNgan"];
			entity.MotaChiTiet = Convert.IsDBNull(dataRow["MotaChiTiet"]) ? null : (System.String)dataRow["MotaChiTiet"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.DichVu"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.DichVu Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.DichVu entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdDichVuSource	
			if (CanDeepLoad(entity, "CongTy|IdDichVuSource", deepLoadType, innerList) 
				&& entity.IdDichVuSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.IdDichVu;
				CongTy tmpEntity = EntityManager.LocateEntity<CongTy>(EntityLocator.ConstructKeyFromPkItems(typeof(CongTy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdDichVuSource = tmpEntity;
				else
					entity.IdDichVuSource = DataRepository.CongTyProvider.GetByIdCongTy(transactionManager, entity.IdDichVu);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdDichVuSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdDichVuSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CongTyProvider.DeepLoad(transactionManager, entity.IdDichVuSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdDichVuSource
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.DichVu object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.DichVu instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.DichVu Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.DichVu entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdDichVuSource
			if (CanDeepSave(entity, "CongTy|IdDichVuSource", deepSaveType, innerList) 
				&& entity.IdDichVuSource != null)
			{
				DataRepository.CongTyProvider.Save(transactionManager, entity.IdDichVuSource);
				entity.IdDichVu = entity.IdDichVuSource.IdCongTy;
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
	
	#region DichVuChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.DichVu</c>
	///</summary>
	public enum DichVuChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CongTy</c> at IdDichVuSource
		///</summary>
		[ChildEntityType(typeof(CongTy))]
		CongTy,
		}
	
	#endregion DichVuChildEntityTypes
	
	#region DichVuFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DichVuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuFilterBuilder : SqlFilterBuilder<DichVuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuFilterBuilder class.
		/// </summary>
		public DichVuFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DichVuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DichVuFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DichVuFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DichVuFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DichVuFilterBuilder
	
	#region DichVuParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DichVuColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuParameterBuilder : ParameterizedSqlFilterBuilder<DichVuColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuParameterBuilder class.
		/// </summary>
		public DichVuParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DichVuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DichVuParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DichVuParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DichVuParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DichVuParameterBuilder
} // end namespace
