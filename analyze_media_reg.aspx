<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="analyze_media_reg.aspx.cs" Inherits="analyze_media_reg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

        <div align="center">
        <br /><br /><br /><br /><br />
        <asp:Panel ID="Panel1" runat="server">
        <table class="tbl">
        <caption>Analyze Media</caption>
        <tr>
        
        <td>        
        Start Date: 
        </td>        
        <td align="left"> 
<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>

<asp:CalendarExtender ID="CalendarExtender1" runat="server" 
	TargetControlID="txtStartDate" CssClass="MyCalendar" Format="dd-MM-yyyy">
</asp:CalendarExtender>

            </td>
	    <td valign="top">	

	    </td>
	    
	    <td>        
        End Date: 
        </td>        
        <td align="left"> 

        

<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>

<asp:CalendarExtender ID="CalendarExtender2" runat="server" 
	TargetControlID="txtEndDate" CssClass="MyCalendar" Format="dd-MM-yyyy">
</asp:CalendarExtender>
            </td>
	    <td valign="top">	

	    </td>	    
        </tr>
        
        <tr>
        <td>Select Branch: </td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server">
            </asp:DropDownList>
        </td>
        <td></td>
        <td>Select Course:</td>
        <td>
             <asp:DropDownList ID="drpEnquiredFor" runat="server">
            </asp:DropDownList>
        </td>
        <td></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="btn" Width="100%" onclick="btnDisplay_Click" /></td>
            <td></td>
            <td></td>
            <td><asp:Button ID="btnExportExcel" runat="server" Text="Export To Excel" CssClass="btn" onclick="btnExportExcel_Click" /></td>
            <td></td>
        </tr>


        </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server">
        


            <table>
                <tr valign="top">
                    <td>
        <asp:GridView ID="gvMediaDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Caption="Media Details" CaptionAlign="Top"> 
                    <RowStyle BackColor="#cfcfdf" />
                    <FooterStyle BackColor="#c96a9c" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#c96a9c" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
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

                    <td>&nbsp;&nbsp;</td>

                    <td>
                        <asp:GridView ID="gvCandidateDetails" runat="server" Caption="Candidate Details" CaptionAlign="Top" EnableModelValidation="True">
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


                
        </asp:Panel>
        <asp:Label ID="lblFromDate" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblToDate" runat="server" Visible="False"></asp:Label>
        </div>                        
    
</asp:Content>



