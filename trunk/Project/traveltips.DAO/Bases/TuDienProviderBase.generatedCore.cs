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
	/// This class is the base class for any <see cref="TuDienProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TuDienProviderBaseCore : EntityProviderBase<traveltips.Entities.TuDien, traveltips.Entities.TuDienKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.TuDienKey key)
		{
			return Delete(transactionManager, key.IdTuDien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idTuDien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idTuDien)
		{
			return Delete(null, idTuDien);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTuDien">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idTuDien);		
		
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
		public override traveltips.Entities.TuDien Get(TransactionManager transactionManager, traveltips.Entities.TuDienKey key, int start, int pageLength)
		{
			return GetByIdTuDien(transactionManager, key.IdTuDien, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_TuDien index.
		/// </summary>
		/// <param name="idTuDien"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public traveltips.Entities.TuDien GetByIdTuDien(System.Int64 idTuDien)
		{
			int count = -1;
			return GetByIdTuDien(null,idTuDien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TuDien index.
		/// </summary>
		/// <param name="idTuDien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public traveltips.Entities.TuDien GetByIdTuDien(System.Int64 idTuDien, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTuDien(null, idTuDien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TuDien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTuDien"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public traveltips.Entities.TuDien GetByIdTuDien(TransactionManager transactionManager, System.Int64 idTuDien)
		{
			int count = -1;
			return GetByIdTuDien(transactionManager, idTuDien, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TuDien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTuDien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public traveltips.Entities.TuDien GetByIdTuDien(TransactionManager transactionManager, System.Int64 idTuDien, int start, int pageLength)
		{
			int count = -1;
			return GetByIdTuDien(transactionManager, idTuDien, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TuDien index.
		/// </summary>
		/// <param name="idTuDien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public traveltips.Entities.TuDien GetByIdTuDien(System.Int64 idTuDien, int start, int pageLength, out int count)
		{
			return GetByIdTuDien(null, idTuDien, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_TuDien index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idTuDien"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.TuDien"/> class.</returns>
		public abstract traveltips.Entities.TuDien GetByIdTuDien(TransactionManager transactionManager, System.Int64 idTuDien, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;TuDien&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;TuDien&gt;"/></returns>
		public static traveltips.Entities.TList<TuDien> Fill(IDataReader reader, traveltips.Entities.TList<TuDien> rows, int start, int pageLength)
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
			
			traveltips.Entities.TuDien c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("TuDien")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.TuDienColumn.IdTuDien - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.TuDienColumn.IdTuDien - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<TuDien>(
			key.ToString(), // EntityTrackingKey
			"TuDien",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.TuDien();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdTuDien = (System.Int64)reader["id_TuDien"];
			c.OriginalIdTuDien = c.IdTuDien;
			c.IdDanhMuc = reader.IsDBNull(reader.GetOrdinal("id_DanhMuc")) ? null : (System.Int64?)reader["id_DanhMuc"];
			c.TenTu = reader.IsDBNull(reader.GetOrdinal("TenTu")) ? null : (System.String)reader["TenTu"];
			c.MaTu = reader.IsDBNull(reader.GetOrdinal("MaTu")) ? null : (System.String)reader["MaTu"];
			c.NhomTu = reader.IsDBNull(reader.GetOrdinal("NhomTu")) ? null : (System.String)reader["NhomTu"];
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
		/// Refreshes the <see cref="traveltips.Entities.TuDien"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.TuDien"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.TuDien entity)
		{
			if (!reader.Read()) return;
			
			entity.IdTuDien = (System.Int64)reader["id_TuDien"];
			entity.OriginalIdTuDien = (System.Int64)reader["id_TuDien"];
			entity.IdDanhMuc = reader.IsDBNull(reader.GetOrdinal("id_DanhMuc")) ? null : (System.Int64?)reader["id_DanhMuc"];
			entity.TenTu = reader.IsDBNull(reader.GetOrdinal("TenTu")) ? null : (System.String)reader["TenTu"];
			entity.MaTu = reader.IsDBNull(reader.GetOrdinal("MaTu")) ? null : (System.String)reader["MaTu"];
			entity.NhomTu = reader.IsDBNull(reader.GetOrdinal("NhomTu")) ? null : (System.String)reader["NhomTu"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.TuDien"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.TuDien"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.TuDien entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdTuDien = (System.Int64)dataRow["id_TuDien"];
			entity.OriginalIdTuDien = (System.Int64)dataRow["id_TuDien"];
			entity.IdDanhMuc = Convert.IsDBNull(dataRow["id_DanhMuc"]) ? null : (System.Int64?)dataRow["id_DanhMuc"];
			entity.TenTu = Convert.IsDBNull(dataRow["TenTu"]) ? null : (System.String)dataRow["TenTu"];
			entity.MaTu = Convert.IsDBNull(dataRow["MaTu"]) ? null : (System.String)dataRow["MaTu"];
			entity.NhomTu = Convert.IsDBNull(dataRow["NhomTu"]) ? null : (System.String)dataRow["NhomTu"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.TuDien"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.TuDien Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.TuDien entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.TuDien object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.TuDien instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.TuDien Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.TuDien entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TuDienChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.TuDien</c>
	///</summary>
	public enum TuDienChildEntityTypes
	{
	}
	
	#endregion TuDienChildEntityTypes
	
	#region TuDienFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TuDienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienFilterBuilder : SqlFilterBuilder<TuDienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienFilterBuilder class.
		/// </summary>
		public TuDienFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TuDienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TuDienFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TuDienFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TuDienFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TuDienFilterBuilder
	
	#region TuDienParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TuDienColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienParameterBuilder : ParameterizedSqlFilterBuilder<TuDienColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienParameterBuilder class.
		/// </summary>
		public TuDienParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TuDienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TuDienParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TuDienParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TuDienParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TuDienParameterBuilder
} // end namespace
