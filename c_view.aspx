<%@ Page Language="C#" MasterPageFile="~/cmasterpage.master" AutoEventWireup="true" CodeFile="c_view.aspx.cs" Inherits="c_view" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
<div align="center">
<br />

 <script type="text/javascript" language="javascript">



     var newwindow;

     function popupstatic(url) {

         newwindow = window.open(url, 'name', 'height=400,width=400');

         if (window.focus) { newwindow.focus() }

     }


</script> 

<table class="tbl">
<tr align="left">
<td>
                        Start Date : 
                    </td>
                    <td>
                        <input type="text" id="txtStartDate" name="txtStartDate" />
                    </td>
                    <td>
                        <img src="images/smallcalendar.gif" alt="Display Calenday" 
                                    id="img_cal_start" />
                                
                                <script type="text/javascript">
                                    Calendar.setup({
                                    inputField: "txtStartDate",
                                    button: "img_cal_start",
                                    align: "Tr"
                                    });
                                </script>
                    </td>
                    <td>
                        End Date :
                    </td>
                    
                    <td>
                        <input type="text" id="txtEndDate" name="txtEndDate" />
                    </td>
                    
                    <td>
                        <img src="images/smallcalendar.gif" alt="Display Calenday" 
                                    id="img1" />
                                
                                <script type="text/javascript">
                                    Calendar.setup({
                                        inputField: "txtEndDate",
                                        button: "img1",
                                        align: "Tr"
                                    });
                                </script>
                    </td>
                    
                    
                    <td>Select Branch: </td>
                    
                    <td>
                        <asp:DropDownList ID="drpBranch" runat="server">
                        </asp:DropDownList>
                    </td>
                    
                    <td>
                        <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="btn" 
                            onclick="btnDisplay_Click" />
                    </td>
</tr>
</table>
<br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
        DataKeyNames="Rec.No" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" ForeColor="#333333" >
       
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField FooterText="Details" HeaderText="Details" 
                ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblFromDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblToDate" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    
</div>                        
    
</asp:Content>


