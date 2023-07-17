using DalaranApp.Domain.Admins.ValueObjects;
using MediatR;

namespace DalaranApp.Application.Admins.Queries;

public record GetPlebsQuery(Guid AdminId) : IRequest<IEnumerable<PlebRegistrationRequest>>;