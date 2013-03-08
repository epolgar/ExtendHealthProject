using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuCore;
using FubuMVC.Core.Ajax;
using FubuValidation;
using QuickStart.Model;
using QuickStart.Repositories;
using QuickStart.Context;


namespace QuickStart.Handlers
{
    public class PostHandler
    {
        private readonly IRepository _repository;            
        
        public PostHandler(IRepository repository)
        {
            _repository = repository;            
        }

        public AjaxContinuation Execute(DashboardViewModel inputModel)
        {
            var response = new AjaxContinuation { Success = true };
            
            var task = new ToDo()
            {
                ItemNumber = inputModel.ItemNumber,
                ItemTask = inputModel.NewItem                
            };

            _repository.InsertTask(task);
            _repository.SaveTask();

            response["task"] = task;
            return response;
        }
    }
}