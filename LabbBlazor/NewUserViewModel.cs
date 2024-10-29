namespace LabbBlazor
{
    public class NewUserViewModel
    {
        public NewUserFormValidator NewUser { get; private set; }
        public User ValidatedUser { get; private set; }
        public bool ValidFormSubmited { get; private set; }
        public string? FormSubmitErrorMessage { get; private set; }
        public NewUserViewModel()
        {
            NewUser = new NewUserFormValidator();
            ValidatedUser = new User();
            ValidFormSubmited = false;
            FormSubmitErrorMessage = null;
        }
        public void HandleValidSubmit()
        {
            // Då NewUserFormValidator har required på alla properties förstår jag inte riktigt varför jag behöver null-hantering
            // Men visual studio säger till om man inte sätter properties som nullable
            try
            {
                ValidatedUser = NewUser.GetValidatedUser();
            }
            catch (NullReferenceException e)
            {
                FormSubmitErrorMessage = $"Error, {e.Message}, please fill out the form again";
            }
            ValidFormSubmited = true;
        }
    }
}
