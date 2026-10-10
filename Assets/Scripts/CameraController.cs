using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 2f;
    public float rotationSpeed = 0.15f;

    private float currentRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current == null) return;

        // Girar la camara sin mantener presionado el clic
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Mouse.current.delta.ReadValue().x;
            currentRotation += mouseX * rotationSpeed;
        }

        // Capturar nuevamente el mouse con un clic
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Quaternion rotation =
            Quaternion.Euler(0f, currentRotation, 0f);

        Vector3 offset = new Vector3(0f, height, -distance);

        transform.position =
            target.position + rotation * offset;

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}

