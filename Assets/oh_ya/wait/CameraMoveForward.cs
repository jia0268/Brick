using UnityEngine;

public class CameraMoveForward : MonoBehaviour
{
    // �վ�o���ܶq�ӱ���۾����ʳt��
    public float speed = 5f;

    void Update()
    {
        // �C�@�V�����۾����t�תu��Z�b����V����
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
