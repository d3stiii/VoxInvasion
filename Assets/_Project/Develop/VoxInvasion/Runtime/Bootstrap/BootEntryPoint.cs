using VContainer.Unity;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Runtime.Utilities;

namespace VoxInvasion.Runtime.Bootstrap
{
    public class BootEntryPoint : IStartable
    {
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
        }
    }
}