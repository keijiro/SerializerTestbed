using UnityEngine;

public sealed class PrintInstanceID : MonoBehaviour
{
    void Update()
      => Debug.Log(GetComponent<MeshFilter>().sharedMesh.GetInstanceID());
}
