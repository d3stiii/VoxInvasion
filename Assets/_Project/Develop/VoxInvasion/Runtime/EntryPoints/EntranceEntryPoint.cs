using VContainer.Unity;
using VoxInvasion.Runtime.Services.UI;
using VoxInvasion.Runtime.UI.Entrance;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class EntranceEntryPoint : IStartable
    {
        private readonly ScreenService _screenService;

        public EntranceEntryPoint(ScreenService screenService)
        {
            _screenService = screenService;
        }
        
        public void Start()
        {
            _screenService.Show<LoginScreen>();
        }
    }
}