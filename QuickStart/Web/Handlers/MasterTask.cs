using System;
using System.Collections.Generic;
using QuickStart.Model;

namespace QuickStart.Web.Handlers.Tasks
{
    public class MasterTask
    {
    }

    public class GetHandler
    {
        public TaskListModel Execute()
        {
            return new TaskListModel();
        }
    }       

    public class CreateDropDownModel : TaskListModel
    {
        public CreateDropDownModel()
		{
            this.Status = new Dictionary<string, string>()
                {
                    { Guid.NewGuid().ToString(), "Completed" },
                    { Guid.NewGuid().ToString(), "In Progress" },
                    { Guid.NewGuid().ToString(), "Cancelled" },
                    { Guid.NewGuid().ToString(), "Pending" },
                };
		}

		public IDictionary<string, string> Status { get; private set; }
    }  

    
}

