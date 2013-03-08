using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickStart.Model;
using FubuValidation;

namespace QuickStart.Model
{
    public class TaskListModel
    {
        /// <summary>
        /// List of taks
        /// </summary>
        public List<ToDo> ListOfToDoItems { get; set; }

        /// <summary>
        /// The id of the task list
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// the actual task
        /// </summary>
        public string ItemTask { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskListModel()
        {
            ListOfToDoItems = new List<ToDo>();
            ItemID = 0;
            ItemTask = string.Empty;
        }

    }

    public class CreateTaskInputModel
    {
        [Required]
        public string ItemTask { get; set; }

        public int ItemNumber { get; set; }

        public List<ToDo> Tasks { get; set; }
    }
}