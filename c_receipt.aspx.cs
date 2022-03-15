﻿using System;
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
using System.IO;

//using System.Xml.Linq;

public partial class c_receipt : System.Web.UI.Page
{
HttpCookie Session;

    //For amount in words ---------------
    string Number;
    string deciml;
    string _number;
    string _deciml;
    string[] US = new string[1003];
    string[] SNu = new string[20];
    string[] SNt = new string[10];
    //--------------------------------

    protected void Page_Load(object sender, EventArgs e)
    {

Session = Request.Cookies["srmCookies"];
        Initialize();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        cls_DDL_DML cls = new cls_DDL_DML();
        Panel1.Visible = true;

        lblNo.Text= cls.bizCommand("sIns_cTbl_Receipt @Name='"+txtName.Text +"',@Phone='"+txtContactNumber.Text +"',@Address_='"+txtAddress.Text +"',@City='"+txtCity.Text +"',@State_='"+txtState.Text +"',@Pincode='"+txtPincode.Text +"',@Vendor='"+drpVendor.Text +"',@Exam_Code='"+txtExamCode.Text +"',@No_of_Vouchers='"+txtNoOfVouchers.Text +"',@Amount_Received='"+txtAmountReceived.Text +"',@Descriptions='"+txtAdditionalDetails.Text +"',@Details_added_by='"+Session["un"].ToString() +"',@Branch_Name='"+Session["Branch_Name"].ToString() +"'");
        lblDate.Text = System.DateTime.Now.ToString("dd / MM / yyyy");
        

        cls.bizRead("spSel_Tbl_Branch_Master_Invoice @Branch_Name='" + Session["Branch_Name"].ToString() + "'");
        while (cls.dr.Read())
        {
            lblAddress.Text = cls.dr["Branch_Address"].ToString();
            lblCity.Text = cls.dr["City"].ToString();
            lblState.Text = cls.dr["State"].ToString();
            lblPinCode.Text = cls.dr["Pincode"].ToString();
        }
        cls.dr.Close();

        lblName.Text = txtName.Text;

        if (rbtCheque.Checked == true)
        {
            lblCashCheque.Text = "Cheque";
        }
        else
        {
            lblCashCheque.Text="Cash";
        }

        lblChequeDetails.Text = txtAdditionalDetails.Text;
        lblDetails.Text = txtExamCode.Text;
        lblRs.Text = txtAmountReceived.Text;

        //For amount in words-----------------
        string currency = "Rupees ";
        string _currency = " Paise Only";
        if (Convert.ToDouble(txtAmountReceived.Text) == 0)
        {
            lblAmountInWords.Text = "Null Value";
            return;
        }
        if (Convert.ToDouble(txtAmountReceived.Text) < 0)
        {
            lblAmountInWords.Text = "Invalid Value";
            return;
        }

        if (txtAmountReceived.Text.IndexOf(".") != -1)
        {
            string[] no = txtAmountReceived.Text.Split('.');
            if ((no[0] != null) && (no[1] != "00"))
            {
                Number = no[0];
                deciml = no[1];
                _number = (NameOfNumber(Number));
                _deciml = (NameOfNumber(deciml));
                lblAmountInWords.Text = currency + _number.Trim() + " and " + _deciml.Trim() + _currency;
            }
            if ((no[0] != null) && (no[1] == "00"))
            {
                Number = no[0];
                _number = (NameOfNumber(Number));
                lblAmountInWords.Text = currency + _number + "Only";
            }
            if ((Convert.ToDouble(no[0]) == 0) && (no[1] != null))
            {
                deciml = no[1];
                _deciml = (NameOfNumber(deciml));
                txtAmountReceived.Text = _deciml + _currency;
            }
        }
        else
        {
            txtAmountReceived.Text += ".00";
            string[] no = txtAmountReceived.Text.Split('.');
            if ((no[0] != null) && (no[1] != "00"))
            {
                Number = no[0];
                deciml = no[1];
                _number = (NameOfNumber(Number));
                _deciml = (NameOfNumber(deciml));
                lblAmountInWords.Text = currency + _number.Trim() + " and " + _deciml.Trim() + _currency;
            }
            if ((no[0] != null) && (no[1] == "00"))
            {
                Number = no[0];
                _number = (NameOfNumber(Number));
                lblAmountInWords.Text = currency + _number + "Only";
            }
            if ((Convert.ToDouble(no[0]) == 0) && (no[1] != null))
            {
                deciml = no[1];
                _deciml = (NameOfNumber(deciml));
                txtAmountReceived.Text = _deciml + _currency;
            }
        }
        //-----------------------------------------
        PrintWebControl(Panel1);
    }

