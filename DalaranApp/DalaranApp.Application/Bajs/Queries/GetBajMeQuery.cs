using DalaranApp.Application.Bajs.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMeQuery(Guid bajId) : IRequest<BajMe>;