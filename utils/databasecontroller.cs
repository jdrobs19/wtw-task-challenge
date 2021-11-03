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

        public void UpdateTask(Tasks updatedTask)
        {
            controller = new DatabaseController();
            controller.OpenConnection();
            controller
                .ExecuteQuery("UPDATE [dbo].[tasks] SET [title] = '" +
                updatedTask.Title +
                "', [description] = '" +
                updatedTask.Description +
                "', [status] = '" +
                updatedTask.Status +
                "', [priority] = '" +
                updatedTask.Priority +
                "', [due_date] = '" +
                updatedTask.Due +
                "' WHERE [id] = '" +
                updatedTask.Id +
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

        public List<Tasks> GetTasksByStatus(Tasks taskStatus)
        {
            List<Tasks> tasks = new List<Tasks>();
            controller = new DatabaseController();
            controller.OpenConnection();
            SqlDataReader reader =
                controller
                    .ExecuteQueryWithReturn("SELECT * FROM [dbo].[tasks] WHERE [status] = '" +
                    taskStatus.Status +
                    "'");
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

        public Tasks UpdateTaskStatus(Tasks status, Tasks id)
        {
            Tasks task = new Tasks();
            controller = new DatabaseController();
            controller.OpenConnection();
            SqlDataReader reader =
                controller
                    .ExecuteQueryWithReturn("UPDATE [dbo].[tasks] SET [status] = '" +
                    status +
                    "' WHERE [id] = '" +
                    id +
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

            // controller = new DatabaseController();
            // controller.OpenConnection();
            // controller
            //     .ExecuteQuery("UPDATE [dbo].[tasks] SET [status] = '" +
            //     status +
            //     "' WHERE [id] = '" +
            //     id +
            //     "'");
            // controller.CloseConnection();
            // return tasks;
        }
    }
}

// public class DataConn(Tasks tasks, string query)
//         {
//             string connetionString;
//             SqlConnection cnn;
//             connetionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
//             cnn = new SqlConnection(connetionString);
//             cnn.Open();
//             // add to database
//             string sql = query;
//             SqlCommand command = new SqlCommand(sql, cnn);
//             try
//                 {
//                     command.ExecuteNonQuery();
//                 }
//             catch (Exception e)
//                 {

//                 string help = "";
//                     //Error when save data
//                     //MessageBox.Show("Error to save on database");  //Error when save data
//                 }
//             cnn.Close();
//         }
// }
