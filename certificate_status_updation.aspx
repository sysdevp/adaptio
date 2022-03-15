<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="certificate_status_updation.aspx.cs" Inherits="certificate_status_updation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
        <div align="center">    
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>  
        <br /><br />
        <table>
        <tr valign="top">
        <td>
        <table class="tbl">
        <caption>Candidate Details</caption>
        <tr>
        <td>Name:</td>
        <td colspan="4">
            <asp:Label ID="lblName" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="5"><hr /></td></tr>

        <tr>
        <td>Contact No:</td>
        <td>
            <asp:Label ID="lblContactNo" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;</td>
        <td>Email:</td>
        <td>
            <asp:Label ID="lblEmail" runat="server" ></asp:Label></td>
        </tr>
        <tr><td colspan="5"><hr /></td></tr>
        <tr>
        <td>Course:</td>
        <td>
            <asp:Label ID="lblCourse" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;</td>
        <td>Branch:</td>
        <td>
            <asp:Label ID="lblBranch" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="5"><hr /></td></tr>

        <tr>
        <td>Description:</td>
        <td colspan="4">
            <asp:Label ID="lblDescription" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="5"><hr /></td></tr>

        <tr>
        <td>Fees:</td>
        <td>
            <asp:Label ID="lblFees" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;</td>
        <td>Tax:</td>
        <td>
            <asp:Label ID="lblTax" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="5"><hr /></td></tr>

        <tr>
        <td>Total:</td>
        <td>
            <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;</td>
        <td>Reg On:</td>
        <td>
            <asp:Label ID="lblRegisteredOn" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="5"><hr /></td></tr>

        <tr>
        <td>Paid Till Date:</td>
        <td>
            <asp:Label ID="lblPaidTill" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;</td>
        <td>Balance:</td>
        <td>
            <asp:Label ID="lblBalance" runat="server"></asp:Label></td>
        </tr>
        </table>          
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>          
        <table class="tbl">
        <caption>Certificate Details</caption>
        <tr>
        <td>Certificate Name:</td>
        <td colspan="4">
            <asp:Label ID="lblCertificateName" runat="server"></asp:Label></td>
        <td></td>
        </tr>
        <tr>
        <td>Grade:</td>
        <td>
            <asp:Label ID="lblGrade" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>Start Date1:</td>
        <td>
            <asp:Label ID="lblStartDate1" runat="server"></asp:Label></td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>End Date1:</td>
        <td>
            <asp:Label ID="lblEndDate1" runat="server"></asp:Label></td>
        <td></td>
        </tr>
        <tr>
        <td>Start Date2:</td>
        <td><asp:Label ID="lblStartDate2" runat="server"></asp:Label></td>
        <td></td>
        <td>End Date2:</td>
        <td><asp:Label ID="lblEndDate2" runat="server"></asp:Label></td>
        </tr>
        <tr>
        <td>Start Date3:</td>
        <td><asp:Label ID="lblStartDate3" runat="server"></asp:Label></td>
        <td></td>
        <td>End Date3:</td>
        <td><asp:Label ID="lblEndDate3" runat="server"></asp:Label></td>
        </tr>
        <tr>
        <td>Comments (if any):</td>
        <td colspan="4">
            <asp:Label ID="lblComments" runat="server"></asp:Label></td>
       <td>&nbsp;&nbsp;</td>
        </tr>
        <tr>
        <td>Requested By:</td>
        <td colspan="4">
            <asp:Label ID="lblRequestedBy" runat="server"></asp:Label></td>
        </tr>
        </table>
        </td></tr></table>  
        <br /><br />
            
            <asp:GridView ID="gvMaterialStatus" runat="server" GridLines="Vertical" EnableModelValidation="True" AutoGenerateColumns="True"  CssClass="GridViewStyle" EmptyDataText="No records found" CellPadding="4" ForeColor="#333333" Caption="Material Status">
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


