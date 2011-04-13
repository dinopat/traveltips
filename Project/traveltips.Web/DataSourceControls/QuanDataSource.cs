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
	/// Represents the DataRepository.QuanProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuanDataSourceDesigner))]
	public class QuanDataSource : ProviderDataSource<Quan, QuanKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanDataSource class.
		/// </summary>
		public QuanDataSource() : base(new QuanService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuanDataSourceView used by the QuanDataSource.
		/// </summary>
		protected QuanDataSourceView QuanView
		{
			get { return ( View as QuanDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuanDataSource control invokes to retrieve data.
		/// </summary>
		public QuanSelectMethod SelectMethod
		{
			get
			{
				QuanSelectMethod selectMethod = QuanSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuanSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuanDataSourceView class that is to be
		/// used by the QuanDataSource.
		/// </summary>
		/// <returns>An instance of the QuanDataSourceView class.</returns>
		protected override BaseDataSourceView<Quan, QuanKey> GetNewDataSourceView()
		{
			return new QuanDataSourceView(this, DefaultViewName);
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
	/// Supports the QuanDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuanDataSourceView : ProviderDataSourceView<Quan, QuanKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuanDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuanDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuanDataSourceView(QuanDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuanDataSource QuanOwner
		{
			get { return Owner as QuanDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuanSelectMethod SelectMethod
		{
			get { return QuanOwner.SelectMethod; }
			set { QuanOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuanService QuanProvider
		{
			get { return Provider as QuanService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Quan> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Quan> results = null;
			Quan item;
			count = 0;
			
			System.Int64 idQuan;
			System.Int64? idThanhPho_nullable;

			switch ( SelectMethod )
			{
				case QuanSelectMethod.Get:
					QuanKey entityKey  = new QuanKey();
					entityKey.Load(values);
					item = QuanProvider.Get(entityKey);
					results = new TList<Quan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuanSelectMethod.GetAll:
                    results = QuanProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case QuanSelectMethod.GetPaged:
					results = QuanProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuanSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuanProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuanProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuanSelectMethod.GetByIdQuan:
					idQuan = ( values["IdQuan"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdQuan"], typeof(System.Int64)) : (long)0;
					item = QuanProvider.GetByIdQuan(idQuan);
					results = new TList<Quan>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case QuanSelectMethod.GetByIdThanhPho:
					idThanhPho_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdThanhPho"], typeof(System.Int64?));
					results = QuanProvider.GetByIdThanhPho(idThanhPho_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuanSelectMethod.Get || SelectMethod == QuanSelectMethod.GetByIdQuan )
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
				Quan entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					QuanProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Quan> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			QuanProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuanDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuanDataSource class.
	/// </summary>
	public class QuanDataSourceDesigner : ProviderDataSourceDesigner<Quan, QuanKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuanDataSourceDesigner class.
		/// </summary>
		public QuanDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuanSelectMethod SelectMethod
		{
			get { return ((QuanDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuanDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuanDataSourceActionList

	/// <summary>
	/// Supports the QuanDataSourceDesigner class.
	/// </summary>
	internal class QuanDataSourceActionList : DesignerActionList
	{
		private QuanDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuanDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuanDataSourceActionList(QuanDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuanSelectMethod SelectMethod
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

	#endregion QuanDataSourceActionList
	
	#endregion QuanDataSourceDesigner
	
	#region QuanSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuanDataSource.SelectMethod property.
	/// </summary>
	public enum QuanSelectMethod
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
		/// Represents the GetByIdQuan method.
		/// </summary>
		GetByIdQuan,
		/// <summary>
		/// Represents the GetByIdThanhPho method.
		/// </summary>
		GetByIdThanhPho
	}
	
	#endregion QuanSelectMethod

	#region QuanFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanFilter : SqlFilter<QuanColumn>
	{
	}
	
	#endregion QuanFilter

	#region QuanExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanExpressionBuilder : SqlExpressionBuilder<QuanColumn>
	{
	}
	
	#endregion QuanExpressionBuilder	

	#region QuanProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuanChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Quan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuanProperty : ChildEntityProperty<QuanChildEntityTypes>
	{
	}
	
	#endregion QuanProperty
}

