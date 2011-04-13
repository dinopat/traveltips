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
	/// Represents the DataRepository.SanPhamProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SanPhamDataSourceDesigner))]
	public class SanPhamDataSource : ProviderDataSource<SanPham, SanPhamKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamDataSource class.
		/// </summary>
		public SanPhamDataSource() : base(new SanPhamService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SanPhamDataSourceView used by the SanPhamDataSource.
		/// </summary>
		protected SanPhamDataSourceView SanPhamView
		{
			get { return ( View as SanPhamDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SanPhamDataSource control invokes to retrieve data.
		/// </summary>
		public SanPhamSelectMethod SelectMethod
		{
			get
			{
				SanPhamSelectMethod selectMethod = SanPhamSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SanPhamSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SanPhamDataSourceView class that is to be
		/// used by the SanPhamDataSource.
		/// </summary>
		/// <returns>An instance of the SanPhamDataSourceView class.</returns>
		protected override BaseDataSourceView<SanPham, SanPhamKey> GetNewDataSourceView()
		{
			return new SanPhamDataSourceView(this, DefaultViewName);
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
	/// Supports the SanPhamDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SanPhamDataSourceView : ProviderDataSourceView<SanPham, SanPhamKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SanPhamDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SanPhamDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SanPhamDataSourceView(SanPhamDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SanPhamDataSource SanPhamOwner
		{
			get { return Owner as SanPhamDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SanPhamSelectMethod SelectMethod
		{
			get { return SanPhamOwner.SelectMethod; }
			set { SanPhamOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SanPhamService SanPhamProvider
		{
			get { return Provider as SanPhamService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SanPham> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SanPham> results = null;
			SanPham item;
			count = 0;
			
			System.Int64 idSanPham;
			System.Int64? idLoaiSp_nullable;

			switch ( SelectMethod )
			{
				case SanPhamSelectMethod.Get:
					SanPhamKey entityKey  = new SanPhamKey();
					entityKey.Load(values);
					item = SanPhamProvider.Get(entityKey);
					results = new TList<SanPham>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SanPhamSelectMethod.GetAll:
                    results = SanPhamProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SanPhamSelectMethod.GetPaged:
					results = SanPhamProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SanPhamSelectMethod.Find:
					if ( FilterParameters != null )
						results = SanPhamProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SanPhamProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SanPhamSelectMethod.GetByIdSanPham:
					idSanPham = ( values["IdSanPham"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdSanPham"], typeof(System.Int64)) : (long)0;
					item = SanPhamProvider.GetByIdSanPham(idSanPham);
					results = new TList<SanPham>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SanPhamSelectMethod.GetByIdLoaiSp:
					idLoaiSp_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdLoaiSp"], typeof(System.Int64?));
					results = SanPhamProvider.GetByIdLoaiSp(idLoaiSp_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SanPhamSelectMethod.Get || SelectMethod == SanPhamSelectMethod.GetByIdSanPham )
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
				SanPham entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SanPhamProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SanPham> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SanPhamProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SanPhamDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SanPhamDataSource class.
	/// </summary>
	public class SanPhamDataSourceDesigner : ProviderDataSourceDesigner<SanPham, SanPhamKey>
	{
		/// <summary>
		/// Initializes a new instance of the SanPhamDataSourceDesigner class.
		/// </summary>
		public SanPhamDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SanPhamSelectMethod SelectMethod
		{
			get { return ((SanPhamDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SanPhamDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SanPhamDataSourceActionList

	/// <summary>
	/// Supports the SanPhamDataSourceDesigner class.
	/// </summary>
	internal class SanPhamDataSourceActionList : DesignerActionList
	{
		private SanPhamDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SanPhamDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SanPhamDataSourceActionList(SanPhamDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SanPhamSelectMethod SelectMethod
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

	#endregion SanPhamDataSourceActionList
	
	#endregion SanPhamDataSourceDesigner
	
	#region SanPhamSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SanPhamDataSource.SelectMethod property.
	/// </summary>
	public enum SanPhamSelectMethod
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
		/// Represents the GetByIdSanPham method.
		/// </summary>
		GetByIdSanPham,
		/// <summary>
		/// Represents the GetByIdLoaiSp method.
		/// </summary>
		GetByIdLoaiSp
	}
	
	#endregion SanPhamSelectMethod

	#region SanPhamFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamFilter : SqlFilter<SanPhamColumn>
	{
	}
	
	#endregion SanPhamFilter

	#region SanPhamExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamExpressionBuilder : SqlExpressionBuilder<SanPhamColumn>
	{
	}
	
	#endregion SanPhamExpressionBuilder	

	#region SanPhamProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SanPhamChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SanPhamProperty : ChildEntityProperty<SanPhamChildEntityTypes>
	{
	}
	
	#endregion SanPhamProperty
}

