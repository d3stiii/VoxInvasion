using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.AssetManagement;
using VoxInvasion.Runtime.Services.Networking;
using VoxInvasion.Runtime.Services.UI;

namespace VoxInvasion.Runtime.Lifetimes
{
    public class ProjectLifetime : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIFactory>(Lifetime.Singleton);
            builder.Register<ScreenService>(Lifetime.Singleton);
            builder.Register<IAssetLoader, AssetLoader>(Lifetime.Singleton);
            builder.Register<ConfigProvider>(Lifetime.Singleton);
            builder.Register<IServerConnector, GameServerConnector>(Lifetime.Singleton);
            builder.Register<PacketHandlerProvider>(Lifetime.Singleton);
        }
    }
}