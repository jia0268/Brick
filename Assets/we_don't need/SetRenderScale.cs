using UnityEngine;
using UnityEngine.XR;

public class SetRenderScale : MonoBehaviour
{
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 0.5f; // �]�m�� 1.0�A�Y��l�ѪR��
    }
}
