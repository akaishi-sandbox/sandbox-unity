using MessagePack;
using UniRx;
using System;

namespace MagicOnion.Server.EmbeddedServices
{
    public interface IMagicOnionEmbeddedHeartbeat : IService<IMagicOnionEmbeddedHeartbeat>
    {
        IObservable<DuplexStreamingResult<Nil, Nil>> Connect();
    }
}
