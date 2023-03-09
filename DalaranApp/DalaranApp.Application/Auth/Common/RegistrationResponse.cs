using DalaranApp.Domain.Auth.ValueObjects;

namespace DalaranApp.Application.Auth.Common;

public record RegistrationResponse(string Token, SecretPassphrase Passphrase);