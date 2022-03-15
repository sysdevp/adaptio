using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

public partial class brochures : System.Web.UI.Page
{
HttpCookie Session;

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];

    }
    protected void btnMailSendC_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();        

        string path = HttpContext.Current.Server.MapPath("~/Brochures/C.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "C Programming Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the C Programming (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");
        
        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdC.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgC.Text = "Message has been sent";
            txtEmailIdC.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgC.Text = ex.Message;
            txtEmailIdC.Text = "";
        } 
    }
    protected void btnMailSendCPlus_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/CPP.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "C++ Programming Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the C++ Programming (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdCPlus.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgCPlus.Text = "Message has been sent";
            txtEmailIdCPlus.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgCPlus.Text = ex.Message;
            txtEmailIdCPlus.Text = "";
        } 
    }
    protected void btnMailSendCCNA_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/CCNA.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "CCNA Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the CCNA (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdCCNA.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgCCNA.Text = "Message has been sent";
            txtEmailIdCCNA.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgCCNA.Text = ex.Message;
            txtEmailIdCCNA.Text = "";
        } 
    }
    protected void btnMailSendCEH_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/CEH.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "CEH Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the CEH (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdCEH.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgCEH.Text = "Message has been sent";
            txtEmailIdCEH.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgCEH.Text = ex.Message;
            txtEmailIdCEH.Text = "";
        } 
    }
    protected void btnMailSendCSCU_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/CSCU.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "CSCU Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the CSCU (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdCSCU.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgCSCU.Text = "Message has been sent";
            txtEmailIdCSCU.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgCSCU.Text = ex.Message;
            txtEmailIdCSCU.Text = "";
        } 
    }
    protected void btnMailSendJava_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/Java.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Java Programming Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Java Programming (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdJava.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgJava.Text = "Message has been sent";
            txtEmailIdJava.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgJava.Text = ex.Message;
            txtEmailIdJava.Text = "";
        } 
    }
    protected void btnMailSendJavaBeginner_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/Java_Beginners.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Java Beginners Programming Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Java Beginners Programming (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdJavaBeginner.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgJavaBeginner.Text = "Message has been sent";
            txtEmailIdJavaBeginner.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgJavaBeginner.Text = ex.Message;
            txtEmailIdJavaBeginner.Text = "";
        } 
    }
    protected void btnMailSendMCSE_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/MCSE.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "MCSE Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the MCSE (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdMCSE.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgMCSE.Text = "Message has been sent";
            txtEmailIdMCSE.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgMCSE.Text = ex.Message;
            txtEmailIdMCSE.Text = "";
        } 
    }
    protected void btnMailSendNet_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/DotNet.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = ".NET Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the .NET (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdNet.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgNet.Text = "Message has been sent";
            txtEmailIdNet.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgNet.Text = ex.Message;
            txtEmailIdNet.Text = "";
        } 
    }
    protected void btnMailSendOracle_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/OracleDBA.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Oracle Database 11g DBA Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Oracle Database 11g DBA (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdOracle.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgOracle.Text = "Message has been sent";
            txtEmailIdOracle.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgOracle.Text = ex.Message;
            txtEmailIdOracle.Text = "";
        } 
    }
    protected void btnMailSendRedHat_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/Redhat.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Red Hat Programming Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Red Hat Programming (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdRedHat.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgRedHat.Text = "Message has been sent";
            txtEmailIdRedHat.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgRedHat.Text = ex.Message;
            txtEmailIdRedHat.Text = "";
        } 
    }
    protected void btnMailSendSoftware_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/Software_Testing.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Software Testing Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Software Testing (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdSoftware.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgSoftwareTesting.Text = "Message has been sent";
            txtEmailIdSoftware.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgSoftwareTesting.Text = ex.Message;
            txtEmailIdSoftware.Text = "";
        } 
    }
    protected void btnMailSendPhp_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/PHP.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "PHP MySQL Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the PHP MySQL (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdPHP.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgSoftwareTesting.Text = "Message has been sent";
            txtEmailIdPHP.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgSoftwareTesting.Text = ex.Message;
            txtEmailIdPHP.Text = "";
        } 
    }
    protected void btnMailSendOracleDvlp_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/OracleDeveloper.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Oracle Database 11g Developer Brochure";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Oracle Database 11g Developer (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdOracleDvlp.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgOracle.Text = "Message has been sent";
            txtEmailIdOracle.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgOracle.Text = ex.Message;
            txtEmailIdOracle.Text = "";
        }
    }
    protected void btnBigData_Click(object sender, EventArgs e)
    {
        MailMessage message = new MailMessage();

        string path = HttpContext.Current.Server.MapPath("~/Brochures/BigDataAndHadoopDeveloper.zip");
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);

        message.IsBodyHtml = true;
        StringBuilder sb = new StringBuilder();
        message.Subject = "Big Data and Hadoop Developer";

        sb.Append("Dear Student," + "<br/>");
        sb.Append("Thank you for your association with Mazenet !!" + "<br/>");
        sb.Append("Attached is the Big Data and Hadoop Developer (Course) Brochure." + "<br/>");
        sb.Append("Kindly find the same.");

        message.Body = sb.ToString();
        message.From = new MailAddress(Session["un"].ToString());
        message.To.Add(new MailAddress(txtEmailIdBigData.Text));

        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(Session["un"].ToString(), Session["pwd"].ToString());

        try
        {
            client.Send(message);
            lblMsgBigData.Text = "Message has been sent";
            txtEmailIdOracle.Text = "";
        }
        catch (SystemException ex)
        {
            lblMsgOracle.Text = ex.Message;
            txtEmailIdOracle.Text = "";
        }
    }
}