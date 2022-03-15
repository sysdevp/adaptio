using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class conversion_report_details : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        cls.bizAdapter("spSel_ConvertionReport_CT_View @Date1='" + Request.QueryString["Date1"].ToString() + "',@Date2='" + Request.QueryString["Date2"].ToString() + "',@Branch='" + Request.QueryString["Branch"].ToString() + "'", "tbl_enquiry");
        GridView1.DataSource = cls.ds;
        GridView1.DataBind();
    }
}