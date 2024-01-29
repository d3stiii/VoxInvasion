using System.Net.Sockets;
using UnityEngine;
using VoxInvasion.Runtime.Networking.Packets;
using VoxInvasion.Runtime.Networking.Packets.Entrance;
using VoxInvasion.Runtime.Services.Common;
using VoxInvasion.Runtime.Services.FatalError;
using VoxInvasion.Runtime.Services.Networking;
using VoxInvasion.Runtime.Services.StaticData;
using TcpClient = NetCoreServer.TcpClient;

namespace VoxInvasion.Runtime.Networking
{
    public class Client : TcpClient
    {
        private readonly PacketHandlerProvider _packetHandlerProvider;
        private readonly ThreadService _threadService;
        private readonly ErrorHandler _errorHandler;

        public Client(ConfigProvider configProvider, PacketHandlerProvider packetHandlerProvider,
            ThreadService threadService, ErrorHandler errorHandler) : base(
            configProvider.ServerConnectionConfig.IP, configProvider.ServerConnectionConfig.Port)
        {
            _packetHandlerProvider = packetHandlerProvider;
            _threadService = threadService;
            _errorHandler = errorHandler;
        }

        public void SendAsync(IPacket packet)
        {
            var data = packet.Serialize();
            base.SendAsync(data);
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            var packet = buffer.Deserialize(offset, size);
            var handler = _packetHandlerProvider.GetHandler(packet.Id);
            if (handler == null)
            {
                Debug.LogWarning($"No handler found for packet {packet.Id}");
                return;
            }

            _threadService.ExecuteInMainThread(() => handler.Execute(packet, this));
        }

        protected override void OnConnected()
        {
            _packetHandlerProvider.Initialize();
            Debug.Log($"Connection with server established with id {Id}");
            SendAsync(new WelcomePacket { Message = "Hello server." });
        }

        protected override void OnDisconnected()
        {
            _errorHandler.HandleError("Disconnected from server");
            Debug.Log("Connection with server closed");
        }

        protected override void OnError(SocketError error)
        {
            _errorHandler.HandleError($"Server error: {error}");
            Debug.LogError($"Client caught an error with code {error}");
        }
    }
}