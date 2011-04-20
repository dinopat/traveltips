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
using traveltips.Entities;
using traveltips.Services;

public partial class Admin_ManageOwner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetListChuCongTy();
        }
    }

    private void GetListChuCongTy()
    {
        ChuCongTyService ch = new ChuCongTyService();
        TList<ChuCongTy> listCh = ch.GetChuCongTyInfo();
        DataTable dt = new DataTable();
        dt.Columns.Add("id_ChuCongTy", typeof(long));
        dt.Columns.Add("TenChuCongTy", typeof(string));
        dt.Columns.Add("DiaChi", typeof(string));
        dt.Columns.Add("Email", typeof(string));//email,chua co truong Email trong tbl_ChuCongTy
        dt.Columns.Add("Flag", typeof(string));
        foreach (ChuCongTy item in listCh)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.IdChuCongTy;
            dr[1] = item.TenChuCongTy;
            dr[2] = item.DiaChi;
            dr[3] = item.DiaChi;
            if(item.Flag.ToString().Equals("0"))
            {
                dr[4] = "đang sử dụng";
            }
            else
            {
                dr[4] = "bị khóa";
            }
            
            dt.Rows.Add(dr);
        }
        grvChuCongTy.DataSource = dt;
        grvChuCongTy.DataBind();
    }

    protected void grvChuCongTy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lbl = (Label)grvChuCongTy.Rows[e.RowIndex].Cells[4].FindControl("id_ChuCongTy");
        ChuCongTyService cty = new ChuCongTyService();
        cty.DeleteChuCongTyByIdChuCongTy(long.Parse(lbl.Text));
        GetListChuCongTy();
    }

    protected void grvChuCongTy_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lbl = (Label)grvChuCongTy.Rows[e.RowIndex].Cells[4].FindControl("id_ChuCongTy");
        ChuCongTyService cty = new ChuCongTyService();
        ChuCongTy chuCT= cty.GetChuCongTyInfoByIdChuCongTy(long.Parse(lbl.Text));
        txtDiaChi.Text = chuCT.DiaChi;
        txtDTCD.Text = chuCT.DienThoaiCd;
        txtDTDD.Text = chuCT.DienThoaiDd;
        txtMatKhau.Text = chuCT.Password;
        txtTenChuCongTy.Text = chuCT.TenChuCongTy;
        txtTenCongTy.Text = chuCT.TenCongTy;
        txtTenDangNhap.Text = chuCT.TenDangNhap;
        hddIdChuCongTy.Value = lbl.Text;
        hddIsCreateUser.Value = "false";
    }


    protected void btnUpdateUser_Click(object sender, EventArgs e)
    {
        ChuCongTyService cty = new ChuCongTyService();
        bool isUpdated = false;
        bool isInserted = false;
        try
        {
            if (hddIsCreateUser.Value == "true")
            {
                // tao moi chu cong ty
                ChuCongTy chuCT = new ChuCongTy();
                chuCT.TenDangNhap = txtTenDangNhap.Text.Trim();
                chuCT.TenCongTy = txtTenCongTy.Text.Trim();
                chuCT.TenChuCongTy = txtTenChuCongTy.Text.Trim();
                chuCT.DienThoaiDd = txtDTDD.Text.Trim();
                chuCT.DienThoaiCd = txtDTCD.Text.Trim();
                chuCT.DiaChi = txtDiaChi.Text.Trim();
                chuCT.Password = txtMatKhau.Text.Trim();
                isInserted = cty.InsertChuCongTy(chuCT);
                if (isInserted)
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.createOwnerSuccessfully.ToString());
                }
                else
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.createOwnerFailure.ToString());
                }
            }
            else
            {
                //cap nhat chu cong ty
                ChuCongTy ctyInfo = cty.GetChuCongTyInfoByIdChuCongTy(long.Parse(hddIdChuCongTy.Value.ToString()));
                ctyInfo.TenDangNhap = txtTenDangNhap.Text.Trim();
                ctyInfo.TenCongTy = txtTenCongTy.Text.Trim();
                ctyInfo.TenChuCongTy = txtTenChuCongTy.Text.Trim();
                ctyInfo.DienThoaiDd = txtDTDD.Text.Trim();
                ctyInfo.DienThoaiCd = txtDTCD.Text.Trim();
                ctyInfo.DiaChi = txtDiaChi.Text.Trim();
                ctyInfo.Password = txtMatKhau.Text.Trim();

                isUpdated = cty.UpdateChuCongTy(ctyInfo);
                if (isUpdated)
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.updateOwnerSuccessfully.ToString());
                }
                else
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.updateOwnerFailure.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Utility.SetErrorMessage(lblError, "loi cap nhat owner "+ex.Message+ex.StackTrace);
        }
    }
    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        hddIsCreateUser.Value = "true";
        txtDiaChi.Text = "";
        txtDTCD.Text = "";
        txtDTDD.Text = "";
        txtMatKhau.Text = "";
        txtTenChuCongTy.Text = "";
        txtTenCongTy.Text = "";
        txtTenDangNhap.Text = "";
    }
    protected void grvChuCongTy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Block")
        {
            //Response.Redirect("Vote.aspx?id=" + e.CommandArgument);
            bool isUpdated = false;
            ChuCongTyService cty = new ChuCongTyService();
            try
            {
                //cap nhat chu cong ty
                isUpdated = cty.BlockChuCongTyByIdChuCongTy(long.Parse(e.CommandArgument.ToString()));
                if (isUpdated)
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.blockOwnerSuccessfully.ToString());
                    GetListChuCongTy();
                }
                else
                {
                    Utility.SetErrorMessage(lblError, Resources.MessageResource.blockOwnerFailure.ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.SetErrorMessage(lblError, "loi block owner " + ex.Message + ex.StackTrace);
            }
        }
    }
}
