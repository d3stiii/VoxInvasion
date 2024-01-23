using System;
using VContainer;
using VoxInvasion.Runtime.Networking.Protocol.Handlers;

namespace VoxInvasion.Runtime.Services.Networking
{
    public class PacketHandlerFactory
    {
        private readonly IObjectResolver _container;

        public PacketHandlerFactory(IObjectResolver container)
        {
            _container = container;
        }

        public IPacketHandler CreateHandler(Type handlerType)
        {
            var handlerInstance = (IPacketHandler) Activator.CreateInstance(handlerType);
            _container.Inject(handlerInstance);
            return handlerInstance;
        }
    }
}