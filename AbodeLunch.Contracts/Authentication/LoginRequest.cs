namespace AbodeLunch.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);