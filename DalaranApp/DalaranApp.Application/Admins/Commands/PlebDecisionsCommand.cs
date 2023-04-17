using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public record PlebDecisionsCommand(IEnumerable<Decision> Decisions) : IRequest;