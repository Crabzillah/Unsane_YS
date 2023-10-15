
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f; // how close player needs to get to the object in order to interact with it

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius); // here we draw or radius to see it in the editor.
    }


}
