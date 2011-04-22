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
using traveltips.Entities;

public partial class Admin_LoginAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        if (!Page.IsPostBack)
        {
        }
    }
    private bool CheckLogin()
    {
        lblError.Text = string.Empty;
        bool ok = true;
        string matKhau = txtPassWord.Text.Trim();
        string email = txtEmail.Text.Trim();
        if (String.IsNullOrEmpty(matKhau) || String.IsNullOrEmpty(email))
        {
            Utility.SetErrorMessage(lblError, Resources.MessageResource.emailOrPasswordNotOk.ToString());
            ok = false;
        }
        else
        {
            if (!Utility.CheckEmailAddress(email))
            {
                Utility.SetErrorMessage(lblError, Resources.MessageResource.invalidEmail.ToString());
                ok = false;
            }
            else
            {
                AdminService adminService = new AdminService();
                string pass = adminService.GetPassWordByEmail(email);
                if (pass.Equals(matKhau))
                {
                    ok = true;
                }
                else
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.emailOrPasswordNotOk.ToString());
                    ok = false;
                }
            }
        }
        return ok;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool checkInput = this.CheckLogin();
        if (checkInput)
        {
            AdminService adminService = new AdminService();
            Admin currentAdmin = adminService.GetByEmail(txtEmail.Text.Trim());
            Session["AdminID"]=currentAdmin.IdAdmin;
            Response.Redirect("Profile.aspx");
        }
    }
}
