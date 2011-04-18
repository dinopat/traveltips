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
using traveltips.Services;

public partial class Admin_RequestPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        if (!Page.IsPostBack)
        {
        }
    }
    private bool CheckValidEmail()
    {
        lblError.Text = string.Empty;
        bool isValid = true;
        string email = txtEmail.Text.Trim();

        if (!Utility.CheckEmailAddress(email))
        {
            Utility.SetErrorMessage(lblError, Resources.MessageResource.invalidEmail.ToString());
            isValid = false;
        }
        else
        {
            AdminService adminService = new AdminService();
            if (adminService.IsExistEmailOfAdmin_Sp(email))
            {
                isValid = true;
            }
            else
            {
                Utility.SetErrorMessage(lblError, Resources.MessageResource.emailNotUsed.ToString());
                isValid = false;
            }
        }
        return isValid;
    }
    protected void btnRequestPW_Click(object sender, EventArgs e)
    {
        if (CheckValidEmail())
        {
            //Do send password
        }
    }
}
