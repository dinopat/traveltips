
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using traveltips.Entities;

#endregion

namespace traveltips.DAO.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : System.Configuration.Provider.ProviderBase
	{
		private Type entityCreationalFactoryType = null;
        private static object syncObject = new object();
        private bool enableEntityTracking = true;
        private bool enableListTracking = false;
        private bool useEntityFactory = true;
		private bool enableMethodAuthorization = false;
        private int defaultCommandTimeout = 30;
		
		[ThreadStatic] // Allow the LoadPolicy to be controlled on a per thread basis
		private LoadPolicy loadPolicy = LoadPolicy.DiscardChanges;

	    /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
        public override void Initialize(string name, NameValueCollection config)
	    {
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(traveltips.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
                bool.TryParse(config["enableEntityTracking"], out this.enableEntityTracking);

                bool.TryParse(config["enableListTracking"], out this.enableListTracking);

                bool.TryParse(config["useEntityFactory"], out this.useEntityFactory);
				
				bool.TryParse(config["enableMethodAuthorization"], out this.enableMethodAuthorization);				
				
				int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
				
				if (String.Compare(config["currentLoadPolicy"], LoadPolicy.DiscardChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.DiscardChanges;
                }
                
                if (String.Compare(config["currentLoadPolicy"], LoadPolicy.PreserveChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.PreserveChanges;
                }				
			}   
         }
	    
        /// <summary>
        /// Gets or sets the Creational Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual Type EntityCreationalFactoryType
        {
            get
            {
                return entityCreationalFactoryType;
            }
            set
            {
                entityCreationalFactoryType = value;
            }
        }

        /// <summary>
        /// Gets or sets the ability to track entities.
        /// </summary>
        /// <value>true/false.</value>
        public virtual bool EnableEntityTracking
        {
            get
            {
                return enableEntityTracking;
            }
            set { enableEntityTracking = value; }
        }

        /// <summary>
        /// Gets or sets the Entity Factory Type.
        /// </summary>
        /// <value>The entity factory type.</value>
        public virtual bool EnableListTracking
        {
            get
            {
                return enableListTracking;
            }
            set 
            {
                enableListTracking = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use entity factory property to enable the usage of the EntityFactory and it's type cache.
        /// </summary>
        /// <value>bool value</value>
        public virtual bool UseEntityFactory
        {
            get
            {
                return useEntityFactory;
            }
            set 
            {
                useEntityFactory = value; 
            }
        }

        /// <summary>
        /// Gets or sets the use Enable Method Authorization to enable the usage of the Microsoft Patterns and Practices 
		/// IAuthorizationRuleProvider for code level authorization.
		/// </summary>
        /// <value>A bool value.</value>
        public virtual bool EnableMethodAuthorization
        {
            get
            {
                return enableMethodAuthorization;
            }
            set 
            {
                enableMethodAuthorization = value; 
            }
        }

        /// <summary>
        /// Gets or sets the default timeout for every command
        /// </summary>
        /// <value>integer value in seconds.</value>
        public virtual int DefaultCommandTimeout
        {
            get
            {
                return defaultCommandTimeout;
            }
            set
            {
                defaultCommandTimeout = value;
            }
        }
		
		/// <summary>
		/// Get or set the current LoadPolicy in effect
		/// </summary>
		/// <value>A <c cref="LoadPolicy"/> enumeration member.</value>
		public virtual LoadPolicy CurrentLoadPolicy
		{
			get
			{
				return loadPolicy;
			}
			set
			{
				loadPolicy = value;
			}
		}
		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation is supporting Transactions.
		///</summary>
		public abstract bool IsTransactionSupported{get;}
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public virtual TransactionManager CreateTransaction() {throw new NotSupportedException();}
		
		
		///<summary>
		/// Current QuocGiaProviderBase instance.
		///</summary>
		public virtual QuocGiaProviderBase QuocGiaProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AdminProviderBase instance.
		///</summary>
		public virtual AdminProviderBase AdminProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SanPhamProviderBase instance.
		///</summary>
		public virtual SanPhamProviderBase SanPhamProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LoaiSpProviderBase instance.
		///</summary>
		public virtual LoaiSpProviderBase LoaiSpProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ThanhPhoProviderBase instance.
		///</summary>
		public virtual ThanhPhoProviderBase ThanhPhoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ThuocTinhProviderBase instance.
		///</summary>
		public virtual ThuocTinhProviderBase ThuocTinhProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TuDienProviderBase instance.
		///</summary>
		public virtual TuDienProviderBase TuDienProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuanProviderBase instance.
		///</summary>
		public virtual QuanProviderBase QuanProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TinTucProviderBase instance.
		///</summary>
		public virtual TinTucProviderBase TinTucProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ThuocTinhSanPhamProviderBase instance.
		///</summary>
		public virtual ThuocTinhSanPhamProviderBase ThuocTinhSanPhamProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LanguageProviderBase instance.
		///</summary>
		public virtual LanguageProviderBase LanguageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LabelNnProviderBase instance.
		///</summary>
		public virtual LabelNnProviderBase LabelNnProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DanhMucProviderBase instance.
		///</summary>
		public virtual DanhMucProviderBase DanhMucProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ChuCongTyProviderBase instance.
		///</summary>
		public virtual ChuCongTyProviderBase ChuCongTyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CongTyProviderBase instance.
		///</summary>
		public virtual CongTyProviderBase CongTyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CommentProviderBase instance.
		///</summary>
		public virtual CommentProviderBase CommentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DichVuProviderBase instance.
		///</summary>
		public virtual DichVuProviderBase DichVuProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LabelLanguageProviderBase instance.
		///</summary>
		public virtual LabelLanguageProviderBase LabelLanguageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DuongProviderBase instance.
		///</summary>
		public virtual DuongProviderBase DuongProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current KhuVucProviderBase instance.
		///</summary>
		public virtual KhuVucProviderBase KhuVucProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserProviderBase instance.
		///</summary>
		public virtual UserProviderBase UserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GalleryProviderBase instance.
		///</summary>
		public virtual GalleryProviderBase GalleryProvider{get {throw new NotImplementedException();}}
		
		
					
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(DbCommand commandWrapper);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public abstract void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(DbCommand commandWrapper);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(DbCommand commandWrapper);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(string storedProcedureName, params object[] parameterValues);		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues);
		
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(DbCommand commandWrapper);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper);

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(CommandType commandType, string commandText);
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public abstract object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText);
		#endregion
		
		#endregion
	}
	
	/// <summary>
	/// Possibel load policies that can be applied when a provider Load method is called. Determines 
	/// how entities with EntityState.Unchanged and EntityState.Changed are treated during a Load
	/// when entity tracking is enabled.
	/// </summary>
	public enum LoadPolicy
	{
		/// <summary>
		/// Refresh entities with EntityState.Unchanged if entity tracking is enabled. Entities with 
		/// EntityState.Changed will not be refreshed with information from the database.
		/// </summary>
		PreserveChanges,
		
		/// <summary>
		/// Refresh entities with EntityState.Changed as well as EntityState.Unchanged i.e. discard any
		/// unsaved changes.
		/// </summary>
		DiscardChanges
	}
}
