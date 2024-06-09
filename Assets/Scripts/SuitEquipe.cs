using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitEquipe : MonoBehaviour
{
    static int s_IDMax = 0;

    public GameObject suit;
    public VignetteApplier vignetteApplier;

    public AudioClip Clip;
    public bool CloseCaptioned = false;

    int m_ID;

    void Awake()
    {
        m_ID = s_IDMax;
        s_IDMax++;
    }
    public void EquipeHazmatSuit()
    {
        StartCoroutine(EquipingCouroutine());
    }
    IEnumerator EquipingCouroutine()
    {    
        vignetteApplier.FadeIn();

        yield return new WaitForSeconds(0.5f);

        vignetteApplier.FadeOut();
        SFXPlayer.Instance.PlaySFX(Clip, transform.position, new SFXPlayer.PlayParameters()
        {
            Volume = 1.0f,
            Pitch = Random.Range(0.8f, 1.2f),
            SourceID = m_ID
        }, 0.5f, CloseCaptioned);

        suit.SetActive(false);
    }
}
