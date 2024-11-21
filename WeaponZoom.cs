using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool ZoomedInToggle = false;

    void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(ZoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        ZoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
    }

    private void ZoomOut()
    {
        ZoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
    }
}
