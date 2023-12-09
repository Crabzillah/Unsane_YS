using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;


    public Interactable focus;
    public Animator animator;
    public bool pillIsActive;
    public GameObject pillEffect;
    public float pillEffectTime;
    
    public CinemachineVirtualCamera vcam;
    //public Collider playerCollider;
    float pillFOV;
    float soberFOV;
    
    

    // Start is called before the first frame update
    void Start()
    {
        soberFOV = 90f;
        pillFOV = 60f;
        
        pillIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (pillIsActive == true)
        {
            pillEffect.SetActive(true);

            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2f;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1f;
            StartCoroutine(PillEffectRoutine());
        }
        else
        {
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.5f;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0.5f;
        }

        if (pillIsActive && vcam.m_Lens.FieldOfView > pillFOV)
        {

            vcam.m_Lens.FieldOfView -= 1;
            
            
        }
        if (!pillIsActive & vcam.m_Lens.FieldOfView < soberFOV)
        {

            vcam.m_Lens.FieldOfView += 1;
            
            
        }
        



    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Interactable interactable = collision.GetComponent<Interactable>();

            if (interactable != null && interactable.canInteract)
            {
                SetFocus(interactable);
                Debug.Log("FocusSetAutomatically");
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Interactable interactable = collision.GetComponent<Interactable>();

            if (interactable != null)
            {
                RemoveFocus();
                Debug.Log("FocusRemovedAutomatically");
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

    private void OnDisable()
    {
        pillEffect.SetActive(false);
        pillIsActive = false;
    }
    IEnumerator PillEffectRoutine()
    {
        yield return new WaitForSeconds(pillEffectTime);
        pillIsActive = false;
        pillEffect.SetActive(false);


    }
}
