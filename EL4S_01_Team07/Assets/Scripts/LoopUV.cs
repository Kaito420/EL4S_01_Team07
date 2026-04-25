using UnityEngine;

public class LoopUV : MonoBehaviour
{
    [SerializeField] private float scrollSpeedX = 0.5f;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * scrollSpeedX);
        if(transform.position.x <= -35.5f)
        {
            transform.position = new Vector3(transform.position.x + 35.5f, transform.position.y, transform.position.z);
        }
    }
}
