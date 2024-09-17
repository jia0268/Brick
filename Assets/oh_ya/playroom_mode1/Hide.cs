using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject celebrate; // 慶祝物件
    public AudioSource audioSource; // 音樂播放器
    private bool isHidden = false; // 追踪是否已隱藏

    void Update()
    {
        // 如果音樂播放完畢且物件還未隱藏，則隱藏物件
        if (audioSource != null && !audioSource.isPlaying && !isHidden)
        {
            HideObject();
        }
    }

    // 隱藏物件的方法
    void HideObject()
    {
        if (celebrate != null)
        {
            celebrate.SetActive(false); // 隱藏物件
            isHidden = true; // 確保只隱藏一次
        }
    }
}
