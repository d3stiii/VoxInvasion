using UnityEngine;

namespace VoxInvasion.Runtime.Services.Common
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);
    }
}