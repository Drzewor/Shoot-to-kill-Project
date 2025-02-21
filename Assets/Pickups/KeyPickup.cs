using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    AudioSource audioSource;
    bool isPicked = false;

    private void OnTriggerEnter(Collider other) {
        audioSource = GetComponent<AudioSource>();
        if(other.GetComponent<KeyCounter>() != null && !isPicked)
        {
            isPicked = true;
            audioSource.Play();
            other.GetComponent<KeyCounter>().IncreaseKeyAmount();
            Destroy(gameObject,0.5f);
        }
    }

}
