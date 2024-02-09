using VContainer;
using VContainer.Unity;

namespace VoxInvasion.Runtime.Entrance
{
    public class EntranceScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntranceEntryPoint>();
        }
    }
}