using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAnimation : MonoBehaviour
{
    public GameObject player;


    void JumpToPlayer()
    {
        player.SetActive(true);
        
    }
    void DeactivateSelf()
    {
        this.gameObject.SetActive(false);
    }
}
