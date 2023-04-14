using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public record PlebDecisionsCommand(string IssuingAdmin, IEnumerable<Decision> Decisions) : IRequest;