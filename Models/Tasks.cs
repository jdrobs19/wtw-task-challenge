using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wtw_task_challenge
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Due { get; set; }
    }
}