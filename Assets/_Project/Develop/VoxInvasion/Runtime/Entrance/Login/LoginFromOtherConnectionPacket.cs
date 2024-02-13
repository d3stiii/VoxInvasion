using ProtoBuf;
using UnityEngine;
using VContainer;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;
using VoxInvasion.Runtime.Utilities;

namespace VoxInvasion.Runtime.Entrance.Login
{
    [ProtoContract]
    public class LoginFromOtherConnectionPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginFromOtherConnection;
    }

    public class LoginFromOtherConnectionHandler : IPacketHandler
    {
        private ErrorHandler _errorHandler;
        public PacketId Id { get; } = PacketId.LoginFromOtherConnection;

        public void Execute(IPacket packet, Client client)
        {
            Debug.Log("Disconnected from server. Logged in from other client.");
            _errorHandler.HandleError("Disconnected from server. Logged in from other client.");
        }

        [Inject]
        public void Construct(ErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }
    }
}