using DalaranApp.Contracts.Messaging;
using Mapster;

namespace DalaranApp.Api.Common.Mappings;

public class HubMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        MapSendMessageParamsToReceiveMessageParams(config);
    }

    private void MapSendMessageParamsToReceiveMessageParams(TypeAdapterConfig config)
    {
        config.NewConfig<SendMessageParams, ReceiveMessageParams>()
            .Map(dest => dest.Timestamp,
                _ => DateTime.Now);
    }
}