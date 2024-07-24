using AbodeLunch.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace AbodeLunch.Application.Authentication.Queries.Login;

public record LoginQuery(
string Email,
string Password
) : IRequest<ErrorOr<AuthenticationResult>>;

