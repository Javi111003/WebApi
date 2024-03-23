using Account.Create;

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
                .NotEmpty().WithMessage("your username is required !")
                .Must(IsAExistentedUser).WithMessage("The username is wrong,try'll again");
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please insert the password !")
                .MinimumLength(8).WithMessage("The minimun Password lentgh is 8 chars . Please check that you writed the rigth password");
        }
       private bool IsAExistentedUser(string username)
        {
            var db = new UsersContext();
            return db.Users.Any(s => s.Username == username);
        }
    }

    internal sealed class LoginResponse
    {
        public string Message { get; set; }
    }
}