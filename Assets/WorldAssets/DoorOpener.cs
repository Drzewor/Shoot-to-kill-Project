using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] Transform rightDoor;
    [SerializeField] Transform lefttDoor;
    [SerializeField] Vector3 openAmount = new Vector3(1.25f ,0f);
    [SerializeField] int keysNeedAmount = 1;
    bool open = false;
    KeyCounter keyCounter;

    private void Start() {
        keyCounter = FindObjectOfType<KeyCounter>();
    }


    private void Update() 
    {
        if(keysNeedAmount == keyCounter.KeyAmount && !open)
        {
            rightDoor.position += openAmount;
            lefttDoor.position -= openAmount;
            open = true;
        }
    }

}
