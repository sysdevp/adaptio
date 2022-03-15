<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="asb.aspx.cs" Inherits="asb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

<div align="center">
<br /> <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<table class="tbl">
<caption>Allocate Students to Batch</caption>

    <tr>
        <td colspan="3">            
            <asp:Label ID="lblLoginName" runat="server"></asp:Label>
        </td>
    </tr>


    <tr>
        <td>Select Batch Number: </td>
        <td>
            <asp:DropDownList ID="drpBatchNo" runat="server" AutoPostBack="True" 
                onselectedindexchanged="drpBatchNo_SelectedIndexChanged">
            </asp:DropDownList>            
        </td>

        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Select Batch Number" ControlToValidate="drpBatchNo" 
                ValidationGroup="GA" InitialValue="&lt;-- Select --&gt;">*</asp:RequiredFieldValidator>
        </td>

    </tr>

    <tr>
        <td>Invoice Number: </td>
        <td>
            <asp:TextBox ID="txtInvoiceNumber" runat="server"></asp:TextBox>
        </td>

        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" 
                ValidationGroup="GA" />
        </td>
    </tr>
    
    <tr>
        <td colspan="3">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<table>
    <tr valign="top">
        <td>
            <asp:GridView ID="gvDetails" runat="server" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                EnableModelValidation="True" Caption="Batch Details">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:GridView>
        </td>
        <td> &nbsp; </td>

        <td>
            <asp:GridView ID="gvBatch" runat="server" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                EnableModelValidation="True" Caption="Student Details">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:GridView>
        </td>        
    </tr>
</table>

<br />

<table class="tbl">

<caption>Search Invoice</caption>
    <tr>
        <td colspan="2">Enter Name or Mobile Number to search invoice</td>
    </tr>

    <tr>
        <td>

<asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        EnableCaching="true"
  BehaviorID="AutoCompleteEx"
  MinimumPrefixLength="1"
  TargetControlID="txtNAmeMobile"
  ServicePath="asb.asmx"
  ServiceMethod="GetCompletionList" 
  CompletionInterval="0"  
  CompletionSetCount="20"
  CompletionListCssClass="autocomplete_completionListElement"
  CompletionListItemCssClass="autocomplete_listItem"
  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
  DelimiterCharacters=";, :"
  ShowOnlyCurrentWordInCompletionListItem="true">
  <Animations>
                    <OnShow>
                        <Sequence>
                            <%-- Make the completion list transparent and then show it --%>
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            <%--Cache the original size of the completion list the first time
                                the animation is played and then set it to zero --%>
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            <%-- Expand from 0px to the appropriate size while fading in --%>
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        <%-- Collapse down to 0px and fade out --%>
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide>
                </Animations>
    </asp:AutoCompleteExtender>

            <asp:TextBox ID="txtNAmeMobile" runat="server"></asp:TextBox>            
        </td>

        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search Invoice" 
               onclick="btnSearch_Click" />
        </td>
    </tr>
</table>

<br />



<br />

<table>
    <tr>
        <td>
            <asp:GridView ID="gvInvoiceDetails" runat="server" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                EnableModelValidation="True">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:GridView>
        </td>
    </tr>
</table>

</div>

    </asp:Content>


