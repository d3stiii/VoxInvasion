using System;
using VContainer;

namespace VoxInvasion.Backend.ServerCommunication
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