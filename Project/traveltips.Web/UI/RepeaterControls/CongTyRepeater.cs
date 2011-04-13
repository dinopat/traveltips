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
    /// A designer class for a strongly typed repeater <c>CongTyRepeater</c>
    /// </summary>
	public class CongTyRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CongTyRepeaterDesigner"/> class.
        /// </summary>
		public CongTyRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is CongTyRepeater))
			{ 
				throw new ArgumentException("Component is not a CongTyRepeater."); 
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
			CongTyRepeater z = (CongTyRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="CongTyRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(CongTyRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:CongTyRepeater runat=\"server\"></{0}:CongTyRepeater>")]
	public class CongTyRepeater : Control, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:CongTyRepeater"/> class.
        /// </summary>
		public CongTyRepeater()
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
		[TemplateContainer(typeof(CongTyItem))]
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
		[TemplateContainer(typeof(CongTyItem))]
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
		[TemplateContainer(typeof(CongTyItem))]
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
		[TemplateContainer(typeof(CongTyItem))]
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
				traveltips.Web.Data.CongTyDataSource datasource = null;
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
				datasource = ctl as traveltips.Web.Data.CongTyDataSource;
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
					traveltips.Entities.CongTy entity = o as traveltips.Entities.CongTy;
					CongTyItem container = new CongTyItem(entity);

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
	public class CongTyItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private traveltips.Entities.CongTy _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CongTyItem"/> class.
        /// </summary>
		public CongTyItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CongTyItem"/> class.
        /// </summary>
		public CongTyItem(traveltips.Entities.CongTy entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the IdCongTy
        /// </summary>
        /// <value>The IdCongTy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 IdCongTy
		{
			get { return _entity.IdCongTy; }
		}
        /// <summary>
        /// Gets the IdChuCongTy
        /// </summary>
        /// <value>The IdChuCongTy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdChuCongTy
		{
			get { return _entity.IdChuCongTy; }
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
        /// Gets the IdQuocGia
        /// </summary>
        /// <value>The IdQuocGia.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdQuocGia
		{
			get { return _entity.IdQuocGia; }
		}
        /// <summary>
        /// Gets the IdThanhPho
        /// </summary>
        /// <value>The IdThanhPho.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdThanhPho
		{
			get { return _entity.IdThanhPho; }
		}
        /// <summary>
        /// Gets the IdQuan
        /// </summary>
        /// <value>The IdQuan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdQuan
		{
			get { return _entity.IdQuan; }
		}
        /// <summary>
        /// Gets the IdDuong
        /// </summary>
        /// <value>The IdDuong.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdDuong
		{
			get { return _entity.IdDuong; }
		}
        /// <summary>
        /// Gets the IdKhuVuc
        /// </summary>
        /// <value>The IdKhuVuc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64? IdKhuVuc
		{
			get { return _entity.IdKhuVuc; }
		}
        /// <summary>
        /// Gets the SoNha
        /// </summary>
        /// <value>The SoNha.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SoNha
		{
			get { return _entity.SoNha; }
		}
        /// <summary>
        /// Gets the DienThoaiCd
        /// </summary>
        /// <value>The DienThoaiCd.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DienThoaiCd
		{
			get { return _entity.DienThoaiCd; }
		}
        /// <summary>
        /// Gets the DienThoaiDd
        /// </summary>
        /// <value>The DienThoaiDd.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DienThoaiDd
		{
			get { return _entity.DienThoaiDd; }
		}
        /// <summary>
        /// Gets the Fax
        /// </summary>
        /// <value>The Fax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Fax
		{
			get { return _entity.Fax; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the Website
        /// </summary>
        /// <value>The Website.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Website
		{
			get { return _entity.Website; }
		}
        /// <summary>
        /// Gets the HinhThucTt
        /// </summary>
        /// <value>The HinhThucTt.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HinhThucTt
		{
			get { return _entity.HinhThucTt; }
		}
        /// <summary>
        /// Gets the ThoiGianPv
        /// </summary>
        /// <value>The ThoiGianPv.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ThoiGianPv
		{
			get { return _entity.ThoiGianPv; }
		}
        /// <summary>
        /// Gets the AnhMinhHoa
        /// </summary>
        /// <value>The AnhMinhHoa.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AnhMinhHoa
		{
			get { return _entity.AnhMinhHoa; }
		}
        /// <summary>
        /// Gets the GhiChu
        /// </summary>
        /// <value>The GhiChu.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GhiChu
		{
			get { return _entity.GhiChu; }
		}
        /// <summary>
        /// Gets the MoTaNgan
        /// </summary>
        /// <value>The MoTaNgan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MoTaNgan
		{
			get { return _entity.MoTaNgan; }
		}
        /// <summary>
        /// Gets the MoTaChiTiet
        /// </summary>
        /// <value>The MoTaChiTiet.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MoTaChiTiet
		{
			get { return _entity.MoTaChiTiet; }
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
        /// Gets a <see cref="T:traveltips.Entities.CongTy"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public traveltips.Entities.CongTy Entity
        {
            get { return _entity; }
        }
	}
}
