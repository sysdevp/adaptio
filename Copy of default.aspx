<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="stylelog.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="layer01_holder">
  <div id="left"></div>
  <div id="center"></div>
  <div id="right"></div>
</div>

<div id="layer02_holder">
  <div id="left"></div>
  <div id="center"></div>
  <div id="right"></div>
</div>

<div id="layer03_holder">
  <div id="left"></div>
  <div id="center">
    <table width="100%">

<tr>
<td>Enter Username: </td>
<td></td>
</tr>

<tr>
<td><asp:TextBox ID="txtUserName" runat="server" Width="100%"></asp:TextBox> </td>
<td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator></td>
</tr>


<tr>
<td>Enter Password: </td>
<td></td>
</tr>

<tr>
<td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox> </td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td>
 <asp:Button ID="btnLogin" runat="server" Text="Login" 
                            onclick="btnLogin_Click" />
</td>

<td></td>
</tr>
    
  </table>
  
  
  
  </div>
  <div id="right"></div>
</div>

<div id="layer04_holder">
  <div id="left"></div>
  <div id="center">
  If you forgot your password, please contact administrator.</div>
  <div id="right"></div>
</div>

<div id="layer05_holder">

</div>
    </form>
</body>
</html>
