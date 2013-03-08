using System.Collections.Generic;
using QuickStart.Model;

namespace QuickStart.Repositories
{
    public interface IRepository
    {
        IEnumerable<ToDo> GetAll();
        void Insert(ToDo task);
        void Save();
    }
}
 

    