using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Content.Interaction;

public class StoveController : MonoBehaviour
{
    public XRPushButton m_ResetToggle;
    public XRSlider m_HeatSlider;

    public LiquidReceiver liquidReceiver;

    public GameObject FX_Fire;
    public GameObject FX_Vapor;
    
    protected void OnEnable()
    {
        ConnectControlEvents();
    }

    protected void OnDisable()
    {
        DisconnectControlEvents();
    }

    void ConnectControlEvents()
    {
        m_ResetToggle.onPress.AddListener(EnableReset);
        m_HeatSlider.onValueChange.AddListener(EnableHeatChange);

    }

    void DisconnectControlEvents()
    {
        m_ResetToggle.onPress.RemoveListener(EnableReset);
        m_HeatSlider.onValueChange.RemoveListener(EnableHeatChange);
 
    }

    void EnableReset()
    {
        liquidReceiver.GetLiquidVolume(0);
        liquidReceiver.correctPoured = false;
        liquidReceiver.currentLiquidType = null;
        FX_Fire.SetActive(false);
        FX_Vapor.SetActive(false);
    }

    void EnableHeatChange(float sliderValue)
    {
        if (liquidReceiver.currentLiquidType.Contains("Green"))
        {
            FX_Fire.transform.localScale = Vector3.one * sliderValue;
            FX_Fire.transform.GetChild(0).transform.localScale = Vector3.one * sliderValue;
        }
        else if (liquidReceiver.currentLiquidType.Contains("Blue"))
        {
            FX_Vapor.transform.localScale = Vector3.one * sliderValue;
            FX_Vapor.transform.GetChild(0).transform.localScale = Vector3.one * sliderValue;
        }
    }

}
