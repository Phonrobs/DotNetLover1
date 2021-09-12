using System;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["Subject"].DefaultValue = txtSubject.Text;
        SqlDataSource1.InsertParameters["IsComplete"].DefaultValue = chkIsComplete.Checked.ToString();
        SqlDataSource1.Insert();
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["Subject"].DefaultValue = txtSubject.Text;
        SqlDataSource1.InsertParameters["IsComplete"].DefaultValue = "Can't not convert to boolean";
        SqlDataSource1.Insert();
        GridView1.DataBind();
    }
}