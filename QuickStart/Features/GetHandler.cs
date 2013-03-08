using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickStart.Model;

namespace QuickStart.Features
{
    public class GetHandler
    {
        public TaskListModel Execute(TaskListModel requestModel)
        {
            return new TaskListModel();
        }
    }        
}

