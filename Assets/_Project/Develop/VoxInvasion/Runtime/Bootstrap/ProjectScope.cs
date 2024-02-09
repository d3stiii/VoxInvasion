using UnityEngine;
using VContainer;
using VContainer.Unity;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;
using VoxInvasion.Runtime.Entrance;
using VoxInvasion.Runtime.Utilities;
using VoxInvasion.Runtime.Utilities.UI;

namespace VoxInvasion.Runtime.Bootstrap
{
    public class ProjectScope : LifetimeScope
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIFactory>(Lifetime.Singleton);
            builder.Register<ScreenService>(Lifetime.Singleton);
            builder.Register<AssetLoader>(Lifetime.Singleton);
            builder.Register<ConfigProvider>(Lifetime.Singleton);
            builder.Register<IServerConnector, GameServerConnector>(Lifetime.Singleton);
            builder.Register<PacketHandlerProvider>(Lifetime.Singleton);
            builder.Register<PacketHandlerFactory>(Lifetime.Singleton);
            builder.Register<Client>(Lifetime.Singleton);
            builder.Register<ThreadService>(Lifetime.Singleton);
            builder.Register<AuthService>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton);
            builder.Register<ValidationService>(Lifetime.Singleton);
            builder.Register<ErrorHandler>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);
        }
    }
}