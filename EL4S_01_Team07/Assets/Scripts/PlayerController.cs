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
        if (Keyboard.current.spaceKey.isPressed && isGround)
        {
            Jump();
        }

        //êÖÇ©ÇØÇÈÇ‚Ç¬
        if (Keyboard.current.eKey.isPressed)
        {
        }

        //ã¥Ç©ÇØÇÈÇ‚Ç¬
        if (Keyboard.current.rKey.isPressed)
        {
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
