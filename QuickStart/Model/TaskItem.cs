using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickStart.Model
{
    public class TaskList
    {       
            /// <summary>
            /// List of taks
            /// </summary>
           static private List<ToDo> ToDoList;

            /// <summary>
            /// The id of the task list
            /// </summary>
            public int ItemID
            {
                get; set;
            }

            /// <summary>
            /// Default constructor
            /// </summary>
            public TaskList(IEnumerable<ToDo> list, int ID)
            {
                ToDoList = new List<ToDo>();

                if (list != null && list is List<ToDo>)
                    ToDoList = (List<ToDo>) list;

                ItemID = ID;
            } 

            public void AddTask(ToDo theTask)
            {
                ToDoList.Add(theTask); 
            }
            
            public void DeleteTask(ToDo theTask)
            {
                if (ToDoList.Contains(theTask))
                    ToDoList.Remove(theTask);
            }

            public ToDo EditTask(ToDo theTask)
            {
                foreach (ToDo item in ToDoList)
                {
                    if (item.ItemNumber.Equals(theTask.ItemNumber))
                    {
                        item.ItemTask = theTask.ItemTask;
                        return item;
                    }
                }

                return new ToDo(theTask.ItemNumber, theTask.ItemTask);
            }        
    }
}