namespace TodoList.Entities
{
    public class ListEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
