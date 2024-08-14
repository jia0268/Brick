using UnityEngine;

public class CameraMoveForward : MonoBehaviour
{
    // 調整這個變量來控制相機移動速度
    public float speed = 5f;

    void Update()
    {
        // 每一幀都讓相機按速度沿著Z軸正方向移動
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
