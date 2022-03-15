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

public partial class certificate_status_updation : System.Web.UI.Page
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
            cls.bizRead("spSel_CandidateDetailsUpdate @InvoiceNo='" + Request.QueryString["Invoice Number"].ToString() + "'");
            if (cls.dr.Read())
            {
                lblName.Text = cls.dr["Name"].ToString();
                lblContactNo.Text = cls.dr["Mobile_Number1"].ToString();
                lblEmail.Text = cls.dr["Email_Id"].ToString();
                lblCourse.Text = cls.dr["Course"].ToString();
                lblBranch.Text = cls.dr["Branch_Name"].ToString();
                lblDescription.Text = cls.dr["Descriptions"].ToString();
                lblFees.Text = cls.dr["Fees"].ToString();
                lblTax.Text = cls.dr["Tax"].ToString();
                lblTotal.Text = cls.dr["Total"].ToString();
                lblRegisteredOn.Text = cls.dr["Reg Date"].ToString();
                lblPaidTill.Text = cls.dr["Paid Till"].ToString();
                lblBalance.Text = cls.dr["Balance"].ToString();
            }
            cls.dr.Close();

            cls.bizRead("spSel_CertificateStatusDetails @InvoiceNo='"+Request.QueryString["Invoice Number"].ToString()+"',@RequestID='"+Request.QueryString["Request ID"].ToString()+"'");
            if (cls.dr.Read())
            {
                lblCertificateName.Text = cls.dr["CertificateName"].ToString();
                lblGrade.Text = cls.dr["Grade"].ToString();
                lblStartDate1.Text = cls.dr["sd1"].ToString();
                lblEndDate1.Text = cls.dr["ed1"].ToString();
                lblStartDate2.Text = cls.dr["sd2"].ToString();
                lblEndDate2.Text = cls.dr["ed2"].ToString();
                lblStartDate3.Text = cls.dr["sd3"].ToString();
                lblEndDate3.Text = cls.dr["ed3"].ToString();
                lblComments.Text = cls.dr["Comments"].ToString();
                lblRequestedBy.Text = cls.dr["Requested By"].ToString();
            }
            cls.dr.Close();
        }
        fnFillMaterialStatus();
    }

    public void fnFillMaterialStatus()
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizAdapter("spSel_MaterialStatusinCert @Invoice_Number='" + Request.QueryString["Invoice Number"].ToString() + "'", "tbl_MaterialInvoice");
        gvMaterialStatus.DataSource = cls.ds;
        gvMaterialStatus.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();

        dateInfo.ShortDatePattern="dd/MM/yyyy";
        if(txtIssuedDate.Text=="")
        {
            dtIssuedOn=Convert.ToDateTime("1900/01/01",dateInfo);
            strIssuedBy="";
        }
        else
        {
            dtIssuedOn=Convert.ToDateTime(txtIssuedDate.Text,dateInfo);
            strIssuedBy=Session["un"].ToString();
        }

        if ((drpStatus.Text == "Issued") && (txtIssuedDate.Text == ""))
        {
            lblResult.Text = "Select Issued Date";
        }
        else
        {
            cls.bizCommand("spUpd_CertificateStatus @InvoiceNo='" + Request.QueryString["Invoice Number"].ToString() + "',@RequestID='" + Request.QueryString["Request ID"].ToString() + "',@Status='" + drpStatus.Text + "',@IssuedOn='" + dtIssuedOn.ToString() + "',@IssuedBy='" + strIssuedBy + "'");
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
        mail.To.Add(lblEmail.Text);
        mail.CC.Add(lblRequestedBy.Text);
        mail.Subject="Reg: Course Certificate";
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("Dear " + lblName.Text+","); sb.Append(Environment.NewLine);
        sb.Append("Your Certificate is ready. You can collect the following certificate from Mazenet"); sb.Append(Environment.NewLine);
        sb.Append("Certificate Name: "+lblCertificateName.Text);
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("This is system generated mail. Please do not reply");
        mail.Body = sb.ToString();
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(mail);
    }
}