using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecey = .05f;
    [SerializeField] float angleDecey = 0.5f;
    [SerializeField] float minAngle = 20f;

    Light mylight;

    private void Start() {
        mylight = GetComponent<Light>();
    }

    private void Update() {
        DecreaseLightAngle();
        DecreaseLightIntensiti();
    }

    private void DecreaseLightAngle()
    {
        if(mylight.spotAngle > minAngle)
        {
            mylight.spotAngle -= angleDecey * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensiti()
    {
        mylight.intensity -= lightDecey * Time.deltaTime;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        mylight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        mylight.intensity = intensityAmount;
    }
}
