using UnityEngine;

public sealed class PrintInstanceID : MonoBehaviour
{
    void Update()
      => Debug.Log($"InstanceID = {GetComponent<MeshFilter>().sharedMesh.GetInstanceID()}");
}
