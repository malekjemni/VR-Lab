using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.Video;

public class TVController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ResolveInteractor resolver;


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Video"))
    //    {
    //        VideoBox videoBox = collision.gameObject.GetComponent<VideoBox>();
    //        if (videoBox != null && videoBox.videoClip != null)
    //        {
    //            PlayVideoClip(videoBox.videoClip);
    //        }
    //        else
    //        {
    //            Debug.LogError("No VideoBox component or video clip found on the collided object.");
    //        }
    //    }
    //}
    public void PlayVideoClip(VideoClip _videoClip)
    {

        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer component found on this GameObject.");
            return;
        }

        if (_videoClip == null)
        {
            Debug.LogError("No video clip assigned.");
            return;
        }

        videoPlayer.clip = _videoClip;


        videoPlayer.Play();
    }

    public void StopVideo()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer component found on this GameObject.");
            return;
        }

        videoPlayer.Stop();
    }

    public void ValidateSocket()
    {
        PlayVideoClip(resolver.interactor.GetComponent<VideoBox>().videoClip);
    }

    public void RemoveSocket()
    {
        StopVideo();
    }
}
