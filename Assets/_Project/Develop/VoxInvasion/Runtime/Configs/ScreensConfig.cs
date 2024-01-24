using System;
using System.Collections.Generic;
using UnityEngine;
using VoxInvasion.Runtime.UI;

namespace VoxInvasion.Runtime.Configs
{
    [CreateAssetMenu(menuName = "Configs/ScreenSystem/ScreensConfig", fileName = "ScreensConfig")]
    public class ScreensConfig : ScriptableObject
    {
        [SerializeField] private Transform _uiRootPrefab;
        [SerializeField] private List<BaseScreen> _screens;

        public Transform UIRootPrefab => _uiRootPrefab;

        public TScreen GetScreen<TScreen>() where TScreen : BaseScreen
        {
            foreach (var baseScreen in _screens)
                if (baseScreen is TScreen screen)
                    return screen;

            throw new IndexOutOfRangeException($"Can't find screen of type {typeof(TScreen)}");
        }
    }
}