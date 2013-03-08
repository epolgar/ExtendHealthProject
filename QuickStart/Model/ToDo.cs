using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickStart.Model
{
    public enum PriorityLevel
    {
        Low = 0,
        Important,
        Critical
    }

    public class ToDo
    {
        public int ItemNumber
        {
            get; set;            
        }

        public string ToDoItem
        {
            get; set;
        }

        protected bool IsCompleted
        {
            get; set;            
        }

        protected DateTime DateOfCompletion
        {
            get; set;
        }

        protected PriorityLevel Priority
        {
            get; set;
        }

        public ToDo(int itemNum, string itemTask)
        {
            ItemNumber = itemNum;
            ToDoItem = itemTask;
            IsCompleted = false;
            DateOfCompletion = DateTime.Now;
            Priority = PriorityLevel.Low;
        }
    }
}