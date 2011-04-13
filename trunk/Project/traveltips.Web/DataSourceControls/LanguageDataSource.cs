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
	/// Represents the DataRepository.LanguageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LanguageDataSourceDesigner))]
	public class LanguageDataSource : ProviderDataSource<Language, LanguageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageDataSource class.
		/// </summary>
		public LanguageDataSource() : base(new LanguageService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LanguageDataSourceView used by the LanguageDataSource.
		/// </summary>
		protected LanguageDataSourceView LanguageView
		{
			get { return ( View as LanguageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LanguageDataSource control invokes to retrieve data.
		/// </summary>
		public LanguageSelectMethod SelectMethod
		{
			get
			{
				LanguageSelectMethod selectMethod = LanguageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LanguageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LanguageDataSourceView class that is to be
		/// used by the LanguageDataSource.
		/// </summary>
		/// <returns>An instance of the LanguageDataSourceView class.</returns>
		protected override BaseDataSourceView<Language, LanguageKey> GetNewDataSourceView()
		{
			return new LanguageDataSourceView(this, DefaultViewName);
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
	/// Supports the LanguageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LanguageDataSourceView : ProviderDataSourceView<Language, LanguageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LanguageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LanguageDataSourceView(LanguageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LanguageDataSource LanguageOwner
		{
			get { return Owner as LanguageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LanguageSelectMethod SelectMethod
		{
			get { return LanguageOwner.SelectMethod; }
			set { LanguageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LanguageService LanguageProvider
		{
			get { return Provider as LanguageService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Language> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Language> results = null;
			Language item;
			count = 0;
			
			System.Int32 idLanguage;

			switch ( SelectMethod )
			{
				case LanguageSelectMethod.Get:
					LanguageKey entityKey  = new LanguageKey();
					entityKey.Load(values);
					item = LanguageProvider.Get(entityKey);
					results = new TList<Language>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LanguageSelectMethod.GetAll:
                    results = LanguageProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LanguageSelectMethod.GetPaged:
					results = LanguageProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LanguageSelectMethod.Find:
					if ( FilterParameters != null )
						results = LanguageProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LanguageProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LanguageSelectMethod.GetByIdLanguage:
					idLanguage = ( values["IdLanguage"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["IdLanguage"], typeof(System.Int32)) : (int)0;
					item = LanguageProvider.GetByIdLanguage(idLanguage);
					results = new TList<Language>();
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
			if ( SelectMethod == LanguageSelectMethod.Get || SelectMethod == LanguageSelectMethod.GetByIdLanguage )
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
				Language entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LanguageProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Language> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LanguageProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LanguageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LanguageDataSource class.
	/// </summary>
	public class LanguageDataSourceDesigner : ProviderDataSourceDesigner<Language, LanguageKey>
	{
		/// <summary>
		/// Initializes a new instance of the LanguageDataSourceDesigner class.
		/// </summary>
		public LanguageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LanguageSelectMethod SelectMethod
		{
			get { return ((LanguageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LanguageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LanguageDataSourceActionList

	/// <summary>
	/// Supports the LanguageDataSourceDesigner class.
	/// </summary>
	internal class LanguageDataSourceActionList : DesignerActionList
	{
		private LanguageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LanguageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LanguageDataSourceActionList(LanguageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LanguageSelectMethod SelectMethod
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

	#endregion LanguageDataSourceActionList
	
	#endregion LanguageDataSourceDesigner
	
	#region LanguageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LanguageDataSource.SelectMethod property.
	/// </summary>
	public enum LanguageSelectMethod
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
		/// Represents the GetByIdLanguage method.
		/// </summary>
		GetByIdLanguage
	}
	
	#endregion LanguageSelectMethod

	#region LanguageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageFilter : SqlFilter<LanguageColumn>
	{
	}
	
	#endregion LanguageFilter

	#region LanguageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageExpressionBuilder : SqlExpressionBuilder<LanguageColumn>
	{
	}
	
	#endregion LanguageExpressionBuilder	

	#region LanguageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LanguageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Language"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguageProperty : ChildEntityProperty<LanguageChildEntityTypes>
	{
	}
	
	#endregion LanguageProperty
}

