#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using traveltips.Entities;
using traveltips.DAO;
using traveltips.DAO.Bases;

#endregion

namespace traveltips.DAO
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("traveltips.DAO") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.8.0");
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			public ConnectionProvider(String connectionStringName)
			{
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region QuocGiaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuocGia"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuocGiaProviderBase QuocGiaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuocGiaProvider;
			}
		}
		
		#endregion
		
		#region AdminProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Admin"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminProviderBase AdminProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminProvider;
			}
		}
		
		#endregion
		
		#region SanPhamProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SanPhamProviderBase SanPhamProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SanPhamProvider;
			}
		}
		
		#endregion
		
		#region LoaiSpProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LoaiSp"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LoaiSpProviderBase LoaiSpProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LoaiSpProvider;
			}
		}
		
		#endregion
		
		#region ThanhPhoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ThanhPho"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ThanhPhoProviderBase ThanhPhoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ThanhPhoProvider;
			}
		}
		
		#endregion
		
		#region ThuocTinhProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ThuocTinh"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ThuocTinhProviderBase ThuocTinhProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ThuocTinhProvider;
			}
		}
		
		#endregion
		
		#region TuDienProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TuDien"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TuDienProviderBase TuDienProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TuDienProvider;
			}
		}
		
		#endregion
		
		#region QuanProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Quan"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuanProviderBase QuanProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuanProvider;
			}
		}
		
		#endregion
		
		#region TinTucProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TinTuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TinTucProviderBase TinTucProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TinTucProvider;
			}
		}
		
		#endregion
		
		#region ThuocTinhSanPhamProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ThuocTinhSanPham"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ThuocTinhSanPhamProviderBase ThuocTinhSanPhamProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ThuocTinhSanPhamProvider;
			}
		}
		
		#endregion
		
		#region LanguageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Language"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LanguageProviderBase LanguageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LanguageProvider;
			}
		}
		
		#endregion
		
		#region LabelNnProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LabelNn"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LabelNnProviderBase LabelNnProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LabelNnProvider;
			}
		}
		
		#endregion
		
		#region DanhMucProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DanhMuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DanhMucProviderBase DanhMucProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DanhMucProvider;
			}
		}
		
		#endregion
		
		#region ChuCongTyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ChuCongTy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ChuCongTyProviderBase ChuCongTyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ChuCongTyProvider;
			}
		}
		
		#endregion
		
		#region CongTyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CongTy"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CongTyProviderBase CongTyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CongTyProvider;
			}
		}
		
		#endregion
		
		#region CommentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Comment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CommentProviderBase CommentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CommentProvider;
			}
		}
		
		#endregion
		
		#region DichVuProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DichVu"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DichVuProviderBase DichVuProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DichVuProvider;
			}
		}
		
		#endregion
		
		#region LabelLanguageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="LabelLanguage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LabelLanguageProviderBase LabelLanguageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LabelLanguageProvider;
			}
		}
		
		#endregion
		
		#region DuongProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Duong"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DuongProviderBase DuongProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DuongProvider;
			}
		}
		
		#endregion
		
		#region KhuVucProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KhuVuc"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KhuVucProviderBase KhuVucProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KhuVucProvider;
			}
		}
		
		#endregion
		
		#region UserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserProviderBase UserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserProvider;
			}
		}
		
		#endregion
		
		#region GalleryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Gallery"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GalleryProviderBase GalleryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GalleryProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region QuocGiaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuocGia"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuocGiaFilters : QuocGiaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuocGiaFilters class.
		/// </summary>
		public QuocGiaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuocGiaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuocGiaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuocGiaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuocGiaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuocGiaFilters
	
	#region QuocGiaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuocGiaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuocGia"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuocGiaQuery : QuocGiaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuocGiaQuery class.
		/// </summary>
		public QuocGiaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuocGiaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuocGiaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuocGiaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuocGiaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuocGiaQuery
		
	#region AdminFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Admin"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminFilters : AdminFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminFilters class.
		/// </summary>
		public AdminFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminFilters
	
	#region AdminQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Admin"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminQuery : AdminParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminQuery class.
		/// </summary>
		public AdminQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminQuery
		
	#region SanPhamFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamFilters : SanPhamFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamFilters class.
		/// </summary>
		public SanPhamFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SanPhamFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SanPhamFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SanPhamFilters
	
	#region SanPhamQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SanPhamParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamQuery : SanPhamParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamQuery class.
		/// </summary>
		public SanPhamQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SanPhamQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SanPhamQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SanPhamQuery
		
	#region LoaiSpFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpFilters : LoaiSpFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilters class.
		/// </summary>
		public LoaiSpFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiSpFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiSpFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiSpFilters
	
	#region LoaiSpQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LoaiSpParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpQuery : LoaiSpParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpQuery class.
		/// </summary>
		public LoaiSpQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiSpQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiSpQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiSpQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiSpQuery
		
	#region ThanhPhoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThanhPho"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThanhPhoFilters : ThanhPhoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilters class.
		/// </summary>
		public ThanhPhoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThanhPhoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThanhPhoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThanhPhoFilters
	
	#region ThanhPhoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ThanhPhoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ThanhPho"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThanhPhoQuery : ThanhPhoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThanhPhoQuery class.
		/// </summary>
		public ThanhPhoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThanhPhoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThanhPhoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThanhPhoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThanhPhoQuery
		
	#region ThuocTinhFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhFilters : ThuocTinhFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilters class.
		/// </summary>
		public ThuocTinhFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhFilters
	
	#region ThuocTinhQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ThuocTinhParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhQuery : ThuocTinhParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhQuery class.
		/// </summary>
		public ThuocTinhQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhQuery
		
	#region TuDienFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienFilters : TuDienFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienFilters class.
		/// </summary>
		public TuDienFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TuDienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TuDienFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TuDienFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TuDienFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TuDienFilters
	
	#region TuDienQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TuDienParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienQuery : TuDienParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienQuery class.
		/// </summary>
		public TuDienQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TuDienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TuDienQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TuDienQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TuDienQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TuDienQuery
		
	#region QuanFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanFilters : QuanFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanFilters class.
		/// </summary>
		public QuanFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanFilters
	
	#region QuanQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuanParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanQuery : QuanParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanQuery class.
		/// </summary>
		public QuanQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuanQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuanQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuanQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuanQuery
		
	#region TinTucFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucFilters : TinTucFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucFilters class.
		/// </summary>
		public TinTucFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TinTucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TinTucFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TinTucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TinTucFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TinTucFilters
	
	#region TinTucQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TinTucParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucQuery : TinTucParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucQuery class.
		/// </summary>
		public TinTucQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TinTucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TinTucQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TinTucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TinTucQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TinTucQuery
		
	#region ThuocTinhSanPhamFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamFilters : ThuocTinhSanPhamFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilters class.
		/// </summary>
		public ThuocTinhSanPhamFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhSanPhamFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhSanPhamFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhSanPhamFilters
	
	#region ThuocTinhSanPhamQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ThuocTinhSanPhamParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamQuery : ThuocTinhSanPhamParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamQuery class.
		/// </summary>
		public ThuocTinhSanPhamQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ThuocTinhSanPhamQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ThuocTinhSanPhamQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ThuocTinhSanPhamQuery
		
	#region LanguageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageFilters : LanguageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		public LanguageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageFilters
	
	#region LanguageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LanguageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageQuery : LanguageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		public LanguageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguageQuery
		
	#region LabelNnFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnFilters : LabelNnFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnFilters class.
		/// </summary>
		public LabelNnFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelNnFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelNnFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelNnFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelNnFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelNnFilters
	
	#region LabelNnQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LabelNnParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnQuery : LabelNnParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnQuery class.
		/// </summary>
		public LabelNnQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelNnQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelNnQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelNnQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelNnQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelNnQuery
		
	#region DanhMucFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucFilters : DanhMucFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucFilters class.
		/// </summary>
		public DanhMucFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DanhMucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DanhMucFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DanhMucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DanhMucFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DanhMucFilters
	
	#region DanhMucQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DanhMucParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucQuery : DanhMucParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucQuery class.
		/// </summary>
		public DanhMucQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DanhMucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DanhMucQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DanhMucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DanhMucQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DanhMucQuery
		
	#region ChuCongTyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyFilters : ChuCongTyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilters class.
		/// </summary>
		public ChuCongTyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChuCongTyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChuCongTyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChuCongTyFilters
	
	#region ChuCongTyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChuCongTyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyQuery : ChuCongTyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyQuery class.
		/// </summary>
		public ChuCongTyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ChuCongTyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ChuCongTyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ChuCongTyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ChuCongTyQuery
		
	#region CongTyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyFilters : CongTyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyFilters class.
		/// </summary>
		public CongTyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CongTyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CongTyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CongTyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CongTyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CongTyFilters
	
	#region CongTyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CongTyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyQuery : CongTyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyQuery class.
		/// </summary>
		public CongTyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CongTyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CongTyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CongTyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CongTyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CongTyQuery
		
	#region CommentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentFilters : CommentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentFilters class.
		/// </summary>
		public CommentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommentFilters
	
	#region CommentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CommentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Comment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CommentQuery : CommentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CommentQuery class.
		/// </summary>
		public CommentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CommentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CommentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CommentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CommentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CommentQuery
		
	#region DichVuFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuFilters : DichVuFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuFilters class.
		/// </summary>
		public DichVuFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DichVuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DichVuFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DichVuFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DichVuFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DichVuFilters
	
	#region DichVuQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DichVuParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuQuery : DichVuParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuQuery class.
		/// </summary>
		public DichVuQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DichVuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DichVuQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DichVuQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DichVuQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DichVuQuery
		
	#region LabelLanguageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageFilters : LabelLanguageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilters class.
		/// </summary>
		public LabelLanguageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelLanguageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelLanguageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelLanguageFilters
	
	#region LabelLanguageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LabelLanguageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageQuery : LabelLanguageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageQuery class.
		/// </summary>
		public LabelLanguageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LabelLanguageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LabelLanguageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LabelLanguageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LabelLanguageQuery
		
	#region DuongFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongFilters : DuongFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongFilters class.
		/// </summary>
		public DuongFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DuongFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DuongFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DuongFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DuongFilters
	
	#region DuongQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DuongParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongQuery : DuongParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongQuery class.
		/// </summary>
		public DuongQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DuongQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DuongQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DuongQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DuongQuery
		
	#region KhuVucFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucFilters : KhuVucFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucFilters class.
		/// </summary>
		public KhuVucFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuVucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuVucFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuVucFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuVucFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuVucFilters
	
	#region KhuVucQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KhuVucParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucQuery : KhuVucParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucQuery class.
		/// </summary>
		public KhuVucQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuVucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuVucQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuVucQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuVucQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuVucQuery
		
	#region UserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilters : UserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		public UserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilters
	
	#region UserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserQuery : UserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		public UserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserQuery
		
	#region GalleryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryFilters : GalleryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryFilters class.
		/// </summary>
		public GalleryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GalleryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GalleryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GalleryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GalleryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GalleryFilters
	
	#region GalleryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GalleryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryQuery : GalleryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryQuery class.
		/// </summary>
		public GalleryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GalleryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GalleryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GalleryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GalleryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GalleryQuery
	#endregion

	
}
