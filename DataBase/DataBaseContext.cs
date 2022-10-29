using Microsoft.EntityFrameworkCore;
using TodoList.Entities;

namespace TodoList.DataBase
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options) :base(options)  { }

        public DbSet<ListEntity> Lists { get; set; }
       
    }
}
