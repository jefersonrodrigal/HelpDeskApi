namespace HelpDeskApi.ViewModel
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserProfile {  get; set; } = string.Empty;
    }
}
