using VoxInvasion.Runtime.Services.Common;
using VoxInvasion.Runtime.Services.UI;

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

        public void HandleError(string errorLog)
        {
            Error = errorLog; //TODO: configs with error descriptions for different languages
            _sceneLoader.Load("FatalError");
        }
    }
}