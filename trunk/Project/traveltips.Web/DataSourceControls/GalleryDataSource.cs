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
	/// Represents the DataRepository.GalleryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(GalleryDataSourceDesigner))]
	public class GalleryDataSource : ProviderDataSource<Gallery, GalleryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryDataSource class.
		/// </summary>
		public GalleryDataSource() : base(new GalleryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the GalleryDataSourceView used by the GalleryDataSource.
		/// </summary>
		protected GalleryDataSourceView GalleryView
		{
			get { return ( View as GalleryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the GalleryDataSource control invokes to retrieve data.
		/// </summary>
		public GallerySelectMethod SelectMethod
		{
			get
			{
				GallerySelectMethod selectMethod = GallerySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (GallerySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the GalleryDataSourceView class that is to be
		/// used by the GalleryDataSource.
		/// </summary>
		/// <returns>An instance of the GalleryDataSourceView class.</returns>
		protected override BaseDataSourceView<Gallery, GalleryKey> GetNewDataSourceView()
		{
			return new GalleryDataSourceView(this, DefaultViewName);
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
	/// Supports the GalleryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class GalleryDataSourceView : ProviderDataSourceView<Gallery, GalleryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GalleryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the GalleryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public GalleryDataSourceView(GalleryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal GalleryDataSource GalleryOwner
		{
			get { return Owner as GalleryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal GallerySelectMethod SelectMethod
		{
			get { return GalleryOwner.SelectMethod; }
			set { GalleryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal GalleryService GalleryProvider
		{
			get { return Provider as GalleryService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Gallery> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Gallery> results = null;
			Gallery item;
			count = 0;
			
			System.Int64 idGallery;
			System.Int64? idCongTy_nullable;

			switch ( SelectMethod )
			{
				case GallerySelectMethod.Get:
					GalleryKey entityKey  = new GalleryKey();
					entityKey.Load(values);
					item = GalleryProvider.Get(entityKey);
					results = new TList<Gallery>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case GallerySelectMethod.GetAll:
                    results = GalleryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case GallerySelectMethod.GetPaged:
					results = GalleryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case GallerySelectMethod.Find:
					if ( FilterParameters != null )
						results = GalleryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = GalleryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case GallerySelectMethod.GetByIdGallery:
					idGallery = ( values["IdGallery"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["IdGallery"], typeof(System.Int64)) : (long)0;
					item = GalleryProvider.GetByIdGallery(idGallery);
					results = new TList<Gallery>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case GallerySelectMethod.GetByIdCongTy:
					idCongTy_nullable = (System.Int64?) EntityUtil.ChangeType(values["IdCongTy"], typeof(System.Int64?));
					results = GalleryProvider.GetByIdCongTy(idCongTy_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == GallerySelectMethod.Get || SelectMethod == GallerySelectMethod.GetByIdGallery )
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
				Gallery entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					GalleryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Gallery> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			GalleryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region GalleryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the GalleryDataSource class.
	/// </summary>
	public class GalleryDataSourceDesigner : ProviderDataSourceDesigner<Gallery, GalleryKey>
	{
		/// <summary>
		/// Initializes a new instance of the GalleryDataSourceDesigner class.
		/// </summary>
		public GalleryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GallerySelectMethod SelectMethod
		{
			get { return ((GalleryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new GalleryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region GalleryDataSourceActionList

	/// <summary>
	/// Supports the GalleryDataSourceDesigner class.
	/// </summary>
	internal class GalleryDataSourceActionList : DesignerActionList
	{
		private GalleryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the GalleryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public GalleryDataSourceActionList(GalleryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GallerySelectMethod SelectMethod
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

	#endregion GalleryDataSourceActionList
	
	#endregion GalleryDataSourceDesigner
	
	#region GallerySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the GalleryDataSource.SelectMethod property.
	/// </summary>
	public enum GallerySelectMethod
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
		/// Represents the GetByIdGallery method.
		/// </summary>
		GetByIdGallery,
		/// <summary>
		/// Represents the GetByIdCongTy method.
		/// </summary>
		GetByIdCongTy
	}
	
	#endregion GallerySelectMethod

	#region GalleryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryFilter : SqlFilter<GalleryColumn>
	{
	}
	
	#endregion GalleryFilter

	#region GalleryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryExpressionBuilder : SqlExpressionBuilder<GalleryColumn>
	{
	}
	
	#endregion GalleryExpressionBuilder	

	#region GalleryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;GalleryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Gallery"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GalleryProperty : ChildEntityProperty<GalleryChildEntityTypes>
	{
	}
	
	#endregion GalleryProperty
}

