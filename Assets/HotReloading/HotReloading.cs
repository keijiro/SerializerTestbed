using UnityEngine;

public sealed class HotReloading : MonoBehaviour
{
    int _x, _y;

    int X { get; set; }
    int Y { get; set; }

    (int x, int y) _t;

    Object _obj;

    static Object _obj2;

    void Start()
    {
        (_x, _y, X, Y, _t) = (1, 2, 1, 2, (1, 2));
        _obj = ScriptableObject.CreateInstance<DestroyChecker>();
        _obj2 = ScriptableObject.CreateInstance<DestroyChecker>();
    }

    void Update()
      => Debug.Log($"{_x}, {_y} | {X}, {Y} | {_t.x}, {_t.y} | {_obj}, {_obj2}");
}
