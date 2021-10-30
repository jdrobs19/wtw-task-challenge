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


namespace wtw_task_challenge.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        public void DataConn(Tasks task)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost;Database=wtw_task_challenge;Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            // add to database
            string sql = "INSERT INTO [dbo].[tasks] ([title], [description], [status], [priority], [due_date]) VALUES ('" + task.Title + "','" + task.Description + "','" + task.Status + "','" + task.Priority + "','" + task.Due + "')";
            SqlCommand command = new SqlCommand(sql, cnn);
            try
                {
                    command.ExecuteNonQuery();
                }
            catch (Exception e)
                {
              
                string help = "";
                    //Error when save data
                    //MessageBox.Show("Error to save on database");  //Error when save data
                }
            cnn.Close();
        }
       

        [HttpGet]

        public IEnumerable<Tasks> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Tasks()
            {
                Title = "Test",
                Description = "This is a test",
                Priority = "Medium",
                Due = DateTime.Today
            })
            .ToArray();
        }
    //Get task with specific id
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new Tasks()
        {
            Title = "Test",
            Description = "This is a test",
            Status = "Not Started",
            Priority = "Medium",
            Due = DateTime.Today
        });
    }

    //Post
    [HttpPost]
    public IActionResult Post([FromBody] Tasks task)
    {
        //Add task to database
        DataConn(task);
        
        return Ok(
            task
        );
    }   

    //Put task with specific id
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Tasks task)
    {
        return Ok( 
        task
        );
    }

    //Delete task with specific id
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(new Tasks()
        {
            Title = "Test",
            Description = "This is a test",
            Status = "Started",
            Priority = "Medium",
            Due = DateTime.Today
        });
    }
}
}