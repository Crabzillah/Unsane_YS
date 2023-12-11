using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientHalls : MonoBehaviour
{   
    public GameObject ambience;
    public AudioSource audioSource;

    public bool isPlaying;

    public float fadeTime;
    // Start is called before the first frame update
    private void Start()
    {
        isPlaying = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
                
                audioSource.volume = Mathf.Lerp(0.2f, 0, 10f);
                isPlaying = false;
                ambience.SetActive(false);

            //FadeSound();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ambience.SetActive(true);
            audioSource.volume = Mathf.Lerp(0, 0.2f, 10f);
                
                isPlaying = true;
            
            
            //FadeSound();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
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
