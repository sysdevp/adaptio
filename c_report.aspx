<%@ Page Language="C#" MasterPageFile="~/cmasterpage.master" AutoEventWireup="true" CodeFile="c_report.aspx.cs" Inherits="c_report" Title="Untitled Page" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

<div align="center">
    <asp:Panel ID="Panel1" runat="server">
    
    <br />
        <asp:Button ID="btnSendMyReport" runat="server" Text="Send My Report" 
            CssClass="btn" onclick="btnSendMyReport_Click" />
        
        <br />
        
        <br />
        
        
    <asp:DataGrid ID="dg2" runat="server" Width="50%" ShowFooter="true"  ItemStyle-HorizontalAlign="Center" 
                    onitemdatabound="dg2_ItemDataBound" BorderColor="Black" BorderWidth="1px" 
                    HorizontalAlign="Center" Font-Bold="False" Font-Size="Large">
                    <FooterStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#9999FF" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
                
                
        <br />
        <br />
                
                
    </asp:Panel>
</div>                        
    
</asp:Content>


