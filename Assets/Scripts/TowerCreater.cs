using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreater : MonoBehaviour
{
    private Vector3 _currentPosition = new Vector3();

    public int _numberOfPinsOnTheBottomLayer = 4;
    public GameObject pin;
    public GameObject parent;

    private float _pinSpacingY;
    private float _pinSpacingZ;


    void Start()
    {
        if (!parent.activeSelf) return;
        var scales = pin.transform.localScale;
        _pinSpacingY = scales.y * 2;
        _pinSpacingZ = scales.z + scales.z / 5;
        for (var i = 0; i < _numberOfPinsOnTheBottomLayer; i++)
        {
            _currentPosition = new Vector3(0,
                scales.y + _pinSpacingY * i,
                0 - (_pinSpacingZ * (_numberOfPinsOnTheBottomLayer - i)) / 2);

            for (var j = 0; j < _numberOfPinsOnTheBottomLayer - i; j++)
            {
                pin.transform.position = _currentPosition;
                Instantiate(pin, parent.transform);
                _currentPosition += new Vector3(0, 0, _pinSpacingZ);
            }
        }
    }

    void Update()
    {

    }
}
