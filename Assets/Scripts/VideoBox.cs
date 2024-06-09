using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoBox : MonoBehaviour
{
    public string videoName;
    public VideoClip videoClip;
    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        textDisplay.text = videoName;
    }
}
