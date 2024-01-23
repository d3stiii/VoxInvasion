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
        private readonly ThreadService _threadService;

        public BootEntryPoint(IServerConnector serverConnector, ThreadService threadService)
        {
            _serverConnector = serverConnector;
            _threadService = threadService;
        }

        public void Start()
        {
            _threadService.Initialize();
            _serverConnector.Connect();
            SceneManager.LoadScene("SampleScene");
        }
    }
}