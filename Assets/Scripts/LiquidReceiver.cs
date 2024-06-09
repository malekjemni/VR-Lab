using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LiquidReceiver : MonoBehaviour
{
    public Material greenMaterial;
    public Material blueMaterial;
    public MeshRenderer MeshRenderer;
    public bool correctPoured = false;

    MaterialPropertyBlock m_MaterialPropertyBlock;
    public float fillAmount = 0f;
    public string currentLiquidType = null;

    [System.Serializable]
    public class PotionPouredEvent : UnityEvent<string> { }

    public string[] AcceptedPotionType;

    public PotionPouredEvent OnPotionPoured;

    void OnEnable()
    {
        m_MaterialPropertyBlock = new MaterialPropertyBlock();
        m_MaterialPropertyBlock.SetFloat("LiquidFill", fillAmount);
        MeshRenderer.SetPropertyBlock(m_MaterialPropertyBlock);
    }

    public void ReceiveLiquid(string PotionType)
    {
        if (!correctPoured)
        {
            currentLiquidType = PotionType;
            if (PotionType.Contains("Green"))
            {
                MeshRenderer.material = greenMaterial;
            }
            else if (PotionType.Contains("Blue"))
            {
                MeshRenderer.material = blueMaterial;
            }
        }
        
        correctPoured = true;
    }
    public void GetLiquidVolume(float _fillAmount)
    {
        fillAmount = _fillAmount;

        MeshRenderer.GetPropertyBlock(m_MaterialPropertyBlock);
        m_MaterialPropertyBlock.SetFloat("LiquidFill", fillAmount);
        MeshRenderer.SetPropertyBlock(m_MaterialPropertyBlock);

        if (fillAmount > 0f)
        {
            correctPoured = false;
        }
    }
}
