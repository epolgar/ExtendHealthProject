using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickStart.Model
{
    [Serializable]
    public class TaskList
    {        
            /// <summary>
            /// List of taks
            /// </summary>
            IList<ToDo> myListOfToDoItems;

            public TaskList()
            {
                myListOfToDoItems = new List<ToDo>();
            }

            /// <summary>
            /// Changes the state of a task whoes index is passed as a parameter
            /// </summary>
            /// <param name="theIndex">Index of the task whoes state will change</param>
            public void ChangeState(int theIndex)
            {
                myListOfToDoItems[theIndex].IsCompleted = !myListOfToDoItems[theIndex].IsCompleted;
            }

            /// <summary>
            /// List of tasks
            /// </summary>
            public IList<ToDo> Tasks
            {
                get
                {
                    return myListOfToDoItems;
                }
            }

            /// <summary>
            /// Adds a new taks to the task list
            /// </summary>
            /// <param name="theTask">Task description</param>
            /// <param name="theDateOfCompletion">Date of completion of the task</param>
            /// <param name="thePriority">Priority of the new taks</param>
            public void AddTask(string theTask, DateTime theDateOfCompletion, int thePriority)
            {
                ToDo aToDo = new ToDo();
                aToDo.ToDoItem = theTask;
                aToDo.DateOfCompletion = theDateOfCompletion;
                aToDo.Priority = thePriority;
                myListOfToDoItems.Add(aToDo);
            }

            /// <summary>
            /// Deletes the selected task from the tasks list
            /// </summary>
            /// <param name="theIndex">Index of the task to be removed</param>
            public void DeleteTask(int theIndex)
            {
                myListOfToDoItems.RemoveAt(theIndex);
            }
       
    }
}