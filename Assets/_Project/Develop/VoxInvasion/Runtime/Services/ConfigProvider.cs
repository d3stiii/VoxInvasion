using VoxInvasion.Runtime.Configs;
using VoxInvasion.Runtime.Constants;
using VoxInvasion.Runtime.Services.AssetManagement;

namespace VoxInvasion.Runtime.Services
{
    public class ConfigProvider
    {
        private readonly IAssetLoader _assetLoader;
        private ScreensConfig _screensConfig;

        public ConfigProvider(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        
        public void Load()
        {
            _screensConfig = _assetLoader.Load<ScreensConfig>(AssetsPath.ScreensConfigPath);
        }

        public ScreensConfig ScreensConfig => _screensConfig;
    }
}