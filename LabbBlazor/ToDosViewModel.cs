using System.Net.Sockets;
using System.Text.Json;
namespace LabbBlazor
{
    public class ToDosViewModel
    {
        public IDataAccess DataAccess { get; init; }
        public User CurrentUser { get; init; }
        public List<ToDo> CurrentUserTodos { get; private set; }
        public List<ToDo> CurrentUserTodosFiltered { get; set; }
        public bool OnlyShowIncompletedTodos { get; set; }
        public string SeachTerm { get; set; }

        private string? _todoDataErrorMessage;
        public string? TodoDataErrorMessage
        {
            get => (_todoDataErrorMessage == null) ? null : $"Could not load todo data ({_todoDataErrorMessage})";
            set => _todoDataErrorMessage = value;
        }
        public ToDosViewModel(IDataAccess dataAccess, User currentUser)
        {
            DataAccess = dataAccess;
            CurrentUser = currentUser;
            CurrentUserTodos = new List<ToDo>();
            CurrentUserTodosFiltered = new List<ToDo>();
            OnlyShowIncompletedTodos = false;
            SeachTerm = string.Empty;
        }
        public async Task SetToDoData()
        {
            try
            {
                var result = await DataAccess.GetToDosAsync();
                CurrentUserTodos = result.ToList().GetCurrentUserTodos(CurrentUser.ID);
                TodoDataErrorMessage = null;
            }
            catch (DirectoryNotFoundException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (FileNotFoundException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (IOException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (JsonException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (NotSupportedException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (SocketException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (HttpRequestException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                TodoDataErrorMessage = ex.Message;
            }
        }
        public void Filter()
        {
            Search();
            if (OnlyShowIncompletedTodos)
            {
                ShowIncompletedTodos();
            }
        }
        private void Search()
        {
            CurrentUserTodosFiltered = CurrentUserTodos.SearchTodosByTitle(SeachTerm);
        }
        private void ShowIncompletedTodos()
        {
            CurrentUserTodosFiltered = CurrentUserTodosFiltered.GetIncompletedTodos();
        }
    }
}
