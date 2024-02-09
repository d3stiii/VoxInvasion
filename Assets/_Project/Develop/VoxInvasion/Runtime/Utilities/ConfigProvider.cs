using VoxInvasion.Runtime.Configs;
using VoxInvasion.Runtime.Constants;

namespace VoxInvasion.Runtime.Utilities
{
    public class ConfigProvider
    {
        private readonly AssetLoader _assetLoader;

        public ConfigProvider(AssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
            Load();
        }

        public void Load()
        {
            ScreensConfig = _assetLoader.Load<ScreensConfig>(AssetsPath.ScreensConfigPath);
            ServerConnectionConfig = _assetLoader.Load<ServerConnectionConfig>(AssetsPath.ServerConnectionConfigPath);
        }

        public ScreensConfig ScreensConfig { get; private set; }

        public ServerConnectionConfig ServerConnectionConfig { get; private set; }
    }
}