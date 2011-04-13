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
	/// Represents the DataRepository.TuDienProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TuDienDataSourceDesigner))]
	public class TuDienDataSource : ProviderDataSource<TuDien, TuDienKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienDataSource class.
		/// </summary>
		public TuDienDataSource() : base(new TuDienService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TuDienDataSourceView used by the TuDienDataSource.
		/// </summary>
		protected TuDienDataSourceView TuDienView
		{
			get { return ( View as TuDienDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TuDienDataSource control invokes to retrieve data.
		/// </summary>
		public TuDienSelectMethod SelectMethod
		{
			get
			{
				TuDienSelectMethod selectMethod = TuDienSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TuDienSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TuDienDataSourceView class that is to be
		/// used by the TuDienDataSource.
		/// </summary>
		/// <returns>An instance of the TuDienDataSourceView class.</returns>
		protected override BaseDataSourceView<TuDien, TuDienKey> GetNewDataSourceView()
		{
			return new TuDienDataSourceView(this, DefaultViewName);
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
	/// Supports the TuDienDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TuDienDataSourceView : ProviderDataSourceView<TuDien, TuDienKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TuDienDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TuDienDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TuDienDataSourceView(TuDienDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TuDienDataSource TuDienOwner
		{
			get { return Owner as TuDienDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TuDienSelectMethod SelectMethod
		{
			get { return TuDienOwner.SelectMethod; }
			set { TuDienOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TuDienService TuDienProvider
		{
			get { return Provider as TuDienService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TuDien> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TuDien> results = null;
			TuDien item;
			count = 0;
			
			System.Int64 idTuDien;

			switch ( SelectMethod )
			{
				case TuDienSelectMethod.Get:
					TuDienKey entityKey  = new TuDienKey();
					entityKey.Load(values);
					item = TuDienProvider.Get(entityKey);
					results = new TList<TuDien>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TuDienSelectMethod.GetAll:
                    results = TuDienProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TuDienSelectMethod.GetPaged:
					results = TuDienProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TuDienSelectMethod.Find:
					if ( FilterParameters != null )
						results = TuDienProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TuDienProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TuDienSelectMethod.GetByIdTuDien:
					idTuDien = ( values["IdTuDien"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdTuDien"], typeof(System.Int64)) : (long)0;
					item = TuDienProvider.GetByIdTuDien(idTuDien);
					results = new TList<TuDien>();
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
			if ( SelectMethod == TuDienSelectMethod.Get || SelectMethod == TuDienSelectMethod.GetByIdTuDien )
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
				TuDien entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TuDienProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TuDien> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TuDienProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TuDienDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TuDienDataSource class.
	/// </summary>
	public class TuDienDataSourceDesigner : ProviderDataSourceDesigner<TuDien, TuDienKey>
	{
		/// <summary>
		/// Initializes a new instance of the TuDienDataSourceDesigner class.
		/// </summary>
		public TuDienDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TuDienSelectMethod SelectMethod
		{
			get { return ((TuDienDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TuDienDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TuDienDataSourceActionList

	/// <summary>
	/// Supports the TuDienDataSourceDesigner class.
	/// </summary>
	internal class TuDienDataSourceActionList : DesignerActionList
	{
		private TuDienDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TuDienDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TuDienDataSourceActionList(TuDienDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TuDienSelectMethod SelectMethod
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

	#endregion TuDienDataSourceActionList
	
	#endregion TuDienDataSourceDesigner
	
	#region TuDienSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TuDienDataSource.SelectMethod property.
	/// </summary>
	public enum TuDienSelectMethod
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
		/// Represents the GetByIdTuDien method.
		/// </summary>
		GetByIdTuDien
	}
	
	#endregion TuDienSelectMethod

	#region TuDienFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienFilter : SqlFilter<TuDienColumn>
	{
	}
	
	#endregion TuDienFilter

	#region TuDienExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienExpressionBuilder : SqlExpressionBuilder<TuDienColumn>
	{
	}
	
	#endregion TuDienExpressionBuilder	

	#region TuDienProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TuDienChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TuDien"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TuDienProperty : ChildEntityProperty<TuDienChildEntityTypes>
	{
	}
	
	#endregion TuDienProperty
}

