<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="create batch.aspx.cs" Inherits="create_batch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">

<div align="center">
<br /> <br />

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<table class="tbl">
    <caption>Create New Batch</caption>
    <tr>

        <td>Select Class Room: </td>
        <td>
            <asp:DropDownList ID="drpClassRoom" runat="server">
            </asp:DropDownList>            
        </td>

        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="Select class room" ControlToValidate="drpClassRoom" 
                ValidationGroup="grpCreateBatch" InitialValue="&lt;-- Select --&gt;">*</asp:RequiredFieldValidator>
        </td>

    
            
        <td colspan="3">
            <asp:Label ID="lblTrainerDetails" runat="server"></asp:Label>
        </td>

    </tr>
    <tr>
        <td>Department: </td>
        <td>
            <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="False">                
                <asp:ListItem>&lt;-- Select --&gt;</asp:ListItem>
                <asp:ListItem>.NET</asp:ListItem>
                <asp:ListItem>Java</asp:ListItem>
                <asp:ListItem>S/w Testing</asp:ListItem>
                <asp:ListItem>Oracle</asp:ListItem>
                <asp:ListItem>MCITP</asp:ListItem>
                <asp:ListItem>RedHat</asp:ListItem>
                <asp:ListItem>CCNA</asp:ListItem>
                <asp:ListItem>MCITP</asp:ListItem>
                <asp:ListItem>Ethical Hacking</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Select Department" ControlToValidate="drpDepartment" 
                Display="Dynamic" InitialValue="&lt;-- Select --&gt;" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>
        </td>

        <td>Select Trainer: </td>
        <td>
            <asp:DropDownList ID="drpUser" runat="server">
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnWho" runat="server" Text="?" onclick="btnWho_Click" 
                ToolTip="Trainer Name" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Select User" ControlToValidate="drpUser" 
                Display="Dynamic" InitialValue="&lt;-- Select --&gt;" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td>Course: </td>
        <td>
            <asp:DropDownList ID="drpCourse" runat="server" AutoPostBack="True" 
                onselectedindexchanged="drpCourse_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Select Course" ControlToValidate="drpCourse" 
                Display="Dynamic" InitialValue="&lt;-- Select --&gt;" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>
        </td>

        <td>Remarks: </td>
        <td>
            <asp:TextBox ID="txtCourseDescription" runat="server"></asp:TextBox>
        </td>
        <td>
            
        </td>
    </tr>

    <tr>
        <td>No.of Hrs: </td>
        <td>
            <asp:TextBox ID="txtTotalHRS" runat="server"></asp:TextBox>
        </td>
        <td></td>

        <td>Batch size Planned: </td>
        <td><asp:TextBox ID="txtPlannedBatchSize" runat="server"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ErrorMessage="Enter Planned Batch Size" ControlToValidate="txtPlannedBatchSize" 
                Display="Dynamic" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>            

                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPlannedBatchSize" FilterType="Numbers">
                </asp:FilteredTextBoxExtender>                


        </td>
    </tr>

    <tr>
        <td>Batch Start Date: </td>
        <td>
            <asp:TextBox ID="txtBatchStartsOn" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="Enter Batch Starting Date" ControlToValidate="txtBatchStartsOn" 
                Display="Dynamic" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>
        </td>

        <td>Batch End Date: </td>
        <td>
            <asp:TextBox ID="txtBatchEndsOn" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ErrorMessage="Enter Batch Ending Date" ControlToValidate="txtBatchEndsOn" 
                Display="Dynamic" SetFocusOnError="True" 
                ValidationGroup="grpCreateBatch">*</asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td>Batch Start Time: </td>
        <td>
            <asp:TextBox ID="txtBatchStartsTime" runat="server" ValidationGroup="grpCreateBatch"></asp:TextBox>
        </td>
        <td>
            
        </td>

        <td>Batch End Time: </td>
        <td>
            <asp:TextBox ID="txtBatchEndsTime" runat="server"></asp:TextBox>
        </td>
        <td>
            
        </td>
    </tr>

    <tr>
        <td colspan="3">
            <asp:Button ID="btnCreateBatch" runat="server" Text="Create Batch" 
                onclick="btnCreateBatch_Click" ValidationGroup="grpCreateBatch" />
        </td>

        <td colspan="3">
            <asp:Label ID="lblBatchResult" runat="server" Font-Size="X-Large"></asp:Label>                
        </td>
    </tr>

    <tr>
        <td colspan="6" align="center" bgcolor="White">
        
<asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
            ControlExtender="MaskedEditExtender1"
            ControlToValidate="txtBatchStartsTime"
            IsValidEmpty="False"
            EmptyValueMessage="Time is required"
            InvalidValueMessage="Time is invalid"
            Display="Dynamic"
            TooltipMessage="Input a time"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            ValidationGroup="grpCreateBatch"/>


<asp:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
            ControlExtender="MaskedEditExtender2"
            ControlToValidate="txtBatchEndsTime"
            IsValidEmpty="False"
            EmptyValueMessage="Time is required"
            InvalidValueMessage="Time is invalid"
            Display="Dynamic"
            TooltipMessage="Input a time"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            ValidationGroup="grpCreateBatch"/>


<asp:MaskedEditValidator ID="MaskedEditValidator3" runat="server"
            ControlExtender="MaskedEditExtender3"
            ControlToValidate="txtTotalHRS"
            IsValidEmpty="False"
            MaximumValue="200"
            EmptyValueMessage="Number is required"
            InvalidValueMessage="Number is invalid"
            MaximumValueMessage="Number &gt; 200"
            MinimumValueMessage="Number &lt; 1"
            MinimumValue="1"
            Display="Dynamic"
            TooltipMessage="Input a number from 1 to 200"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            MaximumValueBlurredMessage="*"
            MinimumValueBlurredText="*"
            ValidationGroup="grpCreateBatch" />
            
            <asp:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server" 
                BalloonPopupControlID="pnlPop1" BalloonStyle="Cloud" 
                TargetControlID="txtTotalHRS">
            </asp:BalloonPopupExtender>
            
            <asp:Panel ID="pnlPop1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Enter Total Duration of Course in HRS." ForeColor="#0000CC"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Dont enter Batch Ends Time - (Minus) Batch Starts Time" ForeColor="#CC3300"></asp:Label>
            </asp:Panel>

            <asp:BalloonPopupExtender ID="BalloonPopupExtender2" runat="server" 
                BalloonPopupControlID="pnlPop2" BalloonStyle="Cloud" 
                TargetControlID="txtBatchStartsTime">
            </asp:BalloonPopupExtender>

            <asp:Panel ID="pnlPop2" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Press Ctrl + A or Ctrl P to Change AM / PM" ForeColor="#000000"></asp:Label> 
            </asp:Panel>

            <asp:BalloonPopupExtender ID="BalloonPopupExtender3" runat="server" 
                BalloonPopupControlID="pnlPop3" BalloonStyle="Cloud" 
                TargetControlID="txtBatchEndsTime">
            </asp:BalloonPopupExtender>

            <asp:Panel ID="pnlPop3" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Press Ctrl + A or Ctrl P to Change AM / PM" ForeColor="#000000"></asp:Label> 
            </asp:Panel>

        </td>
    </tr>

</table>

<br />



</div>
    
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" CssClass="MyCalendar" 
        TargetControlID="txtBatchStartsOn">
    </asp:CalendarExtender>

    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" CssClass="MyCalendar" 
        TargetControlID="txtBatchEndsOn">
    </asp:CalendarExtender>
    
        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
            TargetControlID="txtBatchStartsTime" 
            Mask="99:99"
            MessageValidatorTip="true"
            OnFocusCssClass="MaskedEditFocus"
            OnInvalidCssClass="MaskedEditError"
            MaskType="Time"
            AcceptAMPM="True"
            ErrorTooltipEnabled="True" />

        

       <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
            TargetControlID="txtBatchEndsTime" 
            Mask="99:99"
            MessageValidatorTip="true"
            OnFocusCssClass="MaskedEditFocus"
            OnInvalidCssClass="MaskedEditError"
            MaskType="Time"
            AcceptAMPM="True"
            ErrorTooltipEnabled="True" />

        

        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
            TargetControlID="txtTotalHRS"
            Mask="999"
            MessageValidatorTip="true"
            OnFocusCssClass="MaskedEditFocus"
            OnInvalidCssClass="MaskedEditError"
            MaskType="Number"
            InputDirection="RightToLeft"            
            ErrorTooltipEnabled="True" />



    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grpCreateBatch" ShowMessageBox="True" ShowSummary="False" />
    </asp:Content>



