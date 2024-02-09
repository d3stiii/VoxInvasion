using VoxInvasion.Runtime.Lobby;
using VoxInvasion.Runtime.Utilities.UI;

namespace VoxInvasion.Runtime.Utilities
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

        public void HandleError(string errorLog)
        {
            Error = errorLog; //TODO: configs with error descriptions for different languages
            _sceneLoader.Load("FatalError", () => _screenService.Show<FatalErrorScreen>());
        }
    }
}