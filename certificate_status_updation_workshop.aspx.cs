using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net.Mime;
using System.Net.Mail;

public partial class certificate_status_updation_workshop : System.Web.UI.Page
{
HttpCookie Session;

    string strIssuedBy;
    DateTime dtIssuedOn;
    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            lblIssuedDate.Visible = false;
            txtIssuedDate.Visible = false;
            btnUpdate.Visible = false;
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizRead("spSel_WorkshopCertificates @CID='"+ Request.QueryString["Certificate ID"].ToString() +"'");
            if (cls.dr.Read())
            {
                lblCandidateName.Text = cls.dr["CandidateName"].ToString();
                lblContactNo.Text = cls.dr["ContactNo"].ToString();
                lblEmail.Text = cls.dr["EmailID"].ToString();
                lblHeldAt.Text = cls.dr["WorkshopHeldAt"].ToString();
                lblHeldOn.Text = cls.dr["WorkshopHeldOn"].ToString();
                lblRequestedBy.Text = cls.dr["GeneratedBy"].ToString();
                lblTopic.Text = cls.dr["Topic"].ToString();
            }
            cls.dr.Close();
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();

        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        if (txtIssuedDate.Text == "")
        {
            dtIssuedOn = Convert.ToDateTime("1900/01/01", dateInfo);
            strIssuedBy = "";
        }
        else
        {
            dtIssuedOn = Convert.ToDateTime(txtIssuedDate.Text, dateInfo);
            strIssuedBy = Session["un"].ToString();
        }

        if ((drpStatus.Text == "Issued") && (txtIssuedDate.Text == ""))
        {
            lblResult.Text = "Select Issued Date";
        }
        else
        {
            cls.bizCommand("spUpd_WCertificateStatus @CID='" + Request.QueryString["Certificate ID"].ToString() + "',@Status='" + drpStatus.Text + "',@IssuedOn='" + dtIssuedOn.ToString() + "',@IssuedBy='" + strIssuedBy + "'");
            if (drpStatus.Text == "Ready to Issue")
            {
                fnSendMail();
            }
            lblResult.Text = "Status Updated";
        }
    }
    protected void drpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpStatus.Text == "Issued")
        {
            lblIssuedDate.Visible = true;
            txtIssuedDate.Visible = true;
            btnUpdate.Visible = true;
        }
        else if (drpStatus.Text == "Ready to Issue")
        {
            lblIssuedDate.Visible = false;
            txtIssuedDate.Visible = false;
            btnUpdate.Visible = true;
        }
        else
        {
            lblIssuedDate.Visible = false;
            txtIssuedDate.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void fnSendMail()
    {
        MailMessage mail = new MailMessage();
        StringBuilder sb = new StringBuilder();
        mail.From = new MailAddress("mazenet@mazenetsolution.com");
        mail.To.Add(lblCandidateName.Text);
        mail.CC.Add(lblRequestedBy.Text);
        mail.Subject = "Reg: Workshop Certificate";
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("Dear " + lblCandidateName.Text + ","); sb.Append(Environment.NewLine);
        sb.Append("Your Workshop Certificate is ready. You can collect the certificate from Mazenet"); sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("This is system generated mail. Please do not reply");
        mail.Body = sb.ToString();
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(mail);
    }
}