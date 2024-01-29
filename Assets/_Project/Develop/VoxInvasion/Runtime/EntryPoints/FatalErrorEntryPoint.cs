using VContainer.Unity;
using VoxInvasion.Runtime.Services.UI;
using VoxInvasion.Runtime.UI.FatalError;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class FatalErrorEntryPoint : IStartable
    {
        private readonly ScreenService _screenService;

        public FatalErrorEntryPoint(ScreenService screenService) =>
            _screenService = screenService;

        public void Start() =>
            _screenService.Show<FatalErrorScreen>();
    }
}