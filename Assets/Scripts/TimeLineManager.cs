using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineManager : MonoBehaviour
{
    public PlayableDirector introTimeline;
    public PlayableDirector mainMenuFadeOutTimeline;
    public PlayableDirector resetGameTimeline;

    public void PlayMainMenuFadeOut()
    {
        mainMenuFadeOutTimeline.Play();
    }

    public void PlayResetGameFadeOut()
    {
        resetGameTimeline.Play();
    }
}
