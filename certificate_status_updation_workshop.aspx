<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="certificate_status_updation_workshop.aspx.cs" Inherits="certificate_status_updation_workshop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
        <div align="center">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
        <br /><br />

        <table class="tbl">
        <caption>Certificate Details</caption>
        <tr>
        <td>Candidate Name:</td>
        <td colspan="4">
            <asp:Label ID="lblCandidateName" runat="server"></asp:Label></td>
        <td></td>
        </tr>
        <tr>
        <td>Topic/Course:</td>
        <td>
            <asp:Label ID="lblTopic" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>Held On:</td>
        <td>
            <asp:Label ID="lblHeldOn" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>Held At:</td>
        <td>
            <asp:Label ID="lblHeldAt" runat="server"></asp:Label></td>
        <td></td>
        </tr>
        <tr>
        <td>Email ID:</td>
        <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
        <td></td>
        <td>Contact No:</td>
        <td><asp:Label ID="lblContactNo" runat="server"></asp:Label></td>
        </tr>
        <tr>
        <td>Requested By:</td>
        <td colspan="4">
            <asp:Label ID="lblRequestedBy" runat="server"></asp:Label></td>
        </tr>
        </table>
        <br /><br />
        <table class="tbl">
        <caption>Update Status</caption>
        <tr>
        <td>Select Status</td>
        <td>
            <asp:DropDownList ID="drpStatus" runat="server" AutoPostBack="True" 
                onselectedindexchanged="drpStatus_SelectedIndexChanged">
            <asp:ListItem>< --Select Status --></asp:ListItem>
            <asp:ListItem>Ready to Issue</asp:ListItem>
            <asp:ListItem>Issued</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lblIssuedDate" runat="server" Text="Issued Date:"></asp:Label></td>
       
       <td>
           <asp:TextBox ID="txtIssuedDate" runat="server"></asp:TextBox></td> 
           <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIssuedDate" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
       </tr>
       <tr><td colspan="2" align="center">
           <asp:Button ID="btnUpdate" runat="server" Text="Update" 
               onclick="btnUpdate_Click" /></td></tr>
        <tr><td>
            <asp:Label ID="lblResult" runat="server"></asp:Label></td></tr>
        </table>           
        </div>                        
    </asp:Content>


