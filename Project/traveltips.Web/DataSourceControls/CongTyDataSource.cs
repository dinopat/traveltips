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
	/// Represents the DataRepository.CongTyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CongTyDataSourceDesigner))]
	public class CongTyDataSource : ProviderDataSource<CongTy, CongTyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyDataSource class.
		/// </summary>
		public CongTyDataSource() : base(new CongTyService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CongTyDataSourceView used by the CongTyDataSource.
		/// </summary>
		protected CongTyDataSourceView CongTyView
		{
			get { return ( View as CongTyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CongTyDataSource control invokes to retrieve data.
		/// </summary>
		public CongTySelectMethod SelectMethod
		{
			get
			{
				CongTySelectMethod selectMethod = CongTySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CongTySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CongTyDataSourceView class that is to be
		/// used by the CongTyDataSource.
		/// </summary>
		/// <returns>An instance of the CongTyDataSourceView class.</returns>
		protected override BaseDataSourceView<CongTy, CongTyKey> GetNewDataSourceView()
		{
			return new CongTyDataSourceView(this, DefaultViewName);
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
	/// Supports the CongTyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CongTyDataSourceView : ProviderDataSourceView<CongTy, CongTyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CongTyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CongTyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CongTyDataSourceView(CongTyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CongTyDataSource CongTyOwner
		{
			get { return Owner as CongTyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CongTySelectMethod SelectMethod
		{
			get { return CongTyOwner.SelectMethod; }
			set { CongTyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CongTyService CongTyProvider
		{
			get { return Provider as CongTyService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CongTy> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CongTy> results = null;
			CongTy item;
			count = 0;
			
			System.Int64 idCongTy;
			System.Int64? idChuCongTy_nullable;
			System.Int64? idDanhMuc_nullable;

			switch ( SelectMethod )
			{
				case CongTySelectMethod.Get:
					CongTyKey entityKey  = new CongTyKey();
					entityKey.Load(values);
					item = CongTyProvider.Get(entityKey);
					results = new TList<CongTy>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CongTySelectMethod.GetAll:
                    results = CongTyProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CongTySelectMethod.GetPaged:
					results = CongTyProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CongTySelectMethod.Find:
					if ( FilterParameters != null )
						results = CongTyProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CongTyProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CongTySelectMethod.GetByIdCongTy:
					idCongTy = ( values["IdCongTy"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdCongTy"], typeof(System.Int64)) : (long)0;
					item = CongTyProvider.GetByIdCongTy(idCongTy);
					results = new TList<CongTy>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CongTySelectMethod.GetByIdChuCongTy:
					idChuCongTy_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdChuCongTy"], typeof(System.Int64?));
					results = CongTyProvider.GetByIdChuCongTy(idChuCongTy_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CongTySelectMethod.GetByIdDanhMuc:
					idDanhMuc_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdDanhMuc"], typeof(System.Int64?));
					results = CongTyProvider.GetByIdDanhMuc(idDanhMuc_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CongTySelectMethod.Get || SelectMethod == CongTySelectMethod.GetByIdCongTy )
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
				CongTy entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CongTyProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CongTy> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CongTyProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CongTyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CongTyDataSource class.
	/// </summary>
	public class CongTyDataSourceDesigner : ProviderDataSourceDesigner<CongTy, CongTyKey>
	{
		/// <summary>
		/// Initializes a new instance of the CongTyDataSourceDesigner class.
		/// </summary>
		public CongTyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CongTySelectMethod SelectMethod
		{
			get { return ((CongTyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CongTyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CongTyDataSourceActionList

	/// <summary>
	/// Supports the CongTyDataSourceDesigner class.
	/// </summary>
	internal class CongTyDataSourceActionList : DesignerActionList
	{
		private CongTyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CongTyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CongTyDataSourceActionList(CongTyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CongTySelectMethod SelectMethod
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

	#endregion CongTyDataSourceActionList
	
	#endregion CongTyDataSourceDesigner
	
	#region CongTySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CongTyDataSource.SelectMethod property.
	/// </summary>
	public enum CongTySelectMethod
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
		/// Represents the GetByIdCongTy method.
		/// </summary>
		GetByIdCongTy,
		/// <summary>
		/// Represents the GetByIdChuCongTy method.
		/// </summary>
		GetByIdChuCongTy,
		/// <summary>
		/// Represents the GetByIdDanhMuc method.
		/// </summary>
		GetByIdDanhMuc
	}
	
	#endregion CongTySelectMethod

	#region CongTyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyFilter : SqlFilter<CongTyColumn>
	{
	}
	
	#endregion CongTyFilter

	#region CongTyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyExpressionBuilder : SqlExpressionBuilder<CongTyColumn>
	{
	}
	
	#endregion CongTyExpressionBuilder	

	#region CongTyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CongTyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CongTy"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CongTyProperty : ChildEntityProperty<CongTyChildEntityTypes>
	{
	}
	
	#endregion CongTyProperty
}

