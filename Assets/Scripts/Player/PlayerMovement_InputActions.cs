using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_InputActions : MonoBehaviour
{
    public float speed = 4f;

    [Header("Gravity")]
    public float gravity = -9.8f;
    private float verticalVelocity;

    [Header("Mouse Look")]
    public float yawSensitivity = 0.12f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        float yaw = lookInput.x * yawSensitivity;
        transform.Rotate(0f, yaw, 0f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
