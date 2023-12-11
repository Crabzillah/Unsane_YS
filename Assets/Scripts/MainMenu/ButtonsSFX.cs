using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSFX : MonoBehaviour
{
    public AudioSource buttonsFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioClip playFx;
    // Start is called before the first frame update
    public void HoverSound()
    {
        buttonsFx.PlayOneShot(hoverFx);
    }

    // Update is called once per frame
    public void ClickSound()
    {
        buttonsFx.PlayOneShot(clickFx);
    }

    public void PlayClick()
    {
        buttonsFx.PlayOneShot(playFx);
    }
}
