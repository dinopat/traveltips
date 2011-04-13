
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

public partial class LoaiSpEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LoaiSpEdit.aspx?{0}", LoaiSpDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LoaiSpEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "LoaiSp.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdLoaiSp");
	}
	protected void GridViewSanPham_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdSanPham={0}", GridViewSanPham.SelectedDataKey.Values[0]);
		Response.Redirect("SanPhamEdit.aspx?" + urlParams, true);		
	}	
}


