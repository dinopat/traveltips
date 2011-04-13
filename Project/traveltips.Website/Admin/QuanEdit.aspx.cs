
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

public partial class QuanEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "QuanEdit.aspx?{0}", QuanDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "QuanEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Quan.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdQuan");
	}
	protected void GridViewDuong_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdDuong={0}", GridViewDuong.SelectedDataKey.Values[0]);
		Response.Redirect("DuongEdit.aspx?" + urlParams, true);		
	}	
}


