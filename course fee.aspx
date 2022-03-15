<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="course fee.aspx.cs" Inherits="course_fee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

    <div align="center">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
<br /> <br /><br /><br />
<table class="tbl">
<caption>Fees</caption>
     <tr>
        <td>Branch Name: </td>
        <td>
            <asp:DropDownList ID="drpBranchStdFee" runat="server" Width="100%" AutoPostBack="true" onselectedindexchanged="drpBranchStdFee_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpBranchStdFee" ErrorMessage="Select Branch" InitialValue="&lt; - Select Branch - &gt;" SetFocusOnError="True" ValidationGroup="grpStdFee">*</asp:RequiredFieldValidator>&nbsp;</td>

        <td>Select Course: </td>
        <td>
            <asp:DropDownList ID="drpCourseStdFee" runat="server" Width="100%" 
                AutoPostBack="true" 
                onselectedindexchanged="drpCourseStdFee_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpCourseStdFee" ErrorMessage="Select Course" InitialValue="&lt; - Select Course - &gt;" ValidationGroup="grpStdFee">*</asp:RequiredFieldValidator>&nbsp;</td>
    </tr>

    <tr>
        <td>Standard Fee: </td>
        <td><asp:TextBox ID="txtStandardFee" runat="server" Width="100%"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtStandardFee" Display="Dynamic" ErrorMessage="Enter Standard Fee" SetFocusOnError="True" ValidationGroup="grpStdFee">*</asp:RequiredFieldValidator>&nbsp;</td>
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtStandardFee" ValidChars="0123456789">
        </asp:FilteredTextBoxExtender>

        <td>Discount Price: </td>
        <td><asp:TextBox ID="txtDiscountPrice" runat="server" Width="100%" Text="0"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDiscountPrice" Display="Dynamic" ErrorMessage="Enter Discount Price" SetFocusOnError="True" ValidationGroup="grpStdFee">*</asp:RequiredFieldValidator>&nbsp;</td>
        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtDiscountPrice" ValidChars="0123456789">
        </asp:FilteredTextBoxExtender>
    </tr>

    <tr>
        <td>Discount Valid From: </td>
        <td><asp:TextBox ID="txtFromDate" runat="server" Width="100%"></asp:TextBox></td>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendar" Format="dd-MM-yyyy">
        </asp:CalendarExtender>
        <td></td>
        <td>Discount Valid Till: </td>
        <td><asp:TextBox ID="txtTillDate" runat="server" Width="100%"></asp:TextBox></td>
        <td></td>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTillDate" CssClass="MyCalendar" Format="dd-MM-yyyy">
        </asp:CalendarExtender>
    </tr>

    <tr>
        <td colspan="3"><asp:CheckBox ID="chkTaxApplicable" runat="server" Text="Tax Applicable" Checked="true" /></td>
        <td colspan="2"></td>
    </tr>

    <tr>
        <td colspan="3" align="right"><asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="grpStdFee" onclick="btnSubmit_Click" /></td>
        <td colspan="3"><asp:Label ID="lblResultStdFee" runat="server"></asp:Label></td>
    </tr>
</table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grpStdFee" ShowSummary="false" ShowMessageBox="true" />
<br /><br />
        <asp:GridView ID="gvStandardFee" runat="server" GridLines="None" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" >
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <FooterStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="50%" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
<br /><br />
<asp:Panel ID="pnlOldFee" runat="server">
<table>
    <tr valign="top">
        <td>
        <table class="tbl">

    <tr>
        <td>Branch Name: </td>
        <td>
            <asp:DropDownList ID="drpBranch" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="drpBranch_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpBranch" ErrorMessage="Select Branch" InitialValue="&lt; - Select Branch - &gt;" SetFocusOnError="True" ValidationGroup="grpFee">*</asp:RequiredFieldValidator>&nbsp;</td>
    </tr>

    <tr>
        <td>Select Course: </td>
        <td>
            <asp:DropDownList ID="drpCourse" runat="server" Width="100%">     
            </asp:DropDownList>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpCourse" ErrorMessage="Select Course" InitialValue="&lt; - Select Course - &gt;" ValidationGroup="grpFee">*</asp:RequiredFieldValidator>&nbsp;</td>
    </tr>

    <tr>
        <td>Course Fee (Maximum Slot) </td>
        <td>
            <asp:TextBox ID="txtCourseFeeMaximum" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCourseFeeMaximum" Display="Dynamic" ErrorMessage="Enter Course Fee (Maximum Slot)" SetFocusOnError="True" ValidationGroup="grpFee">*</asp:RequiredFieldValidator>&nbsp;</td>
    </tr>

    <tr>
        <td>Course Fee (Minimum Slot) </td>
        <td>
            <asp:TextBox ID="txtCourseFeeMinimum" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCourseFeeMinimum" Display="Dynamic" ErrorMessage="Enter Course Fee (Minimum Slot)" SetFocusOnError="True" ValidationGroup="grpFee">*</asp:RequiredFieldValidator>&nbsp;</td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>

        <td align="right">
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" CssClass="btn" ValidationGroup="grpFee" />
        </td>

        <td></td>
    </tr>

</table>
        </td>

        <td>&nbsp;&nbsp</td>

        <td>
            
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>

            <br />

            <asp:GridView ID="gvDetails" runat="server" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <FooterStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="50%" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Panel>


</div>                        

</asp:Content>


