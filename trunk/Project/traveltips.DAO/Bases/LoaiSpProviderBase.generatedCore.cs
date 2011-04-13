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
	/// This class is the base class for any <see cref="LoaiSpProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LoaiSpProviderBaseCore : EntityProviderBase<traveltips.Entities.LoaiSp, traveltips.Entities.LoaiSpKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.LoaiSpKey key)
		{
			return Delete(transactionManager, key.IdLoaiSp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idLoaiSp">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idLoaiSp)
		{
			return Delete(null, idLoaiSp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idLoaiSp);		
		
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
		public override traveltips.Entities.LoaiSp Get(TransactionManager transactionManager, traveltips.Entities.LoaiSpKey key, int start, int pageLength)
		{
			return GetByIdLoaiSp(transactionManager, key.IdLoaiSp, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="idLoaiSp"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public traveltips.Entities.LoaiSp GetByIdLoaiSp(System.Int64 idLoaiSp)
		{
			int count = -1;
			return GetByIdLoaiSp(null,idLoaiSp, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public traveltips.Entities.LoaiSp GetByIdLoaiSp(System.Int64 idLoaiSp, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiSp(null, idLoaiSp, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public traveltips.Entities.LoaiSp GetByIdLoaiSp(TransactionManager transactionManager, System.Int64 idLoaiSp)
		{
			int count = -1;
			return GetByIdLoaiSp(transactionManager, idLoaiSp, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public traveltips.Entities.LoaiSp GetByIdLoaiSp(TransactionManager transactionManager, System.Int64 idLoaiSp, int start, int pageLength)
		{
			int count = -1;
			return GetByIdLoaiSp(transactionManager, idLoaiSp, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public traveltips.Entities.LoaiSp GetByIdLoaiSp(System.Int64 idLoaiSp, int start, int pageLength, out int count)
		{
			return GetByIdLoaiSp(null, idLoaiSp, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_LoaiSP index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idLoaiSp"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.LoaiSp"/> class.</returns>
		public abstract traveltips.Entities.LoaiSp GetByIdLoaiSp(TransactionManager transactionManager, System.Int64 idLoaiSp, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;LoaiSp&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;LoaiSp&gt;"/></returns>
		public static traveltips.Entities.TList<LoaiSp> Fill(IDataReader reader, traveltips.Entities.TList<LoaiSp> rows, int start, int pageLength)
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
			
			traveltips.Entities.LoaiSp c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("LoaiSp")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.LoaiSpColumn.IdLoaiSp - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.LoaiSpColumn.IdLoaiSp - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<LoaiSp>(
			key.ToString(), // EntityTrackingKey
			"LoaiSp",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.LoaiSp();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdLoaiSp = (System.Int64)reader["id_LoaiSP"];
			c.OriginalIdLoaiSp = c.IdLoaiSp;
			c.IdLoaiSpCha = reader.IsDBNull(reader.GetOrdinal("id_LoaiSPCha")) ? null : (System.Int64?)reader["id_LoaiSPCha"];
			c.TenLoaiSp = reader.IsDBNull(reader.GetOrdinal("TenLoaiSP")) ? null : (System.String)reader["TenLoaiSP"];
			c.MaLoaiSp = reader.IsDBNull(reader.GetOrdinal("MaLoaiSP")) ? null : (System.String)reader["MaLoaiSP"];
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
		/// Refreshes the <see cref="traveltips.Entities.LoaiSp"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LoaiSp"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.LoaiSp entity)
		{
			if (!reader.Read()) return;
			
			entity.IdLoaiSp = (System.Int64)reader["id_LoaiSP"];
			entity.OriginalIdLoaiSp = (System.Int64)reader["id_LoaiSP"];
			entity.IdLoaiSpCha = reader.IsDBNull(reader.GetOrdinal("id_LoaiSPCha")) ? null : (System.Int64?)reader["id_LoaiSPCha"];
			entity.TenLoaiSp = reader.IsDBNull(reader.GetOrdinal("TenLoaiSP")) ? null : (System.String)reader["TenLoaiSP"];
			entity.MaLoaiSp = reader.IsDBNull(reader.GetOrdinal("MaLoaiSP")) ? null : (System.String)reader["MaLoaiSP"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.LoaiSp"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.LoaiSp"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.LoaiSp entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdLoaiSp = (System.Int64)dataRow["id_LoaiSP"];
			entity.OriginalIdLoaiSp = (System.Int64)dataRow["id_LoaiSP"];
			entity.IdLoaiSpCha = Convert.IsDBNull(dataRow["id_LoaiSPCha"]) ? null : (System.Int64?)dataRow["id_LoaiSPCha"];
			entity.TenLoaiSp = Convert.IsDBNull(dataRow["TenLoaiSP"]) ? null : (System.String)dataRow["TenLoaiSP"];
			entity.MaLoaiSp = Convert.IsDBNull(dataRow["MaLoaiSP"]) ? null : (System.String)dataRow["MaLoaiSP"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.LoaiSp"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.LoaiSp Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.LoaiSp entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdLoaiSp methods when available
			
			#region SanPhamCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SanPham>|SanPhamCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SanPhamCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SanPhamCollection = DataRepository.SanPhamProvider.GetByIdLoaiSp(transactionManager, entity.IdLoaiSp);

				if (deep && entity.SanPhamCollection.Count > 0)
				{
					deepHandles.Add("SanPhamCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SanPham>) DataRepository.SanPhamProvider.DeepLoad,
						new object[] { transactionManager, entity.SanPhamCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.LoaiSp object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.LoaiSp instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.LoaiSp Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.LoaiSp entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<SanPham>
				if (CanDeepSave(entity.SanPhamCollection, "List<SanPham>|SanPhamCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SanPham child in entity.SanPhamCollection)
					{
						if(child.IdLoaiSpSource != null)
							child.IdLoaiSp = child.IdLoaiSpSource.IdLoaiSp;
						else
							child.IdLoaiSp = entity.IdLoaiSp;

					}

					if (entity.SanPhamCollection.Count > 0 || entity.SanPhamCollection.DeletedItems.Count > 0)
					{
						DataRepository.SanPhamProvider.Save(transactionManager, entity.SanPhamCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< SanPham >) DataRepository.SanPhamProvider.DeepSave,
							new object[] { transactionManager, entity.SanPhamCollection, deepSaveType, childTypes, innerList }
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
	
	#region LoaiSpChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.LoaiSp</c>
	///</summary>
	public enum LoaiSpChildEntityTypes
	{

		///<summary>
		/// Collection of <c>LoaiSp</c> as OneToMany for SanPhamCollection
		///</summary>
		[ChildEntityType(typeof(TList<SanPham>))]
		SanPhamCollection,
	}
	
	#endregion LoaiSpChildEntityTypes
	
	#region LoaiSpFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LoaiSpColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpFilterBuilder : SqlFilterBuilder<LoaiSpColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilterBuilder class.
		/// </summary>
		public LoaiSpFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiSpFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiSpFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiSpFilterBuilder
	
	#region LoaiSpParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LoaiSpColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpParameterBuilder : ParameterizedSqlFilterBuilder<LoaiSpColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpParameterBuilder class.
		/// </summary>
		public LoaiSpParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiSpParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiSpParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiSpParameterBuilder
} // end namespace
