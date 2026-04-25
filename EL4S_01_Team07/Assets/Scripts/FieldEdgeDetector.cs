using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Linq;

public class FieldEdgeDetector : MonoBehaviour
{
    private GameObject _edgeEndObj;
    private FieldEdgeEnd _edgeEnd;
    private List<FieldEdgeStart> _fieldEdgeStarts = new List<FieldEdgeStart>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _edgeEndObj = transform.parent.gameObject;
        _edgeEnd = _edgeEndObj.GetComponent<FieldEdgeEnd>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var fieldEdgeStart = collision.GetComponent<FieldEdgeStart>();
        if (fieldEdgeStart != null || !_fieldEdgeStarts.Contains(fieldEdgeStart))
        {
            _fieldEdgeStarts.Add(fieldEdgeStart);
            foreach(var edgeStart in _fieldEdgeStarts)
            {
                if(edgeStart == null) continue;
                if ( _edgeEnd._closestFieldEdgeStart == null ||Vector2.Distance(_edgeEndObj.transform.position, edgeStart.transform.position) < Vector2.Distance(_edgeEndObj.transform.position, _edgeEnd._closestFieldEdgeStart.transform.position))
                {
                    _edgeEnd._closestFieldEdgeStart = edgeStart.gameObject;
                }
            }
        }
    }

}
