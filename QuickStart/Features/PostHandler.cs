using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuCore;
using FubuMVC.Core.Ajax;
using FubuValidation;
using QuickStart.Model;
using QuickStart.Repositories;


namespace QuickStart.Features
{
    public class PostHandler
    {
        private readonly IRepository _repository;            
        
        public PostHandler(IRepository repository)
        {
            _repository = repository;            
        } 
        /*
        public AjaxContinuation Execute(TaskListModel inputModel)
        {
            var response = new AjaxContinuation { Success = true };
            var todo = new ToDo(inputModel.ItemID, inputModel.ItemTask);
                           
            _repository.Insert(todo);
            _repository.Save();

            response["todo"] = todo;
            return response;
        }
        */
        public AjaxContinuation Execute(DashboardViewModel inputModel)
        {
            int counter = 1;
            
            if(inputModel.Tasks != null)
            {
                List<string> list = (List<string>) inputModel.Tasks;
                list.Add(inputModel.Task);
                counter = list.Count;                
            }


            var response = new AjaxContinuation { Success = true };
            var todo = new ToDo(counter, inputModel.Task);
                           
            _repository.Insert(todo);
            _repository.Save();

            response["todo"] = todo;
            return response;

           // return new DashboardViewModel();
        }
         
    }

    public class DashboardViewModel
    {
        [Required]
        public string Task { get; set; }

        public DashboardViewModel()
        {
            Tasks = new List<ToDo>();
        }

        public IEnumerable<ToDo> Tasks { get; set; }

        public int TaskNumber
        {
            get;
            set;
        }
    }
               
    public interface ITasker
    {
        string AddItem(string input);
    }

    public class TaskAdder : ITasker
    {
        public string AddItem(string input)
        {
            // TODO -- wire up the actual route to take this in
            
            return "New task";
        }
    }

    public class DashboardRequestModel
    {
    }

}