using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteApplier : MonoBehaviour
{
    public float intensity = 0.75f;
    public float duration = 0.5f;
    public Volume volume = null;

    private Vignette vignette = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (volume.profile.TryGet(out Vignette vignette))
             this.vignette = vignette;
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, intensity));
    }
    public void FadeOut()
    {
        StartCoroutine(Fade(intensity, 0));
    }

    IEnumerator Fade(float startValue,float endValue)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime <= duration) 
        {
            float blend = elapsedTime / duration;
            elapsedTime += Time.deltaTime;

            float intensity = Mathf.Lerp(startValue, endValue, blend);
            ApplyValue(intensity);
        }
        
      yield return null;
    }


    void ApplyValue(float value)    
    {
        vignette.intensity.Override(value);
    }

}
