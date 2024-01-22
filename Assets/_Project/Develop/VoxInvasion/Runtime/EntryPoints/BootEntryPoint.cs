using UnityEngine.SceneManagement;
using VContainer.Unity;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.Networking;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class BootEntryPoint : IStartable
    {
        private readonly ConfigProvider _configProvider;
        private readonly IServerConnector _gameServerConnector;

        public BootEntryPoint(ConfigProvider configProvider, IServerConnector serverConnector)
        {
            _configProvider = configProvider;
            _gameServerConnector = serverConnector;
        }

        public void Start()
        {
            _configProvider.Load();
            _gameServerConnector.Connect("127.0.0.1", 25565);
            SceneManager.LoadScene("SampleScene");
        }
    }
}