<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeView.aspx.cs" Inherits="Admin_TreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="Leaf" Width="170px">
            <Nodes>
                <asp:TreeNode Text="Ẩm Thực" Value="Ẩm Thực">
                    <asp:TreeNode Text="Khu ẩm thực" Value="Khu ẩm thực"></asp:TreeNode>
                    <asp:TreeNode Text="Qu&#225;n ăn" Value="Qu&#225;n ăn"></asp:TreeNode>
                    <asp:TreeNode Text="C&#224; ph&#234;" Value="C&#224; ph&#234;">
                        <asp:TreeNode Text="C&#224; ph&#234; hộp" Value="C&#224; ph&#234; hộp"></asp:TreeNode>
                        <asp:TreeNode Text="C&#224; ph&#234; Wifi" Value="C&#224; ph&#234; Wifi"></asp:TreeNode>
                        <asp:TreeNode Text="C&#224; ph&#234; nhạc sống" Value="C&#224; ph&#234; nhạc sống"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="Nh&#224; h&#224;ng" Value="Nh&#224; h&#224;ng">
                        <asp:TreeNode Text="Nh&#224; h&#224;ng &#193;" Value="Nh&#224; h&#224;ng &#193;"></asp:TreeNode>
                        <asp:TreeNode Text="Nh&#224; h&#224;ng &#194;u" Value="Nh&#224; h&#224;ng &#194;u"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Tour" Value="Tour">
                    <asp:TreeNode Text="Tour trong nước" Value="Tour trong nước"></asp:TreeNode>
                    <asp:TreeNode Text="Tour nước ngo&#224;i" Value="Tour nước ngo&#224;i"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Nghỉ Ngơi" Value="Nghỉ Ngơi">
                    <asp:TreeNode Text="Resort" Value="Resort"></asp:TreeNode>
                    <asp:TreeNode Text="Kh&#225;ch sạn 5 sao" Value="Kh&#225;ch sạn 5 sao"></asp:TreeNode>
                    <asp:TreeNode Text="Kh&#225;ch sạn 4 sao" Value="Kh&#225;ch sạn 4 sao"></asp:TreeNode>
                    <asp:TreeNode Text="Kh&#225;ch sạn 3 sao" Value="Kh&#225;ch sạn 3 sao"></asp:TreeNode>
                    <asp:TreeNode Text="Kh&#225;ch sạn 2 sao" Value="Kh&#225;ch sạn 2 sao"></asp:TreeNode>
                    <asp:TreeNode Text="Kh&#225;ch sạn 1 sao" Value="Kh&#225;ch sạn 1 sao"></asp:TreeNode>
                    <asp:TreeNode Text="Nh&#224; nghỉ" Value="Nh&#224; nghỉ"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Mua Sắm" Value="Mua Sắm">
                    <asp:TreeNode Text="Si&#234;u thị" Value="Si&#234;u thị"></asp:TreeNode>
                    <asp:TreeNode Text="Chợ" Value="Chợ"></asp:TreeNode>
                    <asp:TreeNode Text="Shop - Cửa h&#224;ng" Value="Shop - Cửa h&#224;ng"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Giải Tr&#237;" Value="Giải Tr&#237;">
                    <asp:TreeNode Text="Vũ trường" Value="Vũ trường"></asp:TreeNode>
                    <asp:TreeNode Text="Bar" Value="Bar"></asp:TreeNode>
                    <asp:TreeNode Text="Spa - M&#225;t xa" Value="Spa - M&#225;t xa"></asp:TreeNode>
                    <asp:TreeNode Text="Rạp phim" Value="Rạp phim"></asp:TreeNode>
                    <asp:TreeNode Text="Karaoke" Value="Karaoke"></asp:TreeNode>
                    <asp:TreeNode Text="Bi da" Value="Bi da"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Phương Tiện" Value="Phương Tiện">
                    <asp:TreeNode Text="M&#225;y bay" Value="M&#225;y bay"></asp:TreeNode>
                    <asp:TreeNode Text="T&#224;u hỏa" Value="T&#224;u hỏa"></asp:TreeNode>
                    <asp:TreeNode Text="&#212; t&#244;" Value="&#212; t&#244;"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Danh Lam Thắng Cảnh" Value="Danh Lam Thắng Cảnh"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
