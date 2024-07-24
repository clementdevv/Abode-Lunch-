using AbodeLunch.Domain.Entities;

namespace AbodeLunch.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);