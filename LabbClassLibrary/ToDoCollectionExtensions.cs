namespace LabbClassLibrary
{
    internal static class ToDoCollectionExtensions
    {
        internal static List<ToDo> GetCurrentUserTodos(this List<ToDo> todos, int currentUserId) => todos.Where(x => x.UserId == currentUserId).ToList();
        internal static List<ToDo> GetIncompletedTodos(this List<ToDo> todos) => todos.Where(x => !x.Completed).ToList();
        internal static List<ToDo> SearchTodosByTitle(this List<ToDo> todos, string searchTerm) => todos.Where(x => x.Title!.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
    }
}
