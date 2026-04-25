using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public float moveDistance = 0.0f;


    public GameObject[] _maps;
    private GameObject _currentField;
    public GameObject CurrentField => _currentField;
    private GameObject _nextField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDistance = 0.0f;
        _currentField = Instantiate(_maps[0], Vector3.zero, Quaternion.identity);
        _nextField = Instantiate(_maps[Random.Range(0, _maps.Length)], new Vector3(18, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        _currentField.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
        _nextField.transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
        moveDistance += Time.deltaTime * scrollSpeed;

        if (_currentField.transform.position.x <= -18.0f)
        {
            float offset = _currentField.transform.position.x + 18.0f * 2.0f; // Calculate the offset to ensure smooth transition
            Destroy(_currentField);
            _currentField = _nextField;
            _nextField = Instantiate(_maps[Random.Range(0, _maps.Length)], new Vector3(offset, 0, 0), Quaternion.identity);
        }
    }
}
