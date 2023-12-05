using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : ChangeIcon
{

    private void Start()
    {
        AudioListener.volume = 1;
        AudioController.Ins.PlayBackgroundMusic();
    }
    public override void ChangeIconComplete()
    {
        
        this.GetComponent<Image>().sprite = changeIcon;
    }
    public override void DefualtfIcon()
    {
        this.GetComponent<Image>().sprite = defaultIcon;
    }
    public void AudioMute()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            ChangeIconComplete();
        }
        else
        {
            AudioListener.volume = 1;
            DefualtfIcon();
        }

    }

}

