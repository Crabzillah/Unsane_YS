
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 2f; // how close player needs to get to the object in order to interact with it
    public Transform interactionTransform; // Transform from where we interact

    public GameObject pickUpIndicator;

    public GameObject alarmSource;

    public bool isFocus = false; //Is this interactable currently being focused?
    public Transform player; // reference to the player transform



    public bool hasInteracted = false; // Have we already interacted with this object?

    public bool isAutoPick = false;

    public bool canInteract = true;

    public bool isAlarm = false;
    public virtual void Interact()
    {
        // This method is meant to be overwritten
        //Debug.Log("Interact with " + transform.name);


    }

    void Update()
    {

        // if we are currently being focused
        //and we haven't already interacted with the object
        if (isFocus && !hasInteracted)
        {
            Debug.Log("focused!, not interacted yet");
            if (Input.GetKeyDown(KeyCode.F))
            {
                //if we are close enough
                float distance = Vector3.Distance(player.position, interactionTransform.position); //ep02, 13:50
                                                                                                   //check if player is inside the radius of interactable
                if (distance <= radius)
                {
                    Debug.Log("INTERACTION DONE");
                    Interact();
                    hasInteracted = true;
                    pickUpIndicator.SetActive(false);
                    if(isAlarm)
                    {
                        alarmSource.SetActive(true);
                    }
                }

                hasInteracted = false;
            }

        }
        if(isAutoPick)
        {
            Interact();
            hasInteracted = true;
            pickUpIndicator.SetActive(false);
        }
    }



    public void OnFocused(Transform playerTransform)
    {
        if(canInteract)
        {
            isFocus = true;
            player = playerTransform;
            hasInteracted = false;
            pickUpIndicator.SetActive(true);
        }

    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
        pickUpIndicator.SetActive(false);
    }

    // draw our radius in the editor and set interaction transform of ourself in it's not assigned
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionTransform.position, radius); // here we draw or radius to see it in the editor.
    }


}
