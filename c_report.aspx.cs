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
using System.Net.Mail;
using System.Text;
using System.IO;
//using System.Xml.Linq;

public partial class c_report : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            cls.bizAdapter("spSel_Receipt_Todays_Report @Branch_Name='" + Session["Branch_Name"].ToString() + "'", "cTbl_Receipt");
            dg2.DataSource = cls.ds;
            dg2.DataBind();
            dg2.Caption = "Todays Collection Report for the Branch - " + Session["Branch_Name"].ToString();

        }
    }
    protected void btnSendMyReport_Click(object sender, EventArgs e)
    {
        string sString = "";

        StringBuilder sb2 = new StringBuilder();
        StringWriter sw2 = new StringWriter(sb2);
        HtmlTextWriter htmlTW2 = new HtmlTextWriter(sw2);
        dg2.RenderControl(htmlTW2);
        string dataGridHTML2 = sb2.ToString();

        MailMessage message = new MailMessage();
        message.From = new MailAddress("mazenet@mazenetsolution.com");
        message.To.Add(new MailAddress("ashokraj@mazenetsolution.com"));

        message.Body = sString.Replace(Environment.NewLine, "<br/>");
        message.Body += "<br/> <br/>";
        message.Body += dataGridHTML2;
        message.IsBodyHtml = true;
        message.Subject = "Daily report of the branch " + Session["Branch_Name"].ToString() + "as on " + System.DateTime.Today.ToString("dd/MM/yyyy");
        SmtpClient client = new SmtpClient();
        client.EnableSsl = true;
        try
        {
            client.Send(message);
            //Response.Write("message has been sent");
        }
        catch (SystemException ex)
        {
            Response.Write(ex.Message);
        }
        
        
    }

    float t1,t2 = 0;
    protected void dg2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
        {
            t1 += int.Parse(e.Item.Cells[4].Text);
            t2 += float.Parse(e.Item.Cells[5].Text);
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.BackColor = System.Drawing.Color.Tomato;
            e.Item.Cells[3].Text = "Total";
            e.Item.Cells[4].Text = t1.ToString();
            e.Item.Cells[5].Text = t2.ToString();
        }
    }
}
