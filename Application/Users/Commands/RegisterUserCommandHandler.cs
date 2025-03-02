using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.IsActive = false;
            user.Code = GenerateActivationCode(); // متد تولید کد فعال‌سازی
            return await _userRepository.AddUserAsync(user);
        }

        private string GenerateActivationCode()
        {
            // تولید کد فعال‌سازی تصادفی
            return new Random().Next(100000, 999999).ToString();
        }
    }



}
