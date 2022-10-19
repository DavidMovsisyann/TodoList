using Microsoft.AspNetCore.Mvc;
using TodoList.DataBase;
using TodoList.Entities;
namespace TodoList.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ToDoController : Controller
    {
        private DataBaseContext _dataBase;
        public ToDoController(DataBaseContext database)
        {
            _dataBase = database;
        }

        [HttpPost]
        public void Add([FromBody] ListEntity list)
        {
            _dataBase.Add(list);
            _dataBase.SaveChanges();
        }
        [HttpPost]
        public void Update([FromBody] ListEntity list)
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
        [HttpGet]
        public IEnumerable<ListEntity> GetTasks()
        {
            return _dataBase.Lists.ToList();
        }
        [HttpDelete("Id")]
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
