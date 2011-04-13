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
	/// This class is the base class for any <see cref="UserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserProviderBaseCore : EntityProviderBase<traveltips.Entities.User, traveltips.Entities.UserKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.UserKey key)
		{
			return Delete(transactionManager, key.IdUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idUser)
		{
			return Delete(null, idUser);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idUser);		
		
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
		public override traveltips.Entities.User Get(TransactionManager transactionManager, traveltips.Entities.UserKey key, int start, int pageLength)
		{
			return GetByIdUser(transactionManager, key.IdUser, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_User index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public traveltips.Entities.User GetByIdUser(System.Int64 idUser)
		{
			int count = -1;
			return GetByIdUser(null,idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_User index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public traveltips.Entities.User GetByIdUser(System.Int64 idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(null, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public traveltips.Entities.User GetByIdUser(TransactionManager transactionManager, System.Int64 idUser)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public traveltips.Entities.User GetByIdUser(TransactionManager transactionManager, System.Int64 idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_User index.
		/// </summary>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public traveltips.Entities.User GetByIdUser(System.Int64 idUser, int start, int pageLength, out int count)
		{
			return GetByIdUser(null, idUser, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.User"/> class.</returns>
		public abstract traveltips.Entities.User GetByIdUser(TransactionManager transactionManager, System.Int64 idUser, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;User&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;User&gt;"/></returns>
		public static traveltips.Entities.TList<User> Fill(IDataReader reader, traveltips.Entities.TList<User> rows, int start, int pageLength)
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
			
			traveltips.Entities.User c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("User")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.UserColumn.IdUser - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.UserColumn.IdUser - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<User>(
			key.ToString(), // EntityTrackingKey
			"User",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.User();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdUser = (System.Int64)reader["id_User"];
			c.OriginalIdUser = c.IdUser;
			c.TenDangNhap = reader.IsDBNull(reader.GetOrdinal("TenDangNhap")) ? null : (System.Byte[])reader["TenDangNhap"];
			c.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : (System.String)reader["Password"];
			c.HoTen = reader.IsDBNull(reader.GetOrdinal("HoTen")) ? null : (System.String)reader["HoTen"];
			c.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			c.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			c.DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : (System.Byte[])reader["DienThoai"];
			c.Website = reader.IsDBNull(reader.GetOrdinal("Website")) ? null : (System.String)reader["Website"];
			c.Avatar = reader.IsDBNull(reader.GetOrdinal("Avatar")) ? null : (System.String)reader["Avatar"];
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
		/// Refreshes the <see cref="traveltips.Entities.User"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.User"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.User entity)
		{
			if (!reader.Read()) return;
			
			entity.IdUser = (System.Int64)reader["id_User"];
			entity.OriginalIdUser = (System.Int64)reader["id_User"];
			entity.TenDangNhap = reader.IsDBNull(reader.GetOrdinal("TenDangNhap")) ? null : (System.Byte[])reader["TenDangNhap"];
			entity.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : (System.String)reader["Password"];
			entity.HoTen = reader.IsDBNull(reader.GetOrdinal("HoTen")) ? null : (System.String)reader["HoTen"];
			entity.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : (System.String)reader["Email"];
			entity.DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? null : (System.String)reader["DiaChi"];
			entity.DienThoai = reader.IsDBNull(reader.GetOrdinal("DienThoai")) ? null : (System.Byte[])reader["DienThoai"];
			entity.Website = reader.IsDBNull(reader.GetOrdinal("Website")) ? null : (System.String)reader["Website"];
			entity.Avatar = reader.IsDBNull(reader.GetOrdinal("Avatar")) ? null : (System.String)reader["Avatar"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.User"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.User"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.User entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdUser = (System.Int64)dataRow["id_User"];
			entity.OriginalIdUser = (System.Int64)dataRow["id_User"];
			entity.TenDangNhap = Convert.IsDBNull(dataRow["TenDangNhap"]) ? null : (System.Byte[])dataRow["TenDangNhap"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.HoTen = Convert.IsDBNull(dataRow["HoTen"]) ? null : (System.String)dataRow["HoTen"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.DiaChi = Convert.IsDBNull(dataRow["DiaChi"]) ? null : (System.String)dataRow["DiaChi"];
			entity.DienThoai = Convert.IsDBNull(dataRow["DienThoai"]) ? null : (System.Byte[])dataRow["DienThoai"];
			entity.Website = Convert.IsDBNull(dataRow["Website"]) ? null : (System.String)dataRow["Website"];
			entity.Avatar = Convert.IsDBNull(dataRow["Avatar"]) ? null : (System.String)dataRow["Avatar"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.User"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.User Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.User entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByIdUser methods when available
			
			#region CommentCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Comment>|CommentCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CommentCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CommentCollection = DataRepository.CommentProvider.GetByIdUser(transactionManager, entity.IdUser);

				if (deep && entity.CommentCollection.Count > 0)
				{
					deepHandles.Add("CommentCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Comment>) DataRepository.CommentProvider.DeepLoad,
						new object[] { transactionManager, entity.CommentCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the traveltips.Entities.User object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.User instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.User Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.User entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Comment>
				if (CanDeepSave(entity.CommentCollection, "List<Comment>|CommentCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Comment child in entity.CommentCollection)
					{
						if(child.IdUserSource != null)
							child.IdUser = child.IdUserSource.IdUser;
						else
							child.IdUser = entity.IdUser;

					}

					if (entity.CommentCollection.Count > 0 || entity.CommentCollection.DeletedItems.Count > 0)
					{
						DataRepository.CommentProvider.Save(transactionManager, entity.CommentCollection);
						
						deepHandles.Add(
							(DeepSaveHandle< Comment >) DataRepository.CommentProvider.DeepSave,
							new object[] { transactionManager, entity.CommentCollection, deepSaveType, childTypes, innerList }
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
	
	#region UserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.User</c>
	///</summary>
	public enum UserChildEntityTypes
	{

		///<summary>
		/// Collection of <c>User</c> as OneToMany for CommentCollection
		///</summary>
		[ChildEntityType(typeof(TList<Comment>))]
		CommentCollection,
	}
	
	#endregion UserChildEntityTypes
	
	#region UserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilterBuilder : SqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		public UserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilterBuilder
	
	#region UserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserParameterBuilder : ParameterizedSqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		public UserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserParameterBuilder
} // end namespace
