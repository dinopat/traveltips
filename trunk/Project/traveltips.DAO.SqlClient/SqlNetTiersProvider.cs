
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using traveltips.Entities;
using traveltips.DAO;
using traveltips.DAO.Bases;

#endregion

namespace traveltips.DAO.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : traveltips.DAO.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
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
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "QuocGiaProvider"
			
		private SqlQuocGiaProvider innerSqlQuocGiaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuocGia"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuocGiaProviderBase QuocGiaProvider
		{
			get
			{
				if (innerSqlQuocGiaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuocGiaProvider == null)
						{
							this.innerSqlQuocGiaProvider = new SqlQuocGiaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuocGiaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuocGiaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuocGiaProvider SqlQuocGiaProvider
		{
			get {return QuocGiaProvider as SqlQuocGiaProvider;}
		}
		
		#endregion
		
		
		#region "AdminProvider"
			
		private SqlAdminProvider innerSqlAdminProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Admin"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminProviderBase AdminProvider
		{
			get
			{
				if (innerSqlAdminProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminProvider == null)
						{
							this.innerSqlAdminProvider = new SqlAdminProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminProvider SqlAdminProvider
		{
			get {return AdminProvider as SqlAdminProvider;}
		}
		
		#endregion
		
		
		#region "SanPhamProvider"
			
		private SqlSanPhamProvider innerSqlSanPhamProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SanPhamProviderBase SanPhamProvider
		{
			get
			{
				if (innerSqlSanPhamProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSanPhamProvider == null)
						{
							this.innerSqlSanPhamProvider = new SqlSanPhamProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSanPhamProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSanPhamProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSanPhamProvider SqlSanPhamProvider
		{
			get {return SanPhamProvider as SqlSanPhamProvider;}
		}
		
		#endregion
		
		
		#region "LoaiSpProvider"
			
		private SqlLoaiSpProvider innerSqlLoaiSpProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LoaiSp"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LoaiSpProviderBase LoaiSpProvider
		{
			get
			{
				if (innerSqlLoaiSpProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLoaiSpProvider == null)
						{
							this.innerSqlLoaiSpProvider = new SqlLoaiSpProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLoaiSpProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLoaiSpProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLoaiSpProvider SqlLoaiSpProvider
		{
			get {return LoaiSpProvider as SqlLoaiSpProvider;}
		}
		
		#endregion
		
		
		#region "ThanhPhoProvider"
			
		private SqlThanhPhoProvider innerSqlThanhPhoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ThanhPho"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ThanhPhoProviderBase ThanhPhoProvider
		{
			get
			{
				if (innerSqlThanhPhoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlThanhPhoProvider == null)
						{
							this.innerSqlThanhPhoProvider = new SqlThanhPhoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlThanhPhoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlThanhPhoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlThanhPhoProvider SqlThanhPhoProvider
		{
			get {return ThanhPhoProvider as SqlThanhPhoProvider;}
		}
		
		#endregion
		
		
		#region "ThuocTinhProvider"
			
		private SqlThuocTinhProvider innerSqlThuocTinhProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ThuocTinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ThuocTinhProviderBase ThuocTinhProvider
		{
			get
			{
				if (innerSqlThuocTinhProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlThuocTinhProvider == null)
						{
							this.innerSqlThuocTinhProvider = new SqlThuocTinhProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlThuocTinhProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlThuocTinhProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlThuocTinhProvider SqlThuocTinhProvider
		{
			get {return ThuocTinhProvider as SqlThuocTinhProvider;}
		}
		
		#endregion
		
		
		#region "TuDienProvider"
			
		private SqlTuDienProvider innerSqlTuDienProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TuDien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TuDienProviderBase TuDienProvider
		{
			get
			{
				if (innerSqlTuDienProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTuDienProvider == null)
						{
							this.innerSqlTuDienProvider = new SqlTuDienProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTuDienProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTuDienProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTuDienProvider SqlTuDienProvider
		{
			get {return TuDienProvider as SqlTuDienProvider;}
		}
		
		#endregion
		
		
		#region "QuanProvider"
			
		private SqlQuanProvider innerSqlQuanProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Quan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuanProviderBase QuanProvider
		{
			get
			{
				if (innerSqlQuanProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuanProvider == null)
						{
							this.innerSqlQuanProvider = new SqlQuanProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuanProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuanProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuanProvider SqlQuanProvider
		{
			get {return QuanProvider as SqlQuanProvider;}
		}
		
		#endregion
		
		
		#region "TinTucProvider"
			
		private SqlTinTucProvider innerSqlTinTucProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TinTuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TinTucProviderBase TinTucProvider
		{
			get
			{
				if (innerSqlTinTucProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTinTucProvider == null)
						{
							this.innerSqlTinTucProvider = new SqlTinTucProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTinTucProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTinTucProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTinTucProvider SqlTinTucProvider
		{
			get {return TinTucProvider as SqlTinTucProvider;}
		}
		
		#endregion
		
		
		#region "ThuocTinhSanPhamProvider"
			
		private SqlThuocTinhSanPhamProvider innerSqlThuocTinhSanPhamProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ThuocTinhSanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ThuocTinhSanPhamProviderBase ThuocTinhSanPhamProvider
		{
			get
			{
				if (innerSqlThuocTinhSanPhamProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlThuocTinhSanPhamProvider == null)
						{
							this.innerSqlThuocTinhSanPhamProvider = new SqlThuocTinhSanPhamProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlThuocTinhSanPhamProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlThuocTinhSanPhamProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlThuocTinhSanPhamProvider SqlThuocTinhSanPhamProvider
		{
			get {return ThuocTinhSanPhamProvider as SqlThuocTinhSanPhamProvider;}
		}
		
		#endregion
		
		
		#region "LanguageProvider"
			
		private SqlLanguageProvider innerSqlLanguageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Language"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LanguageProviderBase LanguageProvider
		{
			get
			{
				if (innerSqlLanguageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLanguageProvider == null)
						{
							this.innerSqlLanguageProvider = new SqlLanguageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLanguageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLanguageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLanguageProvider SqlLanguageProvider
		{
			get {return LanguageProvider as SqlLanguageProvider;}
		}
		
		#endregion
		
		
		#region "LabelNnProvider"
			
		private SqlLabelNnProvider innerSqlLabelNnProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LabelNn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LabelNnProviderBase LabelNnProvider
		{
			get
			{
				if (innerSqlLabelNnProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLabelNnProvider == null)
						{
							this.innerSqlLabelNnProvider = new SqlLabelNnProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLabelNnProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLabelNnProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLabelNnProvider SqlLabelNnProvider
		{
			get {return LabelNnProvider as SqlLabelNnProvider;}
		}
		
		#endregion
		
		
		#region "DanhMucProvider"
			
		private SqlDanhMucProvider innerSqlDanhMucProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DanhMuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DanhMucProviderBase DanhMucProvider
		{
			get
			{
				if (innerSqlDanhMucProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDanhMucProvider == null)
						{
							this.innerSqlDanhMucProvider = new SqlDanhMucProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDanhMucProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDanhMucProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDanhMucProvider SqlDanhMucProvider
		{
			get {return DanhMucProvider as SqlDanhMucProvider;}
		}
		
		#endregion
		
		
		#region "ChuCongTyProvider"
			
		private SqlChuCongTyProvider innerSqlChuCongTyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ChuCongTy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ChuCongTyProviderBase ChuCongTyProvider
		{
			get
			{
				if (innerSqlChuCongTyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlChuCongTyProvider == null)
						{
							this.innerSqlChuCongTyProvider = new SqlChuCongTyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlChuCongTyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlChuCongTyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlChuCongTyProvider SqlChuCongTyProvider
		{
			get {return ChuCongTyProvider as SqlChuCongTyProvider;}
		}
		
		#endregion
		
		
		#region "CongTyProvider"
			
		private SqlCongTyProvider innerSqlCongTyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CongTy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CongTyProviderBase CongTyProvider
		{
			get
			{
				if (innerSqlCongTyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCongTyProvider == null)
						{
							this.innerSqlCongTyProvider = new SqlCongTyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCongTyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCongTyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCongTyProvider SqlCongTyProvider
		{
			get {return CongTyProvider as SqlCongTyProvider;}
		}
		
		#endregion
		
		
		#region "CommentProvider"
			
		private SqlCommentProvider innerSqlCommentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Comment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CommentProviderBase CommentProvider
		{
			get
			{
				if (innerSqlCommentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCommentProvider == null)
						{
							this.innerSqlCommentProvider = new SqlCommentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCommentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCommentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCommentProvider SqlCommentProvider
		{
			get {return CommentProvider as SqlCommentProvider;}
		}
		
		#endregion
		
		
		#region "DichVuProvider"
			
		private SqlDichVuProvider innerSqlDichVuProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DichVu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DichVuProviderBase DichVuProvider
		{
			get
			{
				if (innerSqlDichVuProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDichVuProvider == null)
						{
							this.innerSqlDichVuProvider = new SqlDichVuProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDichVuProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDichVuProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDichVuProvider SqlDichVuProvider
		{
			get {return DichVuProvider as SqlDichVuProvider;}
		}
		
		#endregion
		
		
		#region "LabelLanguageProvider"
			
		private SqlLabelLanguageProvider innerSqlLabelLanguageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="LabelLanguage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LabelLanguageProviderBase LabelLanguageProvider
		{
			get
			{
				if (innerSqlLabelLanguageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLabelLanguageProvider == null)
						{
							this.innerSqlLabelLanguageProvider = new SqlLabelLanguageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLabelLanguageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLabelLanguageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLabelLanguageProvider SqlLabelLanguageProvider
		{
			get {return LabelLanguageProvider as SqlLabelLanguageProvider;}
		}
		
		#endregion
		
		
		#region "DuongProvider"
			
		private SqlDuongProvider innerSqlDuongProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Duong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DuongProviderBase DuongProvider
		{
			get
			{
				if (innerSqlDuongProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDuongProvider == null)
						{
							this.innerSqlDuongProvider = new SqlDuongProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDuongProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDuongProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDuongProvider SqlDuongProvider
		{
			get {return DuongProvider as SqlDuongProvider;}
		}
		
		#endregion
		
		
		#region "KhuVucProvider"
			
		private SqlKhuVucProvider innerSqlKhuVucProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KhuVuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KhuVucProviderBase KhuVucProvider
		{
			get
			{
				if (innerSqlKhuVucProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKhuVucProvider == null)
						{
							this.innerSqlKhuVucProvider = new SqlKhuVucProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKhuVucProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlKhuVucProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKhuVucProvider SqlKhuVucProvider
		{
			get {return KhuVucProvider as SqlKhuVucProvider;}
		}
		
		#endregion
		
		
		#region "UserProvider"
			
		private SqlUserProvider innerSqlUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerSqlUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserProvider == null)
						{
							this.innerSqlUserProvider = new SqlUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserProvider SqlUserProvider
		{
			get {return UserProvider as SqlUserProvider;}
		}
		
		#endregion
		
		
		#region "GalleryProvider"
			
		private SqlGalleryProvider innerSqlGalleryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Gallery"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GalleryProviderBase GalleryProvider
		{
			get
			{
				if (innerSqlGalleryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGalleryProvider == null)
						{
							this.innerSqlGalleryProvider = new SqlGalleryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGalleryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGalleryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGalleryProvider SqlGalleryProvider
		{
			get {return GalleryProvider as SqlGalleryProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
