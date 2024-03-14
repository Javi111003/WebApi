namespace Accont.Login
{
    internal sealed class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    internal sealed class LoginValidator : Validator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("your username is required !");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please insert the password !")
                .MinimumLength(8).WithMessage("The minimun Password lentgh is 8 chars . Please check that you writed the rigth password");
        }
    }

    internal sealed class LoginResponse
    {
        public string Message { get; set; }
    }
}