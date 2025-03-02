using MediatR;

namespace Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
    }

}
