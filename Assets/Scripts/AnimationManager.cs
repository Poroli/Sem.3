using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;

public class AnimationManager : MonoBehaviour
{
    public int VideoID;

    [SerializeField] private VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private VideoClip videoClip;

    public void StartCutScene()
    {
        WichVideoToPlay();
        videoPlayer.clip = videoClip;
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
        WaitForCutSceneEnd();
    }

    private void WichVideoToPlay()
    {
        if (VideoID <= videoClips.Length)
        {
            videoClip = videoClips[VideoID];
        }
    }
    private void WaitForCutSceneEnd()
    {
        videoPlayer.loopPointReached += CutSceneEnds;
    }

    private void CutSceneEnds(VideoPlayer vp)
    {
        Debug.Log("Video Ended");
    }

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>(true);
    }
}
