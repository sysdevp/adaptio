using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class batch_status : System.Web.UI.Page
{
HttpCookie Session;

    string strBranch_Name = "";    
    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            mazenet_branches();
            DateTime FirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            txtDate1.Text = FirstDate.ToString("dd-MM-yyyy");
            txtDate2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            Mazenet_ClassRooms();
        }
    }
    protected void btnViewBatchDetails_Click(object sender, EventArgs e)
    {
        if (drpBranch.SelectedIndex == 0)
        {
            strBranch_Name = Session["Branch_Name"].ToString();
        }
        else
        {
            strBranch_Name = drpBranch.Text;
        }
        System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
        dateInfo.ShortDatePattern = "dd/MM/yyyy";        
        DateTime dStt = Convert.ToDateTime(txtDate1.Text, dateInfo);
        DateTime dEnn = Convert.ToDateTime(txtDate2.Text, dateInfo);

        string dSt = dStt.ToString("yyyy/MM/dd");
        string dEn = dEnn.ToString("yyyy/MM/dd");

        cls_DDL_DML cls = new cls_DDL_DML();

        cls.bizRead("spSel_08Am10Am @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_08Am10Am.BackColor = System.Drawing.Color.Red;
                lbl_08Am10Am.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_08Am10Am.BackColor = System.Drawing.Color.Green;
                lbl_08Am10Am.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_08Am10Am.BackColor = System.Drawing.Color.Green;
            lbl_08Am10Am.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_10Am12Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");        
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_10Am12Pm.BackColor = System.Drawing.Color.Red;
                lbl_10Am12Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_10Am12Pm.BackColor = System.Drawing.Color.Green;
                lbl_10Am12Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_10Am12Pm.BackColor = System.Drawing.Color.Green;
            lbl_10Am12Pm.Text = "Available";
        }

        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_12Pm02Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_12Pm02Pm.BackColor = System.Drawing.Color.Red;
                lbl_12Pm02Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_12Pm02Pm.BackColor = System.Drawing.Color.Green;
                lbl_12Pm02Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_12Pm02Pm.BackColor = System.Drawing.Color.Green;
            lbl_12Pm02Pm.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_02Pm04Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_02Pm04Pm.BackColor = System.Drawing.Color.Red;
                lbl_02Pm04Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_02Pm04Pm.BackColor = System.Drawing.Color.Green;
                lbl_02Pm04Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_02Pm04Pm.BackColor = System.Drawing.Color.Green;
            lbl_02Pm04Pm.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_04Pm06Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_04Pm06Pm.BackColor = System.Drawing.Color.Red;
                lbl_04Pm06Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_04Pm06Pm.BackColor = System.Drawing.Color.Green;
                lbl_04Pm06Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_04Pm06Pm.BackColor = System.Drawing.Color.Green;
            lbl_04Pm06Pm.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_06Pm08Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_06Pm08Pm.BackColor = System.Drawing.Color.Red;
                lbl_06Pm08Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_06Pm08Pm.BackColor = System.Drawing.Color.Green;
                lbl_06Pm08Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_06Pm08Pm.BackColor = System.Drawing.Color.Green;
            lbl_06Pm08Pm.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_08Pm10Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_08Pm10Pm.BackColor = System.Drawing.Color.Red;
                lbl_08Pm10Pm.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_08Pm10Pm.BackColor = System.Drawing.Color.Green;
                lbl_08Pm10Pm.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_08Pm10Pm.BackColor = System.Drawing.Color.Green;
            lbl_08Pm10Pm.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        cls.bizRead("spSel_10Am04Pm @Branch_Name='" + strBranch_Name.ToString() + "',@Class_Name='" + drpClassRoom.Text + "',@Date1='" + dSt.ToString() + "',@Date2='" + dEn.ToString() + "'");
        if (cls.dr.Read())
        {
            if (cls.dr["Status"].ToString() == "Blocked")
            {
                pnl_10Am04PM.BackColor = System.Drawing.Color.Red;
                lbl_10Am04PM.Text = "Blocked from: " + cls.dr["Start_Date"].ToString() + " till: " + cls.dr["End_Date"].ToString() + "<br />" + "Available from: " + cls.dr["Available_From"].ToString();
            }
            if (cls.dr["Status"].ToString() == "Available")
            {
                pnl_10Am04PM.BackColor = System.Drawing.Color.Green;
                lbl_10Am04PM.Text = "Available from: " + cls.dr["Available_From"].ToString();
            }
        }
        else
        {
            pnl_10Am04PM.BackColor = System.Drawing.Color.Green;
            lbl_10Am04PM.Text = "Available";
        }
        cls.dr.Close();
        //--------------------------------------------------------------------
        
    }

    private void Mazenet_ClassRooms()
    {

        if (drpBranch.SelectedIndex == 0)
        {
            strBranch_Name = Session["Branch_Name"].ToString();
        }
        else
        {
            strBranch_Name = drpBranch.Text;
        }
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizRead("spSel_ClassRoomName @Branch_Name='" + strBranch_Name.ToString() + "'");
        drpClassRoom.Items.Clear();
        drpClassRoom.Items.Add("<-- Select -->");
        while (cls.dr.Read())
        {
            drpClassRoom.Items.Add(cls.dr[0].ToString());
        }
        cls.dr.Close();
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
        }
        drpBranch.Text = Session["Branch_Name"].ToString();

    }
    protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Mazenet_ClassRooms();
    }

}