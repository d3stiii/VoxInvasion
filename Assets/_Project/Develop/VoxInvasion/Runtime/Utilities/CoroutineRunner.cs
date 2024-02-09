using UnityEngine;

namespace VoxInvasion.Runtime.Utilities
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);
    }
}