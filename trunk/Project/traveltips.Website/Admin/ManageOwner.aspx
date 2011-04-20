<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminFull.master" AutoEventWireup="true" CodeFile="ManageOwner.aspx.cs" Inherits="Admin_ManageOwner" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        	<h3 class="heading colr">
                Quản lý người dùng - chủ công ty</h3>
                        
            <div class="clear"></div>
        
        <div style="margin-left:20px;margin-right:20px;">  
    <asp:GridView ID="grvChuCongTy" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDeleting="grvChuCongTy_RowDeleting" OnRowUpdating="grvChuCongTy_RowUpdating" OnRowCommand="grvChuCongTy_RowCommand"  >
        <Columns>
            <asp:TemplateField HeaderText="T&#234;n">
                <HeaderStyle BackColor="#0D91C8" Width="25%" ForeColor="White" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Width="25%" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                        <asp:Label ID="lblChuCongTy" runat="server" Text='<%# Bind("TenChuCongTy") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Địa chỉ">
                <HeaderStyle BackColor="#0D91C8" Width="30%" ForeColor="White" />
                <ItemStyle Width="30%" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                        <asp:Label ID="lblDiaChi" runat="server" Text='<%# Bind("DiaChi") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <HeaderStyle BackColor="#0D91C8" Width="15%" ForeColor="White" />
                <ItemStyle Width="15%" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="T&#236;nh trạng">
                <HeaderStyle BackColor="#0D91C8" Width="15%" ForeColor="White" />
                <ItemStyle Width="15%" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                        <asp:Label ID="lblFlag" runat="server" Text='<%# Bind("Flag") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chức năng">
                <HeaderStyle BackColor="#0D91C8" Width="15%" ForeColor="White" />
                <ItemStyle Width="15%" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                      
                       
                          <asp:ImageButton ToolTip="Xoá người dùng" ID="imgBtnDeleteUser" runat="server"  ImageUrl="~/images/delete.png"
                            OnClientClick="javascript: return confirm('Bạn có chắc chắn muốn xóa?')" CommandName="Delete" />
                        <asp:ImageButton ToolTip="Cập nhật người dùng" ID="imgBtnEditUser" runat="server"  ImageUrl="~/images/edit.png" CommandName="Update" />
                        <asp:ImageButton ToolTip="Khóa người dùng" ID="imgBtnBlockUser" runat="server"  ImageUrl="~/images/block.png" CommandArgument='<%# Bind("id_ChuCongTy") %>'
                            CommandName="Block" />
                             
                             <asp:Label Visible="false" ID="id_ChuCongTy" runat="server" Text='<%# Bind("id_ChuCongTy") %>'></asp:Label>
                             
                    </ItemTemplate>
               
            </asp:TemplateField>
        </Columns>
    
    </asp:GridView>


</div>  
          		                <div style="margin-left: 90%;">
				    <label class="button">
					     <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="Button" />
					    <span>Tạo mới »</span>
				    </label>
			    </div>
           
       
            <asp:HiddenField ID="hddIdChuCongTy" runat="server" />
            <asp:HiddenField ID="hddIsCreateUser" runat="server" />
            
            <h3 class="heading colr" style="margin-left:10px;margin-top:20px;padding-top:0px;">
               Xem,cập nhật thông tin tài khoản chủ công ty</h3>
                        
            <div class="clear"></div>
            
               <div class="khungnoi" style="margin-left:20px;margin-right:20px;">
                 <div class="divError"><asp:Label ID="lblError" runat="server"></asp:Label></div>
			  <div class="controldiv">
			    <label class="label_align">Tên chủ công ty
				<span>* </span></label>
<asp:TextBox ID="txtTenChuCongTy" runat="server" Width="450px"></asp:TextBox>
			  </div>
			  <div class="controldiv">
			    <label class="label_align">Tên công ty
				<span>* </span></label>
<asp:TextBox ID="txtTenCongTy" runat="server" Width="450px"></asp:TextBox>

			  </div>
			  <div class="controldiv">
	<label class="label_align">
Tên đăng nhập<span>* </span> </label>
 	    <asp:TextBox ID="txtTenDangNhap"  runat="server" Width="450px"></asp:TextBox>
 	</div>
 	
 				  <div class="controldiv">
	<label class="label_align">
Mật khẩu<span>* </span> </label>
 	         <asp:TextBox ID="txtMatKhau" TextMode="Password" runat="server" Width="450px"></asp:TextBox>
 	</div>
 	
 		<div class="controldiv">
                      <label class="label_align">Địa chỉ <span>* </span>
                      </label>
                      <asp:TextBox ID="txtDiaChi"  runat="server" Width="450px"></asp:TextBox>
				</div>
				
	<div class="controldiv">
                      <label class="label_align">Điện thoại cố định <span>* </span>
                      </label>
                       <asp:TextBox ID="txtDTCD"  runat="server" Width="450px"></asp:TextBox>                 
				</div>
						<div class="controldiv">
						
                    <label class="label_align">
                        Điện thoại di động <span>* </span>
                    </label>
				<asp:TextBox ID="txtDTDD"  runat="server" Width="450px"></asp:TextBox>                
					</div>
					
	   	
			   
		</div>

                       
                           
                   <div class="submit_box">
		 
				
					                <div style="margin-left: 145px;">
				    <label class="button">
					     <asp:Button ID="btnUpdateUser" runat="server" OnClick="btnUpdateUser_Click" Text="Button" />
					    <span>Lưu »</span>
				    </label>
			    </div>
					</div>
 
    
    
      
      
      
      
	
   </div>
</asp:Content>

