using VoxInvasion.Runtime.Configs;
using VoxInvasion.Runtime.Constants;
using VoxInvasion.Runtime.Services.AssetManagement;

namespace VoxInvasion.Runtime.Services.StaticData
{
    public class ConfigProvider
    {
        private readonly IAssetLoader _assetLoader;
        private ScreensConfig _screensConfig;
        private ServerConnectionConfig _serverConnectionConfig;

        public ConfigProvider(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
            Load();
        }
        
        public void Load()
        {
            _screensConfig = _assetLoader.Load<ScreensConfig>(AssetsPath.ScreensConfigPath);
            _serverConnectionConfig = _assetLoader.Load<ServerConnectionConfig>(AssetsPath.ServerConnectionConfigPath);
        }

        public ScreensConfig ScreensConfig => _screensConfig;

        public ServerConnectionConfig ServerConnectionConfig => _serverConnectionConfig;
    }
}