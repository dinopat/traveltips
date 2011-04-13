
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

public partial class CongTyEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CongTyEdit.aspx?{0}", CongTyDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CongTyEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CongTy.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdCongTy");
	}
	protected void GridViewGallery_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdGallery={0}", GridViewGallery.SelectedDataKey.Values[0]);
		Response.Redirect("GalleryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewTinTuc_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdTinTuc={0}", GridViewTinTuc.SelectedDataKey.Values[0]);
		Response.Redirect("TinTucEdit.aspx?" + urlParams, true);		
	}	
}


