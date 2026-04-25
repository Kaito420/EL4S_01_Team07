using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fire")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.transform.root.gameObject.tag == "Field")
        {
            Destroy(gameObject);
        }
    }
}
