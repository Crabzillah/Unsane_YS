using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;


    public Interactable focus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if the ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if(interactable != null)
                {
                    SetFocus(interactable);
                    Debug.Log("FocusSet");
                }

            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            //create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if the ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    RemoveFocus();
                    Debug.Log("Focus removed");
                }

            }
        }



    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
        }

        
        newFocus.OnFocused(transform);
    }


    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}
