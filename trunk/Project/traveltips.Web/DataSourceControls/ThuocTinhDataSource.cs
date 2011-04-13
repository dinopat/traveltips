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
	/// Represents the DataRepository.ThuocTinhProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ThuocTinhDataSourceDesigner))]
	public class ThuocTinhDataSource : ProviderDataSource<ThuocTinh, ThuocTinhKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhDataSource class.
		/// </summary>
		public ThuocTinhDataSource() : base(new ThuocTinhService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ThuocTinhDataSourceView used by the ThuocTinhDataSource.
		/// </summary>
		protected ThuocTinhDataSourceView ThuocTinhView
		{
			get { return ( View as ThuocTinhDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ThuocTinhDataSource control invokes to retrieve data.
		/// </summary>
		public ThuocTinhSelectMethod SelectMethod
		{
			get
			{
				ThuocTinhSelectMethod selectMethod = ThuocTinhSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ThuocTinhSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ThuocTinhDataSourceView class that is to be
		/// used by the ThuocTinhDataSource.
		/// </summary>
		/// <returns>An instance of the ThuocTinhDataSourceView class.</returns>
		protected override BaseDataSourceView<ThuocTinh, ThuocTinhKey> GetNewDataSourceView()
		{
			return new ThuocTinhDataSourceView(this, DefaultViewName);
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
	/// Supports the ThuocTinhDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ThuocTinhDataSourceView : ProviderDataSourceView<ThuocTinh, ThuocTinhKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ThuocTinhDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ThuocTinhDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ThuocTinhDataSourceView(ThuocTinhDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ThuocTinhDataSource ThuocTinhOwner
		{
			get { return Owner as ThuocTinhDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ThuocTinhSelectMethod SelectMethod
		{
			get { return ThuocTinhOwner.SelectMethod; }
			set { ThuocTinhOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ThuocTinhService ThuocTinhProvider
		{
			get { return Provider as ThuocTinhService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ThuocTinh> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ThuocTinh> results = null;
			ThuocTinh item;
			count = 0;
			
			System.Int64 idThuocTinh;

			switch ( SelectMethod )
			{
				case ThuocTinhSelectMethod.Get:
					ThuocTinhKey entityKey  = new ThuocTinhKey();
					entityKey.Load(values);
					item = ThuocTinhProvider.Get(entityKey);
					results = new TList<ThuocTinh>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ThuocTinhSelectMethod.GetAll:
                    results = ThuocTinhProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ThuocTinhSelectMethod.GetPaged:
					results = ThuocTinhProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ThuocTinhSelectMethod.Find:
					if ( FilterParameters != null )
						results = ThuocTinhProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ThuocTinhProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ThuocTinhSelectMethod.GetByIdThuocTinh:
					idThuocTinh = ( values["IdThuocTinh"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdThuocTinh"], typeof(System.Int64)) : (long)0;
					item = ThuocTinhProvider.GetByIdThuocTinh(idThuocTinh);
					results = new TList<ThuocTinh>();
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
			if ( SelectMethod == ThuocTinhSelectMethod.Get || SelectMethod == ThuocTinhSelectMethod.GetByIdThuocTinh )
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
				ThuocTinh entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ThuocTinhProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ThuocTinh> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ThuocTinhProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ThuocTinhDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ThuocTinhDataSource class.
	/// </summary>
	public class ThuocTinhDataSourceDesigner : ProviderDataSourceDesigner<ThuocTinh, ThuocTinhKey>
	{
		/// <summary>
		/// Initializes a new instance of the ThuocTinhDataSourceDesigner class.
		/// </summary>
		public ThuocTinhDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ThuocTinhSelectMethod SelectMethod
		{
			get { return ((ThuocTinhDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ThuocTinhDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ThuocTinhDataSourceActionList

	/// <summary>
	/// Supports the ThuocTinhDataSourceDesigner class.
	/// </summary>
	internal class ThuocTinhDataSourceActionList : DesignerActionList
	{
		private ThuocTinhDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ThuocTinhDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ThuocTinhDataSourceActionList(ThuocTinhDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ThuocTinhSelectMethod SelectMethod
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

	#endregion ThuocTinhDataSourceActionList
	
	#endregion ThuocTinhDataSourceDesigner
	
	#region ThuocTinhSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ThuocTinhDataSource.SelectMethod property.
	/// </summary>
	public enum ThuocTinhSelectMethod
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
		/// Represents the GetByIdThuocTinh method.
		/// </summary>
		GetByIdThuocTinh
	}
	
	#endregion ThuocTinhSelectMethod

	#region ThuocTinhFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhFilter : SqlFilter<ThuocTinhColumn>
	{
	}
	
	#endregion ThuocTinhFilter

	#region ThuocTinhExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhExpressionBuilder : SqlExpressionBuilder<ThuocTinhColumn>
	{
	}
	
	#endregion ThuocTinhExpressionBuilder	

	#region ThuocTinhProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ThuocTinhChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ThuocTinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ThuocTinhProperty : ChildEntityProperty<ThuocTinhChildEntityTypes>
	{
	}
	
	#endregion ThuocTinhProperty
}

