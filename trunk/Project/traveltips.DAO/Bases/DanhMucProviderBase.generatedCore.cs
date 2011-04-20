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
	/// This class is the base class for any <see cref="DanhMucProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DanhMucProviderBaseCore : EntityProviderBase<traveltips.Entities.DanhMuc, traveltips.Entities.DanhMucKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.DanhMucKey key)
		{
			return Delete(transactionManager, key.IdDanhMuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idDanhMuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idDanhMuc)
		{
			return Delete(null, idDanhMuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idDanhMuc);		
		
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
		public override traveltips.Entities.DanhMuc Get(TransactionManager transactionManager, traveltips.Entities.DanhMucKey key, int start, int pageLength)
		{
			return GetByIdDanhMuc(transactionManager, key.IdDanhMuc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="idDanhMuc"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public traveltips.Entities.DanhMuc GetByIdDanhMuc(System.Int64 idDanhMuc)
		{
			int count = -1;
			return GetByIdDanhMuc(null,idDanhMuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public traveltips.Entities.DanhMuc GetByIdDanhMuc(System.Int64 idDanhMuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDanhMuc(null, idDanhMuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public traveltips.Entities.DanhMuc GetByIdDanhMuc(TransactionManager transactionManager, System.Int64 idDanhMuc)
		{
			int count = -1;
			return GetByIdDanhMuc(transactionManager, idDanhMuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public traveltips.Entities.DanhMuc GetByIdDanhMuc(TransactionManager transactionManager, System.Int64 idDanhMuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdDanhMuc(transactionManager, idDanhMuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public traveltips.Entities.DanhMuc GetByIdDanhMuc(System.Int64 idDanhMuc, int start, int pageLength, out int count)
		{
			return GetByIdDanhMuc(null, idDanhMuc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_DanhMuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idDanhMuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.DanhMuc"/> class.</returns>
		public abstract traveltips.Entities.DanhMuc GetByIdDanhMuc(TransactionManager transactionManager, System.Int64 idDanhMuc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;DanhMuc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;DanhMuc&gt;"/></returns>
		public static traveltips.Entities.TList<DanhMuc> Fill(IDataReader reader, traveltips.Entities.TList<DanhMuc> rows, int start, int pageLength)
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
			
			traveltips.Entities.DanhMuc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("DanhMuc")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.DanhMucColumn.IdDanhMuc - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.DanhMucColumn.IdDanhMuc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<DanhMuc>(
			key.ToString(), // EntityTrackingKey
			"DanhMuc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.DanhMuc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdDanhMuc = (System.Int64)reader["id_DanhMuc"];
			c.IdDmCha = reader.IsDBNull(reader.GetOrdinal("id_DMCha")) ? null : (System.Int64?)reader["id_DMCha"];
			c.TenDanhMuc = reader.IsDBNull(reader.GetOrdinal("TenDanhMuc")) ? null : (System.String)reader["TenDanhMuc"];
			c.MaDanhMuc = reader.IsDBNull(reader.GetOrdinal("MaDanhMuc")) ? null : (System.String)reader["MaDanhMuc"];
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
		/// Refreshes the <see cref="traveltips.Entities.DanhMuc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.DanhMuc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.DanhMuc entity)
		{
			if (!reader.Read()) return;
			
			entity.IdDanhMuc = (System.Int64)reader["id_DanhMuc"];
			entity.IdDmCha = reader.IsDBNull(reader.GetOrdinal("id_DMCha")) ? null : (System.Int64?)reader["id_DMCha"];
			entity.TenDanhMuc = reader.IsDBNull(reader.GetOrdinal("TenDanhMuc")) ? null : (System.String)reader["TenDanhMuc"];
			entity.MaDanhMuc = reader.IsDBNull(reader.GetOrdinal("MaDanhMuc")) ? null : (System.String)reader["MaDanhMuc"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.DanhMuc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.DanhMuc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.DanhMuc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdDanhMuc = (System.Int64)dataRow["id_DanhMuc"];
			entity.IdDmCha = Convert.IsDBNull(dataRow["id_DMCha"]) ? null : (System.Int64?)dataRow["id_DMCha"];
			entity.TenDanhMuc = Convert.IsDBNull(dataRow["TenDanhMuc"]) ? null : (System.String)dataRow["TenDanhMuc"];
			entity.MaDanhMuc = Convert.IsDBNull(dataRow["MaDanhMuc"]) ? null : (System.String)dataRow["MaDanhMuc"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.DanhMuc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.DanhMuc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.DanhMuc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdDanhMuc methods when available
			
			#region CongTyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CongTy>|CongTyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CongTyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CongTyCollection = DataRepository.CongTyProvider.GetByIdDanhMuc(transactionManager, entity.IdDanhMuc);

				if (deep && entity.CongTyCollection.Count > 0)
				{
					deepHandles.Add("CongTyCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CongTy>) DataRepository.CongTyProvider.DeepLoad,
						new object[] { transactionManager, entity.CongTyCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.DanhMuc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.DanhMuc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.DanhMuc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.DanhMuc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CongTy>
				if (CanDeepSave(entity.CongTyCollection, "List<CongTy>|CongTyCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CongTy child in entity.CongTyCollection)
					{
						if(child.IdDanhMucSource != null)
							child.IdDanhMuc = child.IdDanhMucSource.IdDanhMuc;
						else
							child.IdDanhMuc = entity.IdDanhMuc;

					}

					if (entity.CongTyCollection.Count > 0 || entity.CongTyCollection.DeletedItems.Count > 0)
					{
						DataRepository.CongTyProvider.Save(transactionManager, entity.CongTyCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< CongTy >) DataRepository.CongTyProvider.DeepSave,
							new object[] { transactionManager, entity.CongTyCollection, deepSaveType, childTypes, innerList }
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
	
	#region DanhMucChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.DanhMuc</c>
	///</summary>
	public enum DanhMucChildEntityTypes
	{

		///<summary>
		/// Collection of <c>DanhMuc</c> as OneToMany for CongTyCollection
		///</summary>
		[ChildEntityType(typeof(TList<CongTy>))]
		CongTyCollection,
	}
	
	#endregion DanhMucChildEntityTypes
	
	#region DanhMucFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DanhMucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucFilterBuilder : SqlFilterBuilder<DanhMucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucFilterBuilder class.
		/// </summary>
		public DanhMucFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DanhMucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DanhMucFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DanhMucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DanhMucFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DanhMucFilterBuilder
	
	#region DanhMucParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DanhMucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucParameterBuilder : ParameterizedSqlFilterBuilder<DanhMucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucParameterBuilder class.
		/// </summary>
		public DanhMucParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DanhMucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DanhMucParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DanhMucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DanhMucParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DanhMucParameterBuilder
} // end namespace
