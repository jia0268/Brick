using UnityEngine;

public class ControlY : MonoBehaviour
{
    public float minY = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        // 檢查並獲取Rigidbody，如果存在
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 獲取當前物件的位置
        Vector3 now = transform.position;

        // 檢查物件的Y軸是否低於minY，若低於則將Y軸值設置為minY
        if (now.y < minY)
        {
            now.y = minY;
            transform.position = now;

            // 如果有Rigidbody，並且物體受物理影響，則將其速度重置
            if (rb != null)
            {
                rb.velocity = Vector3.zero;  // 停止垂直運動
            }
        }
    }
}
