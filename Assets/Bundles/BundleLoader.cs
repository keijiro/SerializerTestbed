using UnityEngine;

public sealed class BundleLoader : MonoBehaviour
{
    async void Start()
    {
        var path1 = Application.streamingAssetsPath + "/bundle1";
        var path2 = Application.streamingAssetsPath + "/bundle2";

        await Awaitable.WaitForSecondsAsync(1);

        var bundle1 = AssetBundle.LoadFromFile(path1);

        var mat = bundle1.LoadAsset<Material>("Assets/Bundles/Material2.mat");
        GetComponent<MeshRenderer>().sharedMaterial = mat;

        await Awaitable.WaitForSecondsAsync(1);

        var bundle2 = AssetBundle.LoadFromFile(path2);

        await Awaitable.WaitForSecondsAsync(1);

        mat = bundle1.LoadAsset<Material>("Assets/Bundles/Material2.mat");
        GetComponent<MeshRenderer>().sharedMaterial = mat;
    }
}
