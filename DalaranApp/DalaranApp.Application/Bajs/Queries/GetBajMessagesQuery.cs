using System.Collections.ObjectModel;
using DalaranApp.Application.Bajs.Common;
using MediatR;

namespace DalaranApp.Application.Bajs.Queries;

public record GetBajMessagesQuery(Guid BajId, Guid ContactId) : IRequest<IOrderedEnumerable<BajMessage>>;