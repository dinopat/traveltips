
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

public partial class TinTucEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TinTucEdit.aspx?{0}", TinTucDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TinTucEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TinTuc.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdTinTuc");
	}
}


