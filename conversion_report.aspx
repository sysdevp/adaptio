<%@ Page Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="conversion_report.aspx.cs" Inherits="conversion_report" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
<div align="center">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<br /><br /><br /><br />
<table class="tbl">
<caption>Customize and view the Conversion Report</caption>
<tr>
    <td>Date 1: </td>
    <td align="left">

<asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>                                
<asp:CalendarExtender ID="CalendarExtender1" runat="server" 
	TargetControlID="txtDate1" CssClass="MyCalendar" Format="dd-MM-yyyy">
</asp:CalendarExtender>
                            
    </td>
    
        <td>Date 2: </td>
    <td align="left">

<asp:TextBox ID="txtDate2" runat="server"></asp:TextBox>                                
<asp:CalendarExtender ID="CalendarExtender2" runat="server" 
	TargetControlID="txtDate2" CssClass="MyCalendar" Format="dd-MM-yyyy">
</asp:CalendarExtender>

                            
    </td>
    
    <td>Select Location: </td>
    <td>
        <asp:DropDownCheckBoxes ID="drpBranch" runat="server" AddJQueryReference="True" UseButtons="true" UseSelectAllNode="True">
            <Style2 SelectBoxWidth="200" DropDownBoxBoxWidth="250" DropDownBoxBoxHeight="250" />
            <Texts SelectBoxCaption="Select Branch" />
        </asp:DropDownCheckBoxes>
    </td>
    
    <td>Select Course: </td>    
    
    <td>
        <asp:DropDownCheckBoxes ID="drpCourse" runat="server" AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True">
            <Style2 SelectBoxWidth="200" DropDownBoxBoxWidth="250" DropDownBoxBoxHeight="250" />
            <Texts SelectBoxCaption="Select Course" />
        </asp:DropDownCheckBoxes>
    </td>
</tr>

<tr align="left">

<td colspan="3">
    <asp:Button ID="btnConversionReport" runat="server" 
        Text="View Conversion Report" onclick="btnConversionReport_Click" 
        CssClass="btn" Width="100%" />
</td>

<td colspan="2">
    <asp:CheckBox ID="ChkEnquiryType" runat="server" Text="Direct Walkins Only" />
</td>

<td colspan="3" style="text-decoration: blink"> 



<asp:Label ID="lblWalkins" runat="server" BackColor="White" ForeColor="Black"></asp:Label>
&nbsp;&nbsp
<asp:Label ID="lblRegistrations" runat="server" BackColor="White" ForeColor="Black"></asp:Label>





</td> 




</tr>
</table>

<br />

<table>



<tr>
<td>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        
    
    <asp:GridView ID="gvDetails" runat="server" CellPadding="4" ForeColor="#333333" 
        onrowdatabound="gvDetails_RowDataBound" ShowFooter="True" AutoGenerateColumns="true">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />  

<Columns>
<asp:TemplateField HeaderText="Sl.No" >    
                <ItemTemplate>
              <%#((GridViewRow)Container).RowIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "View">
   <ItemTemplate>
       <asp:LinkButton ID="lnkEdit" runat="server" Text = "View" OnClick = "Edit"></asp:LinkButton>
   </ItemTemplate>
</asp:TemplateField>

       <%-- <asp:BoundField DataField = "Course" HeaderText = "Coursee"  HtmlEncode = "false" />
        <asp:BoundField DataField = "Enquired" HeaderText = "Enquired"  HtmlEncode = "true" />
        <asp:BoundField DataField = "Registered" HeaderText = "Registered"  HtmlEncode = "true" />
        <asp:BoundField DataField="Location" HeaderText="Location" />--%>
</Columns> 
    </asp:GridView>


<asp:Panel ID="pnlPop" runat="server" Height="300px" ScrollBars="Auto" BackColor="#CCCCCC">
<table width="100%" style="padding: 15px 15px 15px 15px">
    <tr>
        <td align="right"> <asp:Button ID="btnCancel" runat="server" Text="Close" OnClientClick = "return Hidepopup()"/> </td>
    </tr>

    <tr> <td bgcolor="#333333" align="center"> <asp:Label ID="Label1" runat="server" Text="Enquiry Details" ForeColor="White"></asp:Label> </td> </tr>

    <tr>
        <td align="center">
<asp:GridView ID="gvEnqDetails" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White"  /> 
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

    <tr><td bgcolor="#333333" align="center"><asp:Label ID="Label2" runat="server" Text="Registration Details" ForeColor="White"></asp:Label></td></tr>

    <tr>
        <td align="center">
<asp:GridView ID="gvRegDetails" runat="server" CellPadding="4" ForeColor="#333333" ShowFooter="false">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" /> 
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
<br />            
</asp:Panel>
 

 <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>


<asp:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
PopupControlID="pnlPop" TargetControlID = "lnkFake" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

 </ContentTemplate> 













<Triggers>
<asp:AsyncPostBackTrigger ControlID = "gvDetails" />

</Triggers> 
  </asp:UpdatePanel>



    
    


</td>
</tr>
</table>
    
</div>                        

<asp:Label ID="lblFromDate" runat="server" Visible="False"></asp:Label>
<asp:Label ID="lblToDate" runat="server" Visible="False"></asp:Label>
    
</asp:Content>


