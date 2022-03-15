using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class conversion_report : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {

            DateTime FirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);            
            txtDate1.Text = FirstDate.ToString("dd-MM-yyyy");            
            txtDate2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            mazenet_branches();
            mazenet_courses();
        }
    }
    protected void btnConversionReport_Click(object sender, EventArgs e)
    {
        
        if (Session["sid"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        cls_DDL_DML cls = new cls_DDL_DML();
        int intEnquiryType;
        if (ChkEnquiryType.Checked == true)
        {
            intEnquiryType = 1;
        }
        else
        {
            intEnquiryType = 0;
        }
        passDate();

        List<String> lstBranch = new List<string>(); string strBranchChecked = "";
        List<String> lstCourse = new List<string>(); string strCourseChecked = "";

        foreach (System.Web.UI.WebControls.ListItem item in drpBranch.Items)
        {
            if (item.Selected)
            {
                lstBranch.Add(item.Text);
            }

            strBranchChecked = String.Join("^", lstBranch.ToArray());
        }

        foreach (System.Web.UI.WebControls.ListItem item in drpCourse.Items)
        {
            if (item.Selected)
            {
                lstCourse.Add(item.Text);
            }

            strCourseChecked = String.Join("^", lstCourse.ToArray());
        }





        cls.bizRead("spSel_ConvertionReportWalkinCount @Date1='" + lblFromDate.Text + "',@Date2='" + lblToDate.Text + "',@Enquiry_Type='" + intEnquiryType + "',@Branch_Name='" + strBranchChecked + "',@course='" + strCourseChecked + "'");
        while (cls.dr.Read())
        {
            lblWalkins.Text = "Walkins: " + cls.dr[0].ToString();
        }
        cls.dr.Close();
        //------
        cls.bizRead("spSel_ConvertionReportRegistrationCount @Date1='" + lblFromDate.Text + "',@Date2='" + lblToDate.Text + "',@Enquiry_Type='" + intEnquiryType + "',@Branch_Name='" + strBranchChecked + "',@course='" + strCourseChecked + "'");
        while (cls.dr.Read())
        {
            lblRegistrations.Text = "Registrations: " + cls.dr[0].ToString();
        }
        cls.dr.Close();
        //------
        cls.bizAdapter("spSel_ConvertionReportResultGrid @Date1='" + lblFromDate.Text + "',@Date2='" + lblToDate.Text + "',@Enquiry_Type='"+intEnquiryType +"',@Branch_Name='" + strBranchChecked + "',@course='" + strCourseChecked + "'", "tbl_enquiry");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
 
    }


    protected void Edit(object sender, EventArgs e)
    {
        string strCourse;
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            strCourse = row.Cells[2].Text;            
        }
        passDate();


        int intEnquiryType;
        if (ChkEnquiryType.Checked == true)
        {
            intEnquiryType = 1;
        }
        else
        {
            intEnquiryType = 0;
        }
        passDate();

        List<String> lstBranch = new List<string>(); string strBranchChecked = "";
        List<String> lstCourse = new List<string>(); string strCourseChecked = "";

        foreach (System.Web.UI.WebControls.ListItem item in drpBranch.Items)
        {
            if (item.Selected)
            {
                lstBranch.Add(item.Text);
            }

            strBranchChecked = String.Join("^", lstBranch.ToArray());
        }

        foreach (System.Web.UI.WebControls.ListItem item in drpCourse.Items)
        {
            if (item.Selected)
            {
                lstCourse.Add(item.Text);
            }

            strCourseChecked = String.Join("^", lstCourse.ToArray());
        }


        cls.bizAdapter("spSel_ConvertionReportEnquiry @Date1='" + lblFromDate.Text + "',@date2='" + lblToDate.Text + "',@Course='" + strCourse.ToString() + "',@Enquiry_Type='" + intEnquiryType + "',@Branch_Name='" + strBranchChecked + "'", "tbl_enquiry");
        gvEnqDetails.DataSource = cls.ds;
        gvEnqDetails.DataBind();

        cls.bizAdapter("spSel_ConvertionReportRegistration @Date1='" + lblFromDate.Text + "',@Date2='" + lblToDate.Text + "',@Course='" + strCourse.ToString() + "',@Enquiry_Type='" + intEnquiryType + "',@Branch_Name='" + strBranchChecked + "'", "tbl_enquiry");
        gvRegDetails.DataSource = cls.ds;
        gvRegDetails.DataBind();        
        popup.Show();
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
        }
        
        drpBranch.Text = Session["Branch_Name"].ToString();        
    }


    private void mazenet_courses()
    {

        if (Session["un"].ToString() == "muthukumar.s@mazenetsolution.com")
        {
            cls.bizRead("spSel_Tbl_Enquired_For_Redhat");
            drpCourse.Items.Clear();            
            while (cls.dr.Read())
            {
                drpCourse.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
            drpCourse.Items[0].Attributes.Add("disabled", "disabled");
            
        }
        else
        {
            if (Session["un"].ToString() == "balaji.b@mazenetsolution.com")
            {

                drpBranch.Items.Remove("Erode");
                drpBranch.Items.Remove("Gandhipuram");
                drpBranch.Items.Remove("Hopes");
                drpBranch.Items.Remove("Karur");
                drpBranch.Items.Remove("Palakkad");
                drpBranch.Items.Remove("Pollachi");
                drpBranch.Items.Remove("Salem");
                drpBranch.Items.Remove("Tanjore");
                drpBranch.Items.Remove("Trichy");
                drpBranch.Items.Remove("Velachery");
                drpBranch.Items.Remove("Madurai");
                drpBranch.Items.Remove("Nagercoil");
            }

            cls.bizRead("spSel_Tbl_Enquired_For");
            drpCourse.Items.Clear();            
            while (cls.dr.Read())
            {
                drpCourse.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();            
        }

        foreach (ListItem item in drpCourse.Items)
        {
            item.Selected = true;
        }
        
    }

    private decimal TotalEnquired = (decimal)0.0;
    private decimal TotalRegistered = (decimal)0.0;
    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TotalEnquired += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Enquired"));
            TotalRegistered += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Registered"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].Text = "Total: ";
            e.Row.Cells[3].Text = TotalEnquired.ToString();
            e.Row.Cells[4].Text = TotalRegistered.ToString();
        }
    }


    public void passDate()
    {
        DateTime dSt, dEn;
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";

        if (txtDate1.Text != "" && txtDate2.Text != "")
        {
            dSt = Convert.ToDateTime(txtDate1.Text, dateInfo);
            dEn = Convert.ToDateTime(txtDate2.Text, dateInfo);

            lblFromDate.Text = dSt.ToString();
            lblToDate.Text = dEn.ToString();
        }
        else
        {
            lblFromDate.Text = "1997/01/01";
            lblToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
}
