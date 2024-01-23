using UnityEngine;
using VoxInvasion.Runtime.Networking.Protocol.Packets;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers.Authentication.Registration
{
    public class RegistrationFailedHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.RegistrationFailed;

        public void Execute(IPacket packet, Client client)
        {
            Debug.Log("Registration failed");
        }
    }
}