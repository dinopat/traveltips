
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

public partial class DuongEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "DuongEdit.aspx?{0}", DuongDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "DuongEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Duong.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdDuong");
	}
}


