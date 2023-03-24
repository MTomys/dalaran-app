using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Commands;

public record PlebsDecisionCommand(IEnumerable<PlebRegistrationRequest> PlebRequests) : IRequest;