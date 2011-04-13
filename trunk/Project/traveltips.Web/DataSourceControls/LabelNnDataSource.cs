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
	/// Represents the DataRepository.LabelNnProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LabelNnDataSourceDesigner))]
	public class LabelNnDataSource : ProviderDataSource<LabelNn, LabelNnKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnDataSource class.
		/// </summary>
		public LabelNnDataSource() : base(new LabelNnService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LabelNnDataSourceView used by the LabelNnDataSource.
		/// </summary>
		protected LabelNnDataSourceView LabelNnView
		{
			get { return ( View as LabelNnDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LabelNnDataSource control invokes to retrieve data.
		/// </summary>
		public LabelNnSelectMethod SelectMethod
		{
			get
			{
				LabelNnSelectMethod selectMethod = LabelNnSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LabelNnSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LabelNnDataSourceView class that is to be
		/// used by the LabelNnDataSource.
		/// </summary>
		/// <returns>An instance of the LabelNnDataSourceView class.</returns>
		protected override BaseDataSourceView<LabelNn, LabelNnKey> GetNewDataSourceView()
		{
			return new LabelNnDataSourceView(this, DefaultViewName);
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
	/// Supports the LabelNnDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LabelNnDataSourceView : ProviderDataSourceView<LabelNn, LabelNnKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelNnDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LabelNnDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LabelNnDataSourceView(LabelNnDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LabelNnDataSource LabelNnOwner
		{
			get { return Owner as LabelNnDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LabelNnSelectMethod SelectMethod
		{
			get { return LabelNnOwner.SelectMethod; }
			set { LabelNnOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LabelNnService LabelNnProvider
		{
			get { return Provider as LabelNnService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LabelNn> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LabelNn> results = null;
			LabelNn item;
			count = 0;
			
			System.Int64 idLabel;

			switch ( SelectMethod )
			{
				case LabelNnSelectMethod.Get:
					LabelNnKey entityKey  = new LabelNnKey();
					entityKey.Load(values);
					item = LabelNnProvider.Get(entityKey);
					results = new TList<LabelNn>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LabelNnSelectMethod.GetAll:
                    results = LabelNnProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LabelNnSelectMethod.GetPaged:
					results = LabelNnProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LabelNnSelectMethod.Find:
					if ( FilterParameters != null )
						results = LabelNnProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LabelNnProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LabelNnSelectMethod.GetByIdLabel:
					idLabel = ( values["IdLabel"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLabel"], typeof(System.Int64)) : (long)0;
					item = LabelNnProvider.GetByIdLabel(idLabel);
					results = new TList<LabelNn>();
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
			if ( SelectMethod == LabelNnSelectMethod.Get || SelectMethod == LabelNnSelectMethod.GetByIdLabel )
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
				LabelNn entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LabelNnProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LabelNn> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LabelNnProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LabelNnDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LabelNnDataSource class.
	/// </summary>
	public class LabelNnDataSourceDesigner : ProviderDataSourceDesigner<LabelNn, LabelNnKey>
	{
		/// <summary>
		/// Initializes a new instance of the LabelNnDataSourceDesigner class.
		/// </summary>
		public LabelNnDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LabelNnSelectMethod SelectMethod
		{
			get { return ((LabelNnDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LabelNnDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LabelNnDataSourceActionList

	/// <summary>
	/// Supports the LabelNnDataSourceDesigner class.
	/// </summary>
	internal class LabelNnDataSourceActionList : DesignerActionList
	{
		private LabelNnDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LabelNnDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LabelNnDataSourceActionList(LabelNnDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LabelNnSelectMethod SelectMethod
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

	#endregion LabelNnDataSourceActionList
	
	#endregion LabelNnDataSourceDesigner
	
	#region LabelNnSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LabelNnDataSource.SelectMethod property.
	/// </summary>
	public enum LabelNnSelectMethod
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
		/// Represents the GetByIdLabel method.
		/// </summary>
		GetByIdLabel
	}
	
	#endregion LabelNnSelectMethod

	#region LabelNnFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnFilter : SqlFilter<LabelNnColumn>
	{
	}
	
	#endregion LabelNnFilter

	#region LabelNnExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnExpressionBuilder : SqlExpressionBuilder<LabelNnColumn>
	{
	}
	
	#endregion LabelNnExpressionBuilder	

	#region LabelNnProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LabelNnChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LabelNn"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelNnProperty : ChildEntityProperty<LabelNnChildEntityTypes>
	{
	}
	
	#endregion LabelNnProperty
}

