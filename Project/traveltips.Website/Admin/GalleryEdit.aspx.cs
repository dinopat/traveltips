
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using traveltips.Web.UI;
#endregion

public partial class GalleryEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "GalleryEdit.aspx?{0}", GalleryDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "GalleryEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Gallery.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdGallery");
	}
}


