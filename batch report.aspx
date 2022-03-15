<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="batch report.aspx.cs" Inherits="batch_report" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">


<div align="center">
<br />
<table class="tbl">

    <tr>
        <td>From: </td>
        <td>
            <asp:DropDownList ID="drpDate1" runat="server">
            </asp:DropDownList>
        </td>
        <td></td>
        <td>Till: </td>
        <td>
            <asp:DropDownList ID="drpDate2" runat="server">
            </asp:DropDownList>
        </td>
        <td></td>
    </tr>

    <tr>
        <td>Select Branch: </td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server">
            </asp:DropDownList>
        </td>

        <td></td>

        <td>Select Trainer:</td>

        <td>
            <asp:DropDownList ID="drpUser" runat="server">
            </asp:DropDownList>
        </td>

        <td></td>
    </tr>

    <tr>
        <td colspan="6">
            <asp:Button ID="btnBatchReport" runat="server" Text="Get Trainers Batch Report" 
                onclick="btnBatchReport_Click" />
            <asp:Label ID="lblDate1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDate2" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>

</table>

    <br />

    <table>
        <tr>
            <td>
                <asp:GridView ID="gvReport" runat="server" CellPadding="4" 
                    EnableModelValidation="True" ForeColor="#333333" GridLines="Vertical" 
                    onrowdatabound="gvReport_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                </asp:GridView>
            </td>
        </tr>
    </table>

    <asp:Panel ID="pnl_Batch" runat="server">    
    <table>
        <tr>
            <td>
                <asp:Panel ID="pnl_1" runat="server">
                    <br />08 AM to 10 AM<br /><br />
                    <asp:Label ID="lbl_1_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_2" runat="server">
                    <br />10 AM to 12 PM<br /><br />
                    <asp:Label ID="lbl_2_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_3" runat="server">
                    <br />12 PM to 02 PM<br /><br />
                    <asp:Label ID="lbl_3_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_4" runat="server">
                    <br />02 PM to 04 PM<br /><br />
                    <asp:Label ID="lbl_4_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Panel ID="pnl_5" runat="server">
                    <br />04 PM to 06 PM<br /><br />
                    <asp:Label ID="lbl_5_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_6" runat="server">
                    <br />06 PM to 08 PM<br /><br />
                    <asp:Label ID="lbl_6_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_7" runat="server">
                    <br />08 PM to 10 PM<br /><br />
                    <asp:Label ID="lbl_7_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>

            <td>
                <asp:Panel ID="pnl_8" runat="server">
                    <br />10 AM to 04 PM<br /><br />
                    <asp:Label ID="lbl_8_nos" runat="server"></asp:Label> <br /> <br />
                </asp:Panel>                
            </td>
        </tr>
    </table>
    </asp:Panel>
</div>


</asp:Content>


