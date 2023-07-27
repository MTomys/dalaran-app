using DalaranApp.Application.Bajs.Common;
using DalaranApp.Contracts.Bajs.Contacts.Responses;
using DalaranApp.Contracts.Bajs.Me;
using Mapster;

namespace DalaranApp.Api.Common.Mappings;

public class BajMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        MapBajContactToBajContactResponse(config);
    }

    private void MapBajContactToBajContactResponse(TypeAdapterConfig config)
    {
        config.NewConfig<BajContact, BajContactResponse>();
        config.NewConfig<IEnumerable<BajContact>, IEnumerable<BajContactResponse>>();
        config.NewConfig<BajMe, BajMeResponse>()
            .Map(dest => dest.Id,
                source => source.Id.ToString());
    }
}