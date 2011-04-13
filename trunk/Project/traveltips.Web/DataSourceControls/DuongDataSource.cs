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
	/// Represents the DataRepository.DuongProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DuongDataSourceDesigner))]
	public class DuongDataSource : ProviderDataSource<Duong, DuongKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongDataSource class.
		/// </summary>
		public DuongDataSource() : base(new DuongService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DuongDataSourceView used by the DuongDataSource.
		/// </summary>
		protected DuongDataSourceView DuongView
		{
			get { return ( View as DuongDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DuongDataSource control invokes to retrieve data.
		/// </summary>
		public DuongSelectMethod SelectMethod
		{
			get
			{
				DuongSelectMethod selectMethod = DuongSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DuongSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DuongDataSourceView class that is to be
		/// used by the DuongDataSource.
		/// </summary>
		/// <returns>An instance of the DuongDataSourceView class.</returns>
		protected override BaseDataSourceView<Duong, DuongKey> GetNewDataSourceView()
		{
			return new DuongDataSourceView(this, DefaultViewName);
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
	/// Supports the DuongDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DuongDataSourceView : ProviderDataSourceView<Duong, DuongKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DuongDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DuongDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DuongDataSourceView(DuongDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DuongDataSource DuongOwner
		{
			get { return Owner as DuongDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DuongSelectMethod SelectMethod
		{
			get { return DuongOwner.SelectMethod; }
			set { DuongOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DuongService DuongProvider
		{
			get { return Provider as DuongService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Duong> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Duong> results = null;
			Duong item;
			count = 0;
			
			System.Int64 idDuong;
			System.Int64? idQuan_nullable;

			switch ( SelectMethod )
			{
				case DuongSelectMethod.Get:
					DuongKey entityKey  = new DuongKey();
					entityKey.Load(values);
					item = DuongProvider.Get(entityKey);
					results = new TList<Duong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DuongSelectMethod.GetAll:
                    results = DuongProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DuongSelectMethod.GetPaged:
					results = DuongProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DuongSelectMethod.Find:
					if ( FilterParameters != null )
						results = DuongProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DuongProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DuongSelectMethod.GetByIdDuong:
					idDuong = ( values["IdDuong"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdDuong"], typeof(System.Int64)) : (long)0;
					item = DuongProvider.GetByIdDuong(idDuong);
					results = new TList<Duong>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DuongSelectMethod.GetByIdQuan:
					idQuan_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdQuan"], typeof(System.Int64?));
					results = DuongProvider.GetByIdQuan(idQuan_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DuongSelectMethod.Get || SelectMethod == DuongSelectMethod.GetByIdDuong )
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
				Duong entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DuongProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Duong> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DuongProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DuongDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DuongDataSource class.
	/// </summary>
	public class DuongDataSourceDesigner : ProviderDataSourceDesigner<Duong, DuongKey>
	{
		/// <summary>
		/// Initializes a new instance of the DuongDataSourceDesigner class.
		/// </summary>
		public DuongDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DuongSelectMethod SelectMethod
		{
			get { return ((DuongDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DuongDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DuongDataSourceActionList

	/// <summary>
	/// Supports the DuongDataSourceDesigner class.
	/// </summary>
	internal class DuongDataSourceActionList : DesignerActionList
	{
		private DuongDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DuongDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DuongDataSourceActionList(DuongDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DuongSelectMethod SelectMethod
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

	#endregion DuongDataSourceActionList
	
	#endregion DuongDataSourceDesigner
	
	#region DuongSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DuongDataSource.SelectMethod property.
	/// </summary>
	public enum DuongSelectMethod
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
		/// Represents the GetByIdDuong method.
		/// </summary>
		GetByIdDuong,
		/// <summary>
		/// Represents the GetByIdQuan method.
		/// </summary>
		GetByIdQuan
	}
	
	#endregion DuongSelectMethod

	#region DuongFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongFilter : SqlFilter<DuongColumn>
	{
	}
	
	#endregion DuongFilter

	#region DuongExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongExpressionBuilder : SqlExpressionBuilder<DuongColumn>
	{
	}
	
	#endregion DuongExpressionBuilder	

	#region DuongProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DuongChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Duong"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DuongProperty : ChildEntityProperty<DuongChildEntityTypes>
	{
	}
	
	#endregion DuongProperty
}

