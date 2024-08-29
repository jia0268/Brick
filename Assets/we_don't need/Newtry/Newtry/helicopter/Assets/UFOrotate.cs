using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOrotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // 調整這個值來改變旋轉速度

    void Update()
    {
        // 每一幀讓光繞著 y 軸旋轉
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
