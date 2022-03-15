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

public partial class certificate_requisition : System.Web.UI.Page
{
HttpCookie Session;

    DateTime dtStDate1, dtEndDate1, dtStDate2, dtEndDate2, dtStDate3, dtEndDate3, dtCurrentDate, dtHeldOn;
    string strGrade;
    int dtDiff1, dtDiff2, dtDiff3=0;
    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
    cls_DDL_DML cls = new cls_DDL_DML();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            btnSendRequest.Enabled = false;

            pnl_Workshop.Visible = false;
            pnl_Course.Visible = false;

            cls.bizRead("spSel_Tbl_Enquired_For");
            drpCourse.Items.Clear();
            drpCourse.Items.Add("< - Select Course - >");
            while (cls.dr.Read())
            {
                drpCourse.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
            //
            if (Session["sid"] == null)
            {
                Response.Redirect("default.aspx");
            }

            if (Session["Branch_Name"].ToString() == "Gandhipuram")
            {
                txtInvoiceNo.Text = "MGA-";
            }
            else if (Session["Branch_Name"].ToString() == "Hopes")
            {
                txtInvoiceNo.Text = "MHO-";
            }
            else if (Session["Branch_Name"].ToString() == "Salem")
            {
                txtInvoiceNo.Text = "MSA-";
            }
            else if (Session["Branch_Name"].ToString() == "Nungambakkam")
            {
                txtInvoiceNo.Text = "MCH-";
            }
            else if (Session["Branch_Name"].ToString() == "Tnagar")
            {
                txtInvoiceNo.Text = "MTN-";
            }
            else if (Session["Branch_Name"].ToString() == "Erode")
            {
                txtInvoiceNo.Text = "MER-";
            }
            else if (Session["Branch_Name"].ToString() == "Tanjore")
            {
                txtInvoiceNo.Text = "MTA-";
            }
            else if (Session["Branch_Name"].ToString() == "Palakkad")
            {
                txtInvoiceNo.Text = "MPA-";
            }
            else if (Session["Branch_Name"].ToString() == "Karur")
            {
                txtInvoiceNo.Text = "MKA-";
            }
        }
    }

    protected void fnChkCertType()
    {
        if (rbtnCertCourse.Checked == true)
        {
            pnl_Course.Visible = true;
            pnl_Workshop.Visible = false;
        }
        else if (rbtnCertWorkshop.Checked == true)
        {
            pnl_Course.Visible = false;
            pnl_Workshop.Visible = true;
        }
    }

    private void fnFillInvoiceCount()
    {
        cls.bizRead("spSel_CourseCompletionAlready @InvoiceNo='" + txtInvoiceNo.Text + "'");
        if (cls.dr.Read())
        {
            lblAlreadyRaised.Text = cls.dr[0].ToString();
        }
        else
        {
            lblAlreadyRaised.Text = string.Empty;
        }
        cls.dr.Close();
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();


        cls.bizRead("spSel_CourseCompletionAlready @InvoiceNo='" + txtInvoiceNo.Text + "'");
        if (cls.dr.Read())
        {
            lblAlreadyRaised.Text = cls.dr[0].ToString();
        }
        else
        {
            lblAlreadyRaised.Text = string.Empty;
        }
        cls.dr.Close();

        cls.bizRead("spSel_CandidateDetails @InvoiceNo='" + txtInvoiceNo.Text + "',@BranchName='" + Session["Branch_Name"].ToString() + "'");
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
            cls.dr.Close();

            if (System.Convert.ToInt32(lblBalance.Text) <= 0 && System.Convert.ToInt32(lblAlreadyRaised.Text) == 0)
            {
                btnSendRequest.Enabled = true;
            }
            else
            {
                btnSendRequest.Enabled = false;
            }

            gridfill();
        }
        else
        {
            lblName.Text = string.Empty;
            lblContactNo.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblCourse.Text = string.Empty;
            lblBranch.Text = string.Empty;
            lblDescription.Text = string.Empty;
            lblFees.Text = string.Empty;
            lblTax.Text = string.Empty;
            lblTotal.Text = string.Empty;
            lblRegisteredOn.Text = string.Empty;
            lblPaidTill.Text = string.Empty;
            lblBalance.Text = string.Empty;
            lblResult.Text = string.Empty;
            cls.dr.Close();
        }
        


        
        fnReset();

        

    }
    protected void btnSendRequest_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();

        

        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        dtStDate1 = Convert.ToDateTime(txtStartDate1.Text, dateInfo);
        if (txtStartDate2.Text == "")
        {
            dtStDate2 = Convert.ToDateTime("1900/01/01", dateInfo);
        }
        else
        {
            dtStDate2 = Convert.ToDateTime(txtStartDate2.Text, dateInfo);
        }

        if (txtStartDate3.Text == "")
        {
            dtStDate3 = Convert.ToDateTime("1900/01/01", dateInfo);
        }
        else
        {
            dtStDate3 = Convert.ToDateTime(txtStartDate3.Text, dateInfo);
        }
        
        dtEndDate1 = Convert.ToDateTime(txtEndDate1.Text, dateInfo);
        dtCurrentDate = System.DateTime.Now;
        dtDiff1 = System.Convert.ToInt32((dtCurrentDate - dtEndDate1).TotalDays);
        
        if (txtEndDate2.Text == "")
        {
            dtEndDate2 = Convert.ToDateTime("1900/01/01", dateInfo);
        }
        else
        {
            dtEndDate2 = Convert.ToDateTime(txtEndDate2.Text, dateInfo);
            dtDiff2 = System.Convert.ToInt32((dtCurrentDate - dtEndDate2).TotalDays);
        }

        if (txtEndDate3.Text == "")
        {
            dtEndDate3 = Convert.ToDateTime("1900/01/01", dateInfo);
        }
        else
        {
            dtEndDate3 = Convert.ToDateTime(txtEndDate3.Text, dateInfo);
            dtDiff3 = System.Convert.ToInt32((dtCurrentDate - dtEndDate3).TotalDays);
        }

        if (drpGrade.SelectedIndex != 0)
        {
            strGrade = drpGrade.Text;
        }
        else
        {
            strGrade = "";
        }


        if (txtEndDate1.Text != "" && txtEndDate2.Text == "" && txtEndDate3.Text == "")
        {
            if (dtDiff1 > 180 || dtEndDate1 > System.DateTime.Now)
            {
                lblResult.Text = "Certificate Request cannot be Send";
            }
            else
            {
                fnIns();
            }
        }
        else if (txtEndDate1.Text != "" && txtEndDate2.Text != "" && txtEndDate3.Text != "")
        {
            if (dtDiff3 > 180 || dtEndDate3 > System.DateTime.Now)
            {
                lblResult.Text = "Certificate Request cannot be Send";
            }
            else
            {
                fnIns();
            }
        }
        else
        {
            lblResult.Text = "select valid course completion date";
        }     
        
    }


    

    private void fnIns()
    {
        cls.bizRead("spSel_CourseCompletionAlready @InvoiceNo='" + txtInvoiceNo.Text + "'");
        if (cls.dr.Read())
        {
            lblAlreadyRaised.Text = cls.dr[0].ToString();
        }
        else
        {
            lblAlreadyRaised.Text = string.Empty;
        }
        cls.dr.Close();


        if (System.Convert.ToInt32(lblBalance.Text) <= 0 && System.Convert.ToInt32(lblAlreadyRaised.Text) == 0)
        {
            cls.bizCommand("spIns_CertificateRequest @InvoiceNo='" + txtInvoiceNo.Text + "',@BranchName='" + Session["Branch_Name"].ToString() + "',@RequestedBy='" + Session["un"].ToString() + "',@CertificateName='" + txtCertificateName.Text + "',@Grade='" + strGrade.ToString() + "',@StartDate1='" + dtStDate1.ToString() + "',@EndDate1='" + dtEndDate1.ToString() + "',@StartDate2='" + dtStDate2.ToString() + "',@EndDate2='" + dtEndDate2.ToString() + "',@StartDate3='" + dtStDate3.ToString() + "',@EndDate3='" + dtEndDate3.ToString() + "',@Comments='" + txtComments.Text + "'");
            lblResult.Text = "Request Sent";
            gridfill();
            fnmailsend();
            fnReset();
        }
        else
        {
            lblResult.Text = "Request was already sent!";
        }

        
    }

    protected void gridfill()
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizAdapter("spSel_RequestedDetails @InvoiceNo='" + txtInvoiceNo.Text + "',@BranchName='" + Session["Branch_Name"].ToString() + "'", "tbl_CertificateRequest");
        gvRequest.DataSource = cls.ds;
        gvRequest.DataBind();
    }
    protected void fnmailsend()
    {
        MailMessage mail = new MailMessage();
        StringBuilder sb = new StringBuilder();
        mail.From = new MailAddress("mazenet@mazenetsolution.com");
        mail.To.Add("logistics@mazenetsolution.com");
        mail.Subject = "Requesting Certificate For "+lblName.Text;
        sb.Append("Certificate Requested by "+Session["un"].ToString());
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("Candidate Name: " + lblName.Text); sb.Append(Environment.NewLine);
        sb.Append("Invoice Number: " + txtInvoiceNo.Text); sb.Append(Environment.NewLine);
        sb.Append("Total Fees: " + lblTotal.Text); sb.Append(Environment.NewLine);
        sb.Append("Amount Paid: " + lblPaidTill.Text); sb.Append(Environment.NewLine);
        sb.Append("Balance Amount to Pay: " + lblBalance.Text); sb.Append(Environment.NewLine);
        sb.Append("Branch: " + Session["Branch_Name"].ToString()); sb.Append(Environment.NewLine);
        sb.Append("Contact No: " + lblContactNo.Text); sb.Append(Environment.NewLine);
        sb.Append("Email ID: " + lblEmail.Text); sb.Append(Environment.NewLine);
        sb.Append("Certificate Name: " + txtCertificateName.Text); sb.Append(Environment.NewLine);
        sb.Append("Grade: " + strGrade); sb.Append(Environment.NewLine);
        sb.Append("Course Start Date: " + txtStartDate1.Text); sb.Append(Environment.NewLine);
        sb.Append("Course End Date: " + txtEndDate1.Text); sb.Append(Environment.NewLine);
        if (txtStartDate2.Text != "")
        {
            sb.Append("Course Start Date2: " + txtStartDate2.Text); sb.Append(Environment.NewLine);
        }
        if (txtStartDate3.Text != "")
        {
            sb.Append("Course Start Date2: " + txtStartDate3.Text); sb.Append(Environment.NewLine);
        }
        if (txtEndDate2.Text != "")
        {
            sb.Append("Course End Date3: " + txtEndDate2.Text); sb.Append(Environment.NewLine);
        }
        if (txtEndDate3.Text != "")
        {
            sb.Append("Course End Date3: " + txtEndDate3.Text); sb.Append(Environment.NewLine);
        }
        sb.Append("Comments: " + txtComments.Text); sb.Append(Environment.NewLine);
        mail.Body = sb.ToString();
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(mail);
    }
    protected void fnReset()
    {
        txtCertificateName.Text = string.Empty;
        drpGrade.SelectedIndex = 0;
        txtStartDate1.Text = string.Empty;
        txtEndDate1.Text = string.Empty;
        txtStartDate2.Text = string.Empty;
        txtEndDate2.Text = string.Empty;
        txtStartDate3.Text = string.Empty;
        txtEndDate3.Text = string.Empty;
        txtComments.Text = string.Empty;
    }

    protected void btnSearchInvoice_Click(object sender, EventArgs e)
    {
        //Pass Date
        if (txtStartDate.Text != "" && txtEndDate.Text != "")
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            dateInfo.ShortDatePattern = "dd/MM/yyyy";
            DateTime dSt = Convert.ToDateTime(txtStartDate.Text, dateInfo);
            DateTime dEn = Convert.ToDateTime(txtEndDate.Text, dateInfo);
            lblFromDate.Text = dSt.ToString();
            lblToDate.Text = dEn.ToString();
        }
        else
        {
            lblFromDate.Text = "1997/01/01";
            lblToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        //Search begin

        if (txtName.Text == "" && drpCourse.SelectedIndex == 0 && txtContactNo.Text == "")
        {
            //none
            spSel_none();
        }
        else if (txtName.Text != "" && drpCourse.SelectedIndex == 0 && txtContactNo.Text == "")
        {
            // Name
            spSel_Name();
        }
        else if (txtName.Text == "" && drpCourse.SelectedIndex != 0 && txtContactNo.Text == "")
        {
            // Course
            spSel_Course();
        }
        else if (txtName.Text != "" && drpCourse.SelectedIndex != 0 && txtContactNo.Text == "")
        {
            // Name & Course
            spSel_Name_Course();
        }
        //
        else if (txtName.Text == "" && drpCourse.SelectedIndex == 0 && txtContactNo.Text != "")
        {
            // ContactNo
            spSel_ContactNo();
        }
        else if (txtName.Text != "" && drpCourse.SelectedIndex == 0 && txtContactNo.Text != "")
        {
            // Name & ContactNo
            spSel_Name_ContactNo();
        }
        else if (txtName.Text == "" && drpCourse.SelectedIndex != 0 && txtContactNo.Text != "")
        {
            // Course & ContactNo
            spSel_Course_ContactNo();
        }
        else if (txtName.Text != "" && drpCourse.SelectedIndex != 0 && txtContactNo.Text != "")
        {
            // Name Course & ContactNo
            spSel_Name_Course_ContactNo();
        }
    }
    public void spSel_none()
    {
        cls.bizAdapter("spSel_none @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();

    }
    public void spSel_Name()
    {
        cls.bizAdapter("spSel_Name @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Name='" + txtName.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    public void spSel_Course()
    {
        cls.bizAdapter("spSel_Course @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Course='" + drpCourse.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    public void spSel_Name_Course()
    {
        cls.bizAdapter("spSel_Name_Course @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Name='" + txtName.Text + "',@Course='" + drpCourse.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    public void spSel_ContactNo()
    {
        cls.bizAdapter("spSel_ContactNo @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@ContactNo='" + txtContactNo.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    //
    public void spSel_Name_ContactNo()
    {
        cls.bizAdapter("spSel_Name_ContactNo @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Name='" + txtName.Text + "',@ContactNo='" + txtContactNo.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    public void spSel_Course_ContactNo()
    {
        cls.bizAdapter("spSel_Course_ContactNo @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Course='" + drpCourse.Text + "',@ContactNo='" + txtContactNo.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    public void spSel_Name_Course_ContactNo()
    {
        cls.bizAdapter("spSel_Name_Course_ContactNo @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Name='" + txtName.Text + "',@Course='" + drpCourse.Text + "',@ContactNo='" + txtContactNo.Text + "'", "Tbl_Enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    protected void rbtnCertWorkshop_CheckedChanged(object sender, EventArgs e)
    {
        fnChkCertType();
    }
    protected void rbtnCertCourse_CheckedChanged(object sender, EventArgs e)
    {
        fnChkCertType();
    }
    protected void btnWorkshpCertSubmit_Click(object sender, EventArgs e)
    {

        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        dtHeldOn = Convert.ToDateTime(txtHeldOn.Text, dateInfo);

        if (dtHeldOn < System.DateTime.Now)
        {
            cls.bizCommand("spIns_WorkshopCertificates @CandidateName='" + txtCandidateName.Text + "',@ContactNo='" + txtWContactNo.Text + "',@EmailID='" + txtWEmailID.Text + "',@Topic='" + txtTopic.Text + "',@WorkshopHeldAt='" + txtHeldAt.Text + "',@WorkshopHeldOn='" + dtHeldOn.ToString() + "',@BranchName='" + Session["Branch_Name"].ToString() + "',@GeneratedBy='" + Session["un"].ToString() + "'");
            fnWSendMail();
            lblWResult.Text = "Request Sent";
            fnWReset();
        }
        else
        {
            lblWResult.Text = "You cannot process the Certificate Now";
        }
    }
    protected void fnWReset()
    {
        txtCandidateName.Text = string.Empty;
        txtWContactNo.Text = string.Empty;
        txtWEmailID.Text = string.Empty;
        txtTopic.Text = string.Empty;
        txtHeldAt.Text = string.Empty;
        txtHeldOn.Text = string.Empty;
    }
    protected void fnWSendMail()
    {
        MailMessage mail = new MailMessage();
        StringBuilder sb = new StringBuilder();
        mail.From = new MailAddress("mazenet@mazenetsolution.com");
        mail.To.Add("logistics@mazenetsolution.com");
        mail.Subject = "Requesting Workshop Certificate For " + txtCandidateName.Text;
        sb.Append("Certificate Requested by " + Session["un"].ToString());
        sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
        sb.Append("Candidate Name: " + txtCandidateName.Text); sb.Append(Environment.NewLine);
        sb.Append("Contact No: " + txtWContactNo.Text); sb.Append(Environment.NewLine);
        sb.Append("Email ID: " + txtWEmailID.Text); sb.Append(Environment.NewLine);
        sb.Append("Topic: " + txtTopic.Text); sb.Append(Environment.NewLine);
        sb.Append("Workshop Held at: " + txtHeldAt.Text); sb.Append(Environment.NewLine);
        sb.Append("Workshop Held On: " + txtHeldOn.Text); sb.Append(Environment.NewLine);

        mail.Body = sb.ToString();
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        client.Send(mail);
    }
}