using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    bool isWalking = false;
    byte stepCounter = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   

    }

    void Update()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) 
        || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
        && isWalking == false)
        {
            StartCoroutine(StepSpundEnumerator());
        }
    }
    
    IEnumerator StepSpundEnumerator()
    {
        isWalking = true;
        audioSource.PlayOneShot(audioClips[stepCounter++], 0.5f);
        yield return new WaitForSeconds(0.7f);
        isWalking = false;
        if(stepCounter >= audioClips.Length-1) stepCounter = 0;
    }
}
