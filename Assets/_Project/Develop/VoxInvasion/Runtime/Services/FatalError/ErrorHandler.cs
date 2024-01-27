using System.Net.Sockets;
using UnityEngine.SceneManagement;
using VoxInvasion.Runtime.Services.Common;
using VoxInvasion.Runtime.Services.UI;
using VoxInvasion.Runtime.UI.FatalError;

namespace VoxInvasion.Runtime.Services.FatalError
{
    public class ErrorHandler
    {
        private readonly ScreenService _screenService;
        private readonly SceneLoader _sceneLoader;
        public string Error { get; private set; }

        public ErrorHandler(ScreenService screenService, SceneLoader sceneLoader)
        {
            _screenService = screenService;
            _sceneLoader = sceneLoader;
        }

        public void HandleServerError(SocketError error)
        {
            Error = error.ToString(); //TODO: configs with error descriptions for different languages
            _sceneLoader.Load("FatalError", () => _screenService.Show<FatalErrorScreen>());
        }
    }
}