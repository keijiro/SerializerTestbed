using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class AssetGC : MonoBehaviour
{
    async Awaitable Start()
    {
        ScriptableObject.CreateInstance<DestroyChecker>();
        await Awaitable.WaitForSecondsAsync(1);
        SceneManager.LoadScene("AssetGC2", LoadSceneMode.Additive);
        await Awaitable.WaitForSecondsAsync(1);
        SceneManager.LoadScene("AssetGC3", LoadSceneMode.Additive);
        await Awaitable.WaitForSecondsAsync(1);
        await SceneManager.UnloadSceneAsync("AssetGC2");
        await Awaitable.WaitForSecondsAsync(1);
        await SceneManager.UnloadSceneAsync("AssetGC3");
        await Awaitable.WaitForSecondsAsync(1);
        SceneManager.LoadScene("AssetGC");
    }
}
