<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="batch_status.aspx.cs" Inherits="batch_status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
<div align="center">

<br /> <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table class="tbl">

    <tr>
        <td>From: </td>
        <td align="left">
            <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>                                
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate1" CssClass="MyCalendar" Format="dd-MM-yyyy">
            </asp:CalendarExtender>                            
        </td>
        <td></td>
    
        <td>Till: </td>
        <td align="left">
            <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>                                
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate2" CssClass="MyCalendar" Format="dd-MM-yyyy">
            </asp:CalendarExtender>                            
        </td>
        <td></td>
    </tr>

    <tr>
        <td>Select Branch: </td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server" AutoPostBack="True" 
                onselectedindexchanged="drpBranch_SelectedIndexChanged">
            </asp:DropDownList>
        </td>

        <td></td>

        <td>Select Class Room:</td>

        <td>
            <asp:DropDownList ID="drpClassRoom" runat="server">
            </asp:DropDownList>
        </td>

        <td></td>
    </tr>

    <tr>
        <td colspan="6">
            <asp:Button ID="btnViewBatchDetails" runat="server" Text="View Batch Details" onclick="btnViewBatchDetails_Click" />
            
        </td>
    </tr>

</table>


<table>
    <tr>
        <td> 
<table>
    <tr>
        <td align="center">
            <asp:Panel ID="pnl_08Am10Am" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_08Am10Am" runat="server" ></asp:Label> <br /> <br /> <br /> 08 AM to 10 AM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_10Am12Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_10Am12Pm" runat="server" ></asp:Label> <br /> <br /> <br /> 10 AM to 12 PM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_12Pm02Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_12Pm02Pm" runat="server" ></asp:Label> <br /> <br /> <br /> 12 PM to 02 PM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_02Pm04Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_02Pm04Pm" runat="server" ></asp:Label> <br /> <br /> <br /> 02 PM to 04 PM <br />
            </asp:Panel>
        </td>
    </tr>

</table>        
        </td>

        <td>
<table>
    <tr>
        <td align="center">
            <asp:Panel ID="pnl_04Pm06Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_04Pm06Pm" runat="server" ></asp:Label> <br /> <br /> <br /> 04 PM to 06 PM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_06Pm08Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_06Pm08Pm" runat="server" ></asp:Label> <br /> <br /> <br /> 06 PM to 08 PM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_08Pm10Pm" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_08Pm10Pm" runat="server" ></asp:Label> <br /> <br /> <br />08 PM to 10 PM <br />
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="center">
            <asp:Panel ID="pnl_10Am04PM" runat="server" Width="300px" Height="150px">
                <br /> <asp:Label ID="lbl_10Am04PM" runat="server" ></asp:Label> <br /> <br /> <br /> 10 AM to 04 PM <br />
            </asp:Panel>
        </td>
    </tr>





</table>        
        </td>
    </tr>
</table>

</div>

</asp:Content>


