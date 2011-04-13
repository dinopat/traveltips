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
	/// Represents the DataRepository.LabelLanguageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LabelLanguageDataSourceDesigner))]
	public class LabelLanguageDataSource : ProviderDataSource<LabelLanguage, LabelLanguageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageDataSource class.
		/// </summary>
		public LabelLanguageDataSource() : base(new LabelLanguageService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LabelLanguageDataSourceView used by the LabelLanguageDataSource.
		/// </summary>
		protected LabelLanguageDataSourceView LabelLanguageView
		{
			get { return ( View as LabelLanguageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LabelLanguageDataSource control invokes to retrieve data.
		/// </summary>
		public LabelLanguageSelectMethod SelectMethod
		{
			get
			{
				LabelLanguageSelectMethod selectMethod = LabelLanguageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LabelLanguageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LabelLanguageDataSourceView class that is to be
		/// used by the LabelLanguageDataSource.
		/// </summary>
		/// <returns>An instance of the LabelLanguageDataSourceView class.</returns>
		protected override BaseDataSourceView<LabelLanguage, LabelLanguageKey> GetNewDataSourceView()
		{
			return new LabelLanguageDataSourceView(this, DefaultViewName);
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
	/// Supports the LabelLanguageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LabelLanguageDataSourceView : ProviderDataSourceView<LabelLanguage, LabelLanguageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LabelLanguageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LabelLanguageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LabelLanguageDataSourceView(LabelLanguageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LabelLanguageDataSource LabelLanguageOwner
		{
			get { return Owner as LabelLanguageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LabelLanguageSelectMethod SelectMethod
		{
			get { return LabelLanguageOwner.SelectMethod; }
			set { LabelLanguageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LabelLanguageService LabelLanguageProvider
		{
			get { return Provider as LabelLanguageService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<LabelLanguage> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<LabelLanguage> results = null;
			LabelLanguage item;
			count = 0;
			
			System.Int64 idLabelLanguage;
			System.Int64? idLabel_nullable;
			System.Int32? idLanguage_nullable;

			switch ( SelectMethod )
			{
				case LabelLanguageSelectMethod.Get:
					LabelLanguageKey entityKey  = new LabelLanguageKey();
					entityKey.Load(values);
					item = LabelLanguageProvider.Get(entityKey);
					results = new TList<LabelLanguage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LabelLanguageSelectMethod.GetAll:
                    results = LabelLanguageProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LabelLanguageSelectMethod.GetPaged:
					results = LabelLanguageProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LabelLanguageSelectMethod.Find:
					if ( FilterParameters != null )
						results = LabelLanguageProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LabelLanguageProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LabelLanguageSelectMethod.GetByIdLabelLanguage:
					idLabelLanguage = ( values["IdLabelLanguage"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdLabelLanguage"], typeof(System.Int64)) : (long)0;
					item = LabelLanguageProvider.GetByIdLabelLanguage(idLabelLanguage);
					results = new TList<LabelLanguage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case LabelLanguageSelectMethod.GetByIdLabel:
					idLabel_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdLabel"], typeof(System.Int64?));
					results = LabelLanguageProvider.GetByIdLabel(idLabel_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case LabelLanguageSelectMethod.GetByIdLanguage:
					idLanguage_nullable = (System.Int32?) EntityUtil.ChangeType(values["IdLanguage"], typeof(System.Int32?));
					results = LabelLanguageProvider.GetByIdLanguage(idLanguage_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == LabelLanguageSelectMethod.Get || SelectMethod == LabelLanguageSelectMethod.GetByIdLabelLanguage )
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
				LabelLanguage entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LabelLanguageProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<LabelLanguage> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LabelLanguageProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LabelLanguageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LabelLanguageDataSource class.
	/// </summary>
	public class LabelLanguageDataSourceDesigner : ProviderDataSourceDesigner<LabelLanguage, LabelLanguageKey>
	{
		/// <summary>
		/// Initializes a new instance of the LabelLanguageDataSourceDesigner class.
		/// </summary>
		public LabelLanguageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LabelLanguageSelectMethod SelectMethod
		{
			get { return ((LabelLanguageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LabelLanguageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LabelLanguageDataSourceActionList

	/// <summary>
	/// Supports the LabelLanguageDataSourceDesigner class.
	/// </summary>
	internal class LabelLanguageDataSourceActionList : DesignerActionList
	{
		private LabelLanguageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LabelLanguageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LabelLanguageDataSourceActionList(LabelLanguageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LabelLanguageSelectMethod SelectMethod
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

	#endregion LabelLanguageDataSourceActionList
	
	#endregion LabelLanguageDataSourceDesigner
	
	#region LabelLanguageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LabelLanguageDataSource.SelectMethod property.
	/// </summary>
	public enum LabelLanguageSelectMethod
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
		/// Represents the GetByIdLabelLanguage method.
		/// </summary>
		GetByIdLabelLanguage,
		/// <summary>
		/// Represents the GetByIdLabel method.
		/// </summary>
		GetByIdLabel,
		/// <summary>
		/// Represents the GetByIdLanguage method.
		/// </summary>
		GetByIdLanguage
	}
	
	#endregion LabelLanguageSelectMethod

	#region LabelLanguageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageFilter : SqlFilter<LabelLanguageColumn>
	{
	}
	
	#endregion LabelLanguageFilter

	#region LabelLanguageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageExpressionBuilder : SqlExpressionBuilder<LabelLanguageColumn>
	{
	}
	
	#endregion LabelLanguageExpressionBuilder	

	#region LabelLanguageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LabelLanguageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="LabelLanguage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LabelLanguageProperty : ChildEntityProperty<LabelLanguageChildEntityTypes>
	{
	}
	
	#endregion LabelLanguageProperty
}

