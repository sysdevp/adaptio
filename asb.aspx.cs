using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class asb : System.Web.UI.Page
{
HttpCookie Session;


    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        if (!IsPostBack)
        {
            cls_DDL_DML cls = new cls_DDL_DML();
            cls.bizRead("spSel_BatchNo @Branch_Name='" + Session["Branch_Name"].ToString() + "'");
            drpBatchNo.Items.Clear();
            drpBatchNo.Items.Add("<-- Select -->");
            while (cls.dr.Read())
            {
                drpBatchNo.Items.Add(cls.dr[0].ToString());
            }
            cls.dr.Close();




            if (Session["Branch_Name"].ToString() == "Gandhipuram")
            {
                txtInvoiceNumber.Text = "MGA-";
            }
            else if (Session["Branch_Name"].ToString() == "Karur")
            {
                txtInvoiceNumber.Text = "MKA-";
            }
            else if (Session["Branch_Name"].ToString() == "Tanjore")
            {
                txtInvoiceNumber.Text = "MTA-";
            }
            else if (Session["Branch_Name"].ToString() == "Erode")
            {
                txtInvoiceNumber.Text = "MER-";
            }
            else if (Session["Branch_Name"].ToString() == "Palakkad")
            {
                txtInvoiceNumber.Text = "MPA-";
            }
            else if (Session["Branch_Name"].ToString() == "Velachery")
            {
                txtInvoiceNumber.Text = "MVE-";
            }
            else if (Session["Branch_Name"].ToString() == "Pollachi")
            {
                txtInvoiceNumber.Text = "MPO-";
            }

            else
            {

            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        cls.bizAdapter("spSel_InvDetail @Branch_Name='" + Session["Branch_Name"].ToString() + "',@NameMobileNumber1='" + txtNAmeMobile.Text + "'", "tbl_BatchDetails");
        gvInvoiceDetails.DataSource = cls.ds;
        gvInvoiceDetails.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        lblResult.Text = cls.bizCommand("spIns_tbl_BatchAllocation @BatchNo='" + drpBatchNo.Text + "',@Invoice_Number='" + txtInvoiceNumber.Text + "',@Branch_Name='" + Session["Branch_Name"].ToString() + "',@Batch_Allocated_By='" + Session["un"].ToString() + "',@LoginName='" + lblLoginName.Text + "'");

        cls.bizAdapter("spSel_Batch @BatchNo='" + drpBatchNo.Text + "'", "tbl_BatchAllocation");
        gvBatch.DataSource = cls.ds;
        gvBatch.DataBind();
    }
    protected void drpBatchNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();

        cls.bizRead("spSel_TrainerLoignName @BatchId='" + drpBatchNo.Text + "'");
        if (cls.dr.Read())
        {
            lblLoginName.Text = cls.dr[0].ToString();
        }
        cls.dr.Close();

        cls.bizAdapter("spSelBatches @BatchNo='" + drpBatchNo.Text + "'", "tbl_BatchDetails");
        gvDetails.DataSource = cls.ds;
        gvDetails.DataBind();

        cls.bizAdapter("spSel_Batch @BatchNo='" + drpBatchNo.Text + "'", "tbl_BatchAllocation");
        gvBatch.DataSource = cls.ds;
        gvBatch.DataBind();


    }

}