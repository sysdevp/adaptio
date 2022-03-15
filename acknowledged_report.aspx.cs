using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class acknowledged_report : System.Web.UI.Page
{
HttpCookie Session;

    DateTime dtFromDate, dtTillDate;
    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            DateTime FirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtFromDate.Text = FirstDate.ToString("dd-MM-yyyy");
            txtTillDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");  
            mazenet_branches();
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

        if (chkAcknowledge.Checked == true)
        {
            cls.bizAdapter("spSel_PendingAck @BranchName='" + strBranchName + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_Enquiry");
            gvAcknowledge.DataSource = cls.ds;
            gvAcknowledge.DataBind();
         }
         else if (chkAcknowledge.Checked == false)
         {
             cls.bizAdapter("spSel_Ack @BranchName='" + strBranchName + "',@FromDate='" + dtFromDate.ToString() + "',@TillDate='" + dtTillDate.ToString() + "'", "tbl_Enquiry");
             gvAcknowledge.DataSource = cls.ds;
             gvAcknowledge.DataBind();
         }
    }
}