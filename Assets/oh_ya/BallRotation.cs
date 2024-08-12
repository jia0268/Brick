using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public float minSpeed = 45f; // 最小擺動速度
    public float maxSpeed = 60f; // 最大擺動速度
    public float maxAngle = 50f; // 最大擺動角度

    private float rotationSpeed;
    private float currentAngle = 0f;
    private bool increasing = true;

    void Start()
    {
        // 設置隨機旋轉速度
        rotationSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // 計算每一幀的旋轉量
        float deltaAngle = rotationSpeed * Time.deltaTime;

        // 更新當前角度
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

        // 應用旋轉
        transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
    }
}
