using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;

    Rigidbody rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // stops tipping over
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        float x = 0f, z = 0f;
        if (keyboard.rightArrowKey.isPressed) x += 1f;
        if (keyboard.leftArrowKey.isPressed)  x -= 1f;
        if (keyboard.upArrowKey.isPressed)    z += 1f;
        if (keyboard.downArrowKey.isPressed)  z -= 1f;

        rb.linearVelocity = new Vector3(x * speed, rb.linearVelocity.y, z * speed);

        if (keyboard.spaceKey.wasPressedThisFrame && grounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
            grounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Grounded if we're touching a surface that faces mostly upward
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.GetContact(i).normal.y > 0.5f)
            {
                grounded = true;
                return;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}