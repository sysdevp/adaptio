<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.master" AutoEventWireup="true" CodeFile="brochures.aspx.cs" Inherits="brochures" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="CPH_Use">
<div align="center">                        
<br /> <br />

<table>
<tr valign="top">

<td> <!--1 Begin -->
    <table class="tbl" style="width:350px">
        <caption>Big Data and Hadoop Developer </caption>
        <tr> <td> <a href="Brochures/BigDataAndHadoopDeveloper.zip">Download Big Data &amp; Hadoop Brochure (1.10 MB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdBigData" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="bigdata" ControlToValidate="txtEmailIdBigData" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="bigdata" ControlToValidate="txtEmailIdBigData" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnBigData" runat="server" Text="Send Mail" CssClass="btn" 
                    ValidationGroup="bigdata" onclick="btnBigData_Click" /> <br />            
            <asp:Label ID="lblMsgBigData" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>     
</td> <!--1 End -->

<td>&nbsp;&nbsp</td>

<td> <!--2 Begin -->
<table class="tbl" style="width:350px">
        <caption>C Programming </caption>
        <tr> <td> <a href="Brochures/C.zip">Download C Programming Brochure (225 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdC" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="a" ControlToValidate="txtEmailIdC" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="a" ControlToValidate="txtEmailIdC" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendC" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="a" onclick="btnMailSendC_Click"/> <br />            
            <asp:Label ID="lblMsgC" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--2 End -->

<td>&nbsp;&nbsp</td>

<td> <!--3 Begin -->
<table class="tbl" style="width:350px">
        <caption>C++ Programming </caption>
        <tr> <td> <a href="Brochures/CPP.zip">Download C++ Programming Brochure (279 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdCPlus" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="b" ControlToValidate="txtEmailIdCPlus" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="b" ControlToValidate="txtEmailIdCPlus" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendCPlus" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="b" onclick="btnMailSendCPlus_Click"/> <br />            
            <asp:Label ID="lblMsgCPlus" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--3 End -->
</tr>   

<tr><td><br /></td></tr>

<tr valign="top">

<td> <!--1 Begin -->
<table class="tbl" style="width:350px">
        <caption>CCNA </caption>
        <tr> <td> <a href="Brochures/CCNA.zip">Download CCNA Brochure (925 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdCCNA" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="c" ControlToValidate="txtEmailIdCCNA" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="c" ControlToValidate="txtEmailIdCCNA" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendCCNA" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="c" onclick="btnMailSendCCNA_Click"/> <br />            
            <asp:Label ID="lblMsgCCNA" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--1 End -->

<td>&nbsp;&nbsp</td>

<td> <!--2 Begin -->
<table class="tbl" style="width:350px">
        <caption>CEHV8 </caption>
        <tr> <td> <a href="Brochures/CEH.zip">Download CEH V10 Brochure (957 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdCEH" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="d" ControlToValidate="txtEmailIdCEH" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="d" ControlToValidate="txtEmailIdCEH" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendCEH" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="d" onclick="btnMailSendCEH_Click"/> <br />            
            <asp:Label ID="lblMsgCEH" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--2 End -->

<td>&nbsp;&nbsp</td>

<td> <!--3 Begin -->
<table class="tbl" style="width:350px">
        <caption>CSCU </caption>
        <tr> <td> <a href="Brochures/CSCU.zip">Download CSCU Brochure (760 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdCSCU" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="e" ControlToValidate="txtEmailIdCSCU" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="e" ControlToValidate="txtEmailIdCSCU" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendCSCU" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="e" onclick="btnMailSendCSCU_Click"/> <br />            
            <asp:Label ID="lblMsgCSCU" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--3 End -->
</tr> 

<tr><td><br /></td></tr>

<tr valign="top">

<td> <!--1 Begin -->
<table class="tbl" style="width:350px">
        <caption>Java for Beginners </caption>
        <tr> <td> <a href="Brochures/Java_Beginners.zip">Download Java for Beginners Brochure (186 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdJavaBeginner" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="f" ControlToValidate="txtEmailIdJavaBeginner" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="f" ControlToValidate="txtEmailIdJavaBeginner" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendJavaBeginner" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="f" onclick="btnMailSendJavaBeginner_Click"/> <br />            
            <asp:Label ID="lblMsgJavaBeginner" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--1 End -->

<td>&nbsp;&nbsp</td>

<td> <!--2 Begin -->
<table class="tbl" style="width:350px">
        <caption>Java Programming </caption>
        <tr> <td> <a href="Brochures/Java.zip">Download Java Programming Brochure (240 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdJava" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="g" ControlToValidate="txtEmailIdJava" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="g" ControlToValidate="txtEmailIdJava" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendJava" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="g" onclick="btnMailSendJava_Click"/> <br />            
            <asp:Label ID="lblMsgJava" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--2 End -->

<td>&nbsp;&nbsp</td>

<td> <!--3 Begin -->
<table class="tbl" style="width:350px">
        <caption>MCSE 2012 </caption>
        <tr> <td> <a href="Brochures/MCSE.zip">Download MCSE Brochure (212 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdMCSE" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="h" ControlToValidate="txtEmailIdMCSE" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="h" ControlToValidate="txtEmailIdMCSE" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendMCSE" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="h" onclick="btnMailSendMCSE_Click"/> <br />            
            <asp:Label ID="lblMsgMCSE" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>        
</td> <!--3 End -->
</tr>

<tr><td><br /></td></tr>

<tr valign="top">


<td> <!--1 Begin -->
<table class="tbl" style="width:350px">
        <caption>.Net 4.5 </caption>
        <tr> <td> <a href="Brochures/DotNet.zip">Download .NET 4.5 Brochure (245 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdNet" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="i" ControlToValidate="txtEmailIdNet" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="i" ControlToValidate="txtEmailIdNet" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendNet" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="i" onclick="btnMailSendNet_Click"/> <br />            
            <asp:Label ID="lblMsgNet" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>    
</td> <!--1 End -->

<td>&nbsp;&nbsp</td>

<td> <!--2 Begin -->
    <table class="tbl" style="width:350px">
        <caption>Red Hat </caption>
        <tr> <td> <a href="Brochures/Redhat.zip">Download Red Hat Brochure (1.25 MB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdRedHat" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="k" ControlToValidate="txtEmailIdRedHat" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="k" ControlToValidate="txtEmailIdRedHat" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendRedHat" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="k" onclick="btnMailSendRedHat_Click"/> <br />            
            <asp:Label ID="lblMsgRedHat" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>
</td> <!--2 End -->
<td>&nbsp;&nbsp</td>
<td> <!--3 Begin -->
    <table class="tbl" style="width:350px">
        <caption>Software Testing </caption>
        <tr> <td> <a href="Brochures/Software_Testing.zip">Download Software Testing Brochure (1.29 MB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdSoftware" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="l" ControlToValidate="txtEmailIdSoftware" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="l" ControlToValidate="txtEmailIdSoftware" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendSoftware" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="l" onclick="btnMailSendSoftware_Click"/> <br />            
            <asp:Label ID="lblMsgSoftwareTesting" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>       
</td> <!--3 End -->

</tr>
<tr><td><br /></td></tr>

<tr valign="top">


<td> <!--1 Begin -->
    <table class="tbl" style="width:350px">
        <caption>PHP MySQL</caption>
        <tr> <td> <a href="Brochures/PHP.zip">Download PHP MySQL Brochure (233 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdPHP" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="m" ControlToValidate="txtEmailIdPHP" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="m" ControlToValidate="txtEmailIdPHP" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendPhp" runat="server" Text="Send Mail" CssClass="btn" 
                    ValidationGroup="m" onclick="btnMailSendPhp_Click" /> <br />            
            <asp:Label ID="lblMsgPhp" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>   
</td> <!--1 End -->


<td>&nbsp;&nbsp</td>

<td> <!--2 Begin -->
    <table class="tbl" style="width:350px">
        <caption>Oracle </caption>
        <tr> <td> <a href="Brochures/OracleDBA.zip">Download Oracle 11g DBA Brochure (297 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdOracle" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="j" ControlToValidate="txtEmailIdOracle" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="j" ControlToValidate="txtEmailIdOracle" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendOracle" runat="server" Text="Send Mail" CssClass="btn" ValidationGroup="j" onclick="btnMailSendOracle_Click"/> <br />            
            <asp:Label ID="lblMsgOracle" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>  
</td> <!--2 End -->

<td>&nbsp;&nbsp</td>

<td> <!--3 Begin -->
    <table class="tbl" style="width:350px">
        <caption>Oracle </caption>
        <tr> <td> <a href="Brochures/OracleDeveloper.zip">Download Oracle 11g Developer Brochure (943 KB)</a> </td> </tr>
        <tr> <td> Email this Brochure to: </td>  </tr>
        <tr> <td> <asp:TextBox ID="txtEmailIdOracleDvlp" runat="server" Width="97%"></asp:TextBox> </td> </tr>
        <tr> 
            <td> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Email Id is Required" ValidationGroup="od" ControlToValidate="txtEmailIdOracleDvlp" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="Enter Valid Email Id" ValidationGroup="od" ControlToValidate="txtEmailIdOracleDvlp" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>        
        <tr>
            <td>             
            <asp:Button ID="btnMailSendOracleDvlp" runat="server" Text="Send Mail" 
                    CssClass="btn" ValidationGroup="od" onclick="btnMailSendOracleDvlp_Click"/> <br />            
            <asp:Label ID="lblMsgOracleDvlp" runat="server"></asp:Label>
            </td>                                    
        </tr>
        <tr><td><br /></td></tr>
    </table>   
</td> <!--3 End -->
</tr>

</table>



</div>                        
</asp:Content>
