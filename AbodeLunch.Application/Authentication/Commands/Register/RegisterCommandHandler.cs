using AbodeLunch.Application.Authentication.Common;
using AbodeLunch.Application.Common.Authentication;
using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Common.Errors; // Add this line to include the Errors class
using AbodeLunch.Domain.Entities;
using ErrorOr;
using MediatR;


namespace AbodeLunch.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1.validate the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            //2.create user (generate unique ID) and persist to DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);
            //3.create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}