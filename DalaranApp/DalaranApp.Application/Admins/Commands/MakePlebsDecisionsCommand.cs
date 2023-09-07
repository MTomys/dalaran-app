using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public record MakePlebsDecisionsCommand(IEnumerable<Decision> Decisions) : IRequest;