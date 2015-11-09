using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnergyOnlineBusinessLogic.Items;

namespace TestforEnergyOnline
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int EditId = 0;
        public EmployeeList el = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            el = new EmployeeList();
            if (!this.IsPostBack)
            {
                tableRefresh();
            }
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Db obj = new Db();
            GridView1.PageIndex = e.NewPageIndex;
            string sql = string.Format("Select * from Employee");
            //GridView1.DataSource = obj.fetch(sql);
            GridView1.DataSource = el.getAllEmployees();
            GridView1.DataBind();


        }

        protected void tableRefresh()
        {
           

            Db obj1 = new Db();
            //   string sql = string.Format("Select * from Employee");
            //GridView1.DataSource = obj1.fetch("Employee");
            //     GridView1.DataSource = obj1.fetch(sql);
            GridView1.DataSource = el.getAllEmployees();
            GridView1.DataBind();
        }

        protected void refresh()
        {
            txtName.Text="";
            txtJob.Text="";
            txtSalary.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void lnkEmpEdit_Click(object sender, EventArgs e)
        {
            EditId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            GridViewRow EditRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            //  TxtEmpId.Text = EditRow.Cells[0].Text;
            txtName.Text = EditRow.Cells[0].Text;
            txtJob.Text = EditRow.Cells[1].Text;
            txtSalary.Text = int.Parse(EditRow.Cells[2].Text, System.Globalization.NumberStyles.Currency).ToString();
            txtEmpNo.Value = EditId.ToString();
            Save.Visible = false;
            Update.Visible  = true;
        }

        protected void lnkEmpDelete_Click(object sender, EventArgs e)
        {
            Db obj = new Db();
            int DeleteId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string query = string.Format("delete Employee where EmpNo= {0}", DeleteId);
            if (obj.DoTransaction(query))
            {
                Response.Write("<script language='javaScript'>alert('Deleted Values Successfully');</script>");
            }
            refresh();
            tableRefresh();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            //Db obj = new Db();
            //obj.SaveEmployees(txtName.Text, txtJob.Text, txtSalary.Text);
            //Response.Write("<script>alert('Data saved successfully')</script>");
            //if (this.IsPostBack == true)
            //{
            //    refresh();

            //}
            //tableRefresh();
            el.SaveEmployee(txtName.Text, txtJob.Text, txtSalary.Text);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(txtEmpNo.Value);
            el.UpdateEmployee(txtName.Text, txtJob.Text, txtSalary.Text, empId);
        }
    }
}