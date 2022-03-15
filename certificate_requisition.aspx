<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="certificate_requisition.aspx.cs" Inherits="certificate_requisition" %>

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
          <asp:RadioButton ID="rbtnCertCourse" runat="server" GroupName="Certificate" 
              Text="Course Completion Certificate" AutoPostBack="True" 
              oncheckedchanged="rbtnCertCourse_CheckedChanged" /></td>
      <td>
          <asp:RadioButton ID="rbtnCertWorkshop" runat="server" GroupName="Certificate" 
              Text="Workshop Certificate" AutoPostBack="True" 
              oncheckedchanged="rbtnCertWorkshop_CheckedChanged" /></td>
      </tr>
      </table>
      <br /><br />
       <asp:Panel ID="pnl_Workshop" runat="server">
       <table class="tbl">
       <caption>Request for Workshop Certificate</caption>
       <tr>
       <td>Candidate Name:</td>
       <td>
           <asp:TextBox ID="txtCandidateName" runat="server"></asp:TextBox></td>
       <td>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Candidate Name" ControlToValidate="txtCandidateName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator></td>
       <td>Contact No:</td>
       <td>
           <asp:TextBox ID="txtWContactNo" runat="server" ></asp:TextBox></td>
           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789+" TargetControlID="txtWContactNo">
           </asp:FilteredTextBoxExtender>
       <td>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="txtWContactNo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator></td>
       </tr>
       <tr>
       <td>Email ID:</td>
       <td>
           <asp:TextBox ID="txtWEmailID" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txtWEmailID" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtWEmailID" ErrorMessage="Enter Valid EmailID" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grpWorkshop">*</asp:RegularExpressionValidator></td>
       <td>Topic:</td>
       <td>
           <asp:TextBox ID="txtTopic" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Workshop Topic/Course Name" ControlToValidate="txtTopic" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator></td>
       </tr>
       <tr>
       <td>Workshop Held At:</td>
       <td>
           <asp:TextBox ID="txtHeldAt" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Workshop Held Place" ControlToValidate="txtHeldAt" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator></td>
       <td>Workshop Held On:</td>
       <td>
           <asp:TextBox ID="txtHeldOn" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Workshop Held Date" ControlToValidate="txtHeldOn" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grpWorkshop">*</asp:RequiredFieldValidator></td>
       <asp:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtHeldOn" CssClass="MyCalendar" Format="dd/MM/yyyy">
        </asp:CalendarExtender>
       </tr>
       <tr><td colspan="3" align="right">
           <asp:Button ID="btnWorkshpCertSubmit" runat="server" Text="Submit" ValidationGroup="grpWorkshop"
                onclick="btnWorkshpCertSubmit_Click" /></td>
       <td>
           <asp:Label ID="lblWResult" runat="server"></asp:Label></td>
       </tr>
       </table>
           <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="grpWorkshop" ShowMessageBox="True" ShowSummary="False" />
       </asp:Panel>
        <asp:Panel ID="pnl_Course" runat="server">
        <table class="tbl">
        <caption>Enter Invoice Number</caption>
        <tr>
        <td>Invoice Number</td>
        <td>
            <asp:TextBox ID="txtInvoiceNo" runat="server"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnVerify" runat="server" Text="Verify" 
                onclick="btnVerify_Click" /></td>
        </tr>
        </table>
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
        
        <td><asp:Label ID="lblBalance" runat="server"></asp:Label></td>

        </tr>

        <tr>
            <td colspan="6"> <asp:Label ID="lblAlreadyRaised" runat="server" Visible="false" ></asp:Label> </td>
        </tr>

        </table>          
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>          
        <table class="tbl">
        <caption>Request for Course Completion Certificate</caption>
        <tr>
        <td>Certificate Name:</td>
        <td colspan="4">
            <asp:TextBox ID="txtCertificateName" runat="server" Width="99%"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Certificate Name" ControlToValidate="txtCertificateName" ValidationGroup="cert">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td>Grade:</td>
        <td>
            <asp:DropDownList ID="drpGrade" runat="server">
            <asp:ListItem><--Select Grade--></asp:ListItem>
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>B+</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>C+</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td>Start Date1:</td>
        <td>
            <asp:TextBox ID="txtStartDate1" runat="server"></asp:TextBox></td>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate1" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Start Date" ControlToValidate="txtStartDate1" ValidationGroup="cert">*</asp:RequiredFieldValidator></td>
        <td>End Date1:</td>
        <td>
            <asp:TextBox ID="txtEndDate1" runat="server"></asp:TextBox></td>
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtEndDate1" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select End Date" ControlToValidate="txtEndDate1" ValidationGroup="cert">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td>Start Date2:</td>
        <td>
            <asp:TextBox ID="txtStartDate2" runat="server"></asp:TextBox></td>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate2" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        <td></td>
        <td>End Date2:</td>
        <td>
            <asp:TextBox ID="txtEndDate2" runat="server"></asp:TextBox></td>
             <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtEndDate2" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </tr>
        <tr>
        <td>Start Date3:</td>
        <td>
            <asp:TextBox ID="txtStartDate3" runat="server"></asp:TextBox></td>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtStartDate3" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        <td></td>
        <td>End Date3:</td>
        <td>
            <asp:TextBox ID="txtEndDate3" runat="server"></asp:TextBox></td>
             <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtEndDate3" CssClass="MyCalendar" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </tr>
        <tr>
        <td>Comments (if any)</td>
        <td colspan="4">
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
       <td>&nbsp;&nbsp;</td>
        </tr>
        <tr><td colspan="4" align="center">
            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" 
                onclick="btnSendRequest_Click" ValidationGroup="cert"/></td>
        <td><asp:Label ID="lblResult" runat="server"></asp:Label></td>
        </tr>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="cert" ShowMessageBox="true" ShowSummary="false"/>
        </table>
        </td></tr></table>
        <br />
        
            <asp:GridView ID="gvRequest" runat="server"  GridLines="Vertical"  
                EnableModelValidation="True" AutoGenerateColumns="True" 
                CssClass="GridViewStyle" EmptyDataText="No records found" CellPadding="4" 
                ForeColor="#333333" Caption="Requested Certificates">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <FooterStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="50%" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <HeaderStyle BackColor="#CA7018" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
    <AlternatingRowStyle BackColor="White" />
            </asp:GridView>

            <br /><br />

            <asp:Panel ID="Panel_Search_Options" runat="server">
            <table class="tbl">
            <caption>
            Search Invoice Number
            </caption>
            <tr>
            
            <td align="right">
                        Start Date : 
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd/MM/yyyy" 
                            TargetControlID="txtStartDate" CssClass="MyCalendar">
                        </asp:CalendarExtender>
                    </td>
                    <td align="right">
                        End Date :
                    </td>
                    
                    <td align="left">
                        <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="True" ></asp:TextBox>
                            
                    </td>
                    
                    <td align="left" valign="top">
                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd/MM/yyyy" 
                            TargetControlID="txtEndDate" CssClass="MyCalendar">
                        </asp:CalendarExtender>
                    </td>        
            
            <td>Name: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>            
            <td></td>
            </tr>
            
            <tr>
            <td>Course: </td>
            
            <td>
            
                <asp:DropDownList ID="drpCourse" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                
                </td>
            
            <td>Contact No: </td>
            <td>
                <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            </td>            
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btnSearchInvoice" runat="server" Text="Search Invoice" 
                    onclick="btnSearchInvoice_Click" ValidationGroup="searchGroup" /></td>
            <td></td>
            </tr>
            <tr>
            <td> <asp:Label ID="lblFromDate" runat="server" Visible="False"></asp:Label> </td>
            <td> <asp:Label ID="lblToDate" runat="server" Visible="False"></asp:Label> </td>
            <td>
                &nbsp;</td>
            </tr>

            </table>
            <table width="auto">
            <tr>
            <td>
            
            
                <asp:Panel ID="Panel2" runat="server" Height="300" ScrollBars="Auto">
                
                <asp:GridView ID="gvDetails" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="Vertical" CaptionAlign="Top">                    
                    <RowStyle BackColor="#cfcfdf" />
                    <FooterStyle BackColor="#c96a9c" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#c96a9c" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                
                </asp:Panel>

            
        </td>
            </tr>
            </table>
            </asp:Panel>
</asp:Panel>
            <br /><br />
        </div>                        
    </asp:Content>


