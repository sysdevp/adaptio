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

public partial class c_popup : System.Web.UI.Page
{
HttpCookie Session;


    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizRead("spSel_Receipt_full @Receipt_No='"+Request.QueryString["id"].ToString() +"'");
        while (cls.dr.Read())
        {
            lblReceiptNo.Text= "Receipt No: " + cls.dr["Receipt_No"].ToString();
            lblReceiptDate.Text="Date: " + cls.dr["Receipt_Date"].ToString();
            lblBranchName.Text = "Branch: " + cls.dr["Branch_Name"].ToString();
            lblEmployee.Text="Responsible Person: " + cls.dr["Details_added_by"].ToString();

            lblName.Text = cls.dr["Name"].ToString();
            lblAddress.Text = cls.dr["Address_"].ToString();
            lblCity.Text = cls.dr["City"].ToString();
            lblState.Text = cls.dr["State_"].ToString();
            lblPincode.Text = cls.dr["Pincode"].ToString();
            lblPhone.Text = cls.dr["Phone"].ToString();

            lblVendor.Text = "Vendor: " + cls.dr["Vendor"].ToString();
            lblExamCode.Text = "Exam Code:" + cls.dr["Exam_Code"].ToString();
            lblNoOfVoucher.Text = "No.of Vouchers: " + cls.dr["No_of_Vouchers"].ToString();
            lblAmount.Text = "Amount Received: " + cls.dr["Amount_Received"].ToString();

            lblDescriptions.Text = "Addition Details: " + cls.dr["Descriptions"].ToString();
            
        }
        cls.dr.Close();

    }
}
