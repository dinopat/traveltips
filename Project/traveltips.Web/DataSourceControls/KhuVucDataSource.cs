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
	/// Represents the DataRepository.KhuVucProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(KhuVucDataSourceDesigner))]
	public class KhuVucDataSource : ProviderDataSource<KhuVuc, KhuVucKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucDataSource class.
		/// </summary>
		public KhuVucDataSource() : base(new KhuVucService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the KhuVucDataSourceView used by the KhuVucDataSource.
		/// </summary>
		protected KhuVucDataSourceView KhuVucView
		{
			get { return ( View as KhuVucDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the KhuVucDataSource control invokes to retrieve data.
		/// </summary>
		public KhuVucSelectMethod SelectMethod
		{
			get
			{
				KhuVucSelectMethod selectMethod = KhuVucSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (KhuVucSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the KhuVucDataSourceView class that is to be
		/// used by the KhuVucDataSource.
		/// </summary>
		/// <returns>An instance of the KhuVucDataSourceView class.</returns>
		protected override BaseDataSourceView<KhuVuc, KhuVucKey> GetNewDataSourceView()
		{
			return new KhuVucDataSourceView(this, DefaultViewName);
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
	/// Supports the KhuVucDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class KhuVucDataSourceView : ProviderDataSourceView<KhuVuc, KhuVucKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuVucDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the KhuVucDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public KhuVucDataSourceView(KhuVucDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal KhuVucDataSource KhuVucOwner
		{
			get { return Owner as KhuVucDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal KhuVucSelectMethod SelectMethod
		{
			get { return KhuVucOwner.SelectMethod; }
			set { KhuVucOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal KhuVucService KhuVucProvider
		{
			get { return Provider as KhuVucService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<KhuVuc> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<KhuVuc> results = null;
			KhuVuc item;
			count = 0;
			
			System.Int64 idKhuVuc;

			switch ( SelectMethod )
			{
				case KhuVucSelectMethod.Get:
					KhuVucKey entityKey  = new KhuVucKey();
					entityKey.Load(values);
					item = KhuVucProvider.Get(entityKey);
					results = new TList<KhuVuc>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case KhuVucSelectMethod.GetAll:
                    results = KhuVucProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case KhuVucSelectMethod.GetPaged:
					results = KhuVucProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case KhuVucSelectMethod.Find:
					if ( FilterParameters != null )
						results = KhuVucProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = KhuVucProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case KhuVucSelectMethod.GetByIdKhuVuc:
					idKhuVuc = ( values["IdKhuVuc"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdKhuVuc"], typeof(System.Int64)) : (long)0;
					item = KhuVucProvider.GetByIdKhuVuc(idKhuVuc);
					results = new TList<KhuVuc>();
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
			if ( SelectMethod == KhuVucSelectMethod.Get || SelectMethod == KhuVucSelectMethod.GetByIdKhuVuc )
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
				KhuVuc entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					KhuVucProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<KhuVuc> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			KhuVucProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region KhuVucDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the KhuVucDataSource class.
	/// </summary>
	public class KhuVucDataSourceDesigner : ProviderDataSourceDesigner<KhuVuc, KhuVucKey>
	{
		/// <summary>
		/// Initializes a new instance of the KhuVucDataSourceDesigner class.
		/// </summary>
		public KhuVucDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhuVucSelectMethod SelectMethod
		{
			get { return ((KhuVucDataSource) DataSource).SelectMethod; }
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
				actions.Add(new KhuVucDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region KhuVucDataSourceActionList

	/// <summary>
	/// Supports the KhuVucDataSourceDesigner class.
	/// </summary>
	internal class KhuVucDataSourceActionList : DesignerActionList
	{
		private KhuVucDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the KhuVucDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public KhuVucDataSourceActionList(KhuVucDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public KhuVucSelectMethod SelectMethod
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

	#endregion KhuVucDataSourceActionList
	
	#endregion KhuVucDataSourceDesigner
	
	#region KhuVucSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the KhuVucDataSource.SelectMethod property.
	/// </summary>
	public enum KhuVucSelectMethod
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
		/// Represents the GetByIdKhuVuc method.
		/// </summary>
		GetByIdKhuVuc
	}
	
	#endregion KhuVucSelectMethod

	#region KhuVucFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucFilter : SqlFilter<KhuVucColumn>
	{
	}
	
	#endregion KhuVucFilter

	#region KhuVucExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucExpressionBuilder : SqlExpressionBuilder<KhuVucColumn>
	{
	}
	
	#endregion KhuVucExpressionBuilder	

	#region KhuVucProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;KhuVucChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="KhuVuc"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuVucProperty : ChildEntityProperty<KhuVucChildEntityTypes>
	{
	}
	
	#endregion KhuVucProperty
}

