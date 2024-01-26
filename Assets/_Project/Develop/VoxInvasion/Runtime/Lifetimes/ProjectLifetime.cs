using UnityEngine;
using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.Networking;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.AssetManagement;
using VoxInvasion.Runtime.Services.Common;
using VoxInvasion.Runtime.Services.Entrance;
using VoxInvasion.Runtime.Services.Networking;
using VoxInvasion.Runtime.Services.UI;

namespace VoxInvasion.Runtime.Lifetimes
{
    public class ProjectLifetime : LifetimeScope
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIFactory>(Lifetime.Singleton);
            builder.Register<ScreenService>(Lifetime.Singleton);
            builder.Register<IAssetLoader, AssetLoader>(Lifetime.Singleton);
            builder.Register<ConfigProvider>(Lifetime.Singleton);
            builder.Register<IServerConnector, GameServerConnector>(Lifetime.Singleton);
            builder.Register<PacketHandlerProvider>(Lifetime.Singleton);
            builder.Register<PacketHandlerFactory>(Lifetime.Singleton);
            builder.Register<Client>(Lifetime.Singleton);
            builder.Register<ThreadService>(Lifetime.Singleton);
            builder.Register<AuthService>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton);
            builder.Register<ValidationService>(Lifetime.Singleton);
        }
    }
}