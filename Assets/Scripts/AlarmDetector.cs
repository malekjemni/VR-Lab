using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    public GameObject alarmLight;
    public Transform fireTransform;
    public float scaleThreshold = 0.8f; 
    public float activationTime = 5.0f; 

    private float timer = 0.0f;
    private bool isAlarmActivated = false;

    void Update()
    {
        if (fireTransform.localScale.magnitude >= scaleThreshold)
        {
            if (!isAlarmActivated)
            {
                timer += Time.deltaTime;
                if (timer >= activationTime)
                {
                    ActivateAlarm();
                }
            }
        }
        else
        {
            timer = 0.0f;
            DesactivateAlarm();
        }
    }

    void ActivateAlarm()
    {
        alarmLight.SetActive(true);
        isAlarmActivated = true;
    }
    public void DesactivateAlarm()
    {
        alarmLight.SetActive(false);
        isAlarmActivated = false;
    }
}
