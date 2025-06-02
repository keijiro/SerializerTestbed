using UnityEngine;

public sealed class DestroyChecker : ScriptableObject
{
    void OnDisable()
      => Debug.Log($"Disabled: {GetInstanceID()}");
}
