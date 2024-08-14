using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public float minSpeed = 45f; // �̤p�\�ʳt��
    public float maxSpeed = 60f; // �̤j�\�ʳt��
    public float maxAngle = 50f; // �̤j�\�ʨ���

    private float rotationSpeed;
    private float currentAngle = 0f;
    private bool increasing = true;

    void Start()
    {
        // �]�m�H������t��
        rotationSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

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
