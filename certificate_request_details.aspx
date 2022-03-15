<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="certificate_request_details.aspx.cs" Inherits="certificate_request_details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
        <div align="center">  
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager> 
        <br /><br /><br /><br /><br />
        <table class="tbl">
      <caption>Select Certificate Type</caption>
      <tr>
      <td>
          <asp:RadioButton ID="rbtnCertCourse" runat="server" GroupName="Certificate" Checked="true"
              Text="Course Certificate" AutoPostBack="True" /></td>
      <td>
          <asp:RadioButton ID="rbtnCertWorkshop" runat="server" GroupName="Certificate" 
              Text="Workshop Certificate" AutoPostBack="True" /></td>
      </tr>
      </table>
      <br /><br />
        <table class="tbl">
        <caption>Certificate Details</caption>
        <tr>
        <td>Requested From:</td>
        <td>
            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox></td>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        <td>Requested Till:</td>
        <td>
            <asp:TextBox ID="txtTillDate" runat="server"></asp:TextBox></td>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTillDate" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </tr>
        <tr>
        <td>Location:</td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server">
            </asp:DropDownList>
        </td>
        <td>Status:</td>
        <td>
            <asp:DropDownList ID="drpStatus" runat="server">
            <asp:ListItem>< --Select Status --></asp:ListItem>
            <asp:ListItem>Processing</asp:ListItem>
            <asp:ListItem>Ready to Issue</asp:ListItem>
            <asp:ListItem>Issued</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td colspan="4" align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" /></td>
        </tr>
        </table>   
        <br /><br />
        <asp:Panel ID="pnl_Course" runat="server">
            
        <asp:GridView ID="gvCertificateDetails" runat="server"  GridLines="Vertical" EnableModelValidation="True" AutoGenerateColumns="True"  CssClass="GridViewStyle" EmptyDataText="No records found" CellPadding="4" ForeColor="#333333">
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
    <asp:HyperLinkField DataNavigateUrlFields="Invoice Number,Request ID" DataNavigateUrlFormatString="certificate_status_updation.aspx?Invoice Number={0}&Request ID={1}" HeaderText="Update" Text="Update" />  
    </Columns>
            </asp:GridView>   
     </asp:Panel>
          
            
            <br /><br />
            <asp:Panel ID="pnl_Workshop" runat="server">
           
        <asp:GridView ID="gvWCertificationDetails" runat="server"  GridLines="Vertical" EnableModelValidation="True" AutoGenerateColumns="True"  CssClass="GridViewStyle" EmptyDataText="No records found" CellPadding="4" ForeColor="#333333">
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <FooterStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="50%" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <HeaderStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <AlternatingRowStyle BackColor="White" />

    <Columns>
    <asp:HyperLinkField DataNavigateUrlFields="Certificate ID" DataNavigateUrlFormatString="certificate_status_updation_workshop.aspx?Certificate ID={0}" HeaderText="Update" Text="Update" />  
    </Columns>
            </asp:GridView>    
             </asp:Panel>        
        </div>                        
    </asp:Content>


