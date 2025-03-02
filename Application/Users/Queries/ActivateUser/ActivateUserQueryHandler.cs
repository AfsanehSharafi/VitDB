using MediatR;

namespace Application.Users.Queries.ActivateUser
{
    public class ActivateUserQueryHandler : IRequestHandler<ActivateUserQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ActivateUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.ActiveUserAsync(request.Code);
        }
    }

}
