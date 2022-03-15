using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class analyze_media_reg : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            DateTime FirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtStartDate.Text = FirstDate.ToString("dd-MM-yyyy");
            txtEndDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            mazenet_branches();
            fnCourseEnquiredFor();
        }
    }

    protected void btnDisplay_Click(object sender, EventArgs e)
    {

        DateTime dSt, dEn;
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";

        if (txtStartDate.Text != "" && txtEndDate.Text != "")
        {
            dSt = Convert.ToDateTime(txtStartDate.Text, dateInfo);
            dEn = Convert.ToDateTime(txtEndDate.Text, dateInfo);

            lblFromDate.Text = dSt.ToString();
            lblToDate.Text = dEn.ToString();
        }
        else
        {
            lblFromDate.Text = "1997/01/01";
            lblToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        if (drpBranch.Text == "< - Select Branch - >" && drpEnquiredFor.Text == "< - Select All - >")
        {
            correspondingBranch();
        }
        else if (drpBranch.Text == "All Branch" && drpEnquiredFor.Text == "< - Select All - >")
        {
            fnAllBranch();
        }
        else if (drpBranch.Text != "< - Select Branch - >" && drpEnquiredFor.Text == "< - Select All - >")
        {
            selectiveBranch();
        }
        else if (drpBranch.Text == "All Branch" && drpEnquiredFor.Text != "< - Select All - >")
        {
            selectiveCourse();
        }
        else if (drpBranch.Text == "< - Select Branch - >" && drpEnquiredFor.Text != "< - Select All - >")
        {
            selectiveCourse();
        }
        else if (drpBranch.Text != "< - Select Branch - >" && drpEnquiredFor.Text != "< - Select All - >")
        {
            selectiveBranchandCourse();
        }

        //else
        //{
        //    if (drpBranch.Text != "All Branch")
        //    {
        //        selectiveBranch();
        //    }
        //    else
        //    {
        //        fnAllBranch();
        //    }
        //}
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
            cls.bizRead("spSel_Branch");
            drpBranch.Items.Clear();
            drpBranch.Items.Add("< - Select Branch - >");
            while (cls.dr.Read())
            {
                drpBranch.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();

            drpBranch.Text = Session["Branch_Name"].ToString();

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

    public void fnCourseEnquiredFor()
    {
        try
        {
            cls.bizRead("spSel_Tbl_Enquired_For");
            drpEnquiredFor.Items.Clear();
            drpEnquiredFor.Items.Add("< - Select All - >");
            while (cls.dr.Read())
            {
                drpEnquiredFor.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    public void fnAllBranch()
    {
        cls.bizAdapter("spSel_Analyze_Media_AllBranch_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "'", "Tbl_Enquiry");
        gvMediaDetails.DataSource = cls.ds;
        gvMediaDetails.DataBind();

        cls.bizAdapter("spSel_Analyze_Media_AllBranch_Grid_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "'", "Tbl_Enquiry");
        gvCandidateDetails.DataSource = cls.ds;
        gvCandidateDetails.DataBind();

    }

    public void correspondingBranch()
    {
        cls.bizAdapter("spSel_Analyze_Media_noAllBranch_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "'", "Tbl_Enquiry");
        gvMediaDetails.DataSource = cls.ds;
        gvMediaDetails.DataBind();

        cls.bizAdapter("spSel_Analyze_Media_noAllBranch_Grid_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "'", "Tbl_Enquiry");
        gvCandidateDetails.DataSource = cls.ds;
        gvCandidateDetails.DataBind();


    }

    public void selectiveBranch()
    {
        cls.bizAdapter("spSel_Analyze_Media_noAllBranch_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + drpBranch.Text + "'", "Tbl_Enquiry");
        gvMediaDetails.DataSource = cls.ds;
        gvMediaDetails.DataBind();

        cls.bizAdapter("spSel_Analyze_Media_noAllBranch_Grid_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + drpBranch.Text + "'", "Tbl_Enquiry");
        gvCandidateDetails.DataSource = cls.ds;
        gvCandidateDetails.DataBind();
    }

    public void selectiveCourse()
    {
        cls.bizAdapter("spSel_Analyze_Media_noAllCourse_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Enquired_For='" + drpEnquiredFor.Text + "'", "Tbl_Enquiry");
        gvMediaDetails.DataSource = cls.ds;
        gvMediaDetails.DataBind();

        cls.bizAdapter("spSel_Analyze_Media_noAllCourse_Grid_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Enquired_For='" + drpEnquiredFor.Text + "'", "Tbl_Enquiry");
        gvCandidateDetails.DataSource = cls.ds;
        gvCandidateDetails.DataBind();
    }

    public void selectiveBranchandCourse()
    {
        cls.bizAdapter("spSel_Analyze_Media_noAllBranchCourse_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + drpBranch.Text + "',@Enquired_For='" + drpEnquiredFor.Text + "'", "Tbl_Enquiry");
        gvMediaDetails.DataSource = cls.ds;
        gvMediaDetails.DataBind();

        cls.bizAdapter("spSel_Analyze_Media_noAllBranchCourse_Grid_reg @FromDate='" + lblFromDate.Text + "',@ToDate='" + lblToDate.Text + "',@Branch_Name='" + drpBranch.Text + "',@Enquired_For='" + drpEnquiredFor.Text + "'", "Tbl_Enquiry");
        gvCandidateDetails.DataSource = cls.ds;
        gvCandidateDetails.DataBind();
    }   


    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvCandidateDetails.Rows.Count == 0)
            {

            }
            else
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=MediaWiseReg.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                gvCandidateDetails.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}