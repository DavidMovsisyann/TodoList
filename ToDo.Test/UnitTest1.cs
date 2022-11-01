using Microsoft.EntityFrameworkCore;
using TodoList.Controllers;
using TodoList.DataBase;
using TodoList.Entities;
using TodoList.Repositories;
using System.Text.Json;

namespace ToDo.Test
{
    public class Tests
    {
        private DataBaseContext _dataBase;
        private ListRepository _repository;
        [SetUp]
        public void SetUp()
        {
            var databaseName = "DataBaseContext";
            var _dbContextOptions = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName)
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .Options;
            _dataBase = new DataBaseContext(_dbContextOptions);
            _repository = new ListRepository(_dataBase);  
        }

        [Test]
        public void AddTest()
        {
            //Arrange 
            ToDoController controller = new ToDoController(_dataBase, _repository);
            ListEntity list = new ListEntity();
            ListEntity AddingInList(string name, string text)
            {
                list.Name = name;
                list.Text = text;
                list.CreatedDate = DateTime.Now;
                return list;
            }
            //Act
            controller.Add(AddingInList("Task1", "Buy meal"));
            //Assert
            Assert.IsTrue(_dataBase.Lists.FirstOrDefault() == list);
        }
        [Test]
        public void UpdateTest()
        {
            ToDoController controller = new ToDoController(_dataBase, _repository);
            ListEntity list = new ListEntity();
            ListEntity AddingInList(string name, string text)
            {
                list.Name = name;
                list.Text = text;
                list.CreatedDate = DateTime.Now;
                return list;
            }
            ListEntity ChangeListprops(string name, string text, bool isDone)
            {
                list.Name = name;
                list.Text = text;
                list.CreatedDate = DateTime.Now;
                list.UpdatedDate = DateTime.Now;
                list.IsDone = isDone;
                return list;
            }
            //Act
            controller.Add(AddingInList("Task2", "Eat"));
            var list2 = ChangeListprops("Task 2", "Eat food", true);
            controller.Update(list2);
            //Assert
            Assert.IsTrue(_dataBase.Lists.FirstOrDefault() == list2);
        }
        [Test]
        public void GetTest()
        {
            //Arrange 
            ToDoController controller = new ToDoController(_dataBase, _repository);
            ListEntity list = new ListEntity();
            ListEntity AddingInList(string name, string text)
            {
                list.Name = name;
                list.Text = text;
                list.CreatedDate = DateTime.Now;
                return list;
            }
            //Act
            controller.Add(AddingInList("Task3", "Take a shower"));
            var result = controller.GetTasks();
           
            //Assert
            Assert.IsTrue(result.Capacity == _dataBase.Lists.Count());
        }
        
        [Test]
        public void DeleteTest()
        {
            //Arrange 
            ToDoController controller = new ToDoController(_dataBase, _repository);
            ListEntity list = new ListEntity();
            ListEntity AddingInList(string name, string text)
            {
                list.Name = name;
                list.Text = text;
                list.CreatedDate = DateTime.Now;
                return list;
            }
            //Act
            controller.Add(AddingInList("Task4", "Go to bed"));
            int id =list.Id;
            controller.DeleteTask(id);
            //Assert
            Assert.IsTrue(_dataBase.Lists.FirstOrDefault().Id != id);
            
        }
    }
}