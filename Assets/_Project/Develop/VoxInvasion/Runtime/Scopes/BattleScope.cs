using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.EntryPoints;

namespace VoxInvasion.Runtime.Scopes
{
    public class BattleScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BattleEntryPoint>();
        }
    }
}