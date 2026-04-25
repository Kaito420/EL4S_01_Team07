using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private BridgeInteract _bridgeInteract;

    [SerializeField] private slot slotManager;

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

        //スロット
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            slotManager.StartSlot(OnSlotFinished);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGround = false;
    }

    private void OnSlotFinished(SlotResult result)
    {
        switch (result)
        {
            case SlotResult.MoreLuck:
                Debug.Log("大当たり");
                break;

            case SlotResult.Luck:
                Debug.Log("あたり");
                break;

            case SlotResult.Miss:
                Debug.Log("はずれ");
                break;
        }
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
