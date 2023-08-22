using UnityEngine.SceneManagement;
using VContainer.Unity;
using VoxInvasion.Runtime.Services;

namespace VoxInvasion.Runtime.EntryPoints
{
    public class BootEntryPoint : IStartable
    {
        private readonly ConfigProvider _configProvider;

        public BootEntryPoint(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public void Start()
        {
            _configProvider.Load();

            SceneManager.LoadScene("SampleScene");
        }
    }
}