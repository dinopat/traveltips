using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;

namespace traveltips.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>TuDienRepeater</c>
    /// </summary>
	public class TuDienRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TuDienRepeaterDesigner"/> class.
        /// </summary>
		public TuDienRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is TuDienRepeater))
			{ 
				throw new ArgumentException("Component is not a TuDienRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			TuDienRepeater z = (TuDienRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="TuDienRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(TuDienRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:TuDienRepeater runat=\"server\"></{0}:TuDienRepeater>")]
	public class TuDienRepeater : Control, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:TuDienRepeater"/> class.
        /// </summary>
		public TuDienRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(TuDienItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(TuDienItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}
			

		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(TuDienItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(TuDienItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

        /// <summary>
        /// Gets or sets the data source ID.
        /// </summary>
        /// <value>The data source ID.</value>
		[Category("Data")]
		public virtual string DataSourceID
		{
			get
			{
				if (ViewState["DataSourceID"] == null)
				{
					return string.Empty;
				}
				return (string)ViewState["DataSourceID"];
			}
			set
			{
				ViewState["DataSourceID"] = value;
			}
		}

		//[Category("Data")]
		//public virtual string DataMember
		//{
		//    get
		//    {
		//        if (ViewState["DataMember"] == null)
		//        {
		//            return string.Empty;
		//        }
		//        return (string)ViewState["DataMember"];
		//    }
		//    set
		//    {
		//        ViewState["DataMember"] = value;
		//    }
		//}

		//private ProductDataSourceView m_currentView;

		System.Collections.IEnumerable m_currentView;
        /// <summary>
        /// Connects to data source view.
        /// </summary>
        /// <returns>an IEnumerable of DataSourceView</returns>
		private System.Collections.IEnumerable ConnectToDataSourceView()
		{
			if (m_currentView == null)
			{
				traveltips.Web.Data.TuDienDataSource datasource = null;
				//First look in the naming container
            Control ctl = this.NamingContainer.FindControl(DataSourceID);
            if (ctl == null)
            {
               //if not found, look at the page level
               ctl = this.Page.FindControl(DataSourceID);
               if (ctl == null)
               {
                  throw new System.Web.HttpException("Datasource does not exists");
               }
            }
				datasource = ctl as traveltips.Web.Data.TuDienDataSource;
				if (datasource == null)
				{
					throw new System.Web.HttpException("Datasource must be data control");
				}
				
				System.Collections.IEnumerable dsv = datasource.GetEntityList(); //this.DataMember);
				if (dsv == null)
				{
					throw new System.Web.HttpException("View not found");
				}
				m_currentView = dsv;
			}
			return m_currentView;
		}

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
		protected override void CreateChildControls()
		{
			if (ChildControlsCreated)
			{
				return;
			}
			Controls.Clear();

			System.Collections.IEnumerable datas = (System.Collections.IEnumerable)ConnectToDataSourceView();

			if (datas != null)
			{
				if (m_headerTemplate != null)
				{
					Control headerItem = new Control();
					m_headerTemplate.InstantiateIn(headerItem);
					Controls.Add(headerItem);
				}

				int pos = 0;
				foreach (object o in datas)
				{
					traveltips.Entities.TuDien entity = o as traveltips.Entities.TuDien;
					TuDienItem container = new TuDienItem(entity);

					if (m_itemTemplate != null && (pos % 2) == 0)
					{
						m_itemTemplate.InstantiateIn(container);
					}
					else
					{
						if (m_altenateItemTemplate != null)
						{
							m_altenateItemTemplate.InstantiateIn(container);
						}
						else if (m_itemTemplate != null)
						{
							m_itemTemplate.InstantiateIn(container);
						}
						else
						{
							// no template !!!
						}
					}
					Controls.Add(container);
					pos++;
				}

				if (m_footerTemplate != null)
				{
					Control footerItem = new Control();
					m_footerTemplate.InstantiateIn(footerItem);
					Controls.Add(footerItem);
				}
				ChildControlsCreated = true;
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class TuDienItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private traveltips.Entities.TuDien _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TuDienItem"/> class.
        /// </summary>
		public TuDienItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TuDienItem"/> class.
        /// </summary>
		public TuDienItem(traveltips.Entities.TuDien entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the IdTuDien
        /// </summary>
        /// <value>The IdTuDien.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 IdTuDien
		{
			get { return _entity.IdTuDien; }
		}
        /// <summary>
        /// Gets the IdDanhMuc
        /// </summary>
        /// <value>The IdDanhMuc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdDanhMuc
		{
			get { return _entity.IdDanhMuc; }
		}
        /// <summary>
        /// Gets the TenTu
        /// </summary>
        /// <value>The TenTu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TenTu
		{
			get { return _entity.TenTu; }
		}
        /// <summary>
        /// Gets the MaTu
        /// </summary>
        /// <value>The MaTu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MaTu
		{
			get { return _entity.MaTu; }
		}
        /// <summary>
        /// Gets the NhomTu
        /// </summary>
        /// <value>The NhomTu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String NhomTu
		{
			get { return _entity.NhomTu; }
		}
        /// <summary>
        /// Gets the MoTa
        /// </summary>
        /// <value>The MoTa.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MoTa
		{
			get { return _entity.MoTa; }
		}
        /// <summary>
        /// Gets the Flag
        /// </summary>
        /// <value>The Flag.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte? Flag
		{
			get { return _entity.Flag; }
		}

        /// <summary>
        /// Gets a <see cref="T:traveltips.Entities.TuDien"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public traveltips.Entities.TuDien Entity
        {
            get { return _entity; }
        }
	}
}
