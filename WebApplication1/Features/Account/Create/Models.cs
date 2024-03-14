namespace Account.Create
{
    public class Request
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("your name is requiered!")
                .MinimumLength(3).WithMessage("name is too short!")
                .MaximumLength(25).WithMessage("name is too large!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("your email address is requiered!")
                .EmailAddress().WithMessage("these email address is invalid !Please try´ll write it again");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("yor username is requeired!")
                .MinimumLength(3).WithMessage("username is too short!")
                .MaximumLength(15).WithMessage("username is too long!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("you need to insert your password to sign up!")
                .MinimumLength(8).WithMessage("The minimun characters needed are 8 chars")
                .MaximumLength(25).WithMessage("password is too long!");
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("your age is requiered!")
                .LessThan(120).WithMessage("please , insert your real age")
                .GreaterThan(0).WithMessage("please , insert your real age");
        }
    }

    internal sealed class Response
    {
        public string Message { get; set; }
        public bool Isover18 { get; set; }
    }
}