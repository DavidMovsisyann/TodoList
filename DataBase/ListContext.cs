using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.DataBase
{
    public class ListContext:DbContext
    {
        public ListContext(DbContextOptions options) : base(options) { }

        public DbSet<ListModel> Lists { get; set; }
       
    }
}
