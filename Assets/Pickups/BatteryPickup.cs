using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 50;
    [SerializeField] float intensityAmount = 2;
    AudioSource audioSource;
    private void OnTriggerEnter(Collider other) {
        audioSource = GetComponent<AudioSource>();
        if(other.GetComponent<PlayerHealt>() != null)
        {
            audioSource.Play();
            FlashLightSystem myLight = other.GetComponentInChildren<FlashLightSystem>();
            myLight.RestoreLightAngle(restoreAngle);
            myLight.RestoreLightIntensity(intensityAmount);
            Destroy(gameObject, 0.5f);
        }
    }
}
