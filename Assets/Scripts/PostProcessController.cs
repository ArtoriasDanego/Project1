using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessController : MonoBehaviour
{
    public Volume volume;

    public float startIntensity = 0.2f;
    public float maxIntensity = 0.5f;
    public float maxScore = 500f;

    private Vignette vignette;

    void Start()
    {
        volume.profile.TryGet(out vignette);
    }

    void Update()
    {
        if (vignette == null) return;

        float score = GameManager.Instance.GetScore();
        float difficulty = Mathf.Clamp01(score / maxScore);

        vignette.intensity.value = Mathf.Lerp(startIntensity, maxIntensity, difficulty);
    }
}