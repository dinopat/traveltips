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
	/// Represents the DataRepository.DichVuProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DichVuDataSourceDesigner))]
	public class DichVuDataSource : ProviderDataSource<DichVu, DichVuKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuDataSource class.
		/// </summary>
		public DichVuDataSource() : base(new DichVuService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DichVuDataSourceView used by the DichVuDataSource.
		/// </summary>
		protected DichVuDataSourceView DichVuView
		{
			get { return ( View as DichVuDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DichVuDataSource control invokes to retrieve data.
		/// </summary>
		public DichVuSelectMethod SelectMethod
		{
			get
			{
				DichVuSelectMethod selectMethod = DichVuSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DichVuSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DichVuDataSourceView class that is to be
		/// used by the DichVuDataSource.
		/// </summary>
		/// <returns>An instance of the DichVuDataSourceView class.</returns>
		protected override BaseDataSourceView<DichVu, DichVuKey> GetNewDataSourceView()
		{
			return new DichVuDataSourceView(this, DefaultViewName);
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
	/// Supports the DichVuDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DichVuDataSourceView : ProviderDataSourceView<DichVu, DichVuKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DichVuDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DichVuDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DichVuDataSourceView(DichVuDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DichVuDataSource DichVuOwner
		{
			get { return Owner as DichVuDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DichVuSelectMethod SelectMethod
		{
			get { return DichVuOwner.SelectMethod; }
			set { DichVuOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DichVuService DichVuProvider
		{
			get { return Provider as DichVuService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DichVu> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DichVu> results = null;
			DichVu item;
			count = 0;
			
			System.Int64 idDichVu;

			switch ( SelectMethod )
			{
				case DichVuSelectMethod.Get:
					DichVuKey entityKey  = new DichVuKey();
					entityKey.Load(values);
					item = DichVuProvider.Get(entityKey);
					results = new TList<DichVu>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DichVuSelectMethod.GetAll:
                    results = DichVuProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DichVuSelectMethod.GetPaged:
					results = DichVuProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DichVuSelectMethod.Find:
					if ( FilterParameters != null )
						results = DichVuProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DichVuProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DichVuSelectMethod.GetByIdDichVu:
					idDichVu = ( values["IdDichVu"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdDichVu"], typeof(System.Int64)) : (long)0;
					item = DichVuProvider.GetByIdDichVu(idDichVu);
					results = new TList<DichVu>();
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
			if ( SelectMethod == DichVuSelectMethod.Get || SelectMethod == DichVuSelectMethod.GetByIdDichVu )
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
				DichVu entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DichVuProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DichVu> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DichVuProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DichVuDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DichVuDataSource class.
	/// </summary>
	public class DichVuDataSourceDesigner : ProviderDataSourceDesigner<DichVu, DichVuKey>
	{
		/// <summary>
		/// Initializes a new instance of the DichVuDataSourceDesigner class.
		/// </summary>
		public DichVuDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DichVuSelectMethod SelectMethod
		{
			get { return ((DichVuDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DichVuDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DichVuDataSourceActionList

	/// <summary>
	/// Supports the DichVuDataSourceDesigner class.
	/// </summary>
	internal class DichVuDataSourceActionList : DesignerActionList
	{
		private DichVuDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DichVuDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DichVuDataSourceActionList(DichVuDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DichVuSelectMethod SelectMethod
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

	#endregion DichVuDataSourceActionList
	
	#endregion DichVuDataSourceDesigner
	
	#region DichVuSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DichVuDataSource.SelectMethod property.
	/// </summary>
	public enum DichVuSelectMethod
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
		/// Represents the GetByIdDichVu method.
		/// </summary>
		GetByIdDichVu
	}
	
	#endregion DichVuSelectMethod

	#region DichVuFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuFilter : SqlFilter<DichVuColumn>
	{
	}
	
	#endregion DichVuFilter

	#region DichVuExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuExpressionBuilder : SqlExpressionBuilder<DichVuColumn>
	{
	}
	
	#endregion DichVuExpressionBuilder	

	#region DichVuProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DichVuChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DichVu"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DichVuProperty : ChildEntityProperty<DichVuChildEntityTypes>
	{
	}
	
	#endregion DichVuProperty
}

