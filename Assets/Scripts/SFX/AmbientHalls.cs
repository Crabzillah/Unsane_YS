using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientHalls : MonoBehaviour
{
    public AudioClip newTrack;

    public AudioSource stepVolume;
    // Start is called before the first frame update
    private void Start()
    {
        stepVolume.volume = 0.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            stepVolume.volume = 0.1f;
            AudioManager.instance.ReturnToDefault();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
                stepVolume.volume = 0.3f;
                AudioManager.instance.SwapTrack(newTrack);
            }
        }
        
    }


    //private void FadeSound()
    //{
    //    if(!soundIsMax)
    //    {
    //        //ambience.SetActive(true);
            
    //        audioSource.volume = Mathf.Lerp(0, 1, fadeTime);
    //        soundIsMax = true;
            
    //    }
    //    else
    //    {
    //        audioSource.volume = Mathf.Lerp(1, 0, fadeTime);
    //        soundIsMax = false;
            
    //        //ambience.SetActive(false);
    //    }
    //}

}
