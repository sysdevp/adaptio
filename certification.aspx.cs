using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();
    
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
     
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        authentication();
    }
    public void authentication()
    {
        cls.bizRead("spSel_Login_Authenticate @Login_Name='" + txtUserName.Text + "',@Login_Password='" + txtPassword.Text + "'");
        if (cls.dr.Read())
        {
            Session["un"] = cls.dr[0].ToString();
            Session["Branch_Name"] = cls.dr["Branch_Name"].ToString();
            cls.dr.Close();
            Session["sid"] = Page.Session.SessionID;
            Response.Redirect("c_receipt.aspx");
        }
        else
        {
            lblResult.Text = "Authentication Failed !";
        }
        cls.dr.Close();
    }
}
