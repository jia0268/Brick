using UnityEngine;

public class NPCMovement: MonoBehaviour
{
    public Transform[] waypoints; // 用來存放所有路徑點
    public float speed = 2.0f;    // NPC 的行走速度

    private int waypointIndex = 0; // 當前目標路徑點的索引

    void Update()
    {
        // 如果還有路徑點沒到達
        if (waypointIndex < waypoints.Length)
        {
            // 獲取當前目標路徑點的位置
            Transform target = waypoints[waypointIndex];

            // 移動 NPC 向路徑點
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // 如果到達了這個路徑點，移動到下一個
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                waypointIndex++;
            }
        }
    }
}
