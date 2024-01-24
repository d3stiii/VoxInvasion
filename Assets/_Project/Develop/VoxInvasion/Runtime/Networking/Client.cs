using System.Net.Sockets;
using UnityEngine;
using VoxInvasion.Runtime.Networking.Packets;
using VoxInvasion.Runtime.Networking.Packets.Entrance;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.Networking;
using TcpClient = NetCoreServer.TcpClient;

namespace VoxInvasion.Runtime.Networking
{
    public class Client : TcpClient
    {
        private readonly PacketHandlerProvider _packetHandlerProvider;

        public Client(ConfigProvider configProvider, PacketHandlerProvider packetHandlerProvider) : base(
            configProvider.ServerConnectionConfig.IP, configProvider.ServerConnectionConfig.Port)
        {
            _packetHandlerProvider = packetHandlerProvider;
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

            handler.Execute(packet, this);
        }

        protected override void OnConnected()
        {
            _packetHandlerProvider.Initialize();
            Debug.Log($"Connection with server established with id {Id}");
            SendAsync(new WelcomePacket { Message = "Hello server." });
        }

        protected override void OnDisconnected()
        {
            Debug.Log("Connection with server closed");
        }

        protected override void OnError(SocketError error)
        {
            Debug.LogError($"Client caught an error with code {error}");
        }
    }
}