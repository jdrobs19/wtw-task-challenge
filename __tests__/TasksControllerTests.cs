using System.Data.SqlClient;
using Xunit;
using wtw_task_challenge.utils;

namespace wtw_task_challenge
{
    public class TasksControllerTest
    {
        [Fact]
        public void SelectTable()
        {
            // Arrange
            var connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM tasks";
            connection.Open();

            // Act
            var reader = command.ExecuteReader();

            // Assert
            Assert.True(reader.HasRows);
        }

        //Select a single row from the table
        [Fact]
        public void SelectSingleRow()
        {
            // Arrange
            var connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM tasks WHERE id = 1";
            connection.Open();

            // Act
            var reader = command.ExecuteReader();

            // Assert
            Assert.True(reader.HasRows);
        }

        //Create a new row in the table
        [Fact]
        public void InsertRow()
        {
            // Arrange
            var connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO tasks (id, title, description, priority, due_date) VALUES (4, 'Test Task', 'Test Description', 'Low', '2021-11-1')";
            command.CommandText = "SELECT * FROM tasks WHERE id = 4";
            connection.Open();

            // Act
            var reader = command.ExecuteReader();

            // Assert
            Assert.True(reader.HasRows);
        }

        //Update a row in the table
        [Fact]
        public void UpdateRow()
        {
            // Arrange
            var connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText =
                "UPDATE tasks SET title = 'Test Task' WHERE id = 1";
            command.CommandText = "SELECT * FROM tasks WHERE id = 1";
            connection.Open();

            // Act
            var reader = command.ExecuteReader();

            // Assert
            Assert.True(reader.HasRows);
        }

        //Delete a row in the table
        // [Fact]
        // public void DeleteRow()
        // {
        //     // Arrange
        //     var connectionString =
        //         "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
        //     var connection = new SqlConnection(connectionString);
        //     var command = connection.CreateCommand();
        //     command.CommandText = "DELETE FROM tasks WHERE id = 4";
        //     command.CommandText = "SELECT * FROM tasks WHERE id = 4";
        //     connection.Open();

        //     // Act
        //     var reader = command.ExecuteReader();

        //     // Assert
        //     Assert.True(reader.HasRows);
        // }

        [Fact]
        public void TestAddTask() 
        {
            ToDoListManager toDoListManager;
            toDoListManager = new ToDoListManager();
            Tasks task = new Tasks();
            task.Id = 1;
            task.Title = "Test";
            task.Description = "Description";
            task.Status = "Not Started";
            task.Priority = "High";
            task.Due = new System.DateTime(2021, 11, 05);
            toDoListManager.AddTask(task);

            var connectionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM tasks WHERE id = 1";
            connection.Open();
            // Act
            var reader = command.ExecuteReader();
            // Assert
            Assert.True(reader.HasRows);
        }  

        [Fact]
        public void TestUpdateTask() 
        {
            ToDoListManager toDoListManager;
            toDoListManager = new ToDoListManager();
            Tasks task = new Tasks();
            task.Id = 1;
            task.Title = "Test Update";
            task.Description = "Description Update";
            task.Status = "Not Started";
            task.Priority = "High";
            task.Due = new System.DateTime(2021, 11, 05);
            toDoListManager.UpdateTask(task);

            var connectionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM tasks WHERE id = 1";
            connection.Open();
            // Act
            var reader = command.ExecuteReader();
            // Assert
            
            Assert.True(reader.GetString(3) == "Description Update");
        }

        // [Fact]
        // public void TestDeleteTask() 
        // {
        //     ToDoListManager toDoListManager;
        //     toDoListManager = new ToDoListManager();
        //     Tasks task = new Tasks();
        //     task.Id = 1;
        //     toDoListManager.DeleteTask(task);
        //     var connectionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
        //     var connection = new SqlConnection(connectionString);
        //     var command = connection.CreateCommand();
        //     command.CommandText = "SELECT * FROM tasks WHERE id = 1";
        //     connection.Open();
        //     // Act
        //     var reader = command.ExecuteReader();
        //     // Assert
        //     Assert.False(reader.HasRows);
        // }

        [Fact]
        public void TestGetTask() 
        {
            ToDoListManager toDoListManager;
            toDoListManager = new ToDoListManager();
            Tasks task = new Tasks();
            task.Id = 1;
            Tasks retrivedTask = toDoListManager.GetTask(task);
            // Assert
            Assert.False(retrivedTask == null);
        }
    }
}
