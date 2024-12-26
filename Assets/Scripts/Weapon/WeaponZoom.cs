using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    void OnEnable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        playerFollowCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        playerFollowCamera.m_Lens.FieldOfView = zoomedInFOV;
    }
}
