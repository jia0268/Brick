using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOrotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // �վ�o�ӭȨӧ��ܱ���t��

    void Update()
    {
        // �C�@�V����¶�� y �b����
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
