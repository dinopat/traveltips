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

public partial class Admin_Profile : System.Web.UI.Page
{
    long adminID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Id cua Admin trong Session
        lblError.Text = string.Empty;
        adminID = (long)Session["AdminID"];
        if (!Page.IsPostBack)
        {
            Admin admin = new Admin();
            AdminService adminService = new AdminService();
            admin = adminService.GetByIdAdmin(adminID);
            txtEmail.Text = admin.Email;
            txtUserName.Text = admin.TenDangNhap;
            txtHoTen.Text = admin.HoTen;
            txtPhone.Text = admin.DienThoai;
            txtOldPass.Text = admin.Password;
        }
    }
    protected void btnSaveModify_Click(object sender, EventArgs e)
    {
        try
        {

            Admin admin = new Admin();
            AdminService adminService = new AdminService();
            admin = adminService.GetByIdAdmin(adminID);
            //        admin.Email = txtEmail.Text.Trim();
            admin.HoTen = txtHoTen.Text.Trim();
            admin.DienThoai = txtPhone.Text.Trim();
            adminService.Update(admin);
        }
        catch (Exception ex)
        {
            Utility.SetErrorMessage(lblError, ex.Message + ex.StackTrace);
        }
    }
    private bool checkComfirmPass()
    {
        string newPass = txtNewPass.Text.Trim();
        string comfirmPass = txtRepeatNewPass.Text.Trim();
        bool ok = false;
        if(comfirmPass.Equals(newPass))
        {
            ok = true;
        }
        else
        {
            Utility.SetErrorMessage(lblError, Resources.MessageResource.confirmPasswordNotRight.ToString());
            ok=false;
        }
        return ok;
    }
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin();
        AdminService adminService = new AdminService();
        bool checkPass = this.checkComfirmPass();
        try
        {
            //Check password co khop khong?
            if (checkPass)
            {
                admin = adminService.GetByIdAdmin(adminID);
                admin.Password = txtNewPass.Text.Trim();
                adminService.Update(admin);        
            }
        }
        catch (Exception ex)
        {
            Utility.SetErrorMessage(lblError, ex.Message + ex.StackTrace);
        }
    }
}
