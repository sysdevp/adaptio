using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class course_fee : System.Web.UI.Page
{
HttpCookie Session;


    cls_DDL_DML cls = new cls_DDL_DML();
    int intTax;
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (Session["un"].ToString() == "logistics@mazenetsolution.com" || Session["un"].ToString() == "mani@mazenetsolution.com" || Session["un"].ToString() == "mahalakshmi@mazenetsolution.com" || Session["un"].ToString() == "ashokraj@mazenetsolution.com" || Session["un"].ToString() == "manojkumar.k@mazenetsolution.com" || Session["un"].ToString() == "srihariprasath@mazenetsolution.com" || Session["un"].ToString() == "ravikumar@mazenetsolution.com" || Session["un"].ToString() == "akshay@mazenetsolution.com")
        {

            if (Session["un"].ToString() == "ashokraj@mazenetsolution.com")
            {
                pnlOldFee.Visible = true;
            }
            else
            {
                pnlOldFee.Visible = false;
            }

            if (!IsPostBack)
            {
                mazenet_branches();
                mazenet_courses();
            }
        }
        else
        {
            Response.Redirect("ounauthorized.aspx");
        }
    }

    private void mazenet_branches()
    {
        cls.bizRead("spSel_Branch");
        drpBranch.Items.Clear();drpBranchStdFee.Items.Clear();
        drpBranch.Items.Add("< - Select Branch - >");drpBranchStdFee.Items.Add("< - Select Branch - >");
        while (cls.dr.Read())
        {
            drpBranch.Items.Add(cls.dr[0].ToString());drpBranchStdFee.Items.Add(cls.dr[0].ToString());
        }
        cls.dr.Close();
    }

    private void mazenet_courses()
    {
        if (!IsPostBack)
        {
            cls.bizRead("spSel_Tbl_Enquired_For");
            drpCourse.Items.Clear();drpCourseStdFee.Items.Clear();
            drpCourse.Items.Add("< - Select Course - >");drpCourseStdFee.Items.Add("< - Select Course - >");
            while (cls.dr.Read())
            {
                drpCourse.Items.Add(cls.dr[0].ToString());drpCourseStdFee.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["un"].ToString() == "ashokraj@mazenetsolution.com" || Session["un"].ToString() == "manojkumar.k@mazenetsolution.com" || Session["un"].ToString() == "mahalakshmi@mazenetsolution.com")
            {
                if (float.Parse(txtCourseFeeMaximum.Text) >= float.Parse(txtCourseFeeMinimum.Text))
                {

                    cls_DDL_DML cls = new cls_DDL_DML();
                    cls.bizRead("spSel_ChkInsOrUpd @Branch_Name='" + drpBranch.Text + "',@Course_Name='" + drpCourse.Text + "'");
                    if (cls.dr.Read())
                    {
                        cls.dr.Close();
                        lblResult.Text = cls.bizCommand("spUpd_tbl_fee_master @Branch_Name='" + drpBranch.Text + "',@Course_Name='" + drpCourse.Text + "',@Course_Fee='" + txtCourseFeeMaximum.Text + "',@min_course_fee='" + txtCourseFeeMinimum.Text + "',@details_added_by='" + Session["un"].ToString() + "'");
                    }
                    else
                    {
                        cls.dr.Close();
                        lblResult.Text = cls.bizCommand("spIns_tbl_fee_master @Branch_Name='" + drpBranch.Text + "',@Course_Name='" + drpCourse.Text + "',@Course_Fee='" + txtCourseFeeMaximum.Text + "',@min_course_fee='" + txtCourseFeeMinimum.Text + "',@details_added_by='" + Session["un"].ToString() + "'");
                    }


                    lblTitle.Text = "Fee Details for " + drpBranch.Text;
                    cls.bizAdapter("spSel_FeeBranch @Branch_Name='" + drpBranch.Text + "'", "tbl_fee_master");
                    gvDetails.DataSource = cls.ds;
                    gvDetails.DataBind();
                }
                else
                {
                    lblResult.Text = "Maximum Slot fee sholud be <= Minimum Slot";
                }
            }
            else
            {
                lblResult.Text = "You are not Authorized!";
            }

        }
        catch (Exception ex)
        {
            lblResult.Text = ex.Message;
        }
    
    }
    protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblTitle.Text = "Fee Details for " + drpBranch.Text;
        cls.bizAdapter("spSel_FeeBranch @Branch_Name='" + drpBranch.Text + "'", "tbl_fee_master");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";

        DateTime dtFrom, dtTill;

        if (txtFromDate.Text == "")
        {
            dtFrom = Convert.ToDateTime("01/01/1900", dateInfo);
        }
        else
        {
            dtFrom = Convert.ToDateTime(txtFromDate.Text, dateInfo);
        }

        if (txtTillDate.Text == "")
        {
            dtTill = Convert.ToDateTime("01/01/1900", dateInfo);
        }
        else
        {
            dtTill = Convert.ToDateTime(txtTillDate.Text, dateInfo);
        }

        if ((txtDiscountPrice.Text != "0") && (txtFromDate.Text=="" ))
        {
            lblResultStdFee.Text = "Enter Discount Validity Date";
        }
        else if ((txtDiscountPrice.Text != "0") && (txtTillDate.Text == ""))
        {
            lblResultStdFee.Text = "Enter Discount Validity Date";
        }
        else if (Convert.ToDateTime(dtFrom.ToString()) > Convert.ToDateTime(dtTill.ToString()))
        {
            lblResultStdFee.Text = "From Date should be less than Till Date";
        }

        else
        {
            if (chkTaxApplicable.Checked == true)
            {
                intTax = 1;
            }
            else
            {
                intTax = 0;
            }
            cls.bizCommand("spSel_StandardFeeInsUpd @BranchName='" + drpBranchStdFee.Text + "',@CourseName='" + drpCourseStdFee.Text + "',@StandardFee='" + txtStandardFee.Text + "',@Discount='" + txtDiscountPrice.Text + "',@DiscountFrom='" + dtFrom.ToString() + "',@DiscountTill='" + dtTill.ToString() + "',@ServiceTax='" + intTax + "',@DetailsAddedBy='" + Session["un"].ToString() + "'");
            lblResultStdFee.Text = "Updated Successfully";
            fnFillFee();
        }
        
    }

    public void fnFillFee()
    {
        cls.bizAdapter("spSel_StandardFeeBranch @BranchName='" + drpBranchStdFee.Text + "'", "tbl_StandardFee");
        gvStandardFee.DataSource = cls.ds;
        gvStandardFee.DataBind();
    }

    public void fnFillCourseDetails()
    {
        cls.bizRead("spSel_StandardFeeBranchCourse @BranchName='" + drpBranchStdFee.Text + "',@CourseName='" + drpCourseStdFee.Text + "'");
        if (cls.dr.Read())
        {
            txtStandardFee.Text = cls.dr["Standard Price"].ToString();
            txtDiscountPrice.Text = cls.dr["Discount Price"].ToString();
            txtFromDate.Text = cls.dr["Valid From"].ToString();
            txtTillDate.Text = cls.dr["Valid Till"].ToString();
            if (cls.dr["Tax"].ToString() == "Yes")
            {
                chkTaxApplicable.Checked = true;
            }
            else
            {
                chkTaxApplicable.Checked = false;
            }

        }
        else
        {
            txtStandardFee.Text = string.Empty;
            txtDiscountPrice.Text = "0";
            txtFromDate.Text = string.Empty;
            txtTillDate.Text = string.Empty;
            chkTaxApplicable.Checked = true;
        }
        cls.dr.Close();
    }

    protected void drpBranchStdFee_SelectedIndexChanged(object sender, EventArgs e)
    {
        fnFillFee();
        fnFillCourseDetails();
    }
    protected void drpCourseStdFee_SelectedIndexChanged(object sender, EventArgs e)
    {
        fnFillCourseDetails();
    }
}