
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

public partial class ThanhPhoEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ThanhPhoEdit.aspx?{0}", ThanhPhoDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ThanhPhoEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ThanhPho.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdThanhPho");
	}
	protected void GridViewQuan_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdQuan={0}", GridViewQuan.SelectedDataKey.Values[0]);
		Response.Redirect("QuanEdit.aspx?" + urlParams, true);		
	}	
}


