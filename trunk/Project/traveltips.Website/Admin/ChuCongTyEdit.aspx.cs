
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

public partial class ChuCongTyEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ChuCongTyEdit.aspx?{0}", ChuCongTyDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ChuCongTyEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ChuCongTy.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdChuCongTy");
	}
	protected void GridViewCongTy_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdCongTy={0}", GridViewCongTy.SelectedDataKey.Values[0]);
		Response.Redirect("CongTyEdit.aspx?" + urlParams, true);		
	}	
}


