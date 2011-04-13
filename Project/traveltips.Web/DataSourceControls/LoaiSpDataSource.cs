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
	/// Represents the DataRepository.LoaiSpProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LoaiSpDataSourceDesigner))]
	public class LoaiSpDataSource : ProviderDataSource<LoaiSp, LoaiSpKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpDataSource class.
		/// </summary>
		public LoaiSpDataSource() : base(new LoaiSpService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LoaiSpDataSourceView used by the LoaiSpDataSource.
		/// </summary>
		protected LoaiSpDataSourceView LoaiSpView
		{
			get { return ( View as LoaiSpDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LoaiSpDataSource control invokes to retrieve data.
		/// </summary>
		public LoaiSpSelectMethod SelectMethod
		{
			get
			{
				LoaiSpSelectMethod selectMethod = LoaiSpSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LoaiSpSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LoaiSpDataSourceView class that is to be
		/// used by the LoaiSpDataSource.
		/// </summary>
		/// <returns>An instance of the LoaiSpDataSourceView class.</returns>
		protected override BaseDataSourceView<LoaiSp, LoaiSpKey> GetNewDataSourceView()
		{
			return new LoaiSpDataSourceView(this, DefaultViewName);
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
	/// Supports the LoaiSpDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LoaiSpDataSourceView : ProviderDataSourceView<LoaiSp, LoaiSpKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiSpDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LoaiSpDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LoaiSpDataSourceView(LoaiSpDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LoaiSpDataSource LoaiSpOwner
		{
			get { return Owner as LoaiSpDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LoaiSpSelectMethod SelectMethod
		{
			get { return LoaiSpOwner.SelectMethod; }
			set { LoaiSpOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LoaiSpService LoaiSpProvider
		{
			get { return Provider as LoaiSpService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LoaiSp> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LoaiSp> results = null;
			LoaiSp item;
			count = 0;
			
			System.Int64 idLoaiSp;

			switch ( SelectMethod )
			{
				case LoaiSpSelectMethod.Get:
					LoaiSpKey entityKey  = new LoaiSpKey();
					entityKey.Load(values);
					item = LoaiSpProvider.Get(entityKey);
					results = new TList<LoaiSp>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LoaiSpSelectMethod.GetAll:
                    results = LoaiSpProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LoaiSpSelectMethod.GetPaged:
					results = LoaiSpProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LoaiSpSelectMethod.Find:
					if ( FilterParameters != null )
						results = LoaiSpProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LoaiSpProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LoaiSpSelectMethod.GetByIdLoaiSp:
					idLoaiSp = ( values["IdLoaiSp"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLoaiSp"], typeof(System.Int64)) : (long)0;
					item = LoaiSpProvider.GetByIdLoaiSp(idLoaiSp);
					results = new TList<LoaiSp>();
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
			if ( SelectMethod == LoaiSpSelectMethod.Get || SelectMethod == LoaiSpSelectMethod.GetByIdLoaiSp )
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
				LoaiSp entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LoaiSpProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LoaiSp> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LoaiSpProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LoaiSpDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LoaiSpDataSource class.
	/// </summary>
	public class LoaiSpDataSourceDesigner : ProviderDataSourceDesigner<LoaiSp, LoaiSpKey>
	{
		/// <summary>
		/// Initializes a new instance of the LoaiSpDataSourceDesigner class.
		/// </summary>
		public LoaiSpDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LoaiSpSelectMethod SelectMethod
		{
			get { return ((LoaiSpDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LoaiSpDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LoaiSpDataSourceActionList

	/// <summary>
	/// Supports the LoaiSpDataSourceDesigner class.
	/// </summary>
	internal class LoaiSpDataSourceActionList : DesignerActionList
	{
		private LoaiSpDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LoaiSpDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LoaiSpDataSourceActionList(LoaiSpDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LoaiSpSelectMethod SelectMethod
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

	#endregion LoaiSpDataSourceActionList
	
	#endregion LoaiSpDataSourceDesigner
	
	#region LoaiSpSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LoaiSpDataSource.SelectMethod property.
	/// </summary>
	public enum LoaiSpSelectMethod
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
		/// Represents the GetByIdLoaiSp method.
		/// </summary>
		GetByIdLoaiSp
	}
	
	#endregion LoaiSpSelectMethod

	#region LoaiSpFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpFilter : SqlFilter<LoaiSpColumn>
	{
	}
	
	#endregion LoaiSpFilter

	#region LoaiSpExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpExpressionBuilder : SqlExpressionBuilder<LoaiSpColumn>
	{
	}
	
	#endregion LoaiSpExpressionBuilder	

	#region LoaiSpProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LoaiSpChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiSp"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiSpProperty : ChildEntityProperty<LoaiSpChildEntityTypes>
	{
	}
	
	#endregion LoaiSpProperty
}

