using System.Collections.Generic;
using UnityEngine;
using VoxInvasion.Runtime.UI.Screens;

namespace VoxInvasion.Runtime.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScreenSystem/ScreensConfig", fileName = "ScreensConfig")]
    public class ScreensConfig : ScriptableObject
    {
        [SerializeField] private List<BaseScreen> _screens;

        public List<BaseScreen> Screens => _screens;
    }
}