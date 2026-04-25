using UnityEngine;

public class FallFieldComponent : MonoBehaviour
{
    public float fallRadius = 10.0f;
    public float shakeDuration = 0.1f;
    public bool isFalling = false;
    public float shakeInterval = 0.1f;
    public float shakeTime = 0.1f;
    public float fallPower = 2.0f;

    private Vector3 origin = Vector3.zero;
    private Rigidbody2D fallRigidbody;
    private GameObject player = null;
    private float shakeTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fallRigidbody = GetComponent<Rigidbody2D>();

        fallRigidbody.gravityScale = 0.0f;
        origin = transform.localPosition;

        shakeTimer = Random.Range(-shakeInterval - shakeTime, 0.0f); // Start with a random shake timer to desynchronize shaking if there are multiple platforms
    }

    // Update is called once per frame
    void Update()
    {

        if (isFalling)
        {
            fallRigidbody.gravityScale = 1.0f;
        }
        else
        {
            shakeTimer += Time.deltaTime;
            if(shakeTimer >= shakeInterval)
            {
                transform.localPosition = origin + new Vector3(Random.Range(-1.0f, 1.0f) * shakeDuration, Random.Range(-1.0f, 1.0f) * shakeDuration, 0); // Shake the platform

                if (shakeTimer >= shakeInterval + shakeTime)
                {
                    transform.localPosition = origin;
                    shakeTimer = 0.0f;
                }
            }

            if (player != null)
            {
                float distance = Mathf.Abs(transform.position.x - player.transform.position.x);
                if (distance <= fallRadius)
                {
                    transform.localPosition = origin; // Reset position to stop shaking
                    isFalling = true;
                    fallRigidbody.AddForce(new Vector2(Random.Range(-1.0f,1.0f) * fallPower, Random.Range(-1.0f,1.0f) * fallPower), ForceMode2D.Impulse); // Add a small random force to make the fall look more natural))
                }
                else
                {
                    Debug.Log("Player is too far to trigger the fall. Distance: " + distance);
                }
            }
        }
    }
}
