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
    
    public class Repository : QuickStart.Repositories.IRepository
    {
        
        private readonly List<ToDo> _tasks = new List<ToDo>();

        public IEnumerable<ToDo> GetAll()
        {
            return _tasks;
        }

        public void Insert(ToDo task)
        {
            _tasks.Add(task);
        }

        public void Save()
        {
            //no-op
        }

        // Just here for testing since this is in-memory
        public void Clear()
        {
            _tasks.Clear();
        }
        
    }    
}
