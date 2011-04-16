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
            lblError.Text = "Các trường có dấu * không được để trống";
            isValid = false;
        }
        else
        {
            if (!Utility.CheckEmailAddress(email))
            {
                SetErrorMessage("Địa chỉ email không hợp lệ");
                isValid = false;
            }
            if (matKhau.Length < 6)
            {
                SetErrorMessage("Mật khẩu phải có ít nhất 6 ký tự");
                isValid = false;
            }
            if (!Utility.IsNumber(soDT))
            {
                SetErrorMessage("Điện thoại phải là số");
                isValid = false;
            }
        }
        return isValid;
    }

    private void SetErrorMessage(string errorMessage)
    {
        if (String.IsNullOrEmpty(lblError.Text.Trim()))
        {
            lblError.Text = "- "+errorMessage;
        }
        else
        {
            lblError.Text += "<br /> <br />" + "- " + errorMessage;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!CheckValidRegister())
        {
            AdminService adminService = new AdminService();
            Admin admin = new Admin();
            admin.TenDangNhap = "";
            admin.Password = "";
            admin.Email = "";
            admin.HoTen = "";
            admin.DienThoai = "";
            adminService.Insert(admin);
        }
    }
}
