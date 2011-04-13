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
	/// This class is the base class for any <see cref="KhuVucProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KhuVucProviderBaseCore : EntityProviderBase<traveltips.Entities.KhuVuc, traveltips.Entities.KhuVucKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.KhuVucKey key)
		{
			return Delete(transactionManager, key.IdKhuVuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idKhuVuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idKhuVuc)
		{
			return Delete(null, idKhuVuc);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idKhuVuc">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idKhuVuc);		
		
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
		public override traveltips.Entities.KhuVuc Get(TransactionManager transactionManager, traveltips.Entities.KhuVucKey key, int start, int pageLength)
		{
			return GetByIdKhuVuc(transactionManager, key.IdKhuVuc, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="idKhuVuc"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public traveltips.Entities.KhuVuc GetByIdKhuVuc(System.Int64 idKhuVuc)
		{
			int count = -1;
			return GetByIdKhuVuc(null,idKhuVuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="idKhuVuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public traveltips.Entities.KhuVuc GetByIdKhuVuc(System.Int64 idKhuVuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdKhuVuc(null, idKhuVuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idKhuVuc"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public traveltips.Entities.KhuVuc GetByIdKhuVuc(TransactionManager transactionManager, System.Int64 idKhuVuc)
		{
			int count = -1;
			return GetByIdKhuVuc(transactionManager, idKhuVuc, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idKhuVuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public traveltips.Entities.KhuVuc GetByIdKhuVuc(TransactionManager transactionManager, System.Int64 idKhuVuc, int start, int pageLength)
		{
			int count = -1;
			return GetByIdKhuVuc(transactionManager, idKhuVuc, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="idKhuVuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public traveltips.Entities.KhuVuc GetByIdKhuVuc(System.Int64 idKhuVuc, int start, int pageLength, out int count)
		{
			return GetByIdKhuVuc(null, idKhuVuc, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_KhuVuc index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idKhuVuc"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.KhuVuc"/> class.</returns>
		public abstract traveltips.Entities.KhuVuc GetByIdKhuVuc(TransactionManager transactionManager, System.Int64 idKhuVuc, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;KhuVuc&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;KhuVuc&gt;"/></returns>
		public static traveltips.Entities.TList<KhuVuc> Fill(IDataReader reader, traveltips.Entities.TList<KhuVuc> rows, int start, int pageLength)
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
			
			traveltips.Entities.KhuVuc c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("KhuVuc")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.KhuVucColumn.IdKhuVuc - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.KhuVucColumn.IdKhuVuc - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<KhuVuc>(
			key.ToString(), // EntityTrackingKey
			"KhuVuc",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.KhuVuc();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdKhuVuc = (System.Int64)reader["id_KhuVuc"];
			c.OriginalIdKhuVuc = c.IdKhuVuc;
			c.TenKv = reader.IsDBNull(reader.GetOrdinal("TenKV")) ? null : (System.String)reader["TenKV"];
			c.MaKv = reader.IsDBNull(reader.GetOrdinal("MaKV")) ? null : (System.Byte[])reader["MaKV"];
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
		/// Refreshes the <see cref="traveltips.Entities.KhuVuc"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.KhuVuc"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.KhuVuc entity)
		{
			if (!reader.Read()) return;
			
			entity.IdKhuVuc = (System.Int64)reader["id_KhuVuc"];
			entity.OriginalIdKhuVuc = (System.Int64)reader["id_KhuVuc"];
			entity.TenKv = reader.IsDBNull(reader.GetOrdinal("TenKV")) ? null : (System.String)reader["TenKV"];
			entity.MaKv = reader.IsDBNull(reader.GetOrdinal("MaKV")) ? null : (System.Byte[])reader["MaKV"];
			entity.MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : (System.String)reader["MoTa"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.KhuVuc"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.KhuVuc"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.KhuVuc entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdKhuVuc = (System.Int64)dataRow["id_KhuVuc"];
			entity.OriginalIdKhuVuc = (System.Int64)dataRow["id_KhuVuc"];
			entity.TenKv = Convert.IsDBNull(dataRow["TenKV"]) ? null : (System.String)dataRow["TenKV"];
			entity.MaKv = Convert.IsDBNull(dataRow["MaKV"]) ? null : (System.Byte[])dataRow["MaKV"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.KhuVuc"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.KhuVuc Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.KhuVuc entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the traveltips.Entities.KhuVuc object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.KhuVuc instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.KhuVuc Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.KhuVuc entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region KhuVucChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.KhuVuc</c>
	///</summary>
	public enum KhuVucChildEntityTypes
	{
	}
	
	#endregion KhuVucChildEntityTypes
	
	#region KhuVucFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KhuVucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucFilterBuilder : SqlFilterBuilder<KhuVucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucFilterBuilder class.
		/// </summary>
		public KhuVucFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuVucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuVucFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuVucFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuVucFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuVucFilterBuilder
	
	#region KhuVucParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KhuVucColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucParameterBuilder : ParameterizedSqlFilterBuilder<KhuVucColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucParameterBuilder class.
		/// </summary>
		public KhuVucParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuVucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuVucParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuVucParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuVucParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuVucParameterBuilder
} // end namespace
