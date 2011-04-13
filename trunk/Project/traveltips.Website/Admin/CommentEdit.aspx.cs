
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

public partial class CommentEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CommentEdit.aspx?{0}", CommentDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CommentEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Comment.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdComment");
	}
}


