using CodeBase.EntryPoints;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Lifetimes
{
    public class BattleLifetime : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BattleEntryPoint>();
        }
    }
}