using UnityEngine;

[System.Serializable]
public unsafe struct Data8
{
    public fixed byte data[8];
}

public sealed class BasicFields : MonoBehaviour
{
    [SerializeField] Data8 _data8;

    unsafe void Start()
    {
        for (var i = 0; i < 8; i++) Debug.Log(_data8.data[i]);
    }
}
