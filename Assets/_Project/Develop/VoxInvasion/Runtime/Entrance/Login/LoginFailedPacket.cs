using ProtoBuf;
using UnityEngine;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Login
{
    [ProtoContract]
    public class LoginFailedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginFailed;
    }

    public class LoginFailedHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.LoginFailed;

        public void Execute(IPacket packet, Client client)
        {
            Debug.Log("Login failed");
        }
    }
}