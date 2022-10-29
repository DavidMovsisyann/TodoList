using TodoList.DataBase;
using TodoList.Entities;

namespace TodoList.Repositories
{
    public class ListRepository
    {
        private readonly DataBaseContext _dataBase;
        public ListRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Add( ListEntity list)
        {
            _dataBase.Set<ListEntity>().Add(list);
            _dataBase.SaveChanges();
        }

        public void Update(ListEntity list)
        {
            if (list != null)
            {
                _dataBase.Set<ListEntity>().Update(list);
                _dataBase.SaveChanges();
            }
            else
            {
                throw new Exception("list can't be null");
            }
        }

        public List<ListEntity> GetTasks()
        {
            return _dataBase.Lists.ToList();
        }

        public void DeleteTask(int id)
        {
            if (id > 0)
            {
                var task = _dataBase.Lists.FirstOrDefault(x => x.Id == id);
                _dataBase.Set<ListEntity>().Remove(task);
            }
            else
            {
                throw new Exception("id should be positive number");
            }
        }
    }
}
