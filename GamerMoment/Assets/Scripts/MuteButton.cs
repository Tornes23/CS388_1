using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public GameObject Mute;
    public GameObject UnMute;

    public void MuteAllSound()
    {
        AudioListener.volume = 0;
        Mute.SetActive(false);
        UnMute.SetActive(true);
    }

    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
        Mute.SetActive(true);
        UnMute.SetActive(false);
    }
}
