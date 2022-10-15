using Microsoft.AspNetCore.Mvc;
using TodoList.DataBase;
using TodoList.Models;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ToDoController : Controller
    {
        private ListContext _dataBase;
        public ToDoController(ListContext database)
        {
            _dataBase = database;
        }

        [HttpPost]
        public void Add([FromBody] ListModel list)
        {
            _dataBase.Add(list);
            _dataBase.SaveChanges();
        }
        [HttpPost]
        public void Update([FromBody] ListModel list)
        {
            _dataBase.Update(list);
            _dataBase.SaveChanges();
        }
        [HttpGet]
        public IEnumerable<ListModel> GetTasks()
        {
            return _dataBase.Lists.ToList();
        }
        [HttpDelete("Id")]
        public void DeleteTask(int id)
        {
            var task = _dataBase.Lists.FirstOrDefault(x => x.Id == id);
            _dataBase.Remove(task);
        }
    }
}
