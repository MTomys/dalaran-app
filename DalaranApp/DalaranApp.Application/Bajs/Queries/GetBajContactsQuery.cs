using DalaranApp.Application.Bajs.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajContactsQuery(string BajId) : IRequest<IEnumerable<BajContact>>;