using VContainer;
using VContainer.Unity;

namespace VoxInvasion.Runtime.Battle
{
    public class BattleScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BattleEntryPoint>();
        }
    }
}