using UnityEngine;

public sealed class LifecycleWrapper : MonoBehaviour
{
    async void Start()
    {
        await Awaitable.NextFrameAsync();
        await Awaitable.NextFrameAsync();
        await Awaitable.NextFrameAsync();
        var comp = gameObject.AddComponent<Lifecycle>();
        await Awaitable.NextFrameAsync();
        await Awaitable.NextFrameAsync();
        await Awaitable.NextFrameAsync();
        Destroy(comp);
    }
}
