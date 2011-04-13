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
	/// Represents the DataRepository.DanhMucProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DanhMucDataSourceDesigner))]
	public class DanhMucDataSource : ProviderDataSource<DanhMuc, DanhMucKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucDataSource class.
		/// </summary>
		public DanhMucDataSource() : base(new DanhMucService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DanhMucDataSourceView used by the DanhMucDataSource.
		/// </summary>
		protected DanhMucDataSourceView DanhMucView
		{
			get { return ( View as DanhMucDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DanhMucDataSource control invokes to retrieve data.
		/// </summary>
		public DanhMucSelectMethod SelectMethod
		{
			get
			{
				DanhMucSelectMethod selectMethod = DanhMucSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DanhMucSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DanhMucDataSourceView class that is to be
		/// used by the DanhMucDataSource.
		/// </summary>
		/// <returns>An instance of the DanhMucDataSourceView class.</returns>
		protected override BaseDataSourceView<DanhMuc, DanhMucKey> GetNewDataSourceView()
		{
			return new DanhMucDataSourceView(this, DefaultViewName);
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
	/// Supports the DanhMucDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DanhMucDataSourceView : ProviderDataSourceView<DanhMuc, DanhMucKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DanhMucDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DanhMucDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DanhMucDataSourceView(DanhMucDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DanhMucDataSource DanhMucOwner
		{
			get { return Owner as DanhMucDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DanhMucSelectMethod SelectMethod
		{
			get { return DanhMucOwner.SelectMethod; }
			set { DanhMucOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DanhMucService DanhMucProvider
		{
			get { return Provider as DanhMucService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DanhMuc> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DanhMuc> results = null;
			DanhMuc item;
			count = 0;
			
			System.Int64 idDanhMuc;

			switch ( SelectMethod )
			{
				case DanhMucSelectMethod.Get:
					DanhMucKey entityKey  = new DanhMucKey();
					entityKey.Load(values);
					item = DanhMucProvider.Get(entityKey);
					results = new TList<DanhMuc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DanhMucSelectMethod.GetAll:
                    results = DanhMucProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DanhMucSelectMethod.GetPaged:
					results = DanhMucProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DanhMucSelectMethod.Find:
					if ( FilterParameters != null )
						results = DanhMucProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DanhMucProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DanhMucSelectMethod.GetByIdDanhMuc:
					idDanhMuc = ( values["IdDanhMuc"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdDanhMuc"], typeof(System.Int64)) : (long)0;
					item = DanhMucProvider.GetByIdDanhMuc(idDanhMuc);
					results = new TList<DanhMuc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == DanhMucSelectMethod.Get || SelectMethod == DanhMucSelectMethod.GetByIdDanhMuc )
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
				DanhMuc entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DanhMucProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DanhMuc> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DanhMucProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DanhMucDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DanhMucDataSource class.
	/// </summary>
	public class DanhMucDataSourceDesigner : ProviderDataSourceDesigner<DanhMuc, DanhMucKey>
	{
		/// <summary>
		/// Initializes a new instance of the DanhMucDataSourceDesigner class.
		/// </summary>
		public DanhMucDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DanhMucSelectMethod SelectMethod
		{
			get { return ((DanhMucDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DanhMucDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DanhMucDataSourceActionList

	/// <summary>
	/// Supports the DanhMucDataSourceDesigner class.
	/// </summary>
	internal class DanhMucDataSourceActionList : DesignerActionList
	{
		private DanhMucDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DanhMucDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DanhMucDataSourceActionList(DanhMucDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DanhMucSelectMethod SelectMethod
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

	#endregion DanhMucDataSourceActionList
	
	#endregion DanhMucDataSourceDesigner
	
	#region DanhMucSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DanhMucDataSource.SelectMethod property.
	/// </summary>
	public enum DanhMucSelectMethod
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
		/// Represents the GetByIdDanhMuc method.
		/// </summary>
		GetByIdDanhMuc
	}
	
	#endregion DanhMucSelectMethod

	#region DanhMucFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucFilter : SqlFilter<DanhMucColumn>
	{
	}
	
	#endregion DanhMucFilter

	#region DanhMucExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucExpressionBuilder : SqlExpressionBuilder<DanhMucColumn>
	{
	}
	
	#endregion DanhMucExpressionBuilder	

	#region DanhMucProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DanhMucChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DanhMuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DanhMucProperty : ChildEntityProperty<DanhMucChildEntityTypes>
	{
	}
	
	#endregion DanhMucProperty
}

