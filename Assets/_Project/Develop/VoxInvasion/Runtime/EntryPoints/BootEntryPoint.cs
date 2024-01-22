using UnityEngine.SceneManagement;
using VContainer.Unity;
using VoxInvasion.Runtime.Networking;
using VoxInvasion.Runtime.Services.Networking;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class BootEntryPoint : IStartable
    {
        private readonly Client _client;
        private readonly IServerConnector _serverConnector;

        public BootEntryPoint(IServerConnector serverConnector)
        {
            _serverConnector = serverConnector;
        }

        public void Start()
        {
            _serverConnector.Connect();
            SceneManager.LoadScene("SampleScene");
        }
    }
}