namespace AbodeLunch.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);