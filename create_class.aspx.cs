using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class create_class : System.Web.UI.Page
{
HttpCookie Session;

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {            
            mazenet_branches();
            fillGrid();
        }
    }
    protected void btnCreateNewClassRoom_Click(object sender, EventArgs e)
    {
        string strBranch_Name = "";
        if (drpBranch.SelectedIndex == 0)
        {
            strBranch_Name = Session["Branch_Name"].ToString();
        }
        else
        {
            strBranch_Name = drpBranch.Text;
        }
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizCommand("spIns_tbl_CLassRoomMaster @Branch_Name='"+strBranch_Name.ToString() +"',@Class_Name='"+txtClassName.Text +"',@Seating_Capacity='"+txtSeatingCapacity.Text +"',@Details_Added_By='"+Session["un"].ToString() +"'");
        lblResult.Text = "New Class Room Created";
        fillGrid();
    }

    public void fillGrid()
    {
        string strBranch_Name = "";
        if (drpBranch.SelectedIndex == 0)
        {
            strBranch_Name = Session["Branch_Name"].ToString();
        }
        else
        {
            strBranch_Name = drpBranch.Text;
        }

        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizAdapter("spSel_tbl_ClassRoomMaster @Branch_Name='"+drpBranch.Text +"'", "tbl_ClassRoomMaster");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();

    }

    private void mazenet_branches()
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

        drpBranch.Text = Session["Branch_Name"].ToString();

    }
    protected void drpBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrid();
    }
}