using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TodoDataAccess.Models;

namespace TodoDataAccess.Data
{
    public class DataAccess : IDisposable
    {
        private SqlConnection _cn;

        public DataAccess()
        {
            _cn = new SqlConnection("Server=.;Database=ToDoDb;Trusted_Connection=True;");
        }

        private void Open()
        {
            if (_cn.State != System.Data.ConnectionState.Open)
            {
                _cn.Open();
            }
        }

        private SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            var cmd = _cn.CreateCommand();
            cmd.CommandText = sql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            Open();

            return cmd.ExecuteReader();
        }

        private void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            var cmd = _cn.CreateCommand();
            cmd.CommandText = sql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            Open();

            cmd.ExecuteNonQuery();
        }

        private object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            var cmd = _cn.CreateCommand();
            cmd.CommandText = sql;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            Open();

            return cmd.ExecuteScalar();
        }

        public TaskItem[] GetTaskItems()
        {
            var dr = ExecuteReader("SELECT TaskId, Subject, IsComplete FROM TaskItem ORDER BY TaskId DESC");
            var items = new List<TaskItem>();

            while (dr.Read())
            {
                var taskItem = new TaskItem
                {
                    TaskId = dr.GetInt64(0),
                    Subject = dr.GetString(1),
                    IsComplete = dr.GetBoolean(5)
                };

                items.Add(taskItem);
            }

            dr.Close();

            return items.ToArray();
        }

        public TaskItem GetTaskItem(long id)
        {
            var dr = ExecuteReader("SELECT TaskId, Subject, IsComplete FROM TaskItem WHERE CategoryId=@categoryId", new SqlParameter("taskId", id));
            var taskItem = new TaskItem();

            if (dr.Read())
            {
                taskItem.TaskId = dr.GetInt64(0);
                taskItem.Subject = dr.GetString(1);
                taskItem.IsComplete = dr.GetBoolean(5);
            }

            dr.Close();

            return taskItem;
        }

        public TaskItem CreateTaskItem(TaskItem taskItem)
        {
            var subject = new SqlParameter("subject", taskItem.Subject);
            var isComplete = new SqlParameter("isComplete", taskItem.IsComplete);

            ExecuteNonQuery("INSERT INTO TaskItem(Subject, IsComplete) VALUES(@subject, @isComplete)", subject, isComplete);

            taskItem.TaskId = (long)ExecuteScalar("SELECT @@IDENTITY");

            return taskItem;
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            var taskId = new SqlParameter("taskId", taskItem.TaskId);
            var subject = new SqlParameter("subject", taskItem.Subject);
            var isComplete = new SqlParameter("isComplete", taskItem.IsComplete);

            ExecuteNonQuery("UPDATE TaskItem SET Subject=@subject, IsComplete=@isComplete WHERE TaskId=@taskId", subject, isComplete, taskId);
        }

        public void DeleteTaskItem(long id)
        {
            var taskId = new SqlParameter("taskId", id);

            ExecuteNonQuery("DELETE FROM TaskItem WHERE TaskId=@taskId", taskId);
        }

        public void Dispose()
        {
            if (_cn.State != System.Data.ConnectionState.Closed)
            {
                _cn.Close();
            }
        }
    }
}
