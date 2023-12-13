using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnimator;
    public AudioSource audioSource;
    public AudioClip AggroSFX, catchSFX;
    public GameObject AggroSound;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime,idleTime, detectionDistance, catchDistance, searchDistance, minSearchTime, maxSearchTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing, searching;
    public Transform player;
    public Transform playerSpawnPoint;
    Transform currentDest;
    Vector3 dest;

    public FirstPersonController fpsController;

    public bool isInDeathRoutine;

    public Vector3 rayCastOffset;

    public string deathScene;
    public float aiDistance;
    public GameObject hideText, stopHideText, pillEvent;

    private void Start()
    {
        fpsController = fpsController.GetComponent<FirstPersonController>();
        walking = true;
        isInDeathRoutine = false;
        
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }


    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        aiDistance = Vector3.Distance(player.position, this.transform.position);
        if(Physics.Raycast(transform.position + rayCastOffset, direction, out hit, detectionDistance))
        {
            
            if (hit.collider.gameObject.tag == "Player")
            {
                
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StartCoroutine("searchRoutine");


                searching = true;
            }
        }
        if(searching == true)
        {
            
            ai.speed = 0;
            aiAnimator.ResetTrigger("walk");
            aiAnimator.ResetTrigger("idle");
            aiAnimator.ResetTrigger("sprint");
            aiAnimator.SetTrigger("search");
            if(aiDistance <= searchDistance)
            {
                
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StopCoroutine("searchRoutine");
                StartCoroutine("chaseRoutine");

                chasing = true;
                searching = false;
                
                //audioSource.PlayOneShot(AggroSFX);
            }
        }


        if(chasing == true)
        {
            fpsController.MoveSpeed = 4f;

            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnimator.ResetTrigger("walk");
            aiAnimator.ResetTrigger("idle");
            aiAnimator.ResetTrigger("search");
            aiAnimator.SetTrigger("sprint");
            AggroSound.SetActive(true);
            if (aiDistance <= catchDistance)
            {
                AggroSound.SetActive(false);
                audioSource.PlayOneShot(catchSFX);
                player.gameObject.SetActive(false);
                aiAnimator.ResetTrigger("walk");
                aiAnimator.ResetTrigger("idle");
                aiAnimator.ResetTrigger("search");
                hideText.SetActive(false);
                stopHideText.SetActive(false);
                aiAnimator.ResetTrigger("sprint");
                aiAnimator.SetTrigger("jumpscare");
                isInDeathRoutine = true;
                StartCoroutine(deathRoutine());
                chasing = false;
            }

        }
        if(walking == true)
        {
            fpsController.MoveSpeed = 2f;
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnimator.ResetTrigger("sprint");
            aiAnimator.ResetTrigger("idle");
            aiAnimator.ResetTrigger("search");
            aiAnimator.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnimator.ResetTrigger("sprint");
                aiAnimator.ResetTrigger("walk");
                aiAnimator.ResetTrigger("search");
                aiAnimator.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }


    public void stopChase()
    {
        walking = true;
        chasing = false;
        StopCoroutine("chaseRoutine");
        
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        
        currentDest = destinations[Random.Range(0, destinations.Count)];

    }

    IEnumerator searchRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minSearchTime,maxSearchTime));
        searching = false;
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator chaseRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minChaseTime, maxChaseTime));
        stopChase();

    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        //SceneManager.LoadScene(deathScene);
        pillEvent.SetActive(true);
        player.transform.position = playerSpawnPoint.transform.position;
        player.transform.rotation = playerSpawnPoint.transform.rotation;
        StartCoroutine("searchRoutine");
        isInDeathRoutine = false;

    }
}
