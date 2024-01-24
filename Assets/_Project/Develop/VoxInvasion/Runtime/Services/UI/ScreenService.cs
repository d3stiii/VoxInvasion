using UnityEngine;
using VoxInvasion.Runtime.UI;

namespace VoxInvasion.Runtime.Services.UI
{
    public class ScreenService
    {
        private readonly UIFactory _uiFactory;
        private BaseScreen _currentScreen;

        public ScreenService(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public TScreen Show<TScreen>() where TScreen : BaseScreen
        {
            if (_currentScreen != null)
            {
                HideCurrentScreen();
            }

            var newScreen = _uiFactory.CreateScreen<TScreen>();
            _currentScreen = newScreen;

            return newScreen;
        }

        private void HideCurrentScreen()
        {
            Object.Destroy(_currentScreen.gameObject);
            _currentScreen = null;
        }
    }
}