using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.Services.AssetManagement;

namespace VoxInvasion.Runtime.Lifetimes
{
    public class ProjectLifetime : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IAssetLoader, AssetLoader>(Lifetime.Singleton);
        }
    }
}