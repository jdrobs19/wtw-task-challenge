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
using wtw_task_challenge.utils;


namespace wtw_task_challenge.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ToDoListManager toDoListManager;

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
        toDoListManager.AddTask(task);
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