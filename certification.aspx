<%@ Page Language="C#" AutoEventWireup="true" CodeFile="certification.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="biz_style.css"  type="text/css" />
    
</head>
<body>
 
    <form id="form1" runat="server" defaultbutton="btnLogin" 
    defaultfocus="txtUserName">
    <div>
    <table style="width: 100%;">
                <tr>
                    <td align="left">
                    
                        <asp:Image ID="imgMazeLogo" runat="server" ImageUrl="~/images/maze_logo.jpg" />
                    
                    </td>
                    <td align="right">
                    
                        <asp:Image ID="imgTitle" runat="server" ImageUrl="~/images/title.png" />
                    
                    </td>
                </tr>                
            </table>
            <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/images/bg_main.png" 
                Height="42px">                
                <table style="width: 100%; height: 15px; padding: 10px">
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                </table>
                </asp:Panel>
                
    </div>
    
    <div align="center"style="margin-top: 200px; background-image: none;">
            <table class="tbl">
                <caption>Login</caption>                            
                <tr>
                    <td align="right">
                        Enter User Name :
                    </td>
                    <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td align="right">
                    Enter Password :</td>
                   <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>                    
                    <td align="right" colspan="2">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn" Text="Login" 
                            onclick="btnLogin_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
                                
                <tr>                    
                    <td colspan="2" align="right">
                        <asp:Label ID="lblResult" runat="server" ForeColor="#CC3300"></asp:Label>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
