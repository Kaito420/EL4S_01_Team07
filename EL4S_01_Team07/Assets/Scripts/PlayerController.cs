using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 8f;

    private bool isGround = false;

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        //ÉWÉÉÉìÉv
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGround)
        {
            Jump();
        }

        //êÖÇ©ÇØÇÈÇ‚Ç¬
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
        }

        //ã¥Ç©ÇØÇÈÇ‚Ç¬
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = false;
        }
    }
}
