<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="create_class.aspx.cs" Inherits="create_class" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

<div align="center">
<br /> <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table>
    <tr valign="top">
        <td>
            <table class="tbl">
    <caption>Create New Class Room</caption>
    <tr>
        <td>Select Branch: </td>
        <td> <asp:DropDownList ID="drpBranch" runat="server" AutoPostBack="True" 
                CausesValidation="True" onselectedindexchanged="drpBranch_SelectedIndexChanged"> </asp:DropDownList> </td>
        <td></td>
    </tr>

    <tr>
        <td>Class Name: </td>
        <td> <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox> </td>
        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Class Room Name" ControlToValidate="txtClassName" SetFocusOnError="True" ValidationGroup="grpCreate">*</asp:RequiredFieldValidator> </td>
    </tr>

    <tr>
        <td>Seating Capacity: </td>
        <td> <asp:TextBox ID="txtSeatingCapacity" runat="server"></asp:TextBox> </td>
        <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Seating capacity" ControlToValidate="txtSeatingCapacity" SetFocusOnError="True" ValidationGroup="grpCreate">*</asp:RequiredFieldValidator>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtSeatingCapacity" FilterType="Numbers"> </asp:FilteredTextBoxExtender>
        </td>
    </tr>

    <tr>
        <td colspan="2"> <asp:Button ID="btnCreateNewClassRoom" runat="server" 
                Text="Create Class" onclick="btnCreateNewClassRoom_Click" 
                ValidationGroup="grpCreate" /> </td>
        <td></td>
    </tr>

    <tr>
        <td colspan="2"> <asp:Label ID="lblResult" runat="server"></asp:Label> </td>
        <td></td>
    </tr>

</table>

            <table>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grpCreate" />
                    </td>
                </tr>
            </table>
        </td>
        <td>&nbsp;&nbsp;</td>
        <td>
            <asp:GridView ID="gvDetails" runat="server" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#267ac9" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <Columns>
                    <asp:TemplateField HeaderText="Sl.No" >    
                    <ItemTemplate>
                         <%#((GridViewRow)Container).RowIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
    

</div>
    </asp:Content>


