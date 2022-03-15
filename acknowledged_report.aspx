<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="acknowledged_report.aspx.cs" Inherits="acknowledged_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
        <div align="center">   
        <br /><br />

         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>

        <table class="tbl">
        <caption>Acknowledge Status</caption>
        <tr>
        <td>From Date:</td>
        <td>
            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox></td>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendar" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        <td>Till Date:</td>
        <td>
            <asp:TextBox ID="txtTillDate" runat="server"></asp:TextBox></td>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTillDate" CssClass="MyCalendar" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
        </tr>
        <tr>
        <td>Branch:</td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server">
            </asp:DropDownList>
        </td>
        <td></td>
        <td>
            <asp:CheckBox ID="chkAcknowledge" runat="server" Text="Show Pending Acknowledgement only"/>
        </td>
        </tr>
        <tr><td colspan="6" align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" /></td></tr>
        </table>  
        <br /><br />


       <asp:GridView ID="gvAcknowledge" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Caption="Student Acknowledgement Status" PageSize="5">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FooterStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="50%" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:TemplateField HeaderText="Sl.No" >    
                 <ItemTemplate>
                    <%#((GridViewRow)Container).RowIndex+1 %>
                 </ItemTemplate>
              </asp:TemplateField>
            </Columns>
       </asp:GridView>
                             
        </div>                        
    </asp:Content>


