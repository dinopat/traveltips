
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

public partial class LabelNnEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LabelNnEdit.aspx?{0}", LabelNnDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LabelNnEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "LabelNn.aspx");
		FormUtil.SetDefaultMode(FormView1, "IdLabel");
	}
	protected void GridViewLabelLanguage_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("IdLabelLanguage={0}", GridViewLabelLanguage.SelectedDataKey.Values[0]);
		Response.Redirect("LabelLanguageEdit.aspx?" + urlParams, true);		
	}	
}


