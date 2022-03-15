<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="add_new_material.aspx.cs" Inherits="add_new_material" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="CPH_Use">
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
   </asp:ToolkitScriptManager>

<div align="center">    
    <br /> <br /> <br /> <br />                    
<table class="tbl">
     <tr>
        <td bgcolor="#267ac9" colspan="6" align="center"> Add new material</td>
     </tr>
    
            <tr>
                <td>Material Type: </td>
                <td>
                    <asp:DropDownList ID="drpMaterialType" runat="server">
                    <asp:ListItem><-- Select Material Type --></asp:ListItem>
                    <asp:ListItem Value="1">Hard Copy</asp:ListItem>
                    <asp:ListItem Value="0">Soft copy</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Material Type" InitialValue="<-- Select Material Type -->" ControlToValidate="drpMaterialType" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpMaterial">*</asp:RequiredFieldValidator></td>
                <td>Material From: </td>
                <td>
                    <asp:DropDownList ID="drpMaterialFrom" runat="server">
                    <asp:ListItem><-- Select Material From --></asp:ListItem>
                    <asp:ListItem Value="0">Mazenet</asp:ListItem>
                    <asp:ListItem Value="1">Global</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Material From" InitialValue="<-- Select Material From -->" ControlToValidate="drpMaterialFrom" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpMaterial">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Vendor: </td>
                <td>
                    <asp:DropDownList ID="drpVendor" runat="server">
                    <asp:ListItem><-- Select Vendor --></asp:ListItem>
                    <asp:ListItem>Android</asp:ListItem>
                    <asp:ListItem>BCS</asp:ListItem>
                    <asp:ListItem>Big Data</asp:ListItem>
                    <asp:ListItem>Cisco</asp:ListItem>
                    <asp:ListItem>CompTIA</asp:ListItem>
                    <asp:ListItem>Ec Council</asp:ListItem>
                    <asp:ListItem>Exin</asp:ListItem>
                    <asp:ListItem>Google</asp:ListItem>
                    <asp:ListItem>Microsoft</asp:ListItem>
                    <asp:ListItem>Oracle</asp:ListItem>
                    <asp:ListItem>RedHat</asp:ListItem>
                    <asp:ListItem>Zend</asp:ListItem>
                    <asp:ListItem>Not Applicable</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Vendor" ControlToValidate="drpVendor" InitialValue="<-- Select Vendor -->" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpMaterial">*</asp:RequiredFieldValidator></td>
                <td>Course Type: </td>
                <td>
                    <asp:DropDownList ID="drpCourseType" runat="server">
                     <asp:ListItem><-- Select Course Type --></asp:ListItem>
                    <asp:ListItem Value="1">Hardware</asp:ListItem>
                    <asp:ListItem Value="0">Software</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Course Type" ControlToValidate="drpCourseType" InitialValue="<-- Select Course Type -->" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpMaterial">*</asp:RequiredFieldValidator></td>
            </tr>
    <tr>
        <td>Enter Material Name:</td>
        <td colspan="4"><asp:TextBox ID="txtMaterialName" runat="server" Width="470px"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtMaterialName" Display="Dynamic" ValidationGroup="grpMaterial" 
                                ErrorMessage="Enter new material" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator> 
        </td>
     </tr>
    
    <tr>
        <td align="center" colspan="6"><asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="grpMaterial" CssClass="btn" 
                onclick="btnSubmit_Click" />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </td>
    </tr>
  </table>
    
  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grpMaterial" ShowMessageBox="true" ShowSummary="false" />       
</div>                        
</asp:Content>


