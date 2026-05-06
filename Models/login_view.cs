using System.ComponentModel.DataAnnotations;

namespace AbSense.Models
{
    /// <summary>
    /// Combined ViewModel for the Login page — holds both sub-models
    /// so a single @model works for both the Sign In and Register tabs.
    /// </summary>
    public class LoginPageViewModel
    {
        public LoginModel Login { get; set; } = new();
        public RegisterModel Register { get; set; } = new();
    }

    // ─────────────────────────────────────────────
    //  SIGN IN
    // ─────────────────────────────────────────────
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    // ─────────────────────────────────────────────
    //  REGISTER
    // ─────────────────────────────────────────────
    public class RegisterModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[^@\s]+@specsavers\.com$",
            ErrorMessage = "Registration requires a valid @specsavers.com email address.")]
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 8,
            ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; } = string.Empty;

        public bool AcceptedTerms { get; set; }
    }
}
