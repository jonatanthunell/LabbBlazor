using LabbBlazor.Components.Pages;

namespace LabbBlazor
{
    public static class ToDoCollectionExtensions
    {
        public static List<ToDo> GetSpecificUserTodos(this List<ToDo> allTodos, User specificUser)
        {
            return allTodos.Where(x => x.UserId == specificUser.ID).ToList();
        }
        public static List<ToDo> GetIncompletedTodos(this List<ToDo> todos)
        {
            return todos.Where(x => !x.Completed).ToList();
        }
        public static List<ToDo> FilterTodosByTitle(this List<ToDo> todos, string searchTerm)
        {
            return todos.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower().Trim())).ToList();
        }
    }
}
