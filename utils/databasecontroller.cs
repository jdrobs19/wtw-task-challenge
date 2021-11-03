using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace wtw_task_challenge.utils
{
    public class DatabaseController
    {
        private static string
            connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True";

        private SqlConnection connection;

        private SqlCommand command;

        private SqlDataReader reader;

        public DatabaseController()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void ExecuteQuery(string query)
        {
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteQueryWithReturn(string query)
        {
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            return reader;
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }

    public class ToDoListManager
    {
        private DatabaseController controller;

        public ToDoListManager()
        {
            controller = new DatabaseController();
        }

        public void DeleteTask(Tasks task)
        {
            controller = new DatabaseController();
            controller.OpenConnection();
            controller
                .ExecuteQuery("DELETE FROM [dbo].[tasks] WHERE [id] = '" +
                task.Id +
                "'");
            controller.CloseConnection();

        }
        
        public void AddTask(Tasks task)
        {
            controller = new DatabaseController();
            controller.OpenConnection();
            controller
                .ExecuteQuery("INSERT INTO [dbo].[tasks] ([title], [description], [status], [priority], [due_date]) VALUES ('" +
                task.Title +
                "','" +
                task.Description +
                "','" +
                task.Status +
                "','" +
                task.Priority +
                "','" +
                task.Due +
                "')");
            controller.CloseConnection();

        }

        public void UpdateTask(Tasks task)
        {
            controller = new DatabaseController();
            controller.OpenConnection();
            controller
                .ExecuteQuery("UPDATE [dbo].[tasks] SET [title] = '" +
                task.Title +
                "', [description] = '" +
                task.Description +
                "', [status] = '" +
                task.Status +
                "', [priority] = '" +
                task.Priority +
                "', [due_date] = '" +
                task.Due +
                "' WHERE [id] = '" +
                task.Id +
                "'");
            controller.CloseConnection();

        }

        public List<Tasks> GetTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            controller = new DatabaseController();
            controller.OpenConnection();
            SqlDataReader reader =
                controller
                    .ExecuteQueryWithReturn("SELECT * FROM [dbo].[tasks]");
            while (reader.Read())
            {
                Tasks task = new Tasks();
                task.Id = reader.GetInt32(0);
                task.Title = reader.GetString(1);
                task.Description = reader.GetString(2);
                task.Status = reader.GetString(3);
                task.Priority = reader.GetString(4);
                task.Due = reader.GetDateTime(5);
                tasks.Add (task);
            }
            controller.CloseConnection();
            return tasks;
        }

        public Tasks GetTask(Tasks task)
        {
            controller = new DatabaseController();
            controller.OpenConnection();
            SqlDataReader reader =
                controller
                    .ExecuteQueryWithReturn("SELECT * FROM [dbo].[tasks] WHERE [id] ='" +
                    task.Id +
                    "'");

            while (reader.Read())
            {
                task.Id = reader.GetInt32(0);
                task.Title = reader.GetString(1);
                task.Description = reader.GetString(2);
                task.Status = reader.GetString(3);
                task.Priority = reader.GetString(4);
                task.Due = reader.GetDateTime(5);
            }
            controller.CloseConnection();
            return task;
        }
    }
}