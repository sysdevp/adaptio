using System;
using System.Collections;
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

public partial class c_view : System.Web.UI.Page
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
        }
    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {       

        if (Request.Form["txtStartDate"].ToString() != "")
        {
            lblFromDate.Text = Request.Form["txtStartDate"].ToString();
            lblToDate.Text = Request.Form["txtEndDate"].ToString();
        }
        else
        {
            passDate();
        }

        if (drpBranch.SelectedIndex == 0)
        {
            cls.bizAdapter("spSel_Receipt @Branch_Name='" + Session["Branch_Name"].ToString() + "',@From_Date='" + lblFromDate.Text + "',@To_Date='"+lblToDate.Text +"'", "cTbl_Receipt");
            GridView1.DataSource = cls.ds;
            GridView1.DataBind();
            GridView1.Caption = "Receipt Details" ;
        }
        else
        {
            cls.bizAdapter("spSel_Receipt @Branch_Name='" + drpBranch.Text + "',@From_Date='" + lblFromDate.Text + "',@To_Date='" + lblToDate.Text + "'", "cTbl_Receipt");
            GridView1.DataSource = cls.ds;
            GridView1.DataBind();
            GridView1.Caption = "Receipt Details";
        }
    }   
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {        
        string id = GridView1.SelectedValue.ToString();        
        Response.Write("<script>");
        Response.Write("window.open('c_popup.aspx?id="+id +"','_blank','toolbar=0,location=0,menubar=0,resizable=0,width=400,height=420')");
        Response.Write("</script>"); 
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

    public void passDate()
    {
        DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        lblFromDate.Text = dtFrom.ToString("yyyy/MM/dd");

        DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        lblToDate.Text = (dtTo.AddMonths(1).AddDays(-1)).ToString("yyyy/MM/dd");
        lblFromDate.Text = "";
    }

}

