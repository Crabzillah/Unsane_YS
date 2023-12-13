using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region Singleton
    public static Door instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Door found!");
            return;
        }
        instance = this;
    }

    #endregion

    public Animator doorAnimator;
    public GameObject lockedDoor;
    public float humanSum;
    public float neededSum;

    public float paintingAIndex;
    public float paintingBIndex;
    public float paintingCIndex;
    public float paintingDIndex;
    public float paintingEIndex;

    public AudioSource audioSource;
    public AudioClip openSFX;
    public bool canPlaySFX;
    // Start is called before the first frame update
    void Start()
    {
        canPlaySFX = true;
    }

    // Update is called once per frame
    void Update()
    {
        float humanSum = paintingAIndex + paintingBIndex + paintingCIndex + paintingDIndex + paintingEIndex;
        if (humanSum == neededSum)
        {   
            if(canPlaySFX)
            {
                audioSource.PlayOneShot(openSFX);
                canPlaySFX = false;
            }
            
            doorAnimator.SetTrigger("Open");
            lockedDoor.SetActive(true);

        }
    }
}