    //For Amount in words-------------------
    public string NameOfNumber(string Number)
    {
        string GroupName = "";
        string OutPut = "";

        if ((Number.Length % 3) != 0)
        {
            Number = Number.PadLeft((Number.Length + (3 - (Number.Length % 3))), '0');
        }
        string[] Array = new string[Number.Length / 3];
        Int16 Element = -1;
        Int32 DisplayCount = -1;
        bool LimitGroupsShowAll = false;
        int LimitGroups = 0;
        bool GroupToWords = true;
        for (Int16 Count = 0; Count <= Number.Length - 3; Count += 3)
        {
            Element += 1;
            Array[Element] = Number.Substring(Count, 3);

        }
        if (LimitGroups == 0)
        {
            LimitGroupsShowAll = true;
        }
        for (Int16 Count = 0; (Count <= ((Number.Length / 3) - 1)); Count++)
        {
            DisplayCount++;
            if (((DisplayCount < LimitGroups) || LimitGroupsShowAll))
            {
                if (Array[Count] == "000") continue;
                {
                    GroupName = US[((Number.Length / 3) - 1) - Count + 1];
                }


                if ((GroupToWords == true))
                {
                    OutPut += Group(Array[Count]).TrimEnd(' ') + " " + GroupName + " ";

                }
                else
                {
                    OutPut += Array[Count].TrimStart('0') + " " + GroupName;

                }
            }

        }
        Array = null;
        return OutPut;

    }


    private string Group(string Argument)
    {
        string Hyphen = "";
        string OutPut = "";
        Int16 d1 = Convert.ToInt16(Argument.Substring(0, 1));
        Int16 d2 = Convert.ToInt16(Argument.Substring(1, 1));
        Int16 d3 = Convert.ToInt16(Argument.Substring(2, 1));
        if ((d1 >= 1))
        {
            OutPut += SNu[d1] + " hundred ";
        }
        if ((double.Parse(Argument.Substring(1, 2)) < 20))
        {
            OutPut += SNu[Convert.ToInt16(Argument.Substring(1, 2))];
        }
        if ((double.Parse(Argument.Substring(1, 2)) >= 20))
        {
            if (Convert.ToInt16(Argument.Substring(2, 1)) == 0)
            {
                Hyphen += " ";
            }
            else
            {
                Hyphen += " ";
            }
            OutPut += SNt[d2] + Hyphen + SNu[d3];
        }
        return OutPut;
    }

    private void Initialize()
    {

        SNu[0] = "";
        SNu[1] = "One";
        SNu[2] = "Two";
        SNu[3] = "Three";
        SNu[4] = "Four";
        SNu[5] = "Five";
        SNu[6] = "Six";
        SNu[7] = "Seven";
        SNu[8] = "Eight";
        SNu[9] = "Nine";
        SNu[10] = "Ten";
        SNu[11] = "Eleven";
        SNu[12] = "Twelve";
        SNu[13] = "Thirteen";
        SNu[14] = "Fourteen";
        SNu[15] = "Fifteen";
        SNu[16] = "Sixteen";
        SNu[17] = "Seventeen";
        SNu[18] = "Eighteen";
        SNu[19] = "Nineteen";
        SNt[2] = "Twenty";
        SNt[3] = "Thirty";
        SNt[4] = "Forty";
        SNt[5] = "Fifty";
        SNt[6] = "Sixty";
        SNt[7] = "Seventy";
        SNt[8] = "Eighty";
        SNt[9] = "Ninety";
        US[1] = "";
        US[2] = "Thousand";
        US[3] = "Million";
        US[4] = "Billion";
        US[5] = "Trillion";
        US[6] = "Quadrillion";
        US[7] = "Quintillion";
        US[8] = "Sextillion";
        US[9] = "Septillion";
        US[10] = "Octillion";
    }
    //-----------------------------------------------
    //For printing------------------begin
    public static void PrintWebControl(Control ctrl)
    {
        PrintWebControl(ctrl, string.Empty);
    }

    public static void PrintWebControl(Control ctrl, string Script)
    {
        StringWriter stringWrite = new StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        if (ctrl is WebControl)
        {
            Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
        }
        Page pg = new Page();
        pg.EnableEventValidation = false;
        if (Script != string.Empty)
        {
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
        }
        HtmlForm frm = new HtmlForm();
        pg.Controls.Add(frm);
        frm.Attributes.Add("runat", "server");
        frm.Controls.Add(ctrl);
        pg.DesignerInitialize();
        pg.RenderControl(htmlWrite);
        string strHTML = stringWrite.ToString();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(strHTML);
        HttpContext.Current.Response.Write("<script>window.print();</script>");
        HttpContext.Current.Response.End();
    }
    //For printing------------------end
}
