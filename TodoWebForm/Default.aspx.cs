using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace TodoWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();

            var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO TaskItem(Subject,IsComplete) VALUES(@Subject,@IsComplete)";
            cmd.Parameters.Add(new SqlParameter("Subject", txtSubject.Text));
            cmd.Parameters.Add(new SqlParameter("IsComplete", chkIsComplete.Checked));

            try
            {
                cn.ConnectionString = "Data Source=.;Initial Catalog=ToDoDb;User ID=tododb;Password=123456";
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }

            GridView1.DataBind();
            txtSubject.Text = "";
            chkIsComplete.Checked = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var cn = new SqlConnection();
            
            var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO TaskItem(Subject,IsComplete) VALUES(@Subject,@IsComplete)";
            cmd.Parameters.Add(new SqlParameter("Subject", txtSubject.Text));
            cmd.Parameters.Add(new SqlParameter("complete", chkIsComplete.Checked));

            try
            {
                cn.ConnectionString = "Data Source=.;Initial Catalog=ToDoDb;User ID=tododb;Password=123456";
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }

            GridView1.DataBind();
            txtSubject.Text = "";
            chkIsComplete.Checked = false;
        }
    }
}