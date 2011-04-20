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
	/// This class is the base class for any <see cref="CommentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CommentProviderBaseCore : EntityProviderBase<traveltips.Entities.Comment, traveltips.Entities.CommentKey>
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
		public override bool Delete(TransactionManager transactionManager, traveltips.Entities.CommentKey key)
		{
			return Delete(transactionManager, key.IdComment);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="idComment">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 idComment)
		{
			return Delete(null, idComment);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idComment">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 idComment);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		FK_tbl_Comment_tbl_CongTy Description: 
		/// </summary>
		/// <param name="idCongty"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdCongty(System.Int64? idCongty)
		{
			int count = -1;
			return GetByIdCongty(idCongty, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		FK_tbl_Comment_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongty"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<Comment> GetByIdCongty(TransactionManager transactionManager, System.Int64? idCongty)
		{
			int count = -1;
			return GetByIdCongty(transactionManager, idCongty, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		FK_tbl_Comment_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongty"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdCongty(TransactionManager transactionManager, System.Int64? idCongty, int start, int pageLength)
		{
			int count = -1;
			return GetByIdCongty(transactionManager, idCongty, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		fkTblCommentTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongty"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdCongty(System.Int64? idCongty, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdCongty(null, idCongty, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		fkTblCommentTblCongTy Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idCongty"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdCongty(System.Int64? idCongty, int start, int pageLength,out int count)
		{
			return GetByIdCongty(null, idCongty, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_CongTy key.
		///		FK_tbl_Comment_tbl_CongTy Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idCongty"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public abstract traveltips.Entities.TList<Comment> GetByIdCongty(TransactionManager transactionManager, System.Int64? idCongty, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		FK_tbl_Comment_tbl_User Description: 
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdUser(System.Int64? idUser)
		{
			int count = -1;
			return GetByIdUser(idUser, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		FK_tbl_Comment_tbl_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		/// <remarks></remarks>
		public traveltips.Entities.TList<Comment> GetByIdUser(TransactionManager transactionManager, System.Int64? idUser)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		FK_tbl_Comment_tbl_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdUser(TransactionManager transactionManager, System.Int64? idUser, int start, int pageLength)
		{
			int count = -1;
			return GetByIdUser(transactionManager, idUser, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		fkTblCommentTblUser Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idUser"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdUser(System.Int64? idUser, int start, int pageLength)
		{
			int count =  -1;
			return GetByIdUser(null, idUser, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		fkTblCommentTblUser Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="idUser"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public traveltips.Entities.TList<Comment> GetByIdUser(System.Int64? idUser, int start, int pageLength,out int count)
		{
			return GetByIdUser(null, idUser, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_tbl_Comment_tbl_User key.
		///		FK_tbl_Comment_tbl_User Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idUser"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of traveltips.Entities.Comment objects.</returns>
		public abstract traveltips.Entities.TList<Comment> GetByIdUser(TransactionManager transactionManager, System.Int64? idUser, int start, int pageLength, out int count);
		
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
		public override traveltips.Entities.Comment Get(TransactionManager transactionManager, traveltips.Entities.CommentKey key, int start, int pageLength)
		{
			return GetByIdComment(transactionManager, key.IdComment, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tbl_Feedback index.
		/// </summary>
		/// <param name="idComment"></param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public traveltips.Entities.Comment GetByIdComment(System.Int64 idComment)
		{
			int count = -1;
			return GetByIdComment(null,idComment, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Feedback index.
		/// </summary>
		/// <param name="idComment"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public traveltips.Entities.Comment GetByIdComment(System.Int64 idComment, int start, int pageLength)
		{
			int count = -1;
			return GetByIdComment(null, idComment, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Feedback index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idComment"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public traveltips.Entities.Comment GetByIdComment(TransactionManager transactionManager, System.Int64 idComment)
		{
			int count = -1;
			return GetByIdComment(transactionManager, idComment, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Feedback index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idComment"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public traveltips.Entities.Comment GetByIdComment(TransactionManager transactionManager, System.Int64 idComment, int start, int pageLength)
		{
			int count = -1;
			return GetByIdComment(transactionManager, idComment, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Feedback index.
		/// </summary>
		/// <param name="idComment"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public traveltips.Entities.Comment GetByIdComment(System.Int64 idComment, int start, int pageLength, out int count)
		{
			return GetByIdComment(null, idComment, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tbl_Feedback index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="idComment"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="traveltips.Entities.Comment"/> class.</returns>
		public abstract traveltips.Entities.Comment GetByIdComment(TransactionManager transactionManager, System.Int64 idComment, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a traveltips.Entities.TList&lt;Comment&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="traveltips.Entities.TList&lt;Comment&gt;"/></returns>
		public static traveltips.Entities.TList<Comment> Fill(IDataReader reader, traveltips.Entities.TList<Comment> rows, int start, int pageLength)
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
			
			traveltips.Entities.Comment c = null;
			if (DataRepository.Provider.UseEntityFactory)
			{
			key = new System.Text.StringBuilder("Comment")
			.Append("|").Append((reader.IsDBNull(((int)traveltips.Entities.CommentColumn.IdComment - 1))?(long)0:(System.Int64)reader[((int)traveltips.Entities.CommentColumn.IdComment - 1)]).ToString()).ToString();
			c = EntityManager.LocateOrCreate<Comment>(
			key.ToString(), // EntityTrackingKey
			"Comment",  //Creational Type
			DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
			DataRepository.Provider.EnableEntityTracking); // Track this entity?
			}
			else
			{
			c = new traveltips.Entities.Comment();
			}
			
			if (!DataRepository.Provider.EnableEntityTracking ||
			c.EntityState == EntityState.Added ||
			(DataRepository.Provider.EnableEntityTracking &&
			((DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
			(DataRepository.Provider.CurrentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged ||
								c.EntityState == EntityState.Changed)))))
						{
			c.SuppressEntityEvents = true;
			c.IdComment = (System.Int64)reader["id_Comment"];
			c.IdUser = reader.IsDBNull(reader.GetOrdinal("id_User")) ? null : (System.Int64?)reader["id_User"];
			c.IdCongty = reader.IsDBNull(reader.GetOrdinal("id_Congty")) ? null : (System.Int64?)reader["id_Congty"];
			c.TieuDe = reader.IsDBNull(reader.GetOrdinal("TieuDe")) ? null : (System.String)reader["TieuDe"];
			c.NoiDung = reader.IsDBNull(reader.GetOrdinal("NoiDung")) ? null : (System.String)reader["NoiDung"];
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
		/// Refreshes the <see cref="traveltips.Entities.Comment"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Comment"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, traveltips.Entities.Comment entity)
		{
			if (!reader.Read()) return;
			
			entity.IdComment = (System.Int64)reader["id_Comment"];
			entity.IdUser = reader.IsDBNull(reader.GetOrdinal("id_User")) ? null : (System.Int64?)reader["id_User"];
			entity.IdCongty = reader.IsDBNull(reader.GetOrdinal("id_Congty")) ? null : (System.Int64?)reader["id_Congty"];
			entity.TieuDe = reader.IsDBNull(reader.GetOrdinal("TieuDe")) ? null : (System.String)reader["TieuDe"];
			entity.NoiDung = reader.IsDBNull(reader.GetOrdinal("NoiDung")) ? null : (System.String)reader["NoiDung"];
			entity.Flag = reader.IsDBNull(reader.GetOrdinal("Flag")) ? null : (System.Byte?)reader["Flag"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="traveltips.Entities.Comment"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="traveltips.Entities.Comment"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, traveltips.Entities.Comment entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.IdComment = (System.Int64)dataRow["id_Comment"];
			entity.IdUser = Convert.IsDBNull(dataRow["id_User"]) ? null : (System.Int64?)dataRow["id_User"];
			entity.IdCongty = Convert.IsDBNull(dataRow["id_Congty"]) ? null : (System.Int64?)dataRow["id_Congty"];
			entity.TieuDe = Convert.IsDBNull(dataRow["TieuDe"]) ? null : (System.String)dataRow["TieuDe"];
			entity.NoiDung = Convert.IsDBNull(dataRow["NoiDung"]) ? null : (System.String)dataRow["NoiDung"];
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
		/// <param name="entity">The <see cref="traveltips.Entities.Comment"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">traveltips.Entities.Comment Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, traveltips.Entities.Comment entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region IdCongtySource	
			if (CanDeepLoad(entity, "CongTy|IdCongtySource", deepLoadType, innerList) 
				&& entity.IdCongtySource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdCongty ?? (long)0);
				CongTy tmpEntity = EntityManager.LocateEntity<CongTy>(EntityLocator.ConstructKeyFromPkItems(typeof(CongTy), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdCongtySource = tmpEntity;
				else
					entity.IdCongtySource = DataRepository.CongTyProvider.GetByIdCongTy(transactionManager, (entity.IdCongty ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdCongtySource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdCongtySource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CongTyProvider.DeepLoad(transactionManager, entity.IdCongtySource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdCongtySource

			#region IdUserSource	
			if (CanDeepLoad(entity, "User|IdUserSource", deepLoadType, innerList) 
				&& entity.IdUserSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.IdUser ?? (long)0);
				User tmpEntity = EntityManager.LocateEntity<User>(EntityLocator.ConstructKeyFromPkItems(typeof(User), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.IdUserSource = tmpEntity;
				else
					entity.IdUserSource = DataRepository.UserProvider.GetByIdUser(transactionManager, (entity.IdUser ?? (long)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'IdUserSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.IdUserSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserProvider.DeepLoad(transactionManager, entity.IdUserSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion IdUserSource
			
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
		/// Deep Save the entire object graph of the traveltips.Entities.Comment object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">traveltips.Entities.Comment instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">traveltips.Entities.Comment Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, traveltips.Entities.Comment entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region IdCongtySource
			if (CanDeepSave(entity, "CongTy|IdCongtySource", deepSaveType, innerList) 
				&& entity.IdCongtySource != null)
			{
				DataRepository.CongTyProvider.Save(transactionManager, entity.IdCongtySource);
				entity.IdCongty = entity.IdCongtySource.IdCongTy;
			}
			#endregion 
			
			#region IdUserSource
			if (CanDeepSave(entity, "User|IdUserSource", deepSaveType, innerList) 
				&& entity.IdUserSource != null)
			{
				DataRepository.UserProvider.Save(transactionManager, entity.IdUserSource);
				entity.IdUser = entity.IdUserSource.IdUser;
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
	
	#region CommentChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>traveltips.Entities.Comment</c>
	///</summary>
	public enum CommentChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CongTy</c> at IdCongtySource
		///</summary>
		[ChildEntityType(typeof(CongTy))]
		CongTy,
			
		///<summary>
		/// Composite Property for <c>User</c> at IdUserSource
		///</summary>
		[ChildEntityType(typeof(User))]
		User,
		}
	
	#endregion CommentChildEntityTypes
	
	#region CommentFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CommentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentFilterBuilder : SqlFilterBuilder<CommentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentFilterBuilder class.
		/// </summary>
		public CommentFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommentFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommentFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommentFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommentFilterBuilder
	
	#region CommentParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CommentColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentParameterBuilder : ParameterizedSqlFilterBuilder<CommentColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentParameterBuilder class.
		/// </summary>
		public CommentParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommentParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommentParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommentParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommentParameterBuilder
} // end namespace
