using VContainer;
using VContainer.Unity;

namespace VoxInvasion.Runtime.Bootstrap
{
    public class BootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootEntryPoint>();
        }
    }
}