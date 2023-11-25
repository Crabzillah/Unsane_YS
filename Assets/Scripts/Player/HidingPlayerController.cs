using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlayerController : MonoBehaviour
{

    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform head;
    [SerializeField] float mouseSensitivity;

    float xRot;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float currentMoveSpeed = moveSpeed;

        float moveHorizontal = Input.GetAxis("Horizontal") * mouseSensitivity;
        float moveVertical = Input.GetAxis("Vertical") * mouseSensitivity;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.Rotate(0, mouseX, 0);

        head.localRotation = Quaternion.Euler(xRot, 0, 0);

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        characterController.Move((movement * currentMoveSpeed + velocity) * Time.deltaTime);
    }
}
