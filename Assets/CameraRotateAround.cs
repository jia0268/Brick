using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public Transform target;  // 要圍繞的物體
    public float speed = 10f; // 旋轉速度
    public float distance = 5f;  // 與物體的距離

    void Start()
    {
        // 初始時保持一定距離
        transform.position = target.position + new Vector3(0, 0, -distance);
    }

    void Update()
    {
        // 繞著 target 的 Y 軸旋轉
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        
        // 保持攝像機面向物體
        transform.LookAt(target);
    }
}
