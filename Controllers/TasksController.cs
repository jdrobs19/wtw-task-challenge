using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wtw_task_challenge.utils;

namespace wtw_task_challenge.Controllers
{
    // [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ToDoListManager toDoListManager;

        //get all tasks
        [HttpGet]
        public IEnumerable<Tasks> Get()
        {
            toDoListManager = new ToDoListManager();
            return (IEnumerable<Tasks>)toDoListManager.GetTasks();
        }


        // Get task with specific id
        [HttpGet("id")]
        public IEnumerable<Tasks> GetTask(Tasks id)
        {
            toDoListManager = new ToDoListManager();
            return (IEnumerable<Tasks>)toDoListManager.GetTask(id);
        }

        //Get task with specific status
        [HttpGet("status/{status}")]
        public IEnumerable<Tasks> GetTasksByStatus(Tasks status)
        {
            toDoListManager = new ToDoListManager();
            return (IEnumerable<Tasks>)toDoListManager.GetTasksByStatus(status);
        }

        //Post
        [HttpPost]
        public void AddTask([FromBody] Tasks task)
        {
            //Add task to database
            toDoListManager = new ToDoListManager();
            toDoListManager.AddTask(task);
        }

        // Put task with specific id
        [HttpPut("id")]
        public void Put(Tasks id, [FromBody] Tasks task)
        {
            //Update task in database
            toDoListManager = new ToDoListManager();
            toDoListManager.UpdateTask(id, task);

        }

        //Delete task with specific id
        [HttpDelete("id")]
        public void Delete(Tasks id)
        {
            //Delete task from database
            toDoListManager = new ToDoListManager();
            toDoListManager.DeleteTask(id);
        }
    }
}
