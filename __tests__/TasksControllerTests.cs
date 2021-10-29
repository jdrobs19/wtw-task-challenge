using System.Data.SqlClient;
using Xunit;

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
        [Fact]
        public void DeleteRow()
        {
            // Arrange
            var connectionString =
                "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            var connection = new SqlConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM tasks WHERE id = 4";
            command.CommandText = "SELECT * FROM tasks WHERE id = 4";
            connection.Open();

            // Act
            var reader = command.ExecuteReader();

            // Assert
            Assert.True(reader.HasRows);
        }
    }
}
