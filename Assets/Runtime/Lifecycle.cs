using UnityEngine;

public sealed class Lifecycle : MonoBehaviour
{
    void Awake()
      => Debug.Log("Awake");

    void Start()
      => Debug.Log("Start");

    void Update()
      => Debug.Log("Update");

    void LateUpdate()
      => Debug.Log("LateUpdate");

    void OnDestroy()
      => Debug.Log("OnDestroy");
}
