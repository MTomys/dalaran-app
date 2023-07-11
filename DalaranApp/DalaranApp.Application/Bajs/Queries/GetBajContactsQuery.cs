using DalaranApp.Application.Bajs.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajContactsQuery(Guid BajId) : IRequest<IEnumerable<BajContact>>;