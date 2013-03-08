using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickStart.Model;
using QuickStart.Context;
using QuickStart.Repositories;

namespace QuickStart.Handlers
{
    public class GetHandler
    {
        private readonly IRepository _taskRepository;

        public GetHandler(IRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public DashboardViewModel Execute(DashboardRequestModel requestModel)
        {
            return new DashboardViewModel { };
        }
    }    

    public class DashboardViewModel
    {        
        public IEnumerable<ToDo> Items { get; set; }
        public string NewItem { get; set; }
        public int ItemNumber { get; set; }
        public string EditItem { get; set; }

        public DashboardViewModel()
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                var items = (from i in context.Tasks
                             select i);
                List<ToDo> temp = new List<ToDo>();
                
                foreach (Tasks listItem in items)
                {
                    int x = 0;

                    if (Int32.TryParse(listItem.ItemNumber, out x))
                        temp.Add(new ToDo(Int32.Parse(listItem.ItemNumber), listItem.ItemTask));
                    else
                        temp.Add(new ToDo(0, listItem.ItemTask));
                }

                Items = temp;
            }
        }
    }  

    public class DashboardRequestModel { }      
}

