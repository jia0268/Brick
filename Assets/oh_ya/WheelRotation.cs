using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // �վ�o�ӭȨӧ��ܱ���t��

    void Update()
    {
        // �C�@�V�����l¶�� Z �b����
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
