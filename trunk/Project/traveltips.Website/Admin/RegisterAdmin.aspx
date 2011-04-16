<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminFull.master" AutoEventWireup="true"
    CodeFile="RegisterAdmin.aspx.cs" Inherits="Admin_RegisterAdmin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Section -->
   <%-- <div id="content_sec">--%>
        <!-- Column2 Section -->
        <h3 class="heading colr">
            Đăng ký tài khoản Admin</h3>
        <div class="col2">
            <!-- Product Detail -->
            <div>
                <div class="header">
                    Thông tin tài khoản
                </div>
                <div class="khungnoi">
                
                <div class="divError"><asp:Label ID="lblError" runat="server"></asp:Label></div>
                    <div class="controldiv">
                        <label class="label_align">
                            Tên đăng nhập <span>* </span>
                        </label>
                      <%--  <input type="text" class="long" id="Text1" name="txtEmail1" />--%>
                      <asp:TextBox ID="txtTenDangNhap" runat="server" Width="247"  Text=""></asp:TextBox>
                    </div>
                    <div class="controldiv">
                        <label class="label_align">
                            Email <span>* </span>
                        </label>
                      <%--  <input type="text" class="long" id="Text3" name="txtEmail1" />--%>
                        <asp:TextBox ID="txtEmail" runat="server" Width="247"  Text=""></asp:TextBox>
                    </div>
                    <div class="controldiv">
                        <label class="label_align">
                            Mật khẩu <span>* </span>
                        </label>
                       <%-- <input type="password" class="long widthPass" id="Password4" value="123456" name="Password" />--%>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="247"  Text=""></asp:TextBox>
                    </div>
                    <div class="controldiv">
                        <label class="label_align">
                            <span>Họ tên đầy đủ * </span>
                        </label>
                       <%-- <input type="password" class="long widthPass" id="Password6" value="123456" name="Password" />--%>
                        <asp:TextBox ID="txtFullName" runat="server" Width="247"  Text=""></asp:TextBox>
                    </div>
                    <div class="controldiv">
                        <label class="label_align">
                            Điện thoại <span>* </span>
                        </label>
                       <%-- <input type="password" class="long widthPass" id="Password3" name="Password" />--%>
                       <asp:TextBox ID="txtTelephone" runat="server" Width="247"  Text=""></asp:TextBox>
                    </div>

                </div>
                <div class="submit_box">
                    <div style="margin-left: 127px;">
                        
                        <label class="button">
                            <asp:Button ID="btnSaveRegister" runat="server" OnClick="btnSaveRegister_Click" Text="Button" />
                            <span>Lưu »</span>
                        </label>
                       
                    </div>
                </div>
            </div>
        </div>
        <div class="col2_right">
            <div class="header">
                Qui định đăng ký tài khoản
            </div>
            <div class="hint_register">
                <p>
                    * Xin vui lòng lưu ý những quy định dưới đây trước khi đăng ký thành viên và đăng
                    tải thông tin mua bán, quảng cáo, rao vặt.</p>
                <p>
                    1. Chúng tôi giữ quyền quyết định về việc lưu giữ hay loại bỏ tin đã đăng trên trang
                    web này mà không cần báo trước, tất cả mọi sự vi phạm của bạn vào một hay nhiều
                    điều khoản đã được ghi trong quy định này sẽ dẫn đến việc tin đăng, tài khoản, tư
                    cách thành viên của bạn bị hủy bỏ. Bạn bị cấm vĩnh viễn không được tham gia vào
                    mọi hoạt động trên Website.</p>
                <p>
                    2. Chúng tôi không chịu trách nhiệm và không bảo đảm về tính chính xác của những
                    thông tin từ các thành viên gởi đăng mua bán, rao vặt, và cũng không chịu bất cứ
                    trách nhiệm pháp lý hoặc bồi thường thiệt hại nào về việc mất mát hay hư hỏng đối
                    với những tin đã đăng mua bán, rao vặt.</p>
                <p>
                    3. Nội dung thông tin rao vặt:
                </p>
                <p>
                    * Không sex, crack, hack, chính trị, tôn giáo</p>
                <p>
                    * Không dùng từ ngữ thiếu văn hóa, không thách thức, nói xấu lẫn nhau.</p>
                <p>
                    * Không được phép cố tình truy cập vào tài khoản của người khác.</p>
            </div>
        </div>
        <div class="clear">
        </div>
   <%-- </div>--%>
</asp:Content>
