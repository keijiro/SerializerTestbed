using UnityEngine;

public sealed class Callback : MonoBehaviour, ISerializationCallbackReceiver
{
    static bool _started;

    public void OnBeforeSerialize()
      => Debug.Log("BeforeSerialize");

    public void OnAfterDeserialize()
      => Debug.Log("AfterDeserialize");

    async void Start()
    {
        if (_started) return;
        _started = true;

        await Awaitable.WaitForSecondsAsync(1);

        Instantiate(gameObject);
        Debug.Log("Instantiate");

        await Awaitable.WaitForSecondsAsync(1);

        await Resources.UnloadUnusedAssets();
        Debug.Log("Asset GC");
    }
}
