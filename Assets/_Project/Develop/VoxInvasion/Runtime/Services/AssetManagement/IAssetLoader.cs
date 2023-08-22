using UnityEngine;

namespace VoxInvasion.Runtime.Services.AssetManagement
{
    public interface IAssetLoader
    {
        TAsset Load<TAsset>(string path) where TAsset : Object;
        TAsset[] LoadAll<TAsset>(string path) where TAsset : Object;
    }
}