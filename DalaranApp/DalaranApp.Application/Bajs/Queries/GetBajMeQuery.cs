using DalaranApp.Application.Bajs.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMeQuery(Guid BajId) : IRequest<BajMe>;