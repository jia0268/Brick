using UnityEngine;

public class NPCMovement: MonoBehaviour
{
    public Transform[] waypoints; // �ΨӦs��Ҧ����|�I
    public float speed = 2.0f;    // NPC ���樫�t��

    private int waypointIndex = 0; // ��e�ؼи��|�I������

    void Update()
    {
        // �p�G�٦����|�I�S��F
        if (waypointIndex < waypoints.Length)
        {
            // �����e�ؼи��|�I����m
            Transform target = waypoints[waypointIndex];

            // ���� NPC �V���|�I
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // �p�G��F�F�o�Ӹ��|�I�A���ʨ�U�@��
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                waypointIndex++;
            }
        }
    }
}
