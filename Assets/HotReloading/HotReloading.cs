using UnityEngine;

public sealed class HotReloading : MonoBehaviour
{
    int _x, _y;

    int X { get; set; }
    int Y { get; set; }

    (int x, int y) _t;

    void Start()
      => (_x, _y, X, Y, _t) = (1, 2, 1, 2, (1, 2));

    void Update()
      => Debug.Log($"{_x}, {_y} | {X}, {Y} | {_t.x}, {_t.y}");
}
