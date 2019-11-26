using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public Camera camera;
    public float bullForse = 30f;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var rig = hitInfo.collider.GetComponent<Rigidbody>();
            if (rig != null)
            rig.AddForceAtPosition(ray.direction * bullForse,
                hitInfo.point, ForceMode.VelocityChange);
        }


    }
}
