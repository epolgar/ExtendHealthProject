using System.Collections.Generic;
using QuickStart.Features;
using FubuMVC.Core.Ajax;
using QuickStart.Model;
using QuickStart.Repositories;

namespace QuickStart.Home
{  

    public class HomeAction
    {
        private static TaskViewModel theViewModel = new TaskViewModel();

        public TaskListModel Get()
        {
            TaskListModel theModel = new TaskListModel();
            theViewModel.AddTaskListModel(theModel);
            return theModel;
        }
        /*
        public TaskListModel Get_SomethingElse(CreateTaskInputModel taskModel)
        {
            TaskListModel theViewModel = new TaskListModel { ItemTask = taskModel.ItemTask };
            
            return theViewModel;
        }*/
    }  


    public class TaskViewModel
    {
        private List<TaskListModel> mLists = new List<TaskListModel>();
        
        public List<TaskListModel> ListModels
        {
            get
            {
                return mLists;
            }

            set
            {
                mLists = (List<TaskListModel>) value;
            }

        }

        public TaskViewModel()
        {
           
        }

        public void AddTaskListModel(TaskListModel addList)
        {
            mLists.Add(addList);
        }

        public void DeleteTaskListModel(TaskListModel deleteList)
        {
            if(mLists.Contains(deleteList))
                mLists.Remove(deleteList);
        }
    } 
} 
    
