using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float FOVNormal = 40f;
    [SerializeField] float FOVZoom = 25f;
    [SerializeField] float rotationSpeedNormal = 1f;
    [SerializeField] float rotationSpeedZoom = 0.5f;
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    FirstPersonController firstPersonController;
    bool zoom = false;

    private void Start() 
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && zoom == false)
        {
            ZoomIn();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1) && zoom == true)
        {
            ZoomOut();
        }

    }

    private void ZoomIn()
    {
        fpsCamera.m_Lens.FieldOfView = FOVZoom;
        zoom = true;
        firstPersonController.RotationSpeed = rotationSpeedZoom;
    }

    private void ZoomOut()
    {
        fpsCamera.m_Lens.FieldOfView = FOVNormal;
        firstPersonController.RotationSpeed = rotationSpeedNormal;
        zoom = false;
    }

    private void OnDisable() 
    {
        if(fpsCamera.m_Lens.FieldOfView == FOVZoom)
        {
            ZoomOut();
        }
    }
}
