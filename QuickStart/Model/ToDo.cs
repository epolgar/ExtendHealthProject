using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickStart.Model
{
    enum PriorityLevel
    {
        Low = 0, 
        Important,
        Critical
    }

    public class ToDo
    {
        class ToDo
        {
            private string mToDoItem;
            private bool mToDoItemDone = false;
            private DateTime mDateOfCompletion;
            private PriorityLevel mPriority;

            public string ToDoItem
            {
                get
                {
                    return mToDoItem;
                }
                set
                {
                    mToDoItem = value;
                }
            }

            public bool IsCompleted
            {
                get
                {
                    return mToDoItemDone;
                }
                set
                {
                    mToDoItemDone = value;
                }
            }

            public DateTime DateOfCompletion
            {
                get
                {
                    return mDateOfCompletion;
                }
                set
                {
                    mDateOfCompletion = value;
                }
            }

            /// <summary>
            /// Priority is a prioritylist value that can be used as int if casted
            /// </summary>
            public PriorityLevel Priority
            {
                get
                {
                    return mPriority;
                }
                set
                {    
                    mPriority = value;
                }
            }
        }
    }
}