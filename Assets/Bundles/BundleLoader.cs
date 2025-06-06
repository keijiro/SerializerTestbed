using UnityEngine;

public sealed class BundleLoader : MonoBehaviour
{
    void SetMaterial(Material mat)
      => GetComponent<MeshRenderer>().sharedMaterial = mat;

    async void Start()
    {
        var path1 = Application.streamingAssetsPath + "/bundle1";
        var path2 = Application.streamingAssetsPath + "/bundle2";

        var bundle1 = AssetBundle.LoadFromFile(path1);
        Debug.Log("Bundle 1 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        SetMaterial(bundle1.LoadAsset<Material>("material"));
        Debug.Log("Material loaded");
        await Awaitable.WaitForSecondsAsync(1);

        var bundle2 = AssetBundle.LoadFromFile(path2);
        Debug.Log("Bundle 2 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1.Unload(true);
        bundle2.Unload(true);
        Debug.Log("Unloaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1 = AssetBundle.LoadFromFile(path1);
        Debug.Log("Bundle 1 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle2 = AssetBundle.LoadFromFile(path2);
        Debug.Log("Bundle 2 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        SetMaterial(bundle1.LoadAsset<Material>("material"));
        Debug.Log("Material loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1.Unload(true);
        bundle2.Unload(true);
        Debug.Log("Unloaded");
    }
}
