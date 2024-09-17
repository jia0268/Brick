using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public Transform target;  // �n��¶������
    public float speed = 10f; // ����t��
    public float distance = 5f;  // �P���骺�Z��

    void Start()
    {
        // ��l�ɫO���@�w�Z��
        transform.position = target.position + new Vector3(0, 0, -distance);
    }

    void Update()
    {
        // ¶�� target �� Y �b����
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        
        // �O���ṳ�����V����
        transform.LookAt(target);
    }
}
