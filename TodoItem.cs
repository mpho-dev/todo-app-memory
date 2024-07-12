using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsole
{
    internal class TodoItem
    {
        private int id;
        private string title;
        private string description;
        private bool isCompleted;

        public int Id {
            get { return id; }
            private set { id = value; } 
        }
        public string Title {
            get { return title; }
            set
            {
                if(string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentNullException("Title cannot be empty");
                }else
                {
                    title = value;
                }
            }
        }
        public string Description { 
            get { return description; }
            set { description = value; } 
        }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }
        public bool IsCompleted { 
            get { return isCompleted; }
            set { isCompleted = value; } 
        }

        public TodoItem(int id, string title, string description, bool isCompleted) 
        {
            Id = id;
            Title = title; 
            Description = description;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            IsCompleted = isCompleted;
        }

        public TodoItem(TodoItem item) { 
            this.Id = item.Id;
            this.Title = item.Title;    
            this.Description = item.Description;
            this.DateCreated = item.DateCreated;
            this.DateUpdated = item.DateUpdated;
            this.IsCompleted = item.IsCompleted;
        }

        public void Update(string title, string description, bool isComplete)
        {
            this.Title = title;
            this.Description = description;
            this.DateUpdated = DateTime.Now;
            this.IsCompleted = isComplete;
        }
    }
}
