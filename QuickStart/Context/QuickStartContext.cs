using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickStart.Repositories;
using QuickStart.Model;

namespace QuickStart.Context
{
    public class QuickStartContext : IRepository, IDisposable
    {
        public IEnumerable<Model.ToDo> GetAll()
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                IList<QuickStart.Model.ToDo> theTasks = (IList<QuickStart.Model.ToDo>)context.Tasks;

                return theTasks;
            }           
        }

        public Model.ToDo ReadTask(int taskId)
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                IList<ToDo> tasks = (IList<QuickStart.Model.ToDo>)context.Tasks;
                
                if (tasks != null) return ((List<ToDo>)tasks).Find(x => x.Id == taskId);
            }

            return null;
        }

        public void UpdateTask(QuickStart.Model.ToDo task)
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                IList<ToDo> tasks = (IList<QuickStart.Model.ToDo>)context.Tasks;

                var item = ((List<ToDo>)tasks).Find(x => x.Id == task.Id);

                if (item != null)
                {
                    item.ItemNumber = task.ItemNumber;
                    item.ItemTask = task.ItemTask;
                }
            }
        }

        public void InsertTask(QuickStart.Model.ToDo task)
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                IList<ToDo> tasks = (IList<QuickStart.Model.ToDo>)context.Tasks;
                tasks.Add(task);
            }
        }

        public void SaveTask()
        {
            // no op
        }

        public void DeleteTask(int taskId)
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                IList<ToDo> tasks = (IList<QuickStart.Model.ToDo>)context.Tasks;

                var item = ((List<ToDo>)tasks).Find(x => x.Id == taskId);

                if (item != null)
                    tasks.Remove(item);
            }
        }

        public void Dispose()
        {
            using (TaskEntitiesContainer context = new TaskEntitiesContainer())
            {
                if(context.DatabaseExists())
                    context.DeleteDatabase();
            }
        }
    }
}