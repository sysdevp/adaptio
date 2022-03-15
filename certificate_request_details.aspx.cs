using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class certificate_request_details : System.Web.UI.Page
{
HttpCookie Session;

    DateTime dtFromDate, dtTillDate;
    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            mazenet_branches();
            pnl_Course.Visible = false;
            pnl_Workshop.Visible = false;
        }
    }

    private void mazenet_branches()
    {
        drpBranch.Items.Clear();
        if (Session["un"].ToString() == "sowmya.v@mazenetsolution.com" || Session["un"].ToString() == "yuvaraj@mazenetsolution.com" || Session["un"].ToString() == "divyashree@mazenetsolution.com" || Session["un"].ToString() == "dheena.gk@mazenetsolution.com" || Session["un"].ToString() == "vasanthakumari@mazenetsolution.com")
        {
            drpBranch.Items.Add("< - Select Branch - >");
            drpBranch.Items.Add("Nungambakkam");
            drpBranch.Items.Add("Tnagar");
        }
        else if (Session["un"].ToString() == "anitha.m@mazenetsolution.com" || Session["un"].ToString() == "mageshwaran@mazenetsolution.com")
        {
            drpBranch.Items.Add("< - Select Branch - >");
            drpBranch.Items.Add("Gandhipuram");
            drpBranch.Items.Add("Hopes");
        }
        else
        {
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizRead("spSel_Branch");
            drpBranch.Items.Clear();
            drpBranch.Items.Add("< - Select Branch - >");
            while (cls.dr.Read())
            {
                drpBranch.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();            

            cls.bizRead("spSel_Branch_Role_Tbl_Role @Login_Name='" + Session["un"].ToString() + "'");
            if (cls.dr.Read())
            {
                drpBranch.Enabled = true;
            }
            else
            {
                drpBranch.Enabled = false;
            }
            cls.dr.Close();

            if (Session["un"].ToString() == "mani@mazenetsolution.com" || Session["un"].ToString() == "mahalakshmi@mazenetsolution.com" || Session["un"].ToString() == "accounts@mazenetsolution.com" || Session["un"].ToString() == "asst.accountant@mazenetsolution.com" || Session["un"].ToString() == "ashokraj@mazenetsolution.com" || Session["un"].ToString() == "logistics@mazenetsolution.com" || Session["un"].ToString() == "drt@mazenetsolution.com" || Session["un"].ToString() == "prabakaran.n@mazenetsolution.com" || Session["un"].ToString() == "sugin@mazenetsolution.com")
            {
                drpBranch.Items.Add("All Branch");
            }
        }
        drpBranch.Text = Session["Branch_Name"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        string strBranchName;
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        
        if (txtFromDate.Text == "")
        {
            dtFromDate = Convert.ToDateTime("1900/01/01", dateInfo);
        }
        else
        {
            dtFromDate = Convert.ToDateTime(txtFromDate.Text, dateInfo);
        }

        
        if (txtTillDate.Text == "")
        {
            dtTillDate = Convert.ToDateTime("5000/01/01", dateInfo);
        }
        else
        {
            dtTillDate = Convert.ToDateTime(txtTillDate.Text, dateInfo);
        }

        if (drpBranch.SelectedIndex == 0)
        {
            strBranchName = Session["Branch_Name"].ToString();
        }
        else
        {
            strBranchName = drpBranch.Text;
        }
        if (rbtnCertCourse.Checked == true)
        {
            pnl_Course.Visible = true;
            pnl_Workshop.Visible = false;
            if (drpBranch.Text != "All Branch")
            {
                if (drpStatus.SelectedIndex == 0)
                {
                    cls.bizAdapter("spSel_CertificateNoStatus @BranchName='" + strBranchName + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_CertificateRequest");
                    gvCertificateDetails.DataSource = cls.ds;
                    gvCertificateDetails.DataBind();
                }
                else
                {
                    cls.bizAdapter("spSel_CertificateStatus @BranchName='" + strBranchName + "',@Status='" + drpStatus.Text + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_CertificateRequest");
                    gvCertificateDetails.DataSource = cls.ds;
                    gvCertificateDetails.DataBind();
                }
            }
            else
            {
                if (drpStatus.SelectedIndex == 0)
                {
                    cls.bizAdapter("spSel_CertificateNoStatus_AllBranch @FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_CertificateRequest");
                    gvCertificateDetails.DataSource = cls.ds;
                    gvCertificateDetails.DataBind();
                }
                else
                {
                    cls.bizAdapter("spSel_CertificateStatus_AllBranch @Status='" + drpStatus.Text + "', @FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_CertificateRequest");
                    gvCertificateDetails.DataSource = cls.ds;
                    gvCertificateDetails.DataBind();
                }
            }
        }
        else
        {
            pnl_Course.Visible = false;
            pnl_Workshop.Visible = true;
            if (drpBranch.Text != "All Branch")
            {
                if (drpStatus.SelectedIndex == 0)
                {
                    cls.bizAdapter("spSel_WCertificateNoStatus @BranchName='" + strBranchName + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_WorkshopCertificate");
                    gvWCertificationDetails.DataSource = cls.ds;
                    gvWCertificationDetails.DataBind();
                }
                else
                {
                    cls.bizAdapter("spSel_WCertificateStatus @BranchName='" + strBranchName + "',@Status='" + drpStatus.Text + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_WorkshopCertificate");
                    gvWCertificationDetails.DataSource = cls.ds;
                    gvWCertificationDetails.DataBind();
                }
            }
            else
            {
                if (drpStatus.SelectedIndex == 0)
                {
                    cls.bizAdapter("spSel_WCertificateNoStatus_AllBranch @FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_WorkshopCertificate");
                    gvWCertificationDetails.DataSource = cls.ds;
                    gvWCertificationDetails.DataBind();
                }
                else
                {
                    cls.bizAdapter("spSel_WCertificateStatus_AllBranch @Status='" + drpStatus.Text + "', @FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_WorkshopCertificate");
                    gvWCertificationDetails.DataSource = cls.ds;
                    gvWCertificationDetails.DataBind();
                }
            }
        }
    }
}