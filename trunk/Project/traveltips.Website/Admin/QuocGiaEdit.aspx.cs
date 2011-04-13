
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

public partial class QuocGiaEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "QuocGiaEdit.aspx?{0}", QuocGiaDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "QuocGiaEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "QuocGia.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdQuocGia");
	}
	protected void GridViewThanhPho_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdThanhPho={0}", GridViewThanhPho.SelectedDataKey.Values[0]);
		Response.Redirect("ThanhPhoEdit.aspx?" + urlParams, true);		
	}	
}


