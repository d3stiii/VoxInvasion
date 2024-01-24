using UnityEngine;
using VoxInvasion.Runtime.Networking;

namespace VoxInvasion.Runtime.Services.Networking
{
    public class GameServerConnector : IServerConnector
    {
        private readonly PacketHandlerProvider _packetHandlerProvider;
        private readonly Client _client;

        public GameServerConnector(Client client) =>
            _client = client;

        public void Connect()
        {
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