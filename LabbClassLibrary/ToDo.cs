namespace LabbClassLibrary
{
    public class ToDo
    {
        public int UserId { get; init; }
        public int Id { get; init; }
        public string Title { get; init; }
        public bool Completed { get; set; }
        public ToDo(int userId, int id, string title, bool completed)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Completed = completed;
        }
    }
}
