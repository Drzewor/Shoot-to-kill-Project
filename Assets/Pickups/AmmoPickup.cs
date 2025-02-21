using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount;
    AudioSource audioSource;
    bool isPicked = false;


    private void OnTriggerEnter(Collider other) {
        audioSource = GetComponent<AudioSource>();
        if(other.GetComponent<Ammo>() != null && !isPicked)
        {
            isPicked = true;
            audioSource.Play();
            other.GetComponent<Ammo>().IncreasCurrentAmmo(ammoType,ammoAmount);
            Destroy(gameObject,0.5f);
        }
    }
}
