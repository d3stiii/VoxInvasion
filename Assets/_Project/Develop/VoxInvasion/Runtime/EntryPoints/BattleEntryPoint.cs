using System;
using VContainer.Unity;
using VoxInvasion.Runtime.Services.UI;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class BattleEntryPoint : IStartable, IDisposable
    {
        private readonly UIFactory _uiFactory;

        public BattleEntryPoint(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Start()
        {
            
        }

        public void Dispose()
        {
            _uiFactory.Cleanup();
        }
    }
}