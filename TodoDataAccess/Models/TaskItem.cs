using System;

namespace TodoDataAccess.Models
{
    public class TaskItem
    {
        public long TaskId { get; set; }
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
    }
}
