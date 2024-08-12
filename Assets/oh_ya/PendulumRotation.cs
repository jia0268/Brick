using UnityEngine;

public class PendulumRotation: MonoBehaviour
{
    public float rotationSpeed = 2f; // 擺動速度
    public float maxAngle = 50f; // 最大擺動角度

    private float currentAngle = 0f;
    private bool increasing = true;

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
