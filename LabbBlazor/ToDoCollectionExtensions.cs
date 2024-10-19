namespace LabbBlazor
{
    public static class ToDoCollectionExtensions
    {
        public static List<ToDo> GetSpecificUserTodos(this List<ToDo> allTodos, int specificUser) => allTodos.Where(x => x.UserId == specificUser).ToList();
        public static List<ToDo> GetIncompletedTodos(this List<ToDo> todos) => todos.Where(x => !x.Completed).ToList();
        public static List<ToDo> FilterTodosByTitle(this List<ToDo> todos, string searchTerm) => todos.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
    }
}
