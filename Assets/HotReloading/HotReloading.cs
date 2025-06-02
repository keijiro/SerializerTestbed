using UnityEngine;

public sealed class HotReloading : MonoBehaviour
{
    int _x, _y, _z;

    (int x, int y, int z) _t;

    void Start()
      => (_x, _y, _z, _t) = (1, 2, 3, (1, 2, 3));

    void Update()
      => Debug.Log($"{_x}, {_y}, {_z} | {_t.x}, {_t.y}, {_t.z}");
}
