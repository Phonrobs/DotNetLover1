using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using TodoNetCore.Models;

namespace TodoNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public TaskItem[] TaskItems { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var cn = new SqlConnection();

            var cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT TaskId, Subject, IsComplete FROM TaskItem ORDER BY TaskId DESC";

            try
            {
                cn.ConnectionString = "Data Source=.;Initial Catalog=ToDoDb;User ID=tododb;Password=123456";
                cn.Open();                
                var dr = cmd.ExecuteReader();
                var taskItems = new List<TaskItem>();

                while (dr.Read())
                {
                    taskItems.Add(new TaskItem { 
                        TaskId = dr.GetInt64(0),
                        Subject = dr.GetString(1),
                        IsComplete = dr.GetBoolean(2),
                    });
                }

                dr.Close();
                TaskItems = taskItems.ToArray();
            }
            finally
            {
                cn.Close();
            }
        }

        public void OnPost(TaskItem item)
        {
            var cn = new SqlConnection();

            var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO TaskItem(Subject, IsComplete) VALUES(@Subject, @IsComplete)";

            try
            {
                cn.ConnectionString = "Data Source=.;Initial Catalog=ToDoDb;User ID=tododb;Password=123456";
                cn.Open();

                cmd.Parameters.Add(new SqlParameter("Subject", item.Subject));
                cmd.Parameters.Add(new SqlParameter("IsComplete", item.IsComplete));

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }

            OnGet();
        }

        public void OnPostWithError(TaskItem item)
        {
            var cn = new SqlConnection();

            var cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO TaskItem(Subject, IsComplete) VALUES(@Subject, @IsComplete)";

            try
            {
                cn.ConnectionString = "Data Source=.;Initial Catalog=ToDoDb;User ID=tododb;Password=123456";
                cn.Open();

                cmd.Parameters.Add(new SqlParameter("Subject", item.Subject));
                cmd.Parameters.Add(new SqlParameter("complete", item.IsComplete));

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }

            OnGet();
        }
    }
}
