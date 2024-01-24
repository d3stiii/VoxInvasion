﻿using VContainer;
using VContainer.Unity;
using VoxInvasion.Runtime.EntryPoints;

namespace VoxInvasion.Runtime.Lifetimes
{
    public class EntranceScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntranceEntryPoint>();
        }
    }
}