<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_LoginAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <!-- // Stylesheets // 
    <link href="../css/style_onecolumn.css" rel="stylesheet" type="text/css"/>
        <link rel="stylesheet" type="text/css" href="../css/ddsmoothmenu.css" />
 -->
    <link href="../css/styleAdmin.css" rel="stylesheet" type="text/css" />
    <link href="../css/adminFullBody.css" rel="stylesheet" type="text/css" />   
    <link href="../css/button.css" rel="stylesheet" type="text/css" />   
    <link rel="stylesheet" href="../css/slider.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../css/jquery.css" />
    <link rel="stylesheet" type="text/css" href="../css/contentslider.css" />
    <link href="../css/formGUI.css" rel="stylesheet" type="text/css" />
    <link href="../css/button.css" rel="stylesheet" type="text/css" />
    <!-- // Javascript // -->

    <script type="text/javascript" src="../js/jquery_005.js"></script>

    <script type="text/javascript" src="../js/jquery_002.js"></script>

    <script type="text/javascript" src="../js/ddsmoothmenu.js"></script>

    <script type="text/javascript" src="../js/menu.js"></script>

    <script type="text/javascript" src="../js/jquery_004.js"></script>

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script type="text/javascript" src="../js/anything.js"></script>

    <script type="text/javascript" src="../js/jcarousellite_1.js"></script>

    <script type="text/javascript" src="../js/scroll.js"></script>

    <script type="text/javascript" src="../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../js/Trebuchet_MS_400-Trebuchet_MS_700-Trebuchet_MS_italic_700-Tre.js"></script>

    <script type="text/javascript" src="../js/cufon.js"></script>

    <script type="text/javascript" src="../js/contentslider.js"></script>

    <script type="text/javascript" src="../js/jquery_003.js"></script>

    <script type="text/javascript" src="../js/lightbox.js"></script>

</head>
<body>
        <div style="left: 695.167px; top: 152px;" class="ddshadow toplevelshadow">
        </div>
        <div style="left: 591.267px; top: 152px;" class="ddshadow toplevelshadow">
        </div>
        <div style="left: 373.05px; top: 152px;" class="ddshadow toplevelshadow">
        </div>
        <a name="top"></a>
        <div id="wrapper_sec">
            <!-- Header -->
            <div id="masthead">
                <div class="logo">
                    <a href="#">
                        <img src="../images/logo.png" alt="" /></a>
                </div>
            </div>
            <div class="clear">
            </div>
            <!-- Bread Crumb Section -->
            <div class="clear">
            </div>
            <!-- Content Section -->
            <div id="content_sec">
    <form id="formAdminLogin" runat="server"> 
                <div class="loginadmin">
                    <h3 class="heading colr">
                        Đăng nhập</h3>
                    <table cellspacing="0">
                        <tbody>
                                <tr>
                                <td class="html7magic">
                                                     <div class="divError"><asp:Label ID="lblError" runat="server"></asp:Label></div>
 </td>
                                <td class="html7magic">
                                    </td>
                           
                            <tr>
                                <td class="html7magic">
                                    <label for="email">
                                        Email</label></td>
                                <td class="html7magic">
                                    <label for="pass">
                                        Password</label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" Width="247"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" Width="247"></asp:TextBox>
                                </td>
                                <td>
                                    <label class="button">
                                        <asp:Button ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click" />
                                        <span>Đăng nhập</span>
                                    </label>
                                 </td>
                            </tr>
                            <tr>
                                <td class="login_form_label_field" style="height: 27px">
                                    <input type="checkbox" tabindex="3" name="persistent" id="persistent" value="1" class="inputcheckbox"/><label for="persistent" id="label_persistent">Ghi nhớ đăng nhập</label></td>
                                <td class="login_form_label_field" style="height: 27px">
                                    <a rel="nofollow" href="RequestPassword.aspx">Quên password?</a></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
  </form>
            </div>
            <div class="clear">
            </div>
            <!-- Footer Section -->
        </div>
        <div id="fancybox-tmp">
        </div>
        <div id="fancybox-overlay">
        </div>
        <div id="fancybox-wrap">
            <div id="fancybox-outer">
                <div class="fancy-bg" id="fancy-bg-n">
                </div>
                <div class="fancy-bg" id="fancy-bg-ne">
                </div>
                <div class="fancy-bg" id="fancy-bg-e">
                </div>
                <div class="fancy-bg" id="fancy-bg-se">
                </div>
                <div class="fancy-bg" id="fancy-bg-s">
                </div>
                <div class="fancy-bg" id="fancy-bg-sw">
                </div>
                <div class="fancy-bg" id="fancy-bg-w">
                </div>
                <div class="fancy-bg" id="fancy-bg-nw">
                </div>
                <div id="fancybox-inner">
                </div>
                <a id="fancybox-close"></a><a href="javascript:;" id="fancybox-left"><span class="fancy-ico"
                    id="fancybox-left-ico"></span></a><a href="javascript:;" id="fancybox-right"><span
                        class="fancy-ico" id="fancybox-right-ico"></span></a>
            </div>
        </div>
    </body>
</html>
