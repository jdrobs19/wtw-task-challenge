using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wtw_task_challenge.utils{

    public class DatabaseController{
        private static string connectionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public DatabaseController(){
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection(){
            connection.Open();
        }

        public void CloseConnection(){
            connection.Close();
        }

        public void ExecuteQuery(string query){
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteQueryWithReturn(string query){
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            return reader;
        }
    }

    public class ToDoListManager{
        private DatabaseController controller;

        public void AddTask(Tasks task){
            controller = new DatabaseController();
            controller.OpenConnection();
            controller.ExecuteQuery("INSERT INTO [dbo].[tasks] ([title], [description], [status], [priority], [due_date]) VALUES ('" + task.Title + "','" + task.Description + "','" + task.Status + "','" + task.Priority + "','" + task.Due + "')");
            controller.CloseConnection();
        }

        public void DeleteTask(Tasks task){
            controller = new DatabaseController();
            controller.OpenConnection();
            controller.ExecuteQuery("DELETE FROM [dbo].[tasks] WHERE [id] = '" + task.Id + "'");
            controller.CloseConnection();
        }

        public void UpdateTask(Tasks task){
            controller = new DatabaseController();
            controller.OpenConnection();
            controller.ExecuteQuery("UPDATE [dbo].[tasks] SET [title] = '" + task.Title + "', [description] = '" + task.Description + "', [status] = '" + task.Status + "', [priority] = '" + task.Priority + "', [due_date] = '" + task.Due + "' WHERE [id] = '" + task.Id + "'");
            controller.CloseConnection();
    }

        public List<Tasks> GetTasks(){
            List<Tasks> tasks = new List<Tasks>();
            controller = new DatabaseController();
            controller.OpenConnection();
            MySqlDataReader reader = controller.ExecuteQueryWithReturn("SELECT * FROM [dbo].[tasks]");
            while(reader.Read()){
                Tasks task = new Tasks();
                task.Id = reader.GetInt32(0);
                task.Title = reader.GetString(1);
                task.Description = reader.GetString(2);
                task.Status = reader.GetString(3);
                task.Priority = reader.GetString(4);
                task.Due = reader.GetString(5);
                tasks.Add(task);
            }
            controller.CloseConnection();
            return tasks;
}

        public List<Tasks> GetTasksByStatus(string status){
            List<Tasks> tasks = new List<Tasks>();
            controller = new DatabaseController();
            controller.OpenConnection();
            MySqlDataReader reader = controller.ExecuteQueryWithReturn("SELECT * FROM [dbo].[tasks] WHERE [status] = '" + status + "'");
            while(reader.Read()){
                Tasks task = new Tasks();
                task.Id = reader.GetInt32(0);
                task.Title = reader.GetString(1);
                task.Description = reader.GetString(2);
                task.Status = reader.GetString(3);
                task.Priority = reader.GetString(4);
                task.Due = reader.GetString(5);
                tasks.Add(task);
            }
            controller.CloseConnection();
            return tasks;
        }

        public void UpdateTaskStatus(string status, string id){
            controller = new DatabaseController();
            controller.OpenConnection();
            controller.ExecuteQuery("UPDATE [dbo].[tasks] SET [status] = '" + status + "' WHERE [id] = '" + id + "'");
            controller.CloseConnection();
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
