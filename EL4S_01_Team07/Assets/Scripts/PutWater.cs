using UnityEngine;
using UnityEngine.InputSystem;

public class PutWater : MonoBehaviour
{
    [SerializeField] private GameObject waterPrefab;
    public Vector2 shotSpeed;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 pos = transform.position;
            pos.x += transform.localScale.x / 2 + waterPrefab.transform.localScale.x / 2;
            GameObject water = Instantiate(waterPrefab, pos, Quaternion.identity);
            water.GetComponent<Rigidbody2D>().AddForce(shotSpeed, ForceMode2D.Impulse);
        }
    }
}
