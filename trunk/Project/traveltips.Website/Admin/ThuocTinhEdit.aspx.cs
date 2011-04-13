
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

public partial class ThuocTinhEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ThuocTinhEdit.aspx?{0}", ThuocTinhDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ThuocTinhEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ThuocTinh.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdThuocTinh");
	}
	protected void GridViewThuocTinhSanPham_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdTtsp={0}", GridViewThuocTinhSanPham.SelectedDataKey.Values[0]);
		Response.Redirect("ThuocTinhSanPhamEdit.aspx?" + urlParams, true);		
	}	
}


