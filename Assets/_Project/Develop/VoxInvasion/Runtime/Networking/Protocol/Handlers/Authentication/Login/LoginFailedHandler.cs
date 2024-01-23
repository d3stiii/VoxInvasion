using UnityEngine;
using VoxInvasion.Runtime.Networking.Protocol.Packets;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers.Authentication.Login
{
    public class LoginFailedHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.LoginFailed;

        public void Execute(IPacket packet, Client client)
        {
            Debug.Log("Login failed");
        }
    }
}