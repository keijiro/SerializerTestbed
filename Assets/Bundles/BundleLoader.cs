using UnityEngine;

public sealed class BundleLoader : MonoBehaviour
{
    AssetBundle LoadBundle1()
    {
        var path = Application.streamingAssetsPath + "/bundle1";
        var bundle = AssetBundle.LoadFromFile(path);
        var mat = bundle.LoadAsset<Material>("Assets/Bundles/Material2.mat");
        GetComponent<MeshRenderer>().sharedMaterial = mat;
        return bundle;
    }

    AssetBundle LoadBundle2()
    {
        var path = Application.streamingAssetsPath + "/bundle2";
        return AssetBundle.LoadFromFile(path);
    }

    async void Start()
    {
        var bundle1 = LoadBundle1();
        Debug.Log("Bundle 1 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        var bundle2 = LoadBundle2();
        Debug.Log("Bundle 2 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1.Unload(true);
        bundle2.Unload(true);
        Debug.Log("Unloaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle2 = LoadBundle2();
        Debug.Log("Bundle 2 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1 = LoadBundle1();
        Debug.Log("Bundle 1 loaded");
        await Awaitable.WaitForSecondsAsync(1);

        bundle1.Unload(true);
        bundle2.Unload(true);
        Debug.Log("Unloaded");
    }
}
