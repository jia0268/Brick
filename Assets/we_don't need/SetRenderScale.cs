using UnityEngine;
using UnityEngine.XR;

public class SetRenderScale : MonoBehaviour
{
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 0.5f; // 設置為 1.0，即原始解析度
    }
}
