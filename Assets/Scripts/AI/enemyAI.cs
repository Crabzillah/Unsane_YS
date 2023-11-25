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

    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime,idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;

    int randNum; //random number to randomize AI's destinations

    public int destinationAmount;

    public Vector3 rayCastOffset;

    public string deathScene;

    private void Start()
    {
        walking = true;

        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }


    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if(Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            
            if (hit.collider.gameObject.tag == "Player")
            {
                
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");

                chasing = true;
            }
        }
        if(chasing == true)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnimator.ResetTrigger("walk");
            aiAnimator.ResetTrigger("idle");
            aiAnimator.SetTrigger("sprint");
            if (ai.remainingDistance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                aiAnimator.ResetTrigger("walk");
                aiAnimator.ResetTrigger("idle");
                aiAnimator.ResetTrigger("sprint");
                aiAnimator.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                chasing = false;
            }

        }
        if(walking == true)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnimator.ResetTrigger("sprint");
            aiAnimator.ResetTrigger("idle");
            aiAnimator.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnimator.ResetTrigger("sprint");
                aiAnimator.ResetTrigger("walk");
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
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];

    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        stopChase();

    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);

    }
}
