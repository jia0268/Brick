using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickManager : MonoBehaviour
{
    // 用於追踪當前被控制的物件
    private static GameObject _currentObject;

    public static void SetCurrentObject(GameObject newObject)
    {
        _currentObject = newObject;
    }

    public static GameObject GetCurrentObject()
    {
        return _currentObject;
    }
}
