using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
namespace LabbClassLibrary
{
    public class ToDosViewModel : ViewModel
    {
        public IDataAccess DataAccess { get; init; }
        public List<ToDo> Todos { get; private set; }
        public List<ToDo> CurrentUserTodos { get; private set; }

        private List<ToDo> _currentUserTodosFiltered;
        public List<ToDo> CurrentUserTodosFiltered 
        {
            get { return _currentUserTodosFiltered; }
            set
            {
                _currentUserTodosFiltered = value;
                OnPropertyChanged(nameof(CurrentUserTodosFiltered)); 
            }
        }
        public bool OnlyShowIncompletedTodos { get; set; }
        public string SeachTerm { get; set; }

        private string? _todoDataErrorMessage;
        public string? TodoDataErrorMessage
        {
            get => (_todoDataErrorMessage == null) ? null : $"Could not load todo data ({_todoDataErrorMessage})";
            set => _todoDataErrorMessage = value;
        }
        public ToDosViewModel(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            Todos = new List<ToDo>();
            CurrentUserTodos = new List<ToDo>();
            _currentUserTodosFiltered = new List<ToDo>();
            OnlyShowIncompletedTodos = false;
            SeachTerm = string.Empty;
        }
        public void SetCurrentUserTodos(User currentUser)
        {
            CurrentUserTodos = Todos.GetCurrentUserTodos(currentUser.ID);
        }
        public async Task SetToDoDataAsync()
        {
            try
            {
                var result = await DataAccess.GetToDosAsync();
                Todos = result.ToList();
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
