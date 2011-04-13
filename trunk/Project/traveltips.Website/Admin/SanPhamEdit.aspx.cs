
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

public partial class SanPhamEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SanPhamEdit.aspx?{0}", SanPhamDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SanPhamEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SanPham.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdSanPham");
	}
	protected void GridViewThuocTinhSanPham_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdTtsp={0}", GridViewThuocTinhSanPham.SelectedDataKey.Values[0]);
		Response.Redirect("ThuocTinhSanPhamEdit.aspx?" + urlParams, true);		
	}	
}


