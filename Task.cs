using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _2DO
{
    public enum TaskPriority
    {
        Low = 2,
        Medium = 1,
        High = 0
    }
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool TaskCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan notificationThreshold { get; set; }
        public bool notifiedOnThreshold { get; set; }
        public bool notifiedOnEndDate { get; set; }
        public TaskPriority Priority { get; set; }
        public int CategoryId { get; set; }
    }
}
