#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using traveltips.Entities;
using traveltips.DAO;
using traveltips.DAO.Bases;
using traveltips.Services;
#endregion

namespace traveltips.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ThuocTinhSanPhamProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ThuocTinhSanPhamDataSourceDesigner))]
	public class ThuocTinhSanPhamDataSource : ProviderDataSource<ThuocTinhSanPham, ThuocTinhSanPhamKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamDataSource class.
		/// </summary>
		public ThuocTinhSanPhamDataSource() : base(new ThuocTinhSanPhamService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ThuocTinhSanPhamDataSourceView used by the ThuocTinhSanPhamDataSource.
		/// </summary>
		protected ThuocTinhSanPhamDataSourceView ThuocTinhSanPhamView
		{
			get { return ( View as ThuocTinhSanPhamDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ThuocTinhSanPhamDataSource control invokes to retrieve data.
		/// </summary>
		public ThuocTinhSanPhamSelectMethod SelectMethod
		{
			get
			{
				ThuocTinhSanPhamSelectMethod selectMethod = ThuocTinhSanPhamSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ThuocTinhSanPhamSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ThuocTinhSanPhamDataSourceView class that is to be
		/// used by the ThuocTinhSanPhamDataSource.
		/// </summary>
		/// <returns>An instance of the ThuocTinhSanPhamDataSourceView class.</returns>
		protected override BaseDataSourceView<ThuocTinhSanPham, ThuocTinhSanPhamKey> GetNewDataSourceView()
		{
			return new ThuocTinhSanPhamDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the ThuocTinhSanPhamDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ThuocTinhSanPhamDataSourceView : ProviderDataSourceView<ThuocTinhSanPham, ThuocTinhSanPhamKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ThuocTinhSanPhamDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ThuocTinhSanPhamDataSourceView(ThuocTinhSanPhamDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ThuocTinhSanPhamDataSource ThuocTinhSanPhamOwner
		{
			get { return Owner as ThuocTinhSanPhamDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ThuocTinhSanPhamSelectMethod SelectMethod
		{
			get { return ThuocTinhSanPhamOwner.SelectMethod; }
			set { ThuocTinhSanPhamOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ThuocTinhSanPhamService ThuocTinhSanPhamProvider
		{
			get { return Provider as ThuocTinhSanPhamService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ThuocTinhSanPham> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ThuocTinhSanPham> results = null;
			ThuocTinhSanPham item;
			count = 0;
			
			System.Int64 idTtsp;
			System.Int64? idThuocTinh_nullable;
			System.Int64? idSanPham_nullable;

			switch ( SelectMethod )
			{
				case ThuocTinhSanPhamSelectMethod.Get:
					ThuocTinhSanPhamKey entityKey  = new ThuocTinhSanPhamKey();
					entityKey.Load(values);
					item = ThuocTinhSanPhamProvider.Get(entityKey);
					results = new TList<ThuocTinhSanPham>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ThuocTinhSanPhamSelectMethod.GetAll:
                    results = ThuocTinhSanPhamProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ThuocTinhSanPhamSelectMethod.GetPaged:
					results = ThuocTinhSanPhamProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ThuocTinhSanPhamSelectMethod.Find:
					if ( FilterParameters != null )
						results = ThuocTinhSanPhamProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ThuocTinhSanPhamProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ThuocTinhSanPhamSelectMethod.GetByIdTtsp:
					idTtsp = ( values["IdTtsp"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdTtsp"], typeof(System.Int64)) : (long)0;
					item = ThuocTinhSanPhamProvider.GetByIdTtsp(idTtsp);
					results = new TList<ThuocTinhSanPham>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ThuocTinhSanPhamSelectMethod.GetByIdThuocTinh:
					idThuocTinh_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdThuocTinh"], typeof(System.Int64?));
					results = ThuocTinhSanPhamProvider.GetByIdThuocTinh(idThuocTinh_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ThuocTinhSanPhamSelectMethod.GetByIdSanPham:
					idSanPham_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdSanPham"], typeof(System.Int64?));
					results = ThuocTinhSanPhamProvider.GetByIdSanPham(idSanPham_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ThuocTinhSanPhamSelectMethod.Get || SelectMethod == ThuocTinhSanPhamSelectMethod.GetByIdTtsp )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				ThuocTinhSanPham entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ThuocTinhSanPhamProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<ThuocTinhSanPham> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ThuocTinhSanPhamProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ThuocTinhSanPhamDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ThuocTinhSanPhamDataSource class.
	/// </summary>
	public class ThuocTinhSanPhamDataSourceDesigner : ProviderDataSourceDesigner<ThuocTinhSanPham, ThuocTinhSanPhamKey>
	{
		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamDataSourceDesigner class.
		/// </summary>
		public ThuocTinhSanPhamDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ThuocTinhSanPhamSelectMethod SelectMethod
		{
			get { return ((ThuocTinhSanPhamDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ThuocTinhSanPhamDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ThuocTinhSanPhamDataSourceActionList

	/// <summary>
	/// Supports the ThuocTinhSanPhamDataSourceDesigner class.
	/// </summary>
	internal class ThuocTinhSanPhamDataSourceActionList : DesignerActionList
	{
		private ThuocTinhSanPhamDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ThuocTinhSanPhamDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ThuocTinhSanPhamDataSourceActionList(ThuocTinhSanPhamDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ThuocTinhSanPhamSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ThuocTinhSanPhamDataSourceActionList
	
	#endregion ThuocTinhSanPhamDataSourceDesigner
	
	#region ThuocTinhSanPhamSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ThuocTinhSanPhamDataSource.SelectMethod property.
	/// </summary>
	public enum ThuocTinhSanPhamSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByIdTtsp method.
		/// </summary>
		GetByIdTtsp,
		/// <summary>
		/// Represents the GetByIdThuocTinh method.
		/// </summary>
		GetByIdThuocTinh,
		/// <summary>
		/// Represents the GetByIdSanPham method.
		/// </summary>
		GetByIdSanPham
	}
	
	#endregion ThuocTinhSanPhamSelectMethod

	#region ThuocTinhSanPhamFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamFilter : SqlFilter<ThuocTinhSanPhamColumn>
	{
	}
	
	#endregion ThuocTinhSanPhamFilter

	#region ThuocTinhSanPhamExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamExpressionBuilder : SqlExpressionBuilder<ThuocTinhSanPhamColumn>
	{
	}
	
	#endregion ThuocTinhSanPhamExpressionBuilder	

	#region ThuocTinhSanPhamProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ThuocTinhSanPhamChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinhSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhSanPhamProperty : ChildEntityProperty<ThuocTinhSanPhamChildEntityTypes>
	{
	}
	
	#endregion ThuocTinhSanPhamProperty
}

