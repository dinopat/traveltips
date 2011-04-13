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
	/// Represents the DataRepository.ChuCongTyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ChuCongTyDataSourceDesigner))]
	public class ChuCongTyDataSource : ProviderDataSource<ChuCongTy, ChuCongTyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyDataSource class.
		/// </summary>
		public ChuCongTyDataSource() : base(new ChuCongTyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ChuCongTyDataSourceView used by the ChuCongTyDataSource.
		/// </summary>
		protected ChuCongTyDataSourceView ChuCongTyView
		{
			get { return ( View as ChuCongTyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ChuCongTyDataSource control invokes to retrieve data.
		/// </summary>
		public ChuCongTySelectMethod SelectMethod
		{
			get
			{
				ChuCongTySelectMethod selectMethod = ChuCongTySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ChuCongTySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ChuCongTyDataSourceView class that is to be
		/// used by the ChuCongTyDataSource.
		/// </summary>
		/// <returns>An instance of the ChuCongTyDataSourceView class.</returns>
		protected override BaseDataSourceView<ChuCongTy, ChuCongTyKey> GetNewDataSourceView()
		{
			return new ChuCongTyDataSourceView(this, DefaultViewName);
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
	/// Supports the ChuCongTyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ChuCongTyDataSourceView : ProviderDataSourceView<ChuCongTy, ChuCongTyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ChuCongTyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ChuCongTyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ChuCongTyDataSourceView(ChuCongTyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ChuCongTyDataSource ChuCongTyOwner
		{
			get { return Owner as ChuCongTyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ChuCongTySelectMethod SelectMethod
		{
			get { return ChuCongTyOwner.SelectMethod; }
			set { ChuCongTyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ChuCongTyService ChuCongTyProvider
		{
			get { return Provider as ChuCongTyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ChuCongTy> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ChuCongTy> results = null;
			ChuCongTy item;
			count = 0;
			
			System.Int64 idChuCongTy;

			switch ( SelectMethod )
			{
				case ChuCongTySelectMethod.Get:
					ChuCongTyKey entityKey  = new ChuCongTyKey();
					entityKey.Load(values);
					item = ChuCongTyProvider.Get(entityKey);
					results = new TList<ChuCongTy>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ChuCongTySelectMethod.GetAll:
                    results = ChuCongTyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ChuCongTySelectMethod.GetPaged:
					results = ChuCongTyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ChuCongTySelectMethod.Find:
					if ( FilterParameters != null )
						results = ChuCongTyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ChuCongTyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ChuCongTySelectMethod.GetByIdChuCongTy:
					idChuCongTy = ( values["IdChuCongTy"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdChuCongTy"], typeof(System.Int64)) : (long)0;
					item = ChuCongTyProvider.GetByIdChuCongTy(idChuCongTy);
					results = new TList<ChuCongTy>();
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
			if ( SelectMethod == ChuCongTySelectMethod.Get || SelectMethod == ChuCongTySelectMethod.GetByIdChuCongTy )
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
				ChuCongTy entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ChuCongTyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ChuCongTy> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ChuCongTyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ChuCongTyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ChuCongTyDataSource class.
	/// </summary>
	public class ChuCongTyDataSourceDesigner : ProviderDataSourceDesigner<ChuCongTy, ChuCongTyKey>
	{
		/// <summary>
		/// Initializes a new instance of the ChuCongTyDataSourceDesigner class.
		/// </summary>
		public ChuCongTyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ChuCongTySelectMethod SelectMethod
		{
			get { return ((ChuCongTyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ChuCongTyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ChuCongTyDataSourceActionList

	/// <summary>
	/// Supports the ChuCongTyDataSourceDesigner class.
	/// </summary>
	internal class ChuCongTyDataSourceActionList : DesignerActionList
	{
		private ChuCongTyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ChuCongTyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ChuCongTyDataSourceActionList(ChuCongTyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ChuCongTySelectMethod SelectMethod
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

	#endregion ChuCongTyDataSourceActionList
	
	#endregion ChuCongTyDataSourceDesigner
	
	#region ChuCongTySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ChuCongTyDataSource.SelectMethod property.
	/// </summary>
	public enum ChuCongTySelectMethod
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
		/// Represents the GetByIdChuCongTy method.
		/// </summary>
		GetByIdChuCongTy
	}
	
	#endregion ChuCongTySelectMethod

	#region ChuCongTyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyFilter : SqlFilter<ChuCongTyColumn>
	{
	}
	
	#endregion ChuCongTyFilter

	#region ChuCongTyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyExpressionBuilder : SqlExpressionBuilder<ChuCongTyColumn>
	{
	}
	
	#endregion ChuCongTyExpressionBuilder	

	#region ChuCongTyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ChuCongTyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ChuCongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ChuCongTyProperty : ChildEntityProperty<ChuCongTyChildEntityTypes>
	{
	}
	
	#endregion ChuCongTyProperty
}

