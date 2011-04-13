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
	/// Represents the DataRepository.TinTucProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TinTucDataSourceDesigner))]
	public class TinTucDataSource : ProviderDataSource<TinTuc, TinTucKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucDataSource class.
		/// </summary>
		public TinTucDataSource() : base(new TinTucService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TinTucDataSourceView used by the TinTucDataSource.
		/// </summary>
		protected TinTucDataSourceView TinTucView
		{
			get { return ( View as TinTucDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TinTucDataSource control invokes to retrieve data.
		/// </summary>
		public TinTucSelectMethod SelectMethod
		{
			get
			{
				TinTucSelectMethod selectMethod = TinTucSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TinTucSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TinTucDataSourceView class that is to be
		/// used by the TinTucDataSource.
		/// </summary>
		/// <returns>An instance of the TinTucDataSourceView class.</returns>
		protected override BaseDataSourceView<TinTuc, TinTucKey> GetNewDataSourceView()
		{
			return new TinTucDataSourceView(this, DefaultViewName);
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
	/// Supports the TinTucDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TinTucDataSourceView : ProviderDataSourceView<TinTuc, TinTucKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TinTucDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TinTucDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TinTucDataSourceView(TinTucDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TinTucDataSource TinTucOwner
		{
			get { return Owner as TinTucDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TinTucSelectMethod SelectMethod
		{
			get { return TinTucOwner.SelectMethod; }
			set { TinTucOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TinTucService TinTucProvider
		{
			get { return Provider as TinTucService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TinTuc> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TinTuc> results = null;
			TinTuc item;
			count = 0;
			
			System.Int64 idTinTuc;
			System.Int64? idCongTy_nullable;

			switch ( SelectMethod )
			{
				case TinTucSelectMethod.Get:
					TinTucKey entityKey  = new TinTucKey();
					entityKey.Load(values);
					item = TinTucProvider.Get(entityKey);
					results = new TList<TinTuc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TinTucSelectMethod.GetAll:
                    results = TinTucProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TinTucSelectMethod.GetPaged:
					results = TinTucProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TinTucSelectMethod.Find:
					if ( FilterParameters != null )
						results = TinTucProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TinTucProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TinTucSelectMethod.GetByIdTinTuc:
					idTinTuc = ( values["IdTinTuc"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdTinTuc"], typeof(System.Int64)) : (long)0;
					item = TinTucProvider.GetByIdTinTuc(idTinTuc);
					results = new TList<TinTuc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case TinTucSelectMethod.GetByIdCongTy:
					idCongTy_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdCongTy"], typeof(System.Int64?));
					results = TinTucProvider.GetByIdCongTy(idCongTy_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == TinTucSelectMethod.Get || SelectMethod == TinTucSelectMethod.GetByIdTinTuc )
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
				TinTuc entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TinTucProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TinTuc> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TinTucProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TinTucDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TinTucDataSource class.
	/// </summary>
	public class TinTucDataSourceDesigner : ProviderDataSourceDesigner<TinTuc, TinTucKey>
	{
		/// <summary>
		/// Initializes a new instance of the TinTucDataSourceDesigner class.
		/// </summary>
		public TinTucDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TinTucSelectMethod SelectMethod
		{
			get { return ((TinTucDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TinTucDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TinTucDataSourceActionList

	/// <summary>
	/// Supports the TinTucDataSourceDesigner class.
	/// </summary>
	internal class TinTucDataSourceActionList : DesignerActionList
	{
		private TinTucDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TinTucDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TinTucDataSourceActionList(TinTucDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TinTucSelectMethod SelectMethod
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

	#endregion TinTucDataSourceActionList
	
	#endregion TinTucDataSourceDesigner
	
	#region TinTucSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TinTucDataSource.SelectMethod property.
	/// </summary>
	public enum TinTucSelectMethod
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
		/// Represents the GetByIdTinTuc method.
		/// </summary>
		GetByIdTinTuc,
		/// <summary>
		/// Represents the GetByIdCongTy method.
		/// </summary>
		GetByIdCongTy
	}
	
	#endregion TinTucSelectMethod

	#region TinTucFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucFilter : SqlFilter<TinTucColumn>
	{
	}
	
	#endregion TinTucFilter

	#region TinTucExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucExpressionBuilder : SqlExpressionBuilder<TinTucColumn>
	{
	}
	
	#endregion TinTucExpressionBuilder	

	#region TinTucProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TinTucChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TinTuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TinTucProperty : ChildEntityProperty<TinTucChildEntityTypes>
	{
	}
	
	#endregion TinTucProperty
}

