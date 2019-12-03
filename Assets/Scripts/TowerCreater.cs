using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCreater : DefaultTrackableEventHandler
{
    private Vector3 _currentPosition = new Vector3();

    private int _numberOfPinsOnTheBottomLayer = 4;
    public GameObject pin;
    public GameObject parent;

    private float _pinSpacingY;
    private float _pinSpacingZ;

    public InputField inputField;

    public void OnClickStart()
    {
        try
        {
            _numberOfPinsOnTheBottomLayer = int.Parse(inputField.text);
        }
        catch
        {
            Debug.Log(inputField.text + " is not number");
        }
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
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
