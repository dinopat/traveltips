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

public partial class Admin_RegisterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!Page.IsPostBack)
        {
        }
    }

    private bool CheckValidRegister()
    {       
        lblError.Text = "";
        bool isValid = true;
        string tenDangNhap = txtTenDangNhap.Text.Trim();
        string matKhau = txtPassword.Text.Trim();
        string email = txtEmail.Text.Trim();
        string hoTen = txtFullName.Text.Trim();
        string soDT = txtTelephone.Text.Trim();
        if (String.IsNullOrEmpty(tenDangNhap) || String.IsNullOrEmpty(matKhau) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(hoTen) || String.IsNullOrEmpty(soDT))
        {
            Utility.SetErrorMessage(lblError,Resources.MessageResource.requiredFields.ToString());
            isValid = false;
        }
        else
        {
            if (!Utility.CheckEmailAddress(email))
            {
                Utility.SetErrorMessage(lblError, Resources.MessageResource.invalidEmail.ToString());
                isValid = false;
            }
            if (matKhau.Length < 6)
            {
                Utility.SetErrorMessage(lblError, Resources.MessageResource.passWordAtLeast6Characters.ToString());
                isValid = false;
            }
            if (!Utility.IsNumber(soDT))
            {
                Utility.SetErrorMessage(lblError, Resources.MessageResource.telephoneMustBeNumber.ToString());
                isValid = false;
            }
        }
        return isValid;
    }



    protected void btnSaveRegister_Click(object sender, EventArgs e)
    {
        if (CheckValidRegister())
        {
            try
            {
                AdminService adminService = new AdminService();
                Admin admin = new Admin();
                admin.TenDangNhap = txtTenDangNhap.Text.Trim();
                admin.Password = DataEncryption.MD5Encrypt(txtPassword.Text.Trim());
                admin.Email = txtEmail.Text.Trim();
                admin.HoTen = txtFullName.Text.Trim();
                admin.DienThoai = txtTelephone.Text.Trim();
                if (adminService.IsExistAdminAccount_Sp(txtTenDangNhap.Text.Trim()))
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.existTenDangNhapAdmin);
                }
                else if (adminService.IsExistEmailOfAdmin_Sp(txtEmail.Text.Trim()))
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.existEmailAdmin);
                }
                else
                {
                    bool ok = adminService.Insert(admin);
                    if (!ok)
                    {
                        Utility.SetErrorMessage(lblError, "ko the insert duoc");
                    }
                    else
                    {
                        Utility.SetErrorMessage(lblError, Resources.MessageResource.createAdminSuccessfully);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.SetErrorMessage(lblError,"Register admin : "+ex.Message+ex.StackTrace);
            }
        }
    }
}
