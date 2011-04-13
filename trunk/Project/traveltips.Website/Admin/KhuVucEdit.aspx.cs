
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

public partial class KhuVucEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "KhuVucEdit.aspx?{0}", KhuVucDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "KhuVucEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "KhuVuc.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdKhuVuc");
	}
}


