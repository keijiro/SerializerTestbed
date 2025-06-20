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

        bundle1 = AssetBundle.LoadFromFile(path1);
        bundle2 = AssetBundle.LoadFromFile(path2);

        var mat1 = bundle1.LoadAsset<Material>("material");
        SetMaterial(mat1);

        Debug.Log("Bundles loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1.Unload(false);
        bundle2.Unload(false);

        Debug.Log("Bundles unloaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1 = AssetBundle.LoadFromFile(path1);
        bundle2 = AssetBundle.LoadFromFile(path2);

        var mat2 = bundle1.LoadAsset<Material>("material");
        SetMaterial(mat2);

        Debug.Log("Bundles loaded");
        await Awaitable.WaitForSecondsAsync(1);

        Debug.Log($"mat1 texture: {mat1.mainTexture.GetInstanceID()}");
        Debug.Log($"mat2 texture: {mat2.mainTexture.GetInstanceID()}");
    }
}
