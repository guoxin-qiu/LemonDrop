namespace LemonDrop.Website.Mvc.ViewModels
{
    public class WelcomeInfoVM
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public string WelcomeMsg => $"Hello {FullName}, welcome to join us!";
        public string AccountMsg => $"Your account is {Email}";
    }
}