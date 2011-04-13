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
	/// This class is the base class for any <see cref="ChuCongTyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ChuCongTyProviderBaseCore : EntityProviderBase<traveltips.Entities.ChuCongTy, traveltips.Entities.ChuCongTyKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.ChuCongTyKey key)
		{
			return Delete(transactionManager, key.IdChuCongTy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idChuCongTy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idChuCongTy)
		{
			return Delete(null, idChuCongTy);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idChuCongTy);		
		
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
		public override traveltips.Entities.ChuCongTy Get(TransactionManager transactionManager, traveltips.Entities.ChuCongTyKey key, int start, int pageLength)
		{
			return GetByIdChuCongTy(transactionManager, key.IdChuCongTy, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="idChuCongTy"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public traveltips.Entities.ChuCongTy GetByIdChuCongTy(System.Int64 idChuCongTy)
		{
			int count = -1;
			return GetByIdChuCongTy(null,idChuCongTy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public traveltips.Entities.ChuCongTy GetByIdChuCongTy(System.Int64 idChuCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdChuCongTy(null, idChuCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public traveltips.Entities.ChuCongTy GetByIdChuCongTy(TransactionManager transactionManager, System.Int64 idChuCongTy)
		{
			int count = -1;
			return GetByIdChuCongTy(transactionManager, idChuCongTy, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public traveltips.Entities.ChuCongTy GetByIdChuCongTy(TransactionManager transactionManager, System.Int64 idChuCongTy, int start, int pageLength)
		{
			int count = -1;
			return GetByIdChuCongTy(transactionManager, idChuCongTy, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public traveltips.Entities.ChuCongTy GetByIdChuCongTy(System.Int64 idChuCongTy, int start, int pageLength, out int count)
		{
			return GetByIdChuCongTy(null, idChuCongTy, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_ChuCongTy index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idChuCongTy"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.ChuCongTy"/> class.</returns>
		public abstract traveltips.Entities.ChuCongTy GetByIdChuCongTy(TransactionManager transactionManager, System.Int64 idChuCongTy, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;ChuCongTy&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;ChuCongTy&gt;"/></returns>
		public static traveltips.Entities.TList<ChuCongTy> Fill(IDataReader reader, traveltips.Entities.TList<ChuCongTy> rows, int start, int pageLength)
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
			
			traveltips.Entities.ChuCongTy c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("ChuCongTy")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.ChuCongTyColumn.IdChuCongTy - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.ChuCongTyColumn.IdChuCongTy - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<ChuCongTy>(
			key.ToString(), // EntityTrackingKey
			"ChuCongTy",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.ChuCongTy();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdChuCongTy = (System.Int64)reader["id_ChuCongTy"];
			c.OriginalIdChuCongTy = c.IdChuCongTy;
			c.TenChuCongTy = reader.IsDBNull(reader.GetOrdinal("TenChuCongTy")) ? null : (System.String)reader["TenChuCongTy"];
			c.TenCongTy = reader.IsDBNull(reader.GetOrdinal("TenCongTy")) ? null : (System.String)reader["TenCongTy"];
			c.TenDangNhap = reader.IsDBNull(reader.GetOrdinal("TenDangNhap")) ? null : (System.String)reader["TenDangNhap"];
			c.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : (System.String)reader["Password"];
			c.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			c.DienThoaiCd = reader.IsDBNull(reader.GetOrdinal("DienThoaiCD")) ? null : (System.String)reader["DienThoaiCD"];
			c.DienThoaiDd = reader.IsDBNull(reader.GetOrdinal("DienThoaiDD")) ? null : (System.String)reader["DienThoaiDD"];
			c.NgayTao = reader.IsDBNull(reader.GetOrdinal("NgayTao")) ? null : (System.DateTime?)reader["NgayTao"];
			c.NgayKetThuc = reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")) ? null : (System.DateTime?)reader["NgayKetThuc"];
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
		/// Refreshes the <see cref="traveltips.Entities.ChuCongTy"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ChuCongTy"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.ChuCongTy entity)
		{
			if (!reader.Read()) return;
			
			entity.IdChuCongTy = (System.Int64)reader["id_ChuCongTy"];
			entity.OriginalIdChuCongTy = (System.Int64)reader["id_ChuCongTy"];
			entity.TenChuCongTy = reader.IsDBNull(reader.GetOrdinal("TenChuCongTy")) ? null : (System.String)reader["TenChuCongTy"];
			entity.TenCongTy = reader.IsDBNull(reader.GetOrdinal("TenCongTy")) ? null : (System.String)reader["TenCongTy"];
			entity.TenDangNhap = reader.IsDBNull(reader.GetOrdinal("TenDangNhap")) ? null : (System.String)reader["TenDangNhap"];
			entity.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : (System.String)reader["Password"];
			entity.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			entity.DienThoaiCd = reader.IsDBNull(reader.GetOrdinal("DienThoaiCD")) ? null : (System.String)reader["DienThoaiCD"];
			entity.DienThoaiDd = reader.IsDBNull(reader.GetOrdinal("DienThoaiDD")) ? null : (System.String)reader["DienThoaiDD"];
			entity.NgayTao = reader.IsDBNull(reader.GetOrdinal("NgayTao")) ? null : (System.DateTime?)reader["NgayTao"];
			entity.NgayKetThuc = reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")) ? null : (System.DateTime?)reader["NgayKetThuc"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.ChuCongTy"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.ChuCongTy"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.ChuCongTy entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdChuCongTy = (System.Int64)dataRow["id_ChuCongTy"];
			entity.OriginalIdChuCongTy = (System.Int64)dataRow["id_ChuCongTy"];
			entity.TenChuCongTy = Convert.IsDBNull(dataRow["TenChuCongTy"]) ? null : (System.String)dataRow["TenChuCongTy"];
			entity.TenCongTy = Convert.IsDBNull(dataRow["TenCongTy"]) ? null : (System.String)dataRow["TenCongTy"];
			entity.TenDangNhap = Convert.IsDBNull(dataRow["TenDangNhap"]) ? null : (System.String)dataRow["TenDangNhap"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.DiaChi = Convert.IsDBNull(dataRow["DiaChi"]) ? null : (System.String)dataRow["DiaChi"];
			entity.DienThoaiCd = Convert.IsDBNull(dataRow["DienThoaiCD"]) ? null : (System.String)dataRow["DienThoaiCD"];
			entity.DienThoaiDd = Convert.IsDBNull(dataRow["DienThoaiDD"]) ? null : (System.String)dataRow["DienThoaiDD"];
			entity.NgayTao = Convert.IsDBNull(dataRow["NgayTao"]) ? null : (System.DateTime?)dataRow["NgayTao"];
			entity.NgayKetThuc = Convert.IsDBNull(dataRow["NgayKetThuc"]) ? null : (System.DateTime?)dataRow["NgayKetThuc"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.ChuCongTy"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.ChuCongTy Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.ChuCongTy entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdChuCongTy methods when available
			
			#region CongTyCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CongTy>|CongTyCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CongTyCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CongTyCollection = DataRepository.CongTyProvider.GetByIdChuCongTy(transactionManager, entity.IdChuCongTy);

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
		/// Deep Save the entire object graph of the traveltips.Entities.ChuCongTy object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.ChuCongTy instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.ChuCongTy Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.ChuCongTy entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.IdChuCongTySource != null)
							child.IdChuCongTy = child.IdChuCongTySource.IdChuCongTy;
						else
							child.IdChuCongTy = entity.IdChuCongTy;

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
	
	#region ChuCongTyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.ChuCongTy</c>
	///</summary>
	public enum ChuCongTyChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ChuCongTy</c> as OneToMany for CongTyCollection
		///</summary>
		[ChildEntityType(typeof(TList<CongTy>))]
		CongTyCollection,
	}
	
	#endregion ChuCongTyChildEntityTypes
	
	#region ChuCongTyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ChuCongTyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyFilterBuilder : SqlFilterBuilder<ChuCongTyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilterBuilder class.
		/// </summary>
		public ChuCongTyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChuCongTyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChuCongTyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChuCongTyFilterBuilder
	
	#region ChuCongTyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ChuCongTyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyParameterBuilder : ParameterizedSqlFilterBuilder<ChuCongTyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyParameterBuilder class.
		/// </summary>
		public ChuCongTyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChuCongTyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChuCongTyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChuCongTyParameterBuilder
} // end namespace
