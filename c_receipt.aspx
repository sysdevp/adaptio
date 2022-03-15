<%@ Page Language="C#" MasterPageFile="~/cmasterPage.master" AutoEventWireup="true" CodeFile="c_receipt.aspx.cs" Inherits="c_receipt" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

<div align="center">
<br /><br />

<table class="tbl">
<caption>Personal Details</caption>
<tr align="left">
<td>Name: </td>
<td>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</td>
<td></td>

<td>Contact Number: </td>
<td>
    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
</td>
<td></td>
</tr>

<tr align="left">
<td align="left">Address: </td>
<td>
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
</td>
<td></td>

<td>City: </td>
<td>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
</td>
<td></td>
</tr>

<tr align="left">
<td>State: </td>
<td>
    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
</td>
<td></td>

<td>Pincode: </td>
<td>
    <asp:TextBox ID="txtPincode" runat="server"></asp:TextBox>
</td>
<td></td>
</tr>
</table>
<br />
<table class="tbl">
<caption>Exam Details</caption>
<tr align="left">
<td>Select Vendor: </td>
<td>
    <asp:DropDownList ID="drpVendor" runat="server">
        <asp:ListItem>&lt;-- Select --&gt;</asp:ListItem>
        <asp:ListItem>Prometric</asp:ListItem>
        <asp:ListItem>Pearson VUE</asp:ListItem>
        <asp:ListItem>Ec Council</asp:ListItem>
        <asp:ListItem>ITB</asp:ListItem>
    </asp:DropDownList>
</td>
<td></td>
<td>Exam Code: </td>
<td>
    <asp:TextBox ID="txtExamCode" runat="server"></asp:TextBox>
</td>
<td></td>
</tr>

<tr align="left">
<td>No.of Vouchers: </td>
<td>
    <asp:TextBox ID="txtNoOfVouchers" runat="server"></asp:TextBox>
</td>
<td></td>

<td>Amount Received: </td>
<td>
    <asp:TextBox ID="txtAmountReceived" runat="server"></asp:TextBox>
</td>
<td></td>
</tr>

<tr>
<td colspan="6" align="center">
    Payment Mode:<asp:RadioButton ID="rbtCash" runat="server" Text="Cash" 
        GroupName="g1" /> 
    &nbsp; /&nbsp;<asp:RadioButton ID="rbtCheque" runat="server" Text="Cheque" 
        GroupName="g1" />
</td>
</tr>

<tr align="left">
<td>Additional Details: </td>
<td colspan="4">
    <asp:TextBox ID="txtAdditionalDetails" runat="server" Width="100%"></asp:TextBox>
</td>
<td></td>
</tr>

<tr>
<td colspan="6">
    <asp:Button ID="btnOk" runat="server" Text="Generate Receipt" CssClass="btn" 
        onclick="btnOk_Click" Width="100%" />

</td>
</tr>
</table>



<asp:Panel ID="Panel1" runat="server" Width="8.27in" Font-Size="Large" 
        Visible="False" >
        
        <table width="100%">
        <tr>
            <td align="left">
                <asp:Image ID="Image1" runat="server" ImageUrl="images/maze_logo.jpg" />                
            </td>
            
            <td></td>
        </tr>
        
        <tr>
            <td align="left">
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblCity" runat="server"></asp:Label>, 
                <asp:Label ID="lblState" runat="server"></asp:Label>,
                <asp:Label ID="lblPinCode" runat="server"></asp:Label>
            </td>
            
            <td align="right">
                <asp:Label ID="lblPhone" runat="server"></asp:Label> 
                <br />
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>        
        </table>
        
        <table width="auto" border="1" 
                style="font-family: 'Arial Black'; font-size: large; font-weight: bold; border-style: solid"><tr align="center"><td align="center">
                R E C E I P T</td></tr>
        </table>
        
        <table width="100%">
            <tr>
                
                
                <td align="right" style="font-weight: bold">
                    No: <asp:Label ID="lblNo" runat="server"></asp:Label>
                </td>
            </tr>
            
             <tr>
                
             
                <td align="right" style="font-weight: bold">
                    Date: <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
        <table width="100%">
            <tr>
                <td align="left">
                Received with thanks from . . . . . <asp:Label ID="lblName" runat="server" 
                        Font-Bold="True"></asp:Label> . . . . .
                <br />
                    the sum of. . . . . <asp:Label ID="lblAmountInWords" runat="server"></asp:Label> . . . . .
                <br />
                by <asp:Label ID="lblCashCheque" runat="server"></asp:Label> 
                    &nbsp;<asp:Label ID="lblChequeDetails" runat="server"></asp:Label><br />
                    on Account of <asp:Label ID="lblDetails" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
       
        
        <table width="100%">
            <tr>
                <td align="left" style="font-weight: bold">Rs. <asp:Label ID="lblRs" runat="server"></asp:Label>/- Only</td>
                <td align="right">
                    For Mazenet
                    <br /><br /><br />                    
                </td>
            </tr>
            
            <tr>
                <td align="left" style="font-size: small; font-style: italic">                    
                    * Cheques are subject to realisation<br />
                    Once paid will not be refunded                        
                </td>
                
                <td align="right">
                    Authorized Signatory
                </td>
            </tr>
        </table>
        
        </asp:Panel>
        
        
        
        
</div>                        
    
</asp:Content>


