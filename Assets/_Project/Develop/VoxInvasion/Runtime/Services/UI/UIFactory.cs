using UnityEngine;
using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.Services.StaticData;
using VoxInvasion.Runtime.UI;

namespace VoxInvasion.Runtime.Services.UI
{
    public class UIFactory
    {
        private readonly IObjectResolver _container;
        private readonly ConfigProvider _configProvider;
        private Transform _uiRoot;

        public UIFactory(IObjectResolver container, ConfigProvider configProvider)
        {
            _container = container;
            _configProvider = configProvider;
        }

        public TScreen CreateScreen<TScreen>() where TScreen : BaseScreen
        {
            if (_uiRoot == null)
            {
                _uiRoot = Object.Instantiate(_configProvider.ScreensConfig.UIRootPrefab);
            }

            var screenPrefab = _configProvider.ScreensConfig.GetScreen<TScreen>();
            return _container.Instantiate(screenPrefab, _uiRoot);
        }
    }
}