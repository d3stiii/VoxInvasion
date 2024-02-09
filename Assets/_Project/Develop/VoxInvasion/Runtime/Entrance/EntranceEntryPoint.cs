using VContainer.Unity;
using VoxInvasion.Runtime.Entrance.UI;
using VoxInvasion.Runtime.Utilities.UI;

namespace VoxInvasion.Runtime.Entrance
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