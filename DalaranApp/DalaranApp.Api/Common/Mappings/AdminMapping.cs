using DalaranApp.Contracts.Admins.PlebRequests;
using DalaranApp.Domain.Admins.ValueObjects;
using Mapster;

namespace DalaranApp.Api.Common.Mappings;

public class AdminMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        MapPlebRegistrationRequestToPlebRequestResponse(config);
    }

    private void MapPlebRegistrationRequestToPlebRequestResponse(TypeAdapterConfig config)
    {
        config.NewConfig<PlebRegistrationRequest, GetPlebRequestResponse>()
            .Map(dest => dest.PlebId,
                src => src.PlebId.ToString());
    }
}