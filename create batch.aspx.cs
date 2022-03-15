using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class create_batch : System.Web.UI.Page
{
HttpCookie Session;

    
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizRead("spSel_ClassRoomName @Branch_Name='" + Session["Branch_Name"].ToString() + "'");
            drpClassRoom.Items.Clear();
            drpClassRoom.Items.Add("<-- Select -->");
            while (cls.dr.Read())
            {
                drpClassRoom.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
            //----------------------------------------------------
            cls.bizRead("spSel_Tbl_Enquired_For");
            drpCourse.Items.Clear();
            drpCourse.Items.Add("<-- Select -->");
            while (cls.dr.Read())
            {
                drpCourse.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
            //----------------------------------------------------
            fnRp1ActiveEmail();
        }
    }
    
    protected void btnCreateBatch_Click(object sender, EventArgs e)
    {
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";
        DateTime dSt = Convert.ToDateTime(txtBatchStartsOn.Text, dateInfo);        
        DateTime dEn = Convert.ToDateTime(txtBatchEndsOn.Text, dateInfo);
        
        cls_DDL_DML cls = new cls_DDL_DML();
        lblBatchResult.Text = cls.bizCommand("spIns_tbl_BatchDetails @Branch_Name='" + Session["Branch_Name"].ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Department='" + drpDepartment.Text + "',@LoginName='" + drpUser.Text + "',@Course='" + drpCourse.Text + "',@CourseDescription='" + txtCourseDescription.Text + "',@StartDate='" + dSt + "',@EndDate='" + dEn + "',@StartTime='" + txtBatchStartsTime.Text + "',@EndTime='" + txtBatchEndsTime.Text + "',@BatchStatus='Active',@Details_added_by='" + Session["un"].ToString() + "',@TotalHRS='" + txtTotalHRS.Text + "',@RemainingHRS='" + txtTotalHRS.Text + "',@PlannedBatchSize='"+txtPlannedBatchSize.Text +"'");
        
    }
    protected void btnWho_Click(object sender, EventArgs e)
    {        
        SqlConnection hrmCon = new SqlConnection("server=216.10.240.149;Database=ashokrajd_hrmupload;user id=Maze_un;password=LionZebra@123$%");
        SqlDataReader hrmDr;
        SqlCommand hrmCmd;
        if (hrmCon.State == ConnectionState.Closed)
        {
            hrmCon.Open();
        }
        hrmCmd = new SqlCommand("spSel_NameDesig @emailid='" + drpUser.Text + "'", hrmCon);
        hrmDr = hrmCmd.ExecuteReader();        
        if (hrmDr.Read())
        {
            lblTrainerDetails.Text = hrmDr[0].ToString() + ", " + hrmDr[1].ToString();
        }
        hrmDr.Close();
        hrmCon.Close();
    }
    protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizRead("spSel_TOtal_HRS @Enquired_For='"+drpCourse.Text +"'");
        if (cls.dr.Read())
        {
            txtTotalHRS.Text = cls.dr[0].ToString();
        }
        cls.dr.Close();
    }

    private void fnRp1ActiveEmail()
    {
        SqlConnection hrmCon = new SqlConnection("server=216.10.240.149;Database=ashokrajd_hrmupload;user id=Maze_un;password=LionZebra@123$%");
        SqlDataReader hrmDr;
        SqlCommand hrmCmd;
        if (hrmCon.State == ConnectionState.Closed)
        {
            hrmCon.Open();
        }       

        hrmCmd = new SqlCommand("spSel_Rp1ActiveEmail @Branch_Name='" + Session["Branch_Name"].ToString() + "'", hrmCon);
        hrmDr = hrmCmd.ExecuteReader();
        drpUser.Items.Clear();
        drpUser.Items.Add("<-- Select -->");
        while (hrmDr.Read())
        {
            drpUser.Items.Add(hrmDr[0].ToString());
        }
        hrmDr.Close();
        hrmCon.Close();
    }
}