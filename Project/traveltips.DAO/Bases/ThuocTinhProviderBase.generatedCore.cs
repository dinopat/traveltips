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
	/// This class is the base class for any <see cref="ThuocTinhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ThuocTinhProviderBaseCore : EntityProviderBase<traveltips.Entities.ThuocTinh, traveltips.Entities.ThuocTinhKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.ThuocTinhKey key)
		{
			return Delete(transactionManager, key.IdThuocTinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idThuocTinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idThuocTinh)
		{
			return Delete(null, idThuocTinh);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idThuocTinh);		
		
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
		public override traveltips.Entities.ThuocTinh Get(TransactionManager transactionManager, traveltips.Entities.ThuocTinhKey key, int start, int pageLength)
		{
			return GetByIdThuocTinh(transactionManager, key.IdThuocTinh, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="idThuocTinh"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public traveltips.Entities.ThuocTinh GetByIdThuocTinh(System.Int64 idThuocTinh)
		{
			int count = -1;
			return GetByIdThuocTinh(null,idThuocTinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public traveltips.Entities.ThuocTinh GetByIdThuocTinh(System.Int64 idThuocTinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThuocTinh(null, idThuocTinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public traveltips.Entities.ThuocTinh GetByIdThuocTinh(TransactionManager transactionManager, System.Int64 idThuocTinh)
		{
			int count = -1;
			return GetByIdThuocTinh(transactionManager, idThuocTinh, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public traveltips.Entities.ThuocTinh GetByIdThuocTinh(TransactionManager transactionManager, System.Int64 idThuocTinh, int start, int pageLength)
		{
			int count = -1;
			return GetByIdThuocTinh(transactionManager, idThuocTinh, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public traveltips.Entities.ThuocTinh GetByIdThuocTinh(System.Int64 idThuocTinh, int start, int pageLength, out int count)
		{
			return GetByIdThuocTinh(null, idThuocTinh, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ThuocTinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idThuocTinh"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ThuocTinh"/> class.</returns>
		public abstract traveltips.Entities.ThuocTinh GetByIdThuocTinh(TransactionManager transactionManager, System.Int64 idThuocTinh, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;ThuocTinh&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;ThuocTinh&gt;"/></returns>
		public static traveltips.Entities.TList<ThuocTinh> Fill(IDataReader reader, traveltips.Entities.TList<ThuocTinh> rows, int start, int pageLength)
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
			
			traveltips.Entities.ThuocTinh c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ThuocTinh")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.ThuocTinhColumn.IdThuocTinh - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.ThuocTinhColumn.IdThuocTinh - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ThuocTinh>(
			key.ToString(), // EntityTrackingKey
			"ThuocTinh",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.ThuocTinh();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdThuocTinh = (System.Int64)reader["id_ThuocTinh"];
			c.OriginalIdThuocTinh = c.IdThuocTinh;
			c.TenThuocTinh = reader.IsDBNull(reader.GetOrdinal("TenThuocTinh")) ? null : (System.String)reader["TenThuocTinh"];
			c.MaThuocTinh = reader.IsDBNull(reader.GetOrdinal("MaThuocTinh")) ? null : (System.String)reader["MaThuocTinh"];
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
		/// Refreshes the <see cref="traveltips.Entities.ThuocTinh"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinh"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.ThuocTinh entity)
		{
			if (!reader.Read()) return;
			
			entity.IdThuocTinh = (System.Int64)reader["id_ThuocTinh"];
			entity.OriginalIdThuocTinh = (System.Int64)reader["id_ThuocTinh"];
			entity.TenThuocTinh = reader.IsDBNull(reader.GetOrdinal("TenThuocTinh")) ? null : (System.String)reader["TenThuocTinh"];
			entity.MaThuocTinh = reader.IsDBNull(reader.GetOrdinal("MaThuocTinh")) ? null : (System.String)reader["MaThuocTinh"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.ThuocTinh"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinh"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.ThuocTinh entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdThuocTinh = (System.Int64)dataRow["id_ThuocTinh"];
			entity.OriginalIdThuocTinh = (System.Int64)dataRow["id_ThuocTinh"];
			entity.TenThuocTinh = Convert.IsDBNull(dataRow["TenThuocTinh"]) ? null : (System.String)dataRow["TenThuocTinh"];
			entity.MaThuocTinh = Convert.IsDBNull(dataRow["MaThuocTinh"]) ? null : (System.String)dataRow["MaThuocTinh"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.ThuocTinh"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.ThuocTinh Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.ThuocTinh entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdThuocTinh methods when available
			
			#region ThuocTinhSanPhamCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ThuocTinhSanPham>|ThuocTinhSanPhamCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ThuocTinhSanPhamCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ThuocTinhSanPhamCollection = DataRepository.ThuocTinhSanPhamProvider.GetByIdThuocTinh(transactionManager, entity.IdThuocTinh);

				if (deep && entity.ThuocTinhSanPhamCollection.Count > 0)
				{
					deepHandles.Add("ThuocTinhSanPhamCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ThuocTinhSanPham>) DataRepository.ThuocTinhSanPhamProvider.DeepLoad,
						new object[] { transactionManager, entity.ThuocTinhSanPhamCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.ThuocTinh object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.ThuocTinh instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.ThuocTinh Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.ThuocTinh entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<ThuocTinhSanPham>
				if (CanDeepSave(entity.ThuocTinhSanPhamCollection, "List<ThuocTinhSanPham>|ThuocTinhSanPhamCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ThuocTinhSanPham child in entity.ThuocTinhSanPhamCollection)
					{
						if(child.IdThuocTinhSource != null)
							child.IdThuocTinh = child.IdThuocTinhSource.IdThuocTinh;
						else
							child.IdThuocTinh = entity.IdThuocTinh;

					}

					if (entity.ThuocTinhSanPhamCollection.Count > 0 || entity.ThuocTinhSanPhamCollection.DeletedItems.Count > 0)
					{
						DataRepository.ThuocTinhSanPhamProvider.Save(transactionManager, entity.ThuocTinhSanPhamCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< ThuocTinhSanPham >) DataRepository.ThuocTinhSanPhamProvider.DeepSave,
							new object[] { transactionManager, entity.ThuocTinhSanPhamCollection, deepSaveType, childTypes, innerList }
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
	
	#region ThuocTinhChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.ThuocTinh</c>
	///</summary>
	public enum ThuocTinhChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ThuocTinh</c> as OneToMany for ThuocTinhSanPhamCollection
		///</summary>
		[ChildEntityType(typeof(TList<ThuocTinhSanPham>))]
		ThuocTinhSanPhamCollection,
	}
	
	#endregion ThuocTinhChildEntityTypes
	
	#region ThuocTinhFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ThuocTinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhFilterBuilder : SqlFilterBuilder<ThuocTinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilterBuilder class.
		/// </summary>
		public ThuocTinhFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhFilterBuilder
	
	#region ThuocTinhParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ThuocTinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhParameterBuilder : ParameterizedSqlFilterBuilder<ThuocTinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhParameterBuilder class.
		/// </summary>
		public ThuocTinhParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhParameterBuilder
} // end namespace
