using UnityEngine;
using VoxInvasion.Runtime.Networking;

namespace VoxInvasion.Runtime.Services.Networking
{
    public class GameServerConnector : IServerConnector
    {
        private readonly PacketHandlerProvider _packetHandlerProvider;
        private Client _client;

        public GameServerConnector(PacketHandlerProvider packetHandlerProvider)
        {
            _packetHandlerProvider = packetHandlerProvider;
        }
        
        public void Connect(string ip, ushort port)
        {
            _client = new Client(ip, port, _packetHandlerProvider);
            _client.ConnectAsync();
            Application.quitting += Disconnect;
        }

        public void Disconnect()
        {
            Application.quitting -= Disconnect;
            _client.Disconnect();
        }
    }
}