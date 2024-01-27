using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.EntryPoints;

namespace VoxInvasion.Runtime.Scopes
{
    public class BootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootEntryPoint>();
        }
    }
}