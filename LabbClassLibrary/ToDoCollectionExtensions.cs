namespace LabbClassLibrary
{
    public static class ToDoCollectionExtensions
    {
        public static List<ToDo> GetCurrentUserTodos(this List<ToDo> todos, int currentUserId) => todos.Where(x => x.UserId == currentUserId).ToList();
        public static List<ToDo> GetIncompletedTodos(this List<ToDo> todos) => todos.Where(x => !x.Completed).ToList();
        public static List<ToDo> SearchTodosByTitle(this List<ToDo> todos, string searchTerm) => todos.Where(x => x.Title!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
    }
}
