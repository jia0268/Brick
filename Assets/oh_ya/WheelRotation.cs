using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // 調整這個值來改變旋轉速度

    void Update()
    {
        // 每一幀讓輪子繞著 Z 軸旋轉
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
