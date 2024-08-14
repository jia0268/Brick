using UnityEngine;

public class PendulumRotation: MonoBehaviour
{
    public float rotationSpeed = 2f; // �\�ʳt��
    public float maxAngle = 50f; // �̤j�\�ʨ���

    private float currentAngle = 0f;
    private bool increasing = true;

    void Update()
    {
        // �p��C�@�V������q
        float deltaAngle = rotationSpeed * Time.deltaTime;

        // ��s��e����
        if (increasing)
        {
            currentAngle += deltaAngle;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle;
                increasing = false;
            }
        }
        else
        {
            currentAngle -= deltaAngle;
            if (currentAngle <= 0f)
            {
                currentAngle = 0f;
                increasing = true;
            }
        }

        // ���α���
        transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
    }
}
