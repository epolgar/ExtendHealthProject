using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using FubuCore;


namespace QuickStart.Model
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    
    public class Repository : QuickStart.Repositories.IRepository, IDisposable   {
        
        private readonly List<ToDo> _tasks = new List<ToDo>();
        
        ToDo Repositories.IRepository.ReadTask(int taskId)
        {
            foreach(ToDo task in _tasks)
                if(task.Id.Equals(taskId))
                    return task;

            return new ToDo(taskId, "") { Id = taskId };
        }

        void Repositories.IRepository.UpdateTask(ToDo task)
        {
            foreach (ToDo temptask in _tasks)
                if (temptask.Id.Equals(task.Id))
                {
                    temptask.ItemTask = task.ItemTask;
                    temptask.ItemNumber = task.ItemNumber;
                }
        }

        void Repositories.IRepository.DeleteTask(int taskId)
        {
            int index = 0;

            foreach (ToDo task in _tasks)
                if (task.Id.Equals(taskId))
                    break;
                else
                    index++;

            if (index < _tasks.Count)
                _tasks.RemoveAt(index);
        }

        IEnumerable<ToDo> Repositories.IRepository.GetAll()
        {
            return _tasks;
        }

        void Repositories.IRepository.InsertTask(ToDo task)
        {
            _tasks.Add(task);
        }

        void Repositories.IRepository.SaveTask()
        {
            //no-op
        }

        // Just here for testing since this is in-memory
        void Clear()
        {
            _tasks.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }    
}
