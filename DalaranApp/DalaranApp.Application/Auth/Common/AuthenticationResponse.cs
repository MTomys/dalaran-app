namespace DalaranApp.Application.Auth.Common;

public record AuthenticationResponse(string Username, string Token, string Role);