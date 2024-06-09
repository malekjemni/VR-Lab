using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    public GameObject FX_Fire;
    public float extinguishAmount = 0.001f;
    public float extinguishInterval = 1f;

    private bool isExtinguisherActive = false;
    private Coroutine extinguishCoroutine;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("FireArea"))
            isExtinguisherActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("FireArea"))
            isExtinguisherActive = false;   
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("FireArea"))
            isExtinguisherActive = true;
    }
    void Update()
    {
        if (isExtinguisherActive && extinguishCoroutine == null)
        {
            extinguishCoroutine = StartCoroutine(ExtinguishFire());
        }
        else if (!isExtinguisherActive && extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine);
            extinguishCoroutine = null;
        }
    }
    IEnumerator ExtinguishFire()
    {
        while (true)
        {
            Vector3 newScale = FX_Fire.transform.localScale - new Vector3(extinguishAmount, extinguishAmount, extinguishAmount);
            Vector3 childNewScale = FX_Fire.transform.GetChild(0).transform.localScale - new Vector3(extinguishAmount, extinguishAmount, extinguishAmount);

            newScale = Vector3.Max(newScale, Vector3.zero);
            childNewScale = Vector3.Max(childNewScale, Vector3.zero);

            FX_Fire.transform.localScale = newScale;
            FX_Fire.transform.GetChild(0).transform.localScale = childNewScale;

            if (FX_Fire.transform.localScale == Vector3.zero)
            {
                FX_Fire.SetActive(false);
                break;
            }

            yield return new WaitForSeconds(extinguishInterval);
        }
    }
}
