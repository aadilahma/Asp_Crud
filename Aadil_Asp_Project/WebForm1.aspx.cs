using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Aadil_Asp_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-1KPUQ7T\\SQLEXPRESS01; initial catalog=aadil_db_asp; integrated security=true"); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGrid();
                BindBloodGroup();
                BindCountry();
            }
            
        }
        public void BindBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblBloodGroup", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblbg.DataValueField = "bgid";
            rblbg.DataTextField = "bgname";
            rblbg.DataSource = dt;
            rblbg.DataBind();
          
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0,new ListItem("--Select Country--", "0"));

        }

        public void ShowGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUser join tblBloodGroup on ubg=bgid join tblCountry on ucountry=cid join tblState on ustate=sid ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvuser.DataSource = dt;
            gvuser.DataBind();
          

        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (btninsert.Text == "Insert")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblUser(uname,uage,ubg,ucountry,ustate)values('" + txtname.Text + "','" + txtage.Text + "','" + rblbg.SelectedValue + "','" + ddlcountry.SelectedValue + "','" + ddlstate.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                ShowGrid();
                clear();

            }
            else if (btninsert.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tblUser set uname='" + txtname.Text + "',uage='" + txtage.Text + "', ubg='" + rblbg.SelectedValue + "', ucountry='" + ddlcountry.SelectedValue + "', ustate= '" + ddlstate.SelectedValue + "' where uid='" + ViewState["abc"] + "'  ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                ShowGrid();
                clear();

            }
           
        }
        public void clear()
        {
            txtname.Text = "";
            txtage.Text = "";
            rblbg.ClearSelection();
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            btninsert.Text = "Insert";

        }
        public void BindState()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState where cid='" + ddlcountry.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void gvuser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tbluser where uid='"+e.CommandArgument+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                ShowGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbluser where uid='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["uname"].ToString();
                txtage.Text = dt.Rows[0]["uage"].ToString();
                rblbg.SelectedValue = dt.Rows[0]["ubg"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["ucountry"].ToString();
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["ustate"].ToString();
                btninsert.Text = "Update";
                ViewState["abc"] = e.CommandArgument;

            }
        }
    }
}