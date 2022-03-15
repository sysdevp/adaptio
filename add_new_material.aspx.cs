using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_new_material : System.Web.UI.Page
{
HttpCookie Session;

    cls_DDL_DML cls = new cls_DDL_DML();
    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            cls.bizCommand("spIns_tbl_MaterialMaster @MaterialType='" + drpMaterialType.SelectedValue + "',@MaterialFrom='" + drpMaterialFrom.SelectedValue + "', @Vendor='" + drpVendor.SelectedValue + "', @CourseType='" + drpCourseType.SelectedValue + "', @MaterialName='" + txtMaterialName.Text + "'");
            lblMsg.Text = "New material added successfully.";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
       
}