using UnityEngine;

public class BridgeInteract : MonoBehaviour
{
    [SerializeField] MapManager _mapManager;
    [SerializeField] GameObject _bridgePrefab;
    Transform _start;
    Transform _end;
    public bool _canBuildBridge = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FieldEdgeEnd>(out var fieldEdgeEnd))
        {
            _start = fieldEdgeEnd._closestFieldEdgeStart.transform;
            _end = fieldEdgeEnd.transform;
            _canBuildBridge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FieldEdgeEnd>(out var fieldEdgeEnd))
         {
            _canBuildBridge = false;
         }
    }

    public void BuildBridge()
    {
        if (_canBuildBridge)
        {
            Vector3 pos = (_start.position + _end.position) / 2;
            Quaternion rot = Quaternion.Euler(0, 0, Mathf.Atan2(_end.position.y - _start.position.y, _end.position.x - _start.position.x) * Mathf.Rad2Deg);
            Vector3 scale = new Vector3(Vector2.Distance( _start.position, _end.position), 1.0f, 1.0f);

            // Fieldをペアレントに指定したい
            GameObject bridge = Instantiate(_bridgePrefab, pos, rot, _mapManager.CurrentField.transform);
            bridge.transform.localScale = scale;
        }
    }
}
