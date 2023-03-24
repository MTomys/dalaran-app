using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Queries;

public record GetPlebsQuery(string AdminId) : IRequest<IEnumerable<PlebRegistrationRequest>>;