using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VoxInvasion.Backend.ServerCommunication
{
    public class PacketHandlerProvider
    {
        private readonly PacketHandlerFactory _factory;
        private Dictionary<PacketId, IPacketHandler> _packetHandlers;

        public PacketHandlerProvider(PacketHandlerFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            var packetHandlerType = typeof(IPacketHandler);
            _packetHandlers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => packetHandlerType.IsAssignableFrom(type) && type != packetHandlerType)
                .Select(type => _factory.CreateHandler(type))
                .ToDictionary(handler => handler.Id, handler => handler);
            Debug.Log("Packet handlers initialized");
        }

        public IPacketHandler GetHandler(PacketId packetId) =>
            _packetHandlers.TryGetValue(packetId, out var packetHandler) ? packetHandler : null;
    }
}