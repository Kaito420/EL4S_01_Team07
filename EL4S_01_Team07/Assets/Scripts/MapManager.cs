using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] _maps;
    private GameObject _currentField;
    private GameObject _nextField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentField = Instantiate(_maps[0], Vector3.zero, Quaternion.identity);
        _nextField = Instantiate(_maps[0], new Vector3(18, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        _currentField.transform.Translate(Vector3.left * Time.deltaTime * 5);
        _nextField.transform.Translate(Vector3.left * Time.deltaTime * 5);

        if (_currentField.transform.position.x <= -18.0f)
        {
            Destroy(_currentField);
            _currentField = _nextField;
            _nextField = Instantiate(_maps[0], new Vector3(18, 0, 0), Quaternion.identity);
        }
    }
}
