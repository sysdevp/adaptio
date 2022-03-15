<%@ Page Language="C#" AutoEventWireup="true" CodeFile="c_popup.aspx.cs" Inherits="c_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: large">
    <br />
    
    <table bgcolor="#336699" style="color: #FFFFFF">
    <tr>
    <td><asp:Label ID="lblReceiptNo" runat="server"></asp:Label></td>
    <td><asp:Label ID="lblReceiptDate" runat="server"></asp:Label></td>    
    </tr>
    
    <tr>
    <td><asp:Label ID="lblBranchName" runat="server"></asp:Label></td>
    <td><asp:Label ID="lblEmployee" runat="server"></asp:Label></td>
    </tr>
    </table>
    
    <br />
    
    <table>    
    <tr>
    <td bgcolor="#336699" style="color: #FFFFFF">Sold To:</td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblName" runat="server" Text="lblName"></asp:Label></td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblAddress" runat="server" Text="lblAddress"></asp:Label></td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblCity" runat="server" Text="lblCity"></asp:Label></td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblState" runat="server" Text="lblState"></asp:Label></td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblPincode" runat="server" Text="lblPincode"></asp:Label></td>
    </tr>
    
    <tr>    
    <td><asp:Label ID="lblPhone" runat="server" Text="lblPhone"></asp:Label></td>
    </tr>    
    </table>
    
    <br />
    
    <table>
    <caption style="background-color: #336699; color: #FFFFFF">Certification Details: </caption>
    <tr>
    <td><asp:Label ID="lblVendor" runat="server"></asp:Label></td>
    <td><asp:Label ID="lblExamCode" runat="server"></asp:Label></td>    
    </tr>
    
    <tr>
    <td><asp:Label ID="lblNoOfVoucher" runat="server"></asp:Label></td>
    <td><asp:Label ID="lblAmount" runat="server"></asp:Label></td>    
    </tr>
    
    <tr>
    <td><asp:Label ID="lblDescriptions" runat="server"></asp:Label></td>    
    </tr>
    
    </table>
    
    </div>
    </form>
</body>
</html>
