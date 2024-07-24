using AbodeLunch.Application.Authentication.Common;
using AbodeLunch.Application.Authentication.Queries.Login;
using AbodeLunch.Application.Common.Authentication;
using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Domain.Entities;
using AbodeLunch.Domain.Common.Errors;
using ErrorOr;
using MediatR;


namespace AbodeLunch.Application.Authentication.Commands.Register
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        //2. Validate the password's correct
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
        }
    }
}