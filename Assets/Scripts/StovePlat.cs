using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StovePlat : MonoBehaviour
{
    public float fillAmount = 0f;
    public MeshRenderer MeshRenderer;
    public LiquidReceiver liquidReceiver;
    MaterialPropertyBlock m_MaterialPropertyBlock;
    float m_StartingFillAmount;
    bool m_IsPouring = false;

    void OnEnable()
    {
        m_MaterialPropertyBlock = new MaterialPropertyBlock();
        m_MaterialPropertyBlock.SetFloat("LiquidFill", fillAmount);
        MeshRenderer.SetPropertyBlock(m_MaterialPropertyBlock);
        m_StartingFillAmount = fillAmount;
    }

    void Update()
    {
        if (m_IsPouring)
        {
            fillAmount += 0.1f * Time.deltaTime;

            float fillRatio = fillAmount / m_StartingFillAmount;

            if (fillAmount >= 1f)
            {
                m_IsPouring = false;
                liquidReceiver.correctPoured = false;
            }

        }


        MeshRenderer.GetPropertyBlock(m_MaterialPropertyBlock);
        m_MaterialPropertyBlock.SetFloat("LiquidFill", fillAmount);
        MeshRenderer.SetPropertyBlock(m_MaterialPropertyBlock);
    }

    public void PurLiquid()
    {
        m_IsPouring = true; 
    }
}
