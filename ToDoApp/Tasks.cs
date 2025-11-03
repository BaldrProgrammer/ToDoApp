using System;

namespace TodoApp
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Category { get; set; }

        public Task(string description, string category = "Ogólne")
        {
            Description = description;
            CreatedDate = DateTime.Now;
            IsCompleted = false;
            Category = category;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[✓]" : "[ ]";
            return $"{status} {Description} ({Category}) - {CreatedDate:dd.MM.yyyy}";
        }
    }
}