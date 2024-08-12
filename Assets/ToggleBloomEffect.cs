using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ToggleBloomEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Bloom bloom;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out bloom);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bloom.intensity.value = bloom.intensity.value > 0 ? 0 : 5;
        }
    }
}
