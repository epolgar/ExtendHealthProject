using System.Collections.Generic;
using QuickStart.Model;

namespace QuickStart.Repositories
{
    public interface IRepository
    {
        IEnumerable<ToDo> GetAll();
        ToDo ReadTask(int taskId);
        void UpdateTask(ToDo task);
        void InsertTask(ToDo task);
        void SaveTask();
        void DeleteTask(int taskId);
    }
}
 

    