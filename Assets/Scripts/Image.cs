using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    public string url;

    public void OnButtonUrlClick()
    {
        Application.OpenURL(url);
    }
}
