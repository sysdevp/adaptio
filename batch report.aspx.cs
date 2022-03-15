using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class batch_report : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            mazenet_branches();
            Management();
            user();
            fnFillDates();
            pnl_Batch.Visible = false;
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
            cls.bizRead("spSel_Branch");
            drpBranch.Items.Clear();
            drpBranch.Items.Add("< - Select Branch - >");
            while (cls.dr.Read())
            {
                drpBranch.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();
        }

        drpBranch.Text = Session["Branch_Name"].ToString();
    }

    public void Management()
    {
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

    public void user()
    {
        cls.bizRead("spSel_TrainerLoginDetails @Branch_Name='" + Session["Branch_Name"].ToString() + "'");
        drpUser.Items.Clear();
        drpUser.Items.Add("<-- All Trainers -->");
        while (cls.dr.Read())
        {
            drpUser.Items.Add(cls.dr["LoginName"].ToString());
        }
        cls.dr.Close();
    }
    protected void btnBatchReport_Click(object sender, EventArgs e)
    {
        lblDate1.Text = System.Convert.ToDateTime(drpDate1.Text).ToString("yyyy/MM/dd");
        lblDate2.Text = System.Convert.ToDateTime(drpDate2.Text).ToString("yyyy/MM/dd");

        string Branch_Name = "";
        if (drpBranch.SelectedIndex == 0)
        {
            Branch_Name = Session["Branch_Name"].ToString();
        }
        else
        {
            Branch_Name = drpBranch.Text;
        }

        if (drpUser.SelectedIndex == 0)
        {
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizAdapter("spSel_TrainerBatchReport_AllUser @Date1='"+ lblDate1.Text +"',@Date2='"+lblDate2.Text +"', @Branch_Name='" + Branch_Name.ToString() + "'", "tbl_BatchDetails");
            gvReport.DataSource = cls.ds;
            gvReport.DataBind();
        }
        else
        {
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizAdapter("spSel_TrainerBatchReport @Date1='" + lblDate1.Text + "',@Date2='" + lblDate2.Text + "', @Branch_Name='" + Branch_Name.ToString() + "',@LoginName='" + drpUser.Text + "'", "tbl_BatchDetails");
            gvReport.DataSource = cls.ds;
            gvReport.DataBind();
        }

        pnl_Batch.Visible = true;
    }


    public void fnFillDates()
    {
        drpDate1.Items.Clear();
        for (int i = 0; i <= 12; i++)
        {
            string prevMonth = System.DateTime.Now.AddMonths(-i).ToString("MMMM yyyy");
            drpDate1.Items.Add(prevMonth);
            drpDate2.Items.Add(prevMonth);
        }
    }
    
    int int1 = 0, int2 = 0,int3=0,int4=0,int5=0,int6=0,int7=0,int8=0;
    int int1nos = 0, int2nos = 0, int3nos = 0, int4nos = 0, int5nos = 0, int6nos = 0, int7nos = 0, int8nos = 0;

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;

            if (e.Row.Cells[4].Text == "08:00AM to 10:00AM")
            {
                int1 += 1;                
            }

            if (e.Row.Cells[4].Text == "10:00AM to 12:00PM")
            {
                int2 += 1;                
            }

            if (e.Row.Cells[4].Text == "12:00PM to 02:00PM")
            {
                int3 += 1;                
            }

            if (e.Row.Cells[4].Text == "02:00PM to 04:00PM")
            {
                int4 += 1;                
            }

            if (e.Row.Cells[4].Text == "04:00PM to 06:00PM")
            {
                int5 += 1;                
            }

            if (e.Row.Cells[4].Text == "06:00PM to 08:00PM")
            {
                int6 += 1;                
            }

            if (e.Row.Cells[4].Text == "08:00PM to 10:00PM")
            {
                int7 += 1;                
            }

            if (e.Row.Cells[4].Text == "10:00AM to 04:00PM")
            {
                int8 += 1;                
            }

            if (int1 > 0)
            {
                pnl_1.BackColor = System.Drawing.Color.Red;
                int1nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_1.BackColor = System.Drawing.Color.Blue;
                int1nos = 0;
            }

            if (int2 > 0)
            {
                pnl_2.BackColor = System.Drawing.Color.Red;
                int2nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_2.BackColor = System.Drawing.Color.Blue;
                int2nos = 0;
            }

            if (int3 > 0)
            {
                pnl_3.BackColor = System.Drawing.Color.Red;
                int3nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_3.BackColor = System.Drawing.Color.Blue;
                int3nos = 0;
            }

            if (int4 > 0)
            {
                pnl_4.BackColor = System.Drawing.Color.Red;
                int4nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_4.BackColor = System.Drawing.Color.Blue;
                int4nos = 0;
            }

            if (int5 > 0)
            {
                pnl_5.BackColor = System.Drawing.Color.Red;
                int5nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_5.BackColor = System.Drawing.Color.Blue;
                int5nos = 0;
            }

            if (int6 > 0)
            {
                pnl_6.BackColor = System.Drawing.Color.Red;
                int6nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_6.BackColor = System.Drawing.Color.Blue;
                int6nos = 0;
            }

            if (int7 > 0)
            {
                pnl_7.BackColor = System.Drawing.Color.Red;
                int7nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_7.BackColor = System.Drawing.Color.Blue;
                int7nos = 0;
            }

            if (int8 > 0)
            {
                int8nos += System.Convert.ToInt32(e.Row.Cells[8].Text);
            }
            else
            {
                pnl_8.BackColor = System.Drawing.Color.Blue;
                int8nos = 0;
            }
        }
        lbl_1_nos.Text = "( " + int1nos.ToString() + " ) Student(s)";
        lbl_2_nos.Text = "( " + int2nos.ToString() + " ) Student(s)";
        lbl_3_nos.Text = "( " + int3nos.ToString() + " ) Student(s)";
        lbl_4_nos.Text = "( " + int4nos.ToString() + " ) Student(s)";
        lbl_5_nos.Text = "( " + int5nos.ToString() + " ) Student(s)";
        lbl_6_nos.Text = "( " + int6nos.ToString() + " ) Student(s)";
        lbl_7_nos.Text = "( " + int7nos.ToString() + " ) Student(s)";
        lbl_8_nos.Text = "( " + int8nos.ToString() + " ) Student(s)";        
    }
}