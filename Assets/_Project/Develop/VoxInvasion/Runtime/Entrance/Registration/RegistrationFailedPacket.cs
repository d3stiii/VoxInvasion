using ProtoBuf;
using UnityEngine;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Registration
{
    [ProtoContract]
    public class RegistrationFailedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.RegistrationFailed;
    }
    
    public class RegistrationFailedHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.RegistrationFailed;

        public void Execute(IPacket packet, Client client)
        {
            Debug.Log("Registration failed");
        }
    }
}