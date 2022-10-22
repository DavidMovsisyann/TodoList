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
            _dataBase.Add(list);
            _dataBase.SaveChanges();
        }

        public void Update(ListEntity list)
        {
            if (list != null)
            {
                _dataBase.Update(list);
                _dataBase.SaveChanges();
            }
            else
            {
                _dataBase.Add(list);
                _dataBase.SaveChanges();
            }
        }

        public IEnumerable<ListEntity> GetTasks()
        {
            return _dataBase.Lists.ToList();
        }

        public void DeleteTask(int id)
        {
            if (id > 0)
            {
                var task = _dataBase.Lists.FirstOrDefault(x => x.Id == id);
                _dataBase.Remove(task);
            }
            else
            {
                throw new Exception("id should be positive number ");
            }
        }
    }
}
