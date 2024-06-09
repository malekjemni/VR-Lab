using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlameTrigger : MonoBehaviour
{
    public GameObject FX_Fire;
    public GameObject FX_Vapor;
    public LiquidReceiver LiquidReceiver;
    [Serializable] public class TriggerEvent : UnityEvent<GameObject> { }

    [SerializeField]
    [Tooltip("If set, this trigger will only fire if the other gameobject has this tag.")]
    string m_RequiredTag = string.Empty;

    [SerializeField]
    [Tooltip("Events to fire when a matcing object collides with this trigger.")]
    TriggerEvent m_OnEnter = new TriggerEvent();

    [SerializeField]
    [Tooltip("Events to fire when a matching object stops colliding with this trigger.")]
    TriggerEvent m_OnExit = new TriggerEvent();

    /// <summary>
    /// If set, this trigger will only fire if the other gameobject has this tag.
    /// </summary>
    public string requiredTag => m_RequiredTag;

    /// <summary>
    /// Events to fire when a matching object collides with this trigger.
    /// </summary>
    public TriggerEvent onEnter => m_OnEnter;

    /// <summary>
    /// Events to fire when a matching object stops colliding with this trigger.
    /// </summary>
    public TriggerEvent onExit => m_OnExit;

    void OnTriggerEnter(Collider other)
    {
        if (CanTrigger(other.gameObject))
            SpawnLiquidEffect();
    }

    void OnTriggerExit(Collider other)
    {
        if (CanTrigger(other.gameObject))
            m_OnExit?.Invoke(other.gameObject);
    }

    void OnParticleCollision(GameObject other)
    {
        if (CanTrigger(other.gameObject))
            SpawnLiquidEffect();
    }

    bool CanTrigger(GameObject otherGameObject)
    {
        if (m_RequiredTag != string.Empty)
            return otherGameObject.CompareTag(m_RequiredTag);
        else
            return true;
    }
    void SpawnLiquidEffect()
    {
            if (LiquidReceiver.currentLiquidType.Equals("Green"))
            {
                FX_Fire.SetActive(true);
                FX_Fire.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                FX_Fire.transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
            else if (LiquidReceiver.currentLiquidType.Equals("Blue"))
            {
                FX_Vapor.SetActive(true);
                FX_Vapor.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                FX_Vapor.transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

    }

}
