using System.Collections;
using QuickStart.Home;
using QuickStart.Model;
using System.Collections.Generic;
using QuickStart.Handlers;

namespace QuickStart
{
	
	// Fubu's default policies look for classes suffixed with "Endpoint" or "Endpoints"
    public class HomeEndpoint
	{
        private TaskListModel _themodel;
        private static TaskViewModel taskModelList = new TaskViewModel();

        public CreateTaskInputModel Post(CreateTaskInputModel inputModel)
        {
            if (taskModelList.ListModels.Count > 0)
            {
                int numberTasks = taskModelList.ListModels[taskModelList.ListModels.Count - 1].ListOfToDoItems.Count;
                string task = inputModel.ItemTask;

                if (inputModel.Tasks == null)
                    inputModel.Tasks = new List<ToDo>();

                foreach (ToDo taskToDo in taskModelList.ListModels[taskModelList.ListModels.Count - 1].ListOfToDoItems)
                    inputModel.Tasks.Add(taskToDo);
                
                inputModel.Tasks.Add(new ToDo(numberTasks + 1, task));
                taskModelList.ListModels[taskModelList.ListModels.Count - 1].ListOfToDoItems.Add(new ToDo(numberTasks +1, task));// for the current task
                inputModel.ItemNumber = taskModelList.ListModels[taskModelList.ListModels.Count - 1].ListOfToDoItems.Count;
                
                taskModelList.ListModels[taskModelList.ListModels.Count - 1].ItemTask = inputModel.ItemTask;
            }

            return inputModel;
        }
        
        public HomeEndpoint()
        {
            if (HomeEndpoint.taskModelList.ListModels.Count == 0)
            {
                _themodel = new TaskListModel();
                _themodel.ItemID = 0;
                _themodel.ItemTask = string.Empty;
            }
            else
                _themodel = HomeEndpoint.taskModelList.ListModels[HomeEndpoint.taskModelList.ListModels.Count - 1];
            
            HomeEndpoint.taskModelList.AddTaskListModel(_themodel);
        }
        
        public TaskListModel get_start()
        {
            if (_themodel != null)
                _themodel = new TaskListModel();
            return _themodel;

            // return "Get only : /start";
        }
       
        // Fubu will use HomeEndpoint.Index as the default "home" route
        public TaskListModel Index()
		{
            _themodel = new TaskListModel();
            taskModelList.AddTaskListModel(_themodel);
            return _themodel;
		} 
        /*
        public DashboardViewModel Index()
		{
            return new DashboardViewModel();
		} */
        
	}
}