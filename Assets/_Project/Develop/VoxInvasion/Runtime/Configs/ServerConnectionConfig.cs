using UnityEngine;

namespace VoxInvasion.Runtime.Configs
{
    [CreateAssetMenu(fileName = "ServerConnectionConfig", menuName = "Configs/Networking/ServerConnectionConfig")]
    public class ServerConnectionConfig : ScriptableObject
    {
        [SerializeField] private string _ip;
        [SerializeField] private ushort _port;

        public string IP => _ip;
        public ushort Port => _port;
    }
}