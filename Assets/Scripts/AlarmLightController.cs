using UnityEngine;

public class AlarmLightController : MonoBehaviour
{
    public Light yellowLight;
    public Light redLight;

    public float switchInterval = 0.5f; 
    public float rotationSpeed = 30f;  

    private float timer;
    private bool isYellowLightOn;

    void Start()
    {
        timer = 0f;
       // isYellowLightOn = true;
      //  UpdateLights();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            timer = 0f;
          //  isYellowLightOn = !isYellowLightOn;
           // UpdateLights();
        }
    }

    void UpdateLights()
    {
        yellowLight.enabled = isYellowLightOn;
        redLight.enabled = !isYellowLightOn;
    }
}
