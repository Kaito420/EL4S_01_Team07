using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private BridgeInteract _bridgeInteract;

    private bool isGround = false;

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        //ジャンプ
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGround)
        {
            Jump();
        }

        //水かけるやつ
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
        }

        //橋かけるやつ
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Debug.Log("橋掛けボタン押下");
            _bridgeInteract.BuildBridge();
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            isGround = false;
        }
    }
}
