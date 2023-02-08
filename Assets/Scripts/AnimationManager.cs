using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Video;

public class AnimationManager : MonoBehaviour
{
    public int VideoID;
    public bool CutSceneFinished;

    [SerializeField] private VideoClip[] videoClips;
    [SerializeField] private GameObject uI;
    private VideoPlayer videoPlayer;
    private VideoClip videoClip;

    public void StartCutScene()
    {
        WichVideoToPlay();
        videoPlayer.clip = videoClip;
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
        Time.timeScale = 0;
        uI.SetActive(false);
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
        CutSceneFinished = true;
        videoPlayer.clip = null;
        uI.SetActive(true);
        Time.timeScale = 1;
        videoPlayer.gameObject.SetActive(false);
    }

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>(true);
    }
}
