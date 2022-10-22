using Microsoft.AspNetCore.Mvc;
using TodoList.DataBase;
using TodoList.Entities;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ToDoController : Controller
    {
        private DataBaseContext _dataBase;
        private ListRepository _listRepository;
        public ToDoController(DataBaseContext database,ListRepository listRepository)
        {
            _dataBase = database;
            _listRepository = listRepository;
        }

        [HttpPost]
        public void Add([FromBody] ListEntity list)
        {
           _listRepository.Add(list);
        }
        [HttpPost]
        public void Update([FromBody] ListEntity list)
        {
            _listRepository.Update(list);
        }
        [HttpGet]
        public IEnumerable<ListEntity> GetTasks()
        {
            return _listRepository.GetTasks();
        }

        [HttpDelete("Id")]
        public void DeleteTask(int id)
        {
            _listRepository.DeleteTask(id);
        }
    }
}
